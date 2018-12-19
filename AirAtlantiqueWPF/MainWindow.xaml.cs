using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using Image = System.Windows.Controls.Image;

namespace AirAtlantiqueWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Image im = new Image();
            ImageSource img = new BitmapImage(new Uri("avion.jpg", UriKind.Relative));
            im.Source = img;
            Main.Content = im;
        }

        private void ButtonBase_OnClickHome(object sender, RoutedEventArgs e)
        {
            this.Width = 900;
            Image im = new Image();
            ImageSource img = new BitmapImage(new Uri("avion.jpg", UriKind.Relative));
            im.Source = img;
            Main.Content = im;
        }

        private void ButtonBase_OnClickAvions(object sender, RoutedEventArgs e)
        {
            this.Width = 900;
            Main.Content = new Avions();
        }

        private void ButtonBase_OnClickVols(object sender, RoutedEventArgs e)
        {
            this.Width = 1150;
            Main.Content = new Vol();
        }

        private void ButtonBase_OnClickAeroport(object sender, RoutedEventArgs e)
        {
            this.Width = 900;

            Main.Content = new  Aeroports();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Width = 1600;
            Main.Content = new Clients();
        }
    }
}
