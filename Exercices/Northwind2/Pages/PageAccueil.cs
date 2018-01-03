﻿using Outils.TConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind2.Pages
{
    public class PageAccueil : MenuPage
    {
        public PageAccueil(): base("Accueil", false)
        {
            Menu.AddOption("0", "Quitter l'application", () => Environment.Exit(0));
            Menu.AddOption("1", "Aller sur la page 'Fournisseurs'",
                () => Northwind2App.Instance.NavigateTo(typeof(PageFournisseurs)));
            Menu.AddOption("3", "Aller sur la page 'Produits'",
                () => Northwind2App.Instance.NavigateTo(typeof(PageProduits)));
        }
    }
}
