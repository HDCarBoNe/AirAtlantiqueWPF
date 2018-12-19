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
using System.Windows.Shapes;
using AirAtlantiqueWPF.Controller;

namespace AirAtlantiqueWPF
{
    /// <summary>
    /// Logique d'interaction pour Client_menu.xaml
    /// </summary>
    public partial class Client_menu : Window
    {
        private AeroportBdd aebdd = new AeroportBdd();
        private ClientBdd cbdd = new ClientBdd();
        private VolsBdd vbdd = new VolsBdd();
        private ObservableCollection<Client> lc = new ObservableCollection<Client>();
        private ObservableCollection<Vols> lv = new ObservableCollection<Vols>();
        private ObservableCollection<Aeroport> lae = new ObservableCollection<Aeroport>();

        public Client_menu(int id)
        {
            InitializeComponent();
            System.Windows.Controls.Image im = new Image();
            ImageSource img = new BitmapImage(new Uri("personne.jpg", UriKind.Relative));
            im.Source = img;
           
            aebdd.SelectAeroports(lae);
            cbdd.SelectClient(lc,id);
            info_data.ItemsSource = lc;
            
            vbdd.SelectHistoVols(lv, id);
            info_vol.ItemsSource = lv;



        }
    }
}
