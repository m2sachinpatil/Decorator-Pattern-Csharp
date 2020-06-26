using System.Collections.Generic;
using System.Threading.Tasks;
using Employee.Assignment1.Helper;
using Employee.Assignment1.Model;

namespace Employee.Assignment1.Interface
{
    /// <summary>
    /// Employ interface
    /// </summary>
   public interface IEmployeeOperation
    {
        /// <summary>
        /// Add employee.
        /// </summary>
        /// <param name="employe">Employ object</param>
        /// <param name="filePath">filePath</param>
        /// <returns>Response</returns>
        Task<OutputWrapper<EmployeNode>> AddEmployee(List<EmployeNode> employe, string filePath);

        /// <summary>
        /// Delete employee.
        /// </summary>
        /// <param name="id">RecordId</param>
        /// <param name="filePath">filePath</param>
        /// <returns>Response</returns>
        Task<OutputWrapper<EmployeNode>> DeleteEmploye(int id, string filePath);

        /// <summary>
        /// Get all employee-es.
        /// </summary>
        /// <returns>List of employee es</returns>
        Task<OutputWrapper<EmployeEntity>> GetEmployes(string filePath);
    }
}
