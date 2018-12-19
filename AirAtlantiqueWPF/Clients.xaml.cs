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
    /// Logique d'interaction pour Clients.xaml
    /// </summary>
    public partial class Clients : Page
    {
        Client client;
        ClientBdd cbdd = new ClientBdd();
        ObservableCollection<Client> lc = new ObservableCollection<Client>();
        public Clients()
        {
            InitializeComponent();
            cbdd.SelectClients(lc);
            listClient.ItemsSource = lc;
        }

        private void ListClient_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void ListClient_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int idclient = ((Client) listClient.SelectedCells[0].Item).idClientProperty;
            //MessageBox.Show(idvol.ToString());
           Client_menu menu = new Client_menu(idclient);
            menu.Show();
        }
    }
}
