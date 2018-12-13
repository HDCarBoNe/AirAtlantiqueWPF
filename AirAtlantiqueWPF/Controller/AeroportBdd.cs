using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace AirAtlantiqueWPF.Controller
{
    class AeroportBdd
    {
       
        private static MySqlConnection connection = Db_connect.getConnection();

        public void SelectAeroports(ObservableCollection<Aeroport> l)
        {
            connection.Close();
            connection.Open();
            string query = "SELECT * FROM aeroport";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Aeroport a = new Aeroport(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                l.Add(a);
            }
            reader.Close();
            connection.Close();
        }

        public Aeroport ChooseAeroport(int id)
        {
            connection.Close();
            connection.Open();
            string query = "SELECT * FROM aeroport where idAeroport = @id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            Aeroport b = new Aeroport();
            while (reader.Read())
            {
                
                b = new Aeroport(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
               
              
            }
            reader.Close();
            connection.Close();
            return b;
            
            
        }

        public void SelectAvionInAeroports(ObservableCollection<Aeroport> l)
        {
            connection.Open();
            string query = "SELECT * FROM aeroport";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Aeroport a = new Aeroport(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                l.Add(a);
            }
            reader.Close();
            connection.Close();
        }
    }
}



