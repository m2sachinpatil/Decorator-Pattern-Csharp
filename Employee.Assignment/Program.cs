using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Assignment1.Component;
using Employee.Assignment1.Interface;
using Employee.Assignment1.Model;
using Employee.Assignment1.Repository;

namespace Employee.Assignment1
{
    class Program
    {
        [STAThread()]
        static async System.Threading.Tasks.Task Main()
        {
            IXMLRepository xmlHelper = new XMLRepository();

            IEmployeeOperation employee = new EmployeeOperation(xmlHelper);


            ConsoleKeyInfo cki;
            Console.WriteLine("Console XML Operation for Assignment 1 \r");
            Console.WriteLine("------------------------\n");

            do
            {
                cki = Console.ReadKey(false);

                Console.WriteLine("Choose an option from the following list:");
                Console.WriteLine("\t1 - Add to XML");
                Console.WriteLine("\t2 - Print XML");
                Console.WriteLine("\t3 - Delete XML Record");
                Console.Write("Your option? ");

                switch (Console.ReadLine())
                {
                    case "1":
                        await AddEmployee(employee);
                        break;

                    case "2":
                        await GetEmployee(employee);
                        break;

                    case "3":
                        await DeleteEmployee(employee);
                        break;
                }
            } while (cki.Key != ConsoleKey.Escape);
            Console.Write("Press any key to close the XML console app...");
            Console.ReadKey();
        }

        private static async Task AddEmployee(IEmployeeOperation employee)
        {
            Console.WriteLine("Enter Name, age and designation");
            List<EmployeNode> entity = new List<EmployeNode>();
            EmployeNode nodeName = new EmployeNode
            {
                Key = "name",
                Value = Console.ReadLine()
            };
            entity.Add(nodeName);

            EmployeNode nodeAge = new EmployeNode
            {
                Key = "age",
                Value = Console.ReadLine()
            };
            entity.Add(nodeAge);

            EmployeNode nodeDesignation = new EmployeNode
            {
                Key = "designation",
                Value = Console.ReadLine()
            };
            entity.Add(nodeDesignation);
            var resultAdd = await employee.AddEmployee(entity, Constant.FilePath);
            if (!resultAdd.Failure)
            {
                Console.WriteLine("Record added successfully for employe :" + resultAdd.OutputObject[0].Value);
            }
            else
            {
                Console.WriteLine(resultAdd.Errors[0].ErrorMessage);
            }
        }


        private static async Task GetEmployee(IEmployeeOperation employee)
        {
            var result = await employee.GetEmployes(Constant.FilePath);

            var arrays = result.OutputObject.Select(i => i.EmployeNode).ToArray();
            StringBuilder stringResult = new StringBuilder();
            foreach (var array in arrays)
            {
                foreach (var element in array)
                {
                    stringResult.Append(element.Value);
                    stringResult.Append(" : ");
                }

                stringResult.AppendLine();
            }
            Console.WriteLine(stringResult);
        }

        private static async Task DeleteEmployee(IEmployeeOperation employee)
        {
            Console.WriteLine("Enter Id to delete");
            string idString = Console.ReadLine();

            bool parseSuccessDelete = int.TryParse(idString, out _);
            if (parseSuccessDelete)
            {
                var deleteResult = await employee.DeleteEmploye(Convert.ToInt32(idString),Constant.FilePath);
                if (!deleteResult.Failure)
                {
                    Console.WriteLine("Record deleted successfully");
                }
                else
                {
                    Console.WriteLine(deleteResult.Errors[0].ErrorMessage);
                }
            }
            else
            {
                Console.WriteLine("Please enter number value To Delete");
            }

        }
    }
}
