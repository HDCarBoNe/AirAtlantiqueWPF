using System;
using System.Collections.Generic;
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

namespace AirAtlantiqueWPF
{
    /// <summary>
    /// Logique d'interaction pour Client_menu.xaml
    /// </summary>
    public partial class Client_menu : Window
    {
        public Client_menu(int id)
        {
            InitializeComponent();
            System.Windows.Controls.Image im = new Image();
            ImageSource img = new BitmapImage(new Uri("personne.jpg", UriKind.Relative));
            im.Source = img;
            
        }
    }
}
