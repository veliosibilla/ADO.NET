using Northwind2;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Northwind2.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        [ClassInitialize]
        public static void InitClass(TestContext context)
        {
            dataContext1 = new Contexte1Northwind2();
        }


        [TestMethod()]
        public void TestGetPaysFournisseurs()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetFournisseurs()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetCategories()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetProduits()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestAjouterProduit()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetProduct()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestAjouterModifierProduit()
        {
            Assert.Fail();
        }
    }
}


