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
    public class TestsDataContext
    {
        [TestMethod()]
        public void TestGetPaysFournisseurs()
        {
            List<string> _pays = Contexte.GetPaysFournisseurs() ;
            Assert.AreEqual(16, _pays.Count);
            Assert.AreEqual("USA", _pays[15]);     //  Assert.AreEqual("USA", _pays[_pays.Count-1]);
        }

        [TestMethod()]
        public void ChargerProduitTest()
        {
            Assert.Fail();
        }

        // Vérifier que le Royaume Uni propose 7 produits

        [TestMethod()]
        public void GetNbProduitsTest()
        {
           int NbProds = Contexte.GetNbProduits("UK");
            Assert.AreEqual(7, NbProds);
        }

        [TestMethod()]
        public void TestGetFournisseurs()
        {
            List<Fournisseur> listFour = Contexte.GetFournisseurs("Japon");
            foreach ( Fournisseur F in listFour)
            {
                Assert.AreEqual(6, F.SupplierId);
                Assert.AreEqual(4, F.SupplierId);
            }
        }

        [TestMethod()]
        public void GetClientsCommandesTest()
        {
            Assert.Fail();
        }

        //  Vérifier qu’on récupère 8 catégories de produits et que la dernière est nommée « Seafood »
        [TestMethod()]
        public void GetCategoryTest()
        {
            List<Category> Categories = Contexte.GetCategory();
            Assert.AreEqual(8, Categories.Count);
            Assert.AreEqual("Seafood", Categories[Categories.Count - 1].Name);
            // Assert.AreEqual("USA", _pays[15]);
        }

        // Vérifier qu’il y a 12 produits dans la catégorie Seafood et que le 7ème est le N° 40
        [TestMethod()]
        public void GetProduits()
        {
            Guid IDCat = Guid.Parse("EB4E5F53-8711-4118-946E-F89E00615EC6");
            List<Produit> ProdpCat = Contexte.GetProduits(IDCat);
            Assert.AreEqual(12, ProdpCat.Count);
            Assert.AreEqual(40, ProdpCat[6].ProductId);
        }

        // Ajouter un nouveau produit dans la catégorie Cheeses et vérifier qu’il y a désormais 11 produits dans cette catégorie
        [TestMethod()]
        public void AjouterModifierProduit()
        {
            Guid IDCat = Guid.Parse("323734F8-A4AC-4D92-B4E5-A4E896FC32A2");
            Produit NewCheese = new Produit
            {   CategoryID = IDCat,
                SupplierId = 13,
                Name = "Panacoto",
                UnitPrice = decimal.Parse("321,87"),
                UnitsInStock = Int16.Parse("445")
            };
            bool Operation = false;
            Contexte.AjouterModifierProduit(Operation, NewCheese);
            //Guid IDCat = Guid.Parse("323734F8-A4AC-4D92-B4E5-A4E896FC32A2");
            List<Produit> ListDairyP = Contexte.GetProduits(IDCat);
            Assert.AreEqual(11, ListDairyP.Count);
            //Assert.AreEqual(11, Contexte.AjouterModifierProduit().Count);
            //Guid IDCat = Guid.Parse("EB4E5F53-8711-4118-946E-F89E00615EC6");
            //List<Produit> ProdpCat = Contexte.GetProduits(IDCat);
            //Assert.AreEqual(12, ProdpCat.Count);
            //Assert.AreEqual(40, ProdpCat[6].ProductId);
        }

        // pas d'attribut
        private void Essai()
        {

        }
    }
}