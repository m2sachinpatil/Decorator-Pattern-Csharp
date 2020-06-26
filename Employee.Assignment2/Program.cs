using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Assignment1.Component;
using Employee.Assignment1.Interface;
using Employee.Assignment1.Model;
using Employee.Assignment1.Repository;
using Employee.Assignment2.Decorator;

namespace Employee.Assignment2
{
    class Program
    {
        [STAThread()]
        static async System.Threading.Tasks.Task Main()
        {
            IXMLRepository xmlRepo = new XMLRepository();
            IEmployeeOperation employee = new EmployeeOperation(xmlRepo);
            EmployeDecorator employDeco = new EmployeDecorator(employee);
            


            ConsoleKeyInfo cki;
            Console.WriteLine("Console XML Operation Assignment 2 \r");
            Console.WriteLine("------------------------\n");

            do
            {
                cki = Console.ReadKey(false);

                Console.WriteLine("Choose an option from the following list:");
                Console.WriteLine("\t1 - Add to XML");
                Console.WriteLine("\t2 - Print XML");
                Console.WriteLine("\t3 - Delete XML Record");
                Console.WriteLine("\t4 - Add New Node");
                Console.Write("Your option? ");

                switch (Console.ReadLine())
                {
                    case "1":
                        await AddEmployee(employDeco);
                        break;
                    case "2":
                        await GetEmployee(employDeco);
                        break;

                    case "3":
                        await DeleteEmployee(employDeco);
                        break;
                    case "4":
                        await AddNode();
                        break;
                }
            } while (cki.Key != ConsoleKey.Escape);
            Console.Write("Press any key to close the XML console app...");
            Console.ReadKey();
        }

        private static async Task AddEmployee(EmployeDecorator employDeco)
        {
            var parameters = await employDeco.GetAllParameters();
            List<EmployeNode> entity = new List<EmployeNode>();
            foreach (var param in parameters)
            {
                Console.WriteLine("Enter : " + param);
                EmployeNode nodeName = new EmployeNode
                {
                    Key = "name",
                    Value = Console.ReadLine()
                };
                entity.Add(nodeName);

            }

            var resultAdd = await employDeco.AddEmployee(entity);
            if (!resultAdd.Failure)
            {
                Console.WriteLine("Record added successfully for employe :" + resultAdd.OutputObject[0].Value);
            }
            else
            {
                Console.WriteLine(resultAdd.Errors[0].ErrorMessage);
            }
        }

        private static async Task GetEmployee(EmployeDecorator employDeco)
        {
            var result = await employDeco.GetEmployes();

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

        private static async Task DeleteEmployee(EmployeDecorator employDeco)
        {
            Console.WriteLine("Enter Id to delete");
            string idString = Console.ReadLine();

            bool parseSuccessDelete = int.TryParse(idString, out _);
            if (parseSuccessDelete)
            {
                var deleteResult = await employDeco.DeleteEmploye(Convert.ToInt32(idString));
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

        private static async Task AddNode()
        {
            XMLDecorator xmlDecorator = new XMLDecorator();
            Console.WriteLine("Enter new node name");
            string nodeString = Console.ReadLine();
            var nodeResult = await xmlDecorator.AddNode(nodeString);
            Console.WriteLine(nodeResult
                ? "Node added successfully"
                : "Something went wrong please try again");
        }
    }
}
