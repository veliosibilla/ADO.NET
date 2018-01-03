using Outils.TConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind2.Pages
{
    
    public class PageFournisseurs : MenuPage
    {

        public PageFournisseurs() : base("Fournisseurs")
        {
            Menu.AddOption("1", "Liste des pays", AfficherPays);
            Menu.AddOption("2", "Liste des fournisseurs par pays", AfficherFournisseurs);
        }

        private void AfficherPays()
        {
            List<string> pays = Contexte1.GetPaysFournisseurs();
            ConsoleTable.From(pays,"Pays").Display("Pays");
        }

        private void AfficherFournisseurs()
        {
            Console.WriteLine("Veuillez saisir un pays:");
           string Pays = Console.ReadLine();
            List<Supplier> Fournisseurs = Contexte1.GetFournisseurs(Pays);
            ConsoleTable.From(Fournisseurs).Display("Fournisseurs (ID et Nom Cie.)");
        }
    }
}
