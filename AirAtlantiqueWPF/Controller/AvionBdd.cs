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
        private static MySqlConnection connection = Db_connect.getConnection();
    
        public void SelectAvion(ObservableCollection<Avion> l)
        {
            connection.Open();
            string query = "SELECT * FROM avions";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Avion a = new Avion(reader.GetInt32(0), reader.GetString(1),reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8));
                l.Add(a);
            }
            reader.Close();
            connection.Close();
        }

        public static void updateAvion(Avion a)
        {
            connection.Open();
            string query = "UPDATE avions SET modele="+a.ModelAvionProperty+",motorisation="+a.MotorisationProperty+",capacite="+a.CapaciteProperty+",nb_place_premium="+a.NbrPremiumProperty+",nb_place_business="+a.NbrBusinessProperty+",nb_place_eco="+a.NbrEcoProperty+",etat="+a.EtatAvionProperty+",type="+a.TypeProperty+" WHERE idAvion="+a.idAvionProperty+"";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void insertAvion(string mo, string moto, int capa, int prem, int busi, int eco, int etat, string type)
        {
            connection.Open();
            string query = "INSERT INTO avions(modele, motorisation, capacite, nb_place_premiere, nb_place_buissness, nb_place_eco, etat, type) VALUES(@mo,@moto,@capa,@prem,@busi,@eco,@etat,@type)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@mo", mo);
            cmd.Parameters.AddWithValue("@moto", moto);
            cmd.Parameters.AddWithValue("@capa", capa);
            cmd.Parameters.AddWithValue("@prem", prem);
            cmd.Parameters.AddWithValue("@busi", busi);
            cmd.Parameters.AddWithValue("@eco", eco);
            cmd.Parameters.AddWithValue("@etat", etat);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}

