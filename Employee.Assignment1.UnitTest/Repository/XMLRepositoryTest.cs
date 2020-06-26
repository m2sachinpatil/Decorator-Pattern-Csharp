using NSubstitute;
using NUnit.Framework;
using Employee.Assignment1.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Employee.Assignment1.Repository;


//TODO: treat this test as integration test

namespace Employee.Assignment1.UnitTest.Repository
{
    [TestFixture]
    public class XMLRepositoryTest
    {
        private IXMLRepository repo;

        [SetUp]
        public void Setup()
        {
            this.repo = Substitute.For<IXMLRepository>();
        }

        [Test]
        public void Get_Element_Success_Response()
        {
            var result = new XMLRepository();
            var output = result.GetElements(Constant.FilePath);
            Assert.IsNotEmpty(output.Result.OutputObject);
        }
    }
}
