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
    public partial class Vol : Page
    {
        
        private VolsBdd vbdd = new VolsBdd();
        private AvionBdd abdd = new AvionBdd();
        private AeroportBdd aebdd = new AeroportBdd();
        private ObservableCollection<Avion> la = new ObservableCollection<Avion>();
        private ObservableCollection<Vols> lv = new ObservableCollection<Vols>();
        private ObservableCollection<Aeroport> lae = new ObservableCollection<Aeroport>();
        private CultureInfo cultureSource = new CultureInfo("fr-FR", false);

        private string timedep;
        private string timearrive;



        public Vol()
        {
            
            InitializeComponent();
            abdd.SelectAvion(la);
            vbdd.SelectVols(lv);
            aebdd.SelectAeroports(lae);
            idAvion.ItemsSource = la;
            id_dep.ItemsSource = lae;
            id_arrive.ItemsSource = lae;
            listeVols.ItemsSource = lv;
            comboAv.ItemsSource = la;
            comboAero.ItemsSource = lae;
            this.Title = "Air Atlantique Gestion des Vols";
           


        }

        private void ListeVols_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void AddButton_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            if (arriveprevu.Text != "" && departheure.Text != "" && arriveprevu.Text != "" &&
                arriveprevu.Text != "" && idAvion.Text != "" && id_dep.Text != "" &&
                id_arrive.Text != "")
            {
                timedep = departprevu.SelectedDate.Value.ToString("yyyy-MM-dd") + " " + departheure.SelectedTime.Value.ToString("HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                timearrive = arriveprevu.SelectedDate.Value.ToString("yyyy-MM-dd") + " " + arriveheure.SelectedTime.Value.ToString("HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                vbdd.InsertVols(timedep,timearrive, Int32.Parse(idAvion.Text), Int32.Parse(id_dep.SelectedValue.ToString()), Int32.Parse(id_arrive.SelectedValue.ToString()));
                MessageBox.Show("Vol Ajouté");
                
            }
            else
            {
                MessageBox.Show("Merci de remplir tout les champs");
            }




        }

        
    }
}


