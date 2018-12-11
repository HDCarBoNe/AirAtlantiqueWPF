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
        private static MySqlConnection connection = Db_connect.getConnection();
        private string value2;
        private string value4;
        public void SelectVols(ObservableCollection<Vols> l)
        {
             connection.Open();
            string query = "SELECT * FROM vols";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
             
                if (reader.IsDBNull(2))
                {
                     value2 = "Pas Parti";
                }
                else
                {
                    value2 = reader.GetString(2);
                }

                if (reader.IsDBNull(4))
                {
                    value4 = "Pas Arrivé";
                }
                else
                {
                    value4 = reader.GetString(4);
                }

                Vols a = new Vols(reader.GetInt32(0), reader.GetString(1), value2, reader.GetString(3), value4, reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7));
                l.Add(a);
            }
            reader.Close();
            connection.Close();
        }

        public static void updateVol(Vols a)
        {
            connection.Open();
            string query = "UPDATE vols SET depart_prevu=\"" + a.DepartprevuProperty + "\", depart_reel=\"" + a.DepartreelProperty + "\", arrive_prevu=\"" + a.ArriveprevuProperty + "\", arrive_reel=\"" + a.ArrivereelProperty + "\", id_avion=\"" + a.IdAvionProperty + "\", id_dep=\"" + a.IdDepProperty + "\", id_arrive=\"" + a.IdArriveProperty + "\", ";
            connection.Close();
        }

        public void InsertVols(string departprevu, string arriveprevu, int idavion, int id_dep, int id_arrive)
        {

            connection.Open();
            string query = "INSERT INTO vols( depart_prevu, arrive_prevu, idavion, id_dep, id_arrive) VALUES( @depart_prevu, @depart_reel, @arrive_prevu, @arrive_reel, @idavion, @id_dep, @id_arrive)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@depart_prevu", departprevu);
            cmd.Parameters.AddWithValue("@depart_reel", "");
            cmd.Parameters.AddWithValue("@arrive_prevu", arriveprevu);
            cmd.Parameters.AddWithValue("@arrive_reel", "");
            cmd.Parameters.AddWithValue("@idavion", idavion);
            cmd.Parameters.AddWithValue("@id_dep", id_dep);
            cmd.Parameters.AddWithValue("@id_arrive", id_arrive);
            
            cmd.ExecuteNonQuery();
            connection.Close();
        }


    }
}
