using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Media3D;
//using System.Windows.Forms;
using MenuItem = System.Windows.Forms.MenuItem;
using MainMenu = System.Windows.Forms.MainMenu;


class AvionsController
{
    public void affichage()
    {
        //Creation de la nouvelle fenetre avions
        Window avionWindow = new Window();
        avionWindow.Title = "Air Atlantique";
        // Création de la grid
        Grid tableur = new Grid();
        ScrollViewer scrollV1 = new ScrollViewer();
        scrollV1.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
        tableur.ShowGridLines = true;
        MainMenu menu = new MainMenu();
        MenuItem items = menu.MenuItems.Add("&File");
        items.MenuItems.Add(new MenuItem("&Recharger"));
        items.MenuItems.Add(new MenuItem("&Sauvegarder"));
        items.MenuItems.Add(new MenuItem("$Quitter"));
        

        Db_connect db = new Db_connect();
        var avion = db.SelectAvion();
        var moteur = db.SelectMoteur();
        var nbrAvion = db.SelectNbrAvion();
        var commandes = db.SelectCommandes();
        var passagers = db.SelectPassager();
        /*var premiere = db.SelectPremiere();
        var business = db.SelectBusiness();
        var premium = db.SelectPremium();
        var economy = db.SelectEconomy();
        var capacite = db.SelectCapacite();
        var type = db.SelectType();*/
        ColumnDefinition colDef1 = new ColumnDefinition();
        tableur.ColumnDefinitions.Add(colDef1);
        RowDefinition rowDef1 = new RowDefinition();
        tableur.RowDefinitions.Add(rowDef1);
        //Nom des colonnes
        TextBlock col1 = new TextBlock();
        col1.Text = "Type Avions";
        col1.HorizontalAlignment = HorizontalAlignment.Center;
        col1.FontSize = 20;
        Grid.SetColumn(col1, 0);
        Grid.SetRow(col1, 0);
        tableur.Children.Add(col1);

        //taille de la liste
        int taille = avion.Count;
        // Insertion des valeurs contenu dans la bdd dans les row
        for (int i = 0; i < taille; i++)
        {
            RowDefinition rowDef = new RowDefinition();
            tableur.RowDefinitions.Add(rowDef);
            TextBox textbox = new TextBox();
            textbox.Name = "Avion" + i + "";
            textbox.Text = avion[i];
            Grid.SetRow(textbox, i + 1);
            Grid.SetColumn(textbox, 0);
            tableur.Children.Add(textbox);
        }
        //Colonne Motorisation
        ColumnDefinition colDef2 = new ColumnDefinition();
        tableur.ColumnDefinitions.Add(colDef2);
        TextBlock col2 = new TextBlock();
        col2.Text = "Motorisation";
        col2.HorizontalAlignment = HorizontalAlignment.Center;
        col2.FontSize = 20;
        Grid.SetColumn(col2, 1);
        Grid.SetRow(col2, 0);
        tableur.Children.Add(col2);
        for (int i = 0; i < taille; i++)
        {
            Label lab = new Label();
            lab.Name = "motorisation" + i + "";
            lab.Content = moteur[i];
            Grid.SetRow(lab, i + 1);
            Grid.SetColumn(lab, 1);
            tableur.Children.Add(lab);
        }
        //Colonne Nombre d'avions
        ColumnDefinition colDef3 = new ColumnDefinition();
        tableur.ColumnDefinitions.Add(colDef3);
        TextBlock col3 = new TextBlock();
        col3.Text = "Nombre d'avions";
        col3.HorizontalAlignment = HorizontalAlignment.Center;
        col3.FontSize = 20;
        Grid.SetColumn(col3, 2);
        Grid.SetRow(col3, 0);
        tableur.Children.Add(col3);
        for (int i = 0; i < taille; i++)
        {
            Label lab = new Label();
            lab.Name = "nbrAvion" + i + "";
            lab.Content = nbrAvion[i];
            Grid.SetRow(lab, i + 1);
            Grid.SetColumn(lab, 2);
            tableur.Children.Add(lab);
        }

        scrollV1.Content = tableur;
        avionWindow.Content = scrollV1;
        avionWindow.Show();
    }
}
/*
 MainMenu menu = new MainMenu();
        MenuItem items = menu.MenuItems.Add("&File");
        items.MenuItems.Add(new MenuItem("&Recharger"));
        items.MenuItems.Add(new MenuItem("&Sauvegarder"));
        items.MenuItems.Add(new MenuItem("$Quitter"));
*/