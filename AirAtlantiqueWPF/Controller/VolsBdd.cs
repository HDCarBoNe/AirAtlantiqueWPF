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
              
                if (reader.Read())
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

                    idvol = reader.GetInt32(0);
                   
                    date_dep = reader.GetString(1);

                    date_arr = reader.GetString(3);
                    idavion = reader.GetInt32(5);

                    id1 = reader.GetInt32(6);
                    id2 = reader.GetInt32(7);

                    reader.GetString(3);
                    id_dep = aebdd.ChooseAeroport(id1);

                    id_arrive = aebdd.ChooseAeroport(id2);
                    
                    Vols a = new Vols(idvol, date_dep, value2, date_arr, value4, idavion, id_dep, id_arrive);
                   
                    l.Add(a);
                    MessageBox.Show("COUCOU");
                   
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


    }
}
