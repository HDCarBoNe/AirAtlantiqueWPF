using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AirAtlantiqueWPF.Controller
{
    class VolsBdd
    {
        private static MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private int port;

        public bool Initialize()
        {
            server = "localhost";
            database = "dbb";
            uid = "root";
            password = "";
            port = 3306;
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "Port=" + port + ";" + "DATABASE=" +
                               database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
            connection.Open();
            return true;
        }
        public void SelectVols(ObservableCollection<Vols> l)
        {
            string query = "SELECT * FROM vols";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
               Vols a = new Vols(reader.GetInt32(0), reader.GetDateTime(1), reader.GetDateTime(2), reader.GetDateTime(3), reader.GetDateTime(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7));
                l.Add(a);
            }
            reader.Close();
        }

        public static void updateVol(Vols a)
        {
            string query = "UPDATE vols SET depart_prevu=\"" + a.DepartprevuProperty + "\", depart_reel=\"" + a.DepartreelProperty + "\", arrive_prevu=\"" + a.ArriveprevuProperty + "\", arrive_reel=\"" + a.ArrivereelProperty + "\", id_avion=\"" + a.IdAvionProperty + "\", id_dep=\"" + a.IdDepProperty + "\", id_arrive=\"" + a.IdArriveProperty + "\", ";
        }

    }
}
