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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirAtlantiqueWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Label lab = new Label();
        static ListBox lb = new ListBox();
        static DockPanel dp = new DockPanel();
        public MainWindow()
        {
            InitializeComponent();
            //Avions.Content = "Vrouuum!";
            /*Db_connect db = new Db_connect();
            this.Height = 600;
            this.Width = 900;
            db.Select();
            List<string>[] listItem = db.Select();
            Console.WriteLine(db.Select());
            lb.ItemsSource = listItem[1];
            dp.Children.Add(lb);
            DockPanel.SetDock(lb, Dock.Left);*/
            MySql.Data.MySqlClient.MySqlConnection connexion = Dao.getConnection();
            string request = "select * from avions";
            MySql.Data.MySqlClient.MySqlDataAdapter dataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(request, connexion);
            List<avion> liste = new List<avion>();
            System.Data.DataSet dataSet = new System.Data.DataSet("myDataSet");
            dataAdapter.Fill(dataSet);
            avion p = null;
            foreach (System.Data.DataRow row in dataSet.Tables[0].Rows)
            {
                p = new avion((string)row[1], (string)row[2]);
                liste.Add(p);
            }
            this.DataContext = liste;

        }
    }
}
