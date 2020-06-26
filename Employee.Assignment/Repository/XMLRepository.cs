using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using Employee.Assignment1.Helper;
using Employee.Assignment1.Interface;
using Employee.Assignment1.Model;

namespace Employee.Assignment1.Repository
{
    public class XMLRepository : IXMLRepository
    {
        /// <summary>
        /// XML parser.
        /// </summary>
        /// <param name="path">File Location.</param>
        /// <param name="loadOptions">Optional</param>
        /// <returns></returns>
        public async Task<XDocument> LoadXMLFile(String path, LoadOptions loadOptions = LoadOptions.PreserveWhitespace)
        {
            return await Task.Run(() =>
            {
                using (var stream = File.OpenText(path))
                {
                    return XDocument.Load(stream, loadOptions);
                }
            });
        }

        /// <summary>
        /// Get all XML elements.
        /// </summary>
        /// <param name="filePath">File location</param>
        /// <returns>List of all entity</returns>
        public async Task<OutputWrapper<EmployeEntity>> GetElements(string filePath)
        {
            OutputWrapper<EmployeEntity> outputWrapper = new OutputWrapper<EmployeEntity>();
            List<ErrorContainer<EmployeEntity>> errorContainers = new List<ErrorContainer<EmployeEntity>>();

            try
            {
                XDocument xmlDoc = await LoadXMLFile(filePath);

                var rootElement = XElement.Parse(xmlDoc.ToString());

                var employes = new List<EmployeEntity>();

                foreach (XElement childs in rootElement.Elements())
                {
                    var employe = new EmployeEntity();
                    var employeNodes = childs.Elements().Select(child => new EmployeNode { Key = child.Name.LocalName, Value = child.Value }).ToList();
                    employe.EmployeNode = employeNodes;
                    employes.Add(employe);
                }

                outputWrapper.OutputObject = employes;
                outputWrapper.Failure = false;
            }
            catch (Exception ex)
            {
                errorContainers.Add(new ErrorContainer<EmployeEntity>
                {
                    ErrorMessage = ex.Message,

                });
                outputWrapper.Errors = errorContainers;
                outputWrapper.Failure = true;
            }

            return outputWrapper;
        }

        /// <summary>
        /// Save element with employee data.
        /// </summary>
        /// <param name="employe">Employ data</param>
        /// <param name="filePath">File Location</param>
        /// <returns>Response</returns>
        public async Task<OutputWrapper<EmployeNode>> SaveElement(List<EmployeNode> employe, string filePath)
        {
            OutputWrapper<EmployeNode> outputWrapper = new OutputWrapper<EmployeNode>();
            List<ErrorContainer<EmployeNode>> errorContainers = new List<ErrorContainer<EmployeNode>>();

            XDocument doc = await LoadXMLFile(filePath); 

            try
            {
                XElement xElement = XElement.Parse(doc.ToString());
                int maxId = xElement.Elements(Constant.NodeElement).Max(l => int.Parse(l.Attribute(Constant.PrimaryElement).Value));
                maxId++;
                XElement root = new XElement(Constant.NodeElement, new XAttribute(Constant.PrimaryElement, maxId));

                foreach (var node in employe)
                {
                    root.Add(new XElement(node.Key, node.Value));
                }

                doc.Element(Constant.RootElement)?.Add(root);
                doc.Save(filePath);
                outputWrapper.OutputObject = employe;
                outputWrapper.Failure = false;
            }
            catch(Exception ex)
            {
                errorContainers.Add(new ErrorContainer<EmployeNode>
                {
                    ErrorMessage = ex.Message,
                });
                outputWrapper.Errors = errorContainers;
                outputWrapper.Failure = true;
            }

            return outputWrapper;
        }

        /// <summary>
        /// Delete employee element.
        /// </summary>
        /// <param name="id">Employ Id</param>
        /// <param name="filePath">File Location</param>
        /// <returns>Response</returns>
        public async Task<OutputWrapper<EmployeNode>> DeleteElement(int id, string filePath)
        {
            OutputWrapper<EmployeNode> outputWrapper = new OutputWrapper<EmployeNode>();
            List<ErrorContainer<EmployeNode>> errorContainers = new List<ErrorContainer<EmployeNode>>();
            XDocument doc = await LoadXMLFile(filePath);

            try
            {
                XElement xdoc = XElement.Parse(doc.ToString());
      
                xdoc.XPathSelectElement(Constant.NodeElement + "[@" + Constant.PrimaryElement + "= '" + id + "']").Remove();
            
                xdoc.Save(filePath);

                outputWrapper.Failure = false;
            }
            catch(Exception ex)
            {
                errorContainers.Add(new ErrorContainer<EmployeNode>
                {
                    ErrorMessage = ex.Message,
                });
                outputWrapper.Errors = errorContainers;
                outputWrapper.Failure = true;
            }

            return outputWrapper;
        }
    }
}
