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
            while (reader.Read())
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
            if (reader.Read())
            {
                
                b = new Aeroport(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
               
              
            }
            reader.Close();
           
            return b;
            
            
        }

        public void SelectAvionAeroports(ObservableCollection<AvionInAero> l,int idaero)
        {
            connection.Open();
            string query = "SELECT av.idAvion, av.modele, av.capacite, av.type, av.etat , v.idVols, v.arrive_reel FROM vols v INNER JOIN avions av ON av.idAvion = v.id_avion WHERE v.arrive_reel=(SELECT MAX(v2.arrive_reel) From vols v2 WHERE v2.id_avion = v.id_avion ) AND v.id_arrive = @idaero GROUP By av.idAvion ORDER By av.idAvion";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@idaero", idaero);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
               AvionInAero a = new AvionInAero(reader.GetInt32(0), reader.GetString(1),reader.GetInt32(2),reader.GetInt32(3), reader.GetInt32(4),reader.GetInt32(5),reader.GetDateTime(6));
                l.Add(a);
            }
            reader.Close();
            connection.Close();
        }
    }
}



