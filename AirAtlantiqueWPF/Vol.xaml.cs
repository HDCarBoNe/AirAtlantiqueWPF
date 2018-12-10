﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
//using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AirAtlantiqueWPF.Controller;
using HorizontalAlignment = System.Windows.HorizontalAlignment;
using Label = System.Windows.Controls.Label;
using MenuItem = System.Windows.Controls.MenuItem;
using TextBox = System.Windows.Controls.TextBox;



namespace AirAtlantiqueWPF
{
    public partial class Vol : Window
    {
        Vols vols;
        VolsBdd vbdd = new VolsBdd();
        AvionBdd abdd = new AvionBdd();
        ObservableCollection<Avion> la = new ObservableCollection<Avion>();
        ObservableCollection<Vols> lv = new ObservableCollection<Vols>();
       
        public Vol()
        {
            
            InitializeComponent();
            abdd.SelectAvion(la);
            vbdd.SelectVols(lv);
            listeVols.ItemsSource = lv;
            idAvion.ItemsSource = la;          
            this.Title = "Air Atlantique Gestion des Vols";
            this.Show();
        }

        private void ListeVols_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();

        }

       


    }
}


