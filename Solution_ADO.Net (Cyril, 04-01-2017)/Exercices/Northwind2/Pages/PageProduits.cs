using Outils.TConsole;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Northwind2.Pages
{
	public class PageProduits : MenuPage
	{
		private IList<Category> _catégories;
		private IList<Product> _produits;

		public PageProduits() : base("Produits")
		{
			Menu.AddOption("1", "Liste des produits", () => AfficherProduits());
			Menu.AddOption("2", "Créer un nouveau produit", CréerProduit);
			Menu.AddOption("3", "Modifier un produit", ModifierProduit);
			Menu.AddOption("4", "Supprimer un produit", SupprimerProduit);
		}

		private Guid AfficherProduits()
		{
			// Affiche la liste des catégories et demande la saisie d'un id de catégorie
			if (_catégories == null)
				_catégories = Contexte1.GetCatégories();
			ConsoleTable.From(_catégories).Display("catégories");
			Guid idCate = Input.Read<Guid>("Saisissez l'id de la catégorie dont vous souhaitez voir les produits :");

			// Récupération et affichage de la liste des produits de cette catégorie
			_produits = Contexte1.GetProduits(idCate);
			ConsoleTable.From(_produits).Display("produits");

			return idCate;
		}

		private void CréerProduit()
		{
			// Affichage des catégories
			if (_catégories == null)
				_catégories = Contexte1.GetCatégories();
			ConsoleTable.From(_catégories).Display("catégories");

			// Saisie des infos du produit
			Output.WriteLine("Saisissez les informations du produit :");
			Product prod = new Product();
			prod.CategoryId = Input.Read<Guid>("Id de la catégorie :");
			prod.Name = Input.Read<String>("Nom :");
			prod.SupplierId = Input.Read<int>("Id du fournisseur :");
			prod.UnitPrice = Input.Read<decimal>("Prix unitaire :");
			prod.UnitsInStock = Input.Read<short>("Unités en stock (nombre entier) :");

			// Enregistrement dans la base
			Contexte1.AjouterModifierProduit(prod, Operations.Ajout);
			Output.WriteLine(ConsoleColor.Green, "Produit créé avec succès");
			Output.WriteLine("");
		}

		private void ModifierProduit()
		{
			// Affiche la liste des catégories puis des produits de la catégorie sélectionnée
			Guid idCate = AfficherProduits();
			
			// Récupère le produit dont l'id a été saisi
			int id = Input.Read<int>("Id du produit à modifier :");
			Product prod = _produits.Where(p => p.ProductId == id).FirstOrDefault();
			prod.CategoryId = idCate;

			// Ddemande les nouvelles valeurs des infos du produit, en proposant les valeurs actuelles par défaut
			Output.WriteLine("Modifiez chaque information du produit ou appuyez sur Entrée pour conserver la valeur actuelle :");
			prod.Name = Input.Read<String>("Nom :", prod.Name);
			prod.CategoryId = Input.Read<Guid>("Id de la catégorie :", prod.CategoryId);
			prod.SupplierId = Input.Read<int>("Id du fournisseur :", prod.SupplierId);
			prod.UnitPrice = Input.Read<decimal>("Prix unitaire : ", prod.UnitPrice);
			prod.UnitsInStock = Input.Read<short>("Unités en stock (nombre entier) :", prod.UnitsInStock);

			// Enregistrement dans la base
			Contexte1.AjouterModifierProduit(prod, Operations.Modification);
			Output.WriteLine(ConsoleColor.Green, "Produit modifié avec succès");
			Output.WriteLine("");
		}

		private void SupprimerProduit()
		{
			// Affiche la liste des catégories puis des produits de la catégorie sélectionnée
			Guid idCate = AfficherProduits();

			int id = Input.Read<int>("Id du produit à supprimer :");
			try
			{
				Contexte1.SupprimerProduit(id);
			}
			catch (SqlException e)
			{
				GérerErreurSql(e);
			}
		}

		private void GérerErreurSql(SqlException ex)
		{
			if (ex.Number == 547)
				Output.WriteLine(ConsoleColor.Red,
					"Le produit ne peut pas être supprimé car il est référencé par une commande");
			else
				throw ex;
		}
	}
}
