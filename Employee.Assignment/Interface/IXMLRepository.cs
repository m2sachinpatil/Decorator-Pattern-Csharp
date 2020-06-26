using Employee.Assignment1.Helper;
using Employee.Assignment1.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Employee.Assignment1.Interface
{
  public interface IXMLRepository
  {
      /// <summary>
      /// Get all XML elements.
      /// </summary>
      /// <param name="filePath">File location</param>
      /// <returns>List of all entity</returns>
      Task<OutputWrapper<EmployeEntity>> GetElements(string filePath);

      /// <summary>
      /// Save element with employee data.
      /// </summary>
      /// <param name="employe">Employ data</param>
      /// <param name="filePath">File Location</param>
      /// <returns>Response</returns>
      Task<OutputWrapper<EmployeNode>> SaveElement(List<EmployeNode> employe, string filePath);

      /// <summary>
      /// Delete employee element.
      /// </summary>
      /// <param name="id">Employ Id</param>
      /// <param name="filePath">File Location</param>
      /// <returns>Response</returns>
      Task<OutputWrapper<EmployeNode>> DeleteElement(int id, string filePath);

      /// <summary>
      /// XML parser.
      /// </summary>
      /// <param name="path">File Location.</param>
      /// <param name="loadOptions">Optional</param>
      /// <returns></returns>
        Task<XDocument> LoadXMLFile(String path, LoadOptions loadOptions = LoadOptions.PreserveWhitespace);

  }
}
