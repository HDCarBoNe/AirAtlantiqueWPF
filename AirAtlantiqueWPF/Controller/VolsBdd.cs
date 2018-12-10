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
       
        public void SelectVols(ObservableCollection<Vols> l)
        {
            connection.Open();
            string query = "SELECT * FROM vols";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
               Vols a = new Vols(reader.GetInt32(0), reader.GetDateTime(1), reader.GetDateTime(2), reader.GetDateTime(3), reader.GetDateTime(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7));
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

        public void InsertVols(DateTime departprevu, DateTime departreel, DateTime arriveprevu, DateTime arrivereel, int idavion, int id_dep, int id_arrive)
        {

            connection.Open();
            string query = "INSERT INTO vols( depart_prevu, depart_reel, arrive_prevu, arrive_reel, idavion, id_dep, id_arrive) VALUES( @depart_prevu, @depart_reel, @arrive_prevu, @arrive_reel, @idavion, @id_dep, @id_arrive)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@depart_prevu", departprevu);
            cmd.Parameters.AddWithValue("@depart_reel", departreel);
            cmd.Parameters.AddWithValue("@arrive_prevu", arriveprevu);
            cmd.Parameters.AddWithValue("@arrive_reel", arrivereel);
            cmd.Parameters.AddWithValue("@idavion", idavion);
            cmd.Parameters.AddWithValue("@id_dep", id_dep);
            cmd.Parameters.AddWithValue("@id_arrive", id_arrive);
            
            cmd.ExecuteNonQuery();
            connection.Close();
        }


    }
}
