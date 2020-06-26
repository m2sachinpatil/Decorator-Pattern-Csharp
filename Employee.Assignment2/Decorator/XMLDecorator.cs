using System.Threading.Tasks;
using System.Xml.Linq;
using Employee.Assignment1.Repository;

namespace Employee.Assignment2.Decorator
{
    public class XMLDecorator: XMLRepository
    {
        /// <summary>
        /// Add new node.
        /// </summary>
        /// <param name="nodeName">node name</param>
        /// <returns>Response</returns>
        public async Task<bool> AddNode(string nodeName)
        {
             XDocument xmlDoc = await LoadXMLFile(Constant.FilePath);

             try
             {
                 foreach (var client in xmlDoc.Descendants("employee"))
                 {
                     client.Add(new XElement(nodeName, ""));
                 }

                 xmlDoc.Save(Constant.FilePath);
                 return true;
            }
             catch
             {
                 return false;
             }            
        }
    }
}
