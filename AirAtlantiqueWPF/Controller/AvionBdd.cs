using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AirAtlantiqueWPF.Controller
{
    class AvionBdd
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
            database = "airatlantiquecsharp";
            uid = "dev";
            password = "azerty123";
            port = 3307;
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "Port=" + port + ";" + "DATABASE=" +
                               database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
            connection.Open();
            return true;
        }
        public void SelectAvion(ObservableCollection<Avion> l)
        {
            string query = "SELECT * FROM avions";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Avion a = new Avion(reader.GetInt32(0), reader.GetString(1),reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8));
                l.Add(a);
            }
            reader.Close();
        }

        public static void updateAvion(Avion a)
        {
            string query = "UPDATE avions SET modele="+a.ModelAvionProperty+",motorisation="+a.MotorisationProperty+",capacite="+a.CapaciteProperty+",nb_place_premium="+a.NbrPremiumProperty+",nb_place_business="+a.NbrBusinessProperty+",nb_place_eco="+a.NbrEcoProperty+",etat="+a.EtatAvionProperty+",type="+a.TypeProperty+" WHERE idAvion="+a.idAvionProperty+"";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
    }
}
