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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AirAtlantiqueWPF.Controller;

namespace AirAtlantiqueWPF
{
    /// <summary>
    /// Logique d'interaction pour Aeroports.xaml
    /// </summary>
    public partial class Aeroports : Page
    {
        AeroportBdd aebdd = new AeroportBdd();
        ObservableCollection<Aeroport> lae = new ObservableCollection<Aeroport>();

        public Aeroports()
        {
            InitializeComponent();
            aebdd.SelectAeroports(lae);
            comboAero.ItemsSource = lae;
        }

        private void ComboAero_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //recupération id Aéroport select
            Aeroport aeroselect = (Aeroport)comboAero.SelectedItem;
            ObservableCollection<AvionInAero> aia = new ObservableCollection<AvionInAero>();
            aebdd.SelectAvionAeroports(aia, aeroselect.idAeroportProperty);
            listeAvionAero.ItemsSource = aia;
        }
    }
}
