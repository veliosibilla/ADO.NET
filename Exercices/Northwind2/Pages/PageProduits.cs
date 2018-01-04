using Outils.TConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind2.Pages
{
    class PageProduits :MenuPage
    {
        public PageProduits():base("Produits", true)
        {
                Menu.AddOption("1", "Liste des produits", AfficherProduits);
                Menu.AddOption("2", "Créer un nouveau produit", CreerProduits);
                Menu.AddOption("3", "Modifier un produit", ModifierProduit);
        }

            private void AfficherProduits()
            {
            List<Category> Categorie = Contexte1.GetCategories();
            ConsoleTable.From(Categorie).Display("Liste de catégories:");
            Guid IDcat = Input.Read<Guid>("Saisissez un ID de catégorie produit:");
            List<Product> Produits = Contexte1.GetProduits(IDcat);
            ConsoleTable.From(Produits).Display("Produits de la catégorie choisie:");
            }

            private void CreerProduits()
            {
            List<Category> Categorie = Contexte1.GetCategories();
            ConsoleTable.From(Categorie).Display("Liste de catégories:");

            Product Nouveau_Produit = new Product();

            // List<Product> Nouveau_Produit = Contexte1.AjouterProduit();
            Nouveau_Produit.CategoryID = Input.Read<Guid>("Saisissez un ID de catégorie produit:");
            
            Nouveau_Produit.Name = Input.Read<String>("Saisissez un nom de produit:");

            Nouveau_Produit.SupplierID= Input.Read<int>("Saisissez l'identifiant du fournisseur:");

            Nouveau_Produit.UnitPrice = Input.Read<decimal>("Saisissez le prix unitaire:");

            Nouveau_Produit.UnitsInStock= Input.Read<Int16>("Saisissez le nombre d'unités en stock:");

            Contexte1.AjouterProduit(Nouveau_Produit);
            
                //String Nom_Prod = Input.Read<String>("Saisissez un nom de produit:");
                Output.WriteLine(ConsoleColor.Green, "Produit créé avec succès!");
            }

        private void ModifierProduit()
        {   
            AfficherProduits();
            int IDProd = Input.Read<int>("Saisir l'ID du produit à modifier:");
            Product P = Contexte1.GetProduct(IDProd);

            P.Name = Input.Read<String>("Saisissez un nom de produit:", P.Name);
            P.CategoryID = Input.Read<Guid>("Saisissez un ID de catégorie produit:", P.CategoryID);
            P.SupplierID = Input.Read<int>("Saisissez l'identifiant du fournisseur:", P.SupplierID);
            P.UnitPrice = Input.Read<decimal>("Saisissez le prix unitaire:", P.UnitPrice);
            P.UnitsInStock = Input.Read<Int16>("Saisissez le nombre d'unités en stock:", P.UnitsInStock);
 
            Contexte1.AjouterModifierProduit(P);

            //List<Category> Categorie = Contexte1.GetCategories();
            //ConsoleTable.From(Categorie).Display("Liste de catégories:");

            //Product Nouveau_Produit = new Product();

            //// List<Product> Nouveau_Produit = Contexte1.AjouterProduit();
            //Nouveau_Produit.CategoryID = Input.Read<Guid>("Saisissez un ID de catégorie produit:");

            //Nouveau_Produit.Name = Input.Read<String>("Saisissez un nom de produit:");

            //Nouveau_Produit.SupplierID = Input.Read<int>("Saisissez l'identifiant du fournisseur:");

            //Nouveau_Produit.UnitPrice = Input.Read<decimal>("Saisissez le prix unitaire:");

            //Nouveau_Produit.UnitsInStock = Input.Read<Int16>("Saisissez le nombre d'unités en stock:");

            //Contexte1.AjouterProduit(Nouveau_Produit);

            ////String Nom_Prod = Input.Read<String>("Saisissez un nom de produit:");
            //Output.WriteLine(ConsoleColor.Green, "Produit créé avec succès!");
        }
    }

    
}
