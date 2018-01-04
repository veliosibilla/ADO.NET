using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind2.Tests
{
    [TestClass()]
    public class TestsContexte1
    {
        [TestMethod()]
        public void TestGetPaysFournisseurs()
        {
            Assert.AreEqual(16, Contexte1.GetPaysFournisseurs().Count());
            Assert.AreEqual("USA", Contexte1.GetPaysFournisseurs()[15]);
        }

        [TestMethod()]
        public void TestGetFournisseurs()
        {
            // Assert.Fail();
            Assert.AreEqual(6, Contexte1.GetFournisseurs("Japon").ElementAt(0).SupplierId);
            Assert.AreEqual(4, Contexte1.GetFournisseurs("Japon").ElementAt(1).SupplierId);
        }

        [TestMethod()]
        public void TestGetNbProduits()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetClientsCommandes()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetCatégories()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetProduits()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestAjouterModifierProduit()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestSupprimerProduit()
        {
            Assert.Fail();
        }
    }
}