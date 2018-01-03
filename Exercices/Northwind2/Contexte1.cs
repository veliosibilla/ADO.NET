using Northwind2.Pages;
using Northwind2.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind2
{
    enum Operations {Ajouter, Modifier}

    public class Contexte1
    {

    public static List<string> GetPaysFournisseurs()
    {
        var listPaysF = new List<string>();

        // On créé une commande et on définit le code sql à exécuter
        var cmd = new SqlCommand();
        cmd.CommandText = @"select distinct A.Country   
from Address A
inner join Supplier S on (A.AddressID = S.AddressID)";

        // On crée une connexion à partir de la chaîne de connexion stockée
        // dans les paramètres de l'appli
        using (var cnx = new SqlConnection(Settings.Default.Northconn))
        {
            // On affecte la connexion à la commande
            cmd.Connection = cnx;
            // On ouvre la connexion
            cnx.Open();

            // On exécute la commande en récupérant son résultat dans un objet SqlDataRedader
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                // On lit les lignes de résultat une par une
                while (sdr.Read())
                {
                    //...et pour chacune on crée un objet qu'on ajoute à la liste

                    listPaysF.Add((string)sdr["Country"]);
                }
            }
        }
        // Le fait d'avoir créé la connexion dans une instruction using
        // permet de fermer cette connexion automatiquement à la fin du bloc using

        return listPaysF;
    }

        public static List<Supplier> GetFournisseurs(string Pays)
        {
            var LISTES = new List<Supplier>();

            // On créé une commande et on définit le code sql à exécuter
            var cmd = new SqlCommand();
            cmd.CommandText = @"select A.Country, S.CompanyName, S.SupplierID
from Supplier S
inner join Address A on (A.AddressID=S.AddressID)
where A.Country= @Country
order by A.Country, S.CompanyName, S.SupplierID";

            var param = new SqlParameter
            {
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@Country",
                Value = Pays
            };
            // Ajout à la collection des paramètres de la commande
            cmd.Parameters.Add(param);


            // On crée une connexion à partir de la chaîne de connexion stockée
            // dans les paramètres de l'appli
            using (var cnx = new SqlConnection(Settings.Default.Northconn))
            {
                // On affecte la connexion à la commande
                cmd.Connection = cnx;
                // On ouvre la connexion
                cnx.Open();

                // On exécute la commande en récupérant son résultat dans un objet SqlDataRedader
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    // On lit les lignes de résultat une par une
                    while (sdr.Read())
                    {
                        //...et pour chacune on crée un objet qu'on ajoute à la liste
                        var ListeFournisseurs = new Supplier();
                        ListeFournisseurs.SupplierID=((int)sdr["SupplierID"]);
                        ListeFournisseurs.CompanyName=((string)sdr["CompanyName"]);
                        LISTES.Add(ListeFournisseurs);
                    }
                }
            }
            // Le fait d'avoir créé la connexion dans une instruction using
            // permet de fermer cette connexion automatiquement à la fin du bloc using

            return LISTES;
        }

        //        public static int GetNbProduits(string Pays)
        //        {

        //            // On créé une commande et on définit le code sql à exécuter
        //            var cmd = new SqlCommand();
        //            cmd.CommandText = @"select A.Country, S.CompanyName, S.SupplierID
        //from Supplier S
        //inner join Address A on (A.AddressID=S.AddressID)
        //where A.Country= @Country
        //order by A.Country, S.CompanyName, S.SupplierID";

        //            var param = new SqlParameter
        //            {
        //                SqlDbType = SqlDbType.VarChar,
        //                ParameterName = "@Country",
        //                Value = Pays
        //            };
        //            // Ajout à la collection des paramètres de la commande
        //            cmd.Parameters.Add(param);


        //            // On crée une connexion à partir de la chaîne de connexion stockée
        //            // dans les paramètres de l'appli
        //            using (var cnx = new SqlConnection(Settings.Default.Northconn))
        //            {
        //                // On affecte la connexion à la commande
        //                cmd.Connection = cnx;
        //                // On ouvre la connexion
        //                cnx.Open();

        //                // On exécute la commande en récupérant son résultat dans un objet SqlDataRedader
        //                using (SqlDataReader sdr = cmd.ExecuteReader())
        //                {
        //                    // On lit les lignes de résultat une par une
        //                    while (sdr.Read())
        //                    {
        //                        //...et pour chacune on crée un objet qu'on ajoute à la liste
        //                        var ListeFournisseurs = new Supplier();
        //                        ListeFournisseurs.SupplierID = ((int)sdr["SupplierID"]);
        //                        ListeFournisseurs.CompanyName = ((string)sdr["CompanyName"]);
        //                        LISTES.Add(ListeFournisseurs);
        //                    }
        //                }
        //            }
        //            // Le fait d'avoir créé la connexion dans une instruction using
        //            // permet de fermer cette connexion automatiquement à la fin du bloc using

        //            return LISTES;
        //        }

        public static List<Category> GetCategories()
        {
            var ListesC = new List<Category>();

            // On créé une commande et on définit le code sql à exécuter
            var cmd = new SqlCommand();
            cmd.CommandText = @"select C.CategoryId, C.Name, C.Description
from Category C";

            //var param = new SqlParameter
            //{
            //    SqlDbType = SqlDbType.VarChar,
            //    ParameterName = "@Country",
            //    Value = Pays
            //};
            //// Ajout à la collection des paramètres de la commande
            //cmd.Parameters.Add(param);


            // On crée une connexion à partir de la chaîne de connexion stockée
            // dans les paramètres de l'appli
            using (var cnx = new SqlConnection(Settings.Default.Northconn))
            {
                // On affecte la connexion à la commande
                cmd.Connection = cnx;
                // On ouvre la connexion
                cnx.Open();

                // On exécute la commande en récupérant son résultat dans un objet SqlDataRedader
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    // On lit les lignes de résultat une par une
                    while (sdr.Read())
                    {
                        //...et pour chacune on crée un objet qu'on ajoute à la liste
                        var ListeCategories = new Category();
                        ListeCategories.CategoryID = ((Guid)sdr["CategoryID"]);
                        ListeCategories.Name = ((string)sdr["Name"]);
                        ListeCategories.Description = ((string)sdr["Description"]);
                        ListesC.Add(ListeCategories);
                    }
                }
            }
            // Le fait d'avoir créé la connexion dans une instruction using
            // permet de fermer cette connexion automatiquement à la fin du bloc using

            return ListesC;
        }

        public static List<Product> GetProduits(Guid IDcat)
        {
            var ListesP = new List<Product>();

            // On créé une commande et on définit le code sql à exécuter
            var cmd = new SqlCommand();
            cmd.CommandText = @"select P.CategoryId, P.ProductId, P.Name, P.UnitPrice, P.UnitsInStock
from Product P
inner join Category C on (C.CategoryId=P.CategoryId)
where C.CategoryId=@CatID
order by P.ProductId";

            var param = new SqlParameter
            {
                SqlDbType = SqlDbType.UniqueIdentifier,
                ParameterName = "@CatID",
                Value = IDcat
            };
            // Ajout à la collection des paramètres de la commande
            cmd.Parameters.Add(param);


            // On crée une connexion à partir de la chaîne de connexion stockée
            // dans les paramètres de l'appli
            using (var cnx = new SqlConnection(Settings.Default.Northconn))
            {
                // On affecte la connexion à la commande
                cmd.Connection = cnx;
                // On ouvre la connexion
                cnx.Open();

                // On exécute la commande en récupérant son résultat dans un objet SqlDataRedader
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    // On lit les lignes de résultat une par une
                    while (sdr.Read())
                    {
                        //...et pour chacune on crée un objet qu'on ajoute à la liste
                        var ListeProduits = new Product();
                        ListeProduits.ProductID = ((int)sdr["ProductID"]);
                        ListeProduits.Name = ((string)sdr["Name"]);
                        ListeProduits.UnitPrice = ((decimal)sdr["UnitPrice"]);
                        ListeProduits.UnitsInStock = ((Int16)sdr["UnitsInStock"]);
                        ListesP.Add(ListeProduits);
                    }
                }
            }
            // Le fait d'avoir créé la connexion dans une instruction using
            // permet de fermer cette connexion automatiquement à la fin du bloc using

            return ListesP;
        }

        public static void AjouterProduit(Product Nouveau_Produit)
        {
            //var ListesP = new List<Product>();

            // On créé une commande et on définit le code sql à exécuter
            var cmd = new SqlCommand();
            cmd.CommandText = @"insert Product(CategoryId, SupplierId, Name, UnitPrice, UnitsInStock) values (@IDCat, @IDSupp, @NOMProd, @UP, @UNITSStock)";

            var param1 = new SqlParameter
            {
                SqlDbType = SqlDbType.UniqueIdentifier,
                ParameterName = "@IDCat",
                Value = Nouveau_Produit.CategoryID
            };
            var param2 = new SqlParameter
            {
                SqlDbType = SqlDbType.Int,
                ParameterName = "@IDSupp",
                Value = Nouveau_Produit.SupplierID
            };
            var param3 = new SqlParameter
            {
                SqlDbType = SqlDbType.NVarChar,
                ParameterName = "@NOMProd",
                Value = Nouveau_Produit.Name
            };
            var param4 = new SqlParameter
            {
                SqlDbType = SqlDbType.Money,
                ParameterName = "@UP",
                Value = Nouveau_Produit.UnitPrice
            };
            var param5 = new SqlParameter
            {
                SqlDbType = SqlDbType.SmallInt,
                ParameterName = "@UNITSStock",
                Value = Nouveau_Produit.UnitsInStock
            };
            // Ajout à la collection des paramètres de la commande
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);

            // On crée une connexion à partir de la chaîne de connexion stockée
            // dans les paramètres de l'appli
            using (var cnx = new SqlConnection(Settings.Default.Northconn))
            {
                // On affecte la connexion à la commande
                cmd.Connection = cnx;
                // On ouvre la connexion
                cnx.Open();
                cmd.ExecuteNonQuery();
            }

            // On exécute la commande en récupérant son résultat dans un objet SqlDataRedader
            //using (SqlDataReader sdr = cmd.ExecuteReader())
            //    {
            //        // On lit les lignes de résultat une par une
            //        while (sdr.Read())
            //        {
            //            //...et pour chacune on crée un objet qu'on ajoute à la liste
            //            var ListeProduits = new Product();
            //            ListeProduits.ProductID = ((int)sdr["ProductID"]);
            //            ListeProduits.Name = ((string)sdr["Name"]);
            //            ListeProduits.UnitPrice = ((decimal)sdr["UnitPrice"]);
            //            ListeProduits.UnitsInStock = ((Int16)sdr["UnitsInStock"]);
            //            ListesP.Add(ListeProduits);
            //        }
            //    }
            //}
            // Le fait d'avoir créé la connexion dans une instruction using
            // permet de fermer cette connexion automatiquement à la fin du bloc using
            
        }

        public static Product GetProduct(int IDProd)
        {
            Product Prod = new Product();
            var cmd = new SqlCommand();
            cmd.CommandText = @"select CategoryId, SupplierId, Name, UnitPrice, UnitsInStock from Product where ProductID=@IDProd";

            var param = new SqlParameter
            {
                SqlDbType = SqlDbType.Int,
                ParameterName = "@IDProd",
                Value = IDProd
            };

            cmd.Parameters.Add(param);

            using (var cnx = new SqlConnection(Settings.Default.Northconn))
            {
                // On affecte la connexion à la commande
                cmd.Connection = cnx;
                // On ouvre la connexion
                cnx.Open();

                using (SqlDataReader sdr = cmd.ExecuteReader())
                
                    // On lit les lignes de résultat une par une
                    sdr.Read();
                        //...et pour chacune on crée un objet qu'on ajoute à la liste
                        
                        Prod.CategoryID = ((Guid)sdr["CategoryID"]);
                        Prod.Name = ((string)sdr["Name"]);
                        Prod.UnitPrice = ((decimal)sdr["UnitPrice"]);
                        Prod.UnitsInStock = ((Int16)sdr["UnitsInStock"]);
                        Prod.SupplierID = ((int)sdr["SupplierID"]);

            }
            return Prod;
        }

        public static AjouterModifierProduit (Product P, Operations O)
        {   
            while P != null;
            {

            }
            if (Operations = 1)
            {
                var cmd = new SqlCommand();
                cmd.CommandText = @"insert Product(CategoryId, SupplierId, Name, UnitPrice, UnitsInStock) values (@IDCat, @IDSupp, @NOMProd, @UP, @UNITSStock)";

                var param1 = new SqlParameter
                {
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    ParameterName = "@IDCat",
                    Value = Nouveau_Produit.CategoryID
                };
                var param2 = new SqlParameter
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@IDSupp",
                    Value = Nouveau_Produit.SupplierID
                };
                var param3 = new SqlParameter
                {
                    SqlDbType = SqlDbType.NVarChar,
                    ParameterName = "@NOMProd",
                    Value = Nouveau_Produit.Name
                };
                var param4 = new SqlParameter
                {
                    SqlDbType = SqlDbType.Money,
                    ParameterName = "@UP",
                    Value = Nouveau_Produit.UnitPrice
                };
                var param5 = new SqlParameter
                {
                    SqlDbType = SqlDbType.SmallInt,
                    ParameterName = "@UNITSStock",
                    Value = Nouveau_Produit.UnitsInStock
                };
                // Ajout à la collection des paramètres de la commande
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                cmd.Parameters.Add(param5);

                // On crée une connexion à partir de la chaîne de connexion stockée
                // dans les paramètres de l'appli
                using (var cnx = new SqlConnection(Settings.Default.Northconn))
                {
                    // On affecte la connexion à la commande
                    cmd.Connection = cnx;
                    // On ouvre la connexion
                    cnx.Open();
                    cmd.ExecuteNonQuery();
                }

                // On exécute la commande en récupérant son résultat dans un objet SqlDataRedader
                //using (SqlDataReader sdr = cmd.ExecuteReader())
                //    {
                //        // On lit les lignes de résultat une par une
                //        while (sdr.Read())
                //        {
                //            //...et pour chacune on crée un objet qu'on ajoute à la liste
                //            var ListeProduits = new Product();
                //            ListeProduits.ProductID = ((int)sdr["ProductID"]);
                //            ListeProduits.Name = ((string)sdr["Name"]);
                //            ListeProduits.UnitPrice = ((decimal)sdr["UnitPrice"]);
                //            ListeProduits.UnitsInStock = ((Int16)sdr["UnitsInStock"]);
                //            ListesP.Add(ListeProduits);
                //        }
                //    }
                //}
                // Le fait d'avoir créé la connexion dans une instruction using
                // permet de fermer cette connexion automatiquement à la fin du bloc using

            }
        }
        }
    }
