using System.Collections.Generic;
using System.Threading.Tasks;
using Employee.Assignment1;
using Employee.Assignment1.Component;
using Employee.Assignment1.Helper;
using Employee.Assignment1.Interface;
using Employee.Assignment1.Model;
using Employee.Assignment1.Repository;

namespace Employee.Assignment2.Decorator
{
    /// <summary>
    /// Employ decorator- Extension of employee repository
    /// </summary>
    public class EmployeDecorator 
    {
        public IEmployeeOperation Employee;

        public EmployeDecorator(IEmployeeOperation employee)
        {
            Employee = employee;
        }

        /// <summary>
        /// Add employs
        /// </summary>
        /// <param name="employe"></param>
        /// <returns></returns>
        public async Task<OutputWrapper<EmployeNode>> AddEmployee(List<EmployeNode> employe)
        {
            return await Employee.AddEmployee(employe, Constant.FilePath);
        }

        /// <summary>
        /// Delete employee
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public async Task<OutputWrapper<EmployeNode>> DeleteEmploye(int id)
        {
            return await Employee.DeleteEmploye(id, Constant.FilePath);
        }

        /// <summary>
        /// Get Employ list.
        /// </summary>
        /// <returns>employes</returns>
        public async Task<OutputWrapper<EmployeEntity>> GetEmployes()
        {
            return await Employee.GetEmployes(Constant.FilePath);
        }

        /// <summary>
        /// List of parameters.
        /// </summary>
        /// <returns>parameters</returns>
        public async Task<List<string>> GetAllParameters()
        {
            var result = await Employee.GetEmployes(Constant.FilePath);

            List<string> outResult = new List<string>();

            foreach (var employe in result.OutputObject[0].EmployeNode)
            {
                    outResult.Add(employe.Key);
            }

            return outResult;
        }
    }
}
