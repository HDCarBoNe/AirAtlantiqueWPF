using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace AirAtlantiqueWPF.Controller
{
    class VolsBdd
    {
        AeroportBdd aebdd = new AeroportBdd();
        private static MySqlConnection connection = Db_connect.getConnection();
        private int idvol;
        private string date_dep;
        private string date_arr;
        private int idavion;
        private string value2;
        private string value4;
        private Aeroport id_dep;
        private Aeroport id_arrive;
        private int id1;
        private int id2;
        public void SelectVols(ObservableCollection<Vols> l)
        {
            connection.Close();
           
            string query = "SELECT * FROM vols";
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            
            if (reader.HasRows)
            {
              
                while (reader.Read())
                {
                   
                 
                    if (reader.IsDBNull(2))
                    {
                        value2 = "NULL";
                    }

                
                    else
                    {
                        value2 = reader.GetString(2);
                    }
                 
                    if (reader.IsDBNull(4))
                    {
                        value4 = "NULL";
                    }
                    else
                    {
                        value4 = reader.GetString(4);
                    }

                    idvol = reader.GetInt32(0);
                   
                    date_dep = reader.GetString(1);

                    date_arr = reader.GetString(3);
                    idavion = reader.GetInt32(5);

                    id1 = reader.GetInt32(6);
                    id2 = reader.GetInt32(7);

                    reader.GetString(3);
                    
                
                    
                    Vols a = new Vols(idvol, date_dep, value2, date_arr, value4, idavion, id1, id2);
                   
                    l.Add(a);
                    
                   
                }

                reader.Close();
                connection.Close();

            }
          
        }

        public static void updateVol(Vols a)
        {
            connection.Open();
            string query = "UPDATE vols SET depart_prevu=\"" + a.DepartprevuProperty + "\", depart_reel=\"" + a.DepartreelProperty + "\", arrive_prevu=\"" + a.ArriveprevuProperty + "\", arrive_reel=\"" + a.ArrivereelProperty + "\", id_avion=\"" + a.IdAvionProperty + "\", id_dep=\"" + a.IdDepProperty + "\", id_arrive=\"" + a.IdArriveProperty + "\", ";
            connection.Close();
        }

        public void InsertVols(string departprevu, string arriveprevu, int idavion, int id_dep, int id_arrive)
        {
            connection.Close();
            connection.Open();
            string query = "INSERT INTO vols( depart_prevu, arrive_prevu, id_avion, id_dep, id_arrive) VALUES( @depart_prevu, @arrive_prevu, @id_avion, @id_dep, @id_arrive)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@depart_prevu", departprevu);
          //  cmd.Parameters.AddWithValue("@depart_reel", "");
            cmd.Parameters.AddWithValue("@arrive_prevu", arriveprevu);
          //  cmd.Parameters.AddWithValue("@arrive_reel", "");
            cmd.Parameters.AddWithValue("@id_avion", idavion);
            cmd.Parameters.AddWithValue("@id_dep", id_dep);
            cmd.Parameters.AddWithValue("@id_arrive", id_arrive);
            
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void updateVols(Vols v)
        {
            connection.Close();
            connection.Open();

            string query = " UPDATE vols SET depart_prevu = @depart_prevu, depart_reel = @depart_reel, arrive_prevu = @arrive_prevu, arrive_reel = @arrive_reel, id_avion = @id_avion, id_arrive = @id_arrive WHERE idVols = @idvols";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@depart_prevu", v.DepartprevuProperty);
            cmd.Parameters.AddWithValue("@depart_reel", v.DepartreelProperty);
            cmd.Parameters.AddWithValue("@arrive_prevu", v.ArriveprevuProperty);
            cmd.Parameters.AddWithValue("@arrive_reel", v.ArrivereelProperty);
            cmd.Parameters.AddWithValue("@id_avion", v.IdAvionProperty);
            //cmd.Parameters.AddWithValue("@id_dep", id_dep);
            cmd.Parameters.AddWithValue("@id_arrive", v.IdArriveProperty);
            cmd.Parameters.AddWithValue("@idvols", v.idVolsProperty);
            
       
            cmd.ExecuteNonQuery();
            connection.Close();
        }



    }
}
