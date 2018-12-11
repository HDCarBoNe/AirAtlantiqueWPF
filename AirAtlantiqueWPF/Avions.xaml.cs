using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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
    public partial class Avions : Window
    {
        Avion avion;
        AvionBdd avbdd = new AvionBdd();
        ObservableCollection<Avion> la = new ObservableCollection<Avion>();

        public Avions()
        {
            InitializeComponent();
            avbdd.SelectAvion(la);
            listeAvion.ItemsSource = la;
            this.Title = "Air Atlantique Gestion des Avions";
            this.Show();
         
          
        }

        private void AddButton_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (modeleTextBox.Text != "" && motorisationTextBox.Text != "" && capaciteTextBox.Text != "" &&
                etatTextBox.Text != "" && premiumTextBox.Text != "" && businessTextBox.Text != "" &&
                ecoTextBox.Text != "" && typeTextBox.Text != "")
            {
                avbdd.insertAvion(modeleTextBox.Text, motorisationTextBox.Text, Int32.Parse(capaciteTextBox.Text), Int32.Parse(premiumTextBox.Text), Int32.Parse(businessTextBox.Text), Int32.Parse(ecoTextBox.Text), Int32.Parse(etatTextBox.Text), typeTextBox.Text);
                MessageBox.Show("Avion Ajouté");
                new Avions();
                this.Close();
            }
            else
            {
                MessageBox.Show("Merci de remplir tout les champs");
            }
        }

        private void UpdateButton_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ListeAvion_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}