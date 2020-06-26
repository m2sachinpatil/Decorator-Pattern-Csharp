using NSubstitute;
using NUnit.Framework;
using Employee.Assignment1.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute.ReceivedExtensions;
using Employee.Assignment1.Component;
using Employee.Assignment1.Model;
using System.Threading.Tasks;
using Employee.Assignment1.Helper;
using Employee.Assignment1.Repository;

namespace Employee.Assignment1.UnitTest.Component
{

    [TestFixture]
    class EmployeeOperationTest
    {
        private IXMLRepository repo;

        [SetUp]
        public void Setup()
        {
            this.repo = Substitute.For<IXMLRepository>();
        }

        [Test]
        public void Add_Employ_Response()
        {
            this.repo.SaveElement(Arg.Any<List<EmployeNode>>(), Constant.FilePath).Returns(Task.FromResult(new OutputWrapper<EmployeNode>
            {
                Failure = false
            }));
            var result = new EmployeeOperation(this.repo);
            var output = result.AddEmployee(new List<EmployeNode>(), Constant.FilePath);
            Assert.IsFalse(output.Result.Failure);
        }


        [Test]
        public void Get_Employ_Response()
        {
            this.repo.GetElements(Constant.FilePath).Returns(new OutputWrapper<EmployeEntity>
            {
                OutputObject = new List<EmployeEntity>
                {
                    new EmployeEntity
                    {
                        EmployeNode = new List<EmployeNode>
                        {
                            new EmployeNode
                            {
                                Key = "Name",
                                Value = "TestUser"
                            }
                        }
                    }
                }
            });
            var result = new EmployeeOperation(this.repo);
            var output = result.GetEmployes(Constant.FilePath);
            Assert.IsNotEmpty(output.Result.OutputObject);
        }

        [Test]
        public void Delete_Employ_Response()
        {
            this.repo.DeleteElement(Arg.Any<int>(), Constant.FilePath).Returns(new OutputWrapper<EmployeNode>());
            var result = new EmployeeOperation(this.repo);
            var output = result.DeleteEmploye(1, Constant.FilePath);
            Assert.IsFalse(output.Result.Failure);
        }
    }
}
