using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantiqueWPF.Controller
{
    class ClientBdd
    {
        private static MySqlConnection connection = Db_connect.getConnection();

        public void SelectClients(ObservableCollection<Client> l)
        {
            connection.Close();
            connection.Open();
            string query = "SELECT c.idClient,c.nom,c.prenom,c.telephone,c.adresse,c.ville,c.cp,c.pays,c.pts_fidelite,c.id_last_vol,v.arrive_reel FROM clients c INNER JOIN vols v ON v.idVols = c.id_last_vol Group BY c.idClient";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Client c = new Client(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),reader.GetString(4),reader.GetString(5),reader.GetString(6),reader.GetString(7),reader.GetInt32(8),reader.GetInt32(9),reader.GetDateTime(10));
                l.Add(c);
            }
            reader.Close();
            connection.Close();
        }
        public void SelectClient(ObservableCollection<Client> l, int id)
        {
            connection.Close();
            connection.Open();
            string query = "SELECT c.idClient,c.nom,c.prenom,c.telephone,c.adresse,c.ville,c.cp,c.pays,c.pts_fidelite,c.id_last_vol,v.arrive_reel FROM clients c INNER JOIN vols v ON v.idVols = c.id_last_vol Where c.idClient = @id Group BY c.idClient";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Client c = new Client(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetInt32(8), reader.GetInt32(9), reader.GetDateTime(10));
                l.Add(c);
            }
            reader.Close();
            connection.Close();
        }

        public static void updateClient(Client c)
        {
            connection.Open();
            string query = "UPDATE clients SET nom=@nom,prenom=@prenom,telephone=@tel,adresse=@adr,ville=@vil,cp=@cp,pays=@pays,pts_fidelite=@fide WHERE idClient = @idcl";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nom",c.NomProperty);
            cmd.Parameters.AddWithValue("@prenom", c.PrenomProperty);
            cmd.Parameters.AddWithValue("@tel", c.TelProperty);
            cmd.Parameters.AddWithValue("@vil", c.VilleProperty);
            cmd.Parameters.AddWithValue("@adr", c.AdresseProperty);
            cmd.Parameters.AddWithValue("@cp", c.CpProperty);
            cmd.Parameters.AddWithValue("@pays", c.PaysProperty);
            cmd.Parameters.AddWithValue("@fide", c.PtsFideliteProperty);
            cmd.Parameters.AddWithValue("@idcl", c.idClientProperty);

            //MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
