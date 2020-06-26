using System.Collections.Generic;
using System.Threading.Tasks;
using Employee.Assignment1.Helper;
using Employee.Assignment1.Interface;
using Employee.Assignment1.Model;
using Employee.Assignment1.Repository;

namespace Employee.Assignment1.Component
{
    /// <summary>
    /// Responsibility of employee operations
    /// </summary>
    public class EmployeeOperation : IEmployeeOperation
    {
        public IXMLRepository XmlHelper;

        public EmployeeOperation(IXMLRepository ixmlHelper)
        {
            XmlHelper = ixmlHelper;
        }

        /// <summary>
        /// Add employee.
        /// </summary>
        /// <param name="employe">Employ object</param>
        /// <param name="filePath">filePath</param>
        /// <returns>Response</returns>
        public async Task<OutputWrapper<EmployeNode>> AddEmployee(List<EmployeNode> employe, string filePath)
        {
            return await XmlHelper.SaveElement(employe, filePath);
        }

        /// <summary>
        /// Delete employee.
        /// </summary>
        /// <param name="id">RecordId</param>
        /// <param name="filePath">filePath</param>
        /// <returns>Response</returns>
        public async Task<OutputWrapper<EmployeNode>> DeleteEmploye(int id, string filePath)
        {
            return await XmlHelper.DeleteElement(id, filePath);
        }

        /// <summary>
        /// Get all employee-es.
        /// </summary>
        /// <returns>List of employee es</returns>
        public async Task<OutputWrapper<EmployeEntity>> GetEmployes(string filePath)
        {
           return await XmlHelper.GetElements(filePath);
        }
    }
}
