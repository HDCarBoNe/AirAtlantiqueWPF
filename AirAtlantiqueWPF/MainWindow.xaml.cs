using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace AirAtlantiqueWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Avion_Click(object sender, RoutedEventArgs e)
        {
            new Avions();
            this.Close();
            
        }

        private void Vols_Click(object sender, RoutedEventArgs e)
        {
            new Vol();
            this.Close();

        }

    }
}
