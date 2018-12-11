using System;
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
using System.Globalization;



namespace AirAtlantiqueWPF
{
    public partial class Vol : Window
    {
        Vols vols;
        VolsBdd vbdd = new VolsBdd();
        AvionBdd abdd = new AvionBdd();
        AeroportBdd aebdd = new AeroportBdd();
        ObservableCollection<Avion> la = new ObservableCollection<Avion>();
        ObservableCollection<Vols> lv = new ObservableCollection<Vols>();
        ObservableCollection<Aeroport> lae = new ObservableCollection<Aeroport>();
        string timedep;
        



        public Vol()
        {
            
            InitializeComponent();
            abdd.SelectAvion(la);
            vbdd.SelectVols(lv);
            aebdd.SelectAeroports(lae);
            id_dep.ItemsSource = lae;
            id_arrive.ItemsSource = lae;
            listeVols.ItemsSource = lv;
            idAvion.ItemsSource = la;          
            this.Title = "Air Atlantique Gestion des Vols";
            this.Show();
           


        }

        private void ListeVols_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();

        }

        private void AddButton_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
       
           
        }


    }
}


