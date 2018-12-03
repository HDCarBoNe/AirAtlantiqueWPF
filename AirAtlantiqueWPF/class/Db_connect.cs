using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AirAtlantiqueWPF;
using MySql.Data.MySqlClient;

class Db_connect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private int port;

        //Constructor
        public Db_connect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "airatlantiquecsharp";
            uid = "dev";
            password = "azerty123";
            port = 3307;
            string connectionString;
            connectionString = "SERVER=" + server + ";"+ "Port=" + port +";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                //MessageBox.Show("Connection OK");
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert()
        {
        }

        //Update statement
        public void Update()
        {
        }

        //Delete statement
        public void Delete()
        {
        }

        /*public List<avion> listAvions()
        {
            List<avion> listAvions = new List<avion>();
            if (this.OpenConnection()==true)
            {
                MySqlCommand cmd = this.connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM avions";
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    
                    listAvions.Add(reader[]);
                }
            }
        }*/
        //Select des avions
        public List<string> SelectAvion()
        {
        
            //Create a list to store the result
            List<string> listAvion = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Creation d'un commande SQL 
                MySqlCommand cmd = this.connection.CreateCommand();
                //Requête SQL
                cmd.CommandText = "SELECT avion from avions";
                // Execution de la command SQL
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string avion = (string) reader["avion"];
                    listAvion.Add(avion);
                }
                reader.Close();
             
                // Fermeture de la connexion
                this.CloseConnection();

                //return list to be displayed
                return listAvion;
            }
            else
            {
                return listAvion;
            }
        }
        //Select des moteurs
        public List<string> SelectMoteur()
        {

            //Create a list to store the result
            List<string> listMoteur = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Creation d'un commande SQL 
                MySqlCommand cmd = this.connection.CreateCommand();
                //Requête SQL
                cmd.CommandText = "SELECT Motorisation from avions";
                // Execution de la command SQL
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string moteur = (string)reader["Motorisation"];
                    listMoteur.Add(moteur);
                }
                reader.Close();

                // Fermeture de la connexion
                this.CloseConnection();

                //return list to be displayed
                return listMoteur;
            }
            else
            {
                return listMoteur;
            }
        }
        //Select des Nombre d'avions
        public List<int> SelectNbrAvion()
        {

            //Create a list to store the result
            List<int> listNbrAvion = new List<int>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Creation d'un commande SQL 
                MySqlCommand cmd = this.connection.CreateCommand();
                //Requête SQL
                cmd.CommandText = "SELECT Nombre_davions from avions";
                // Execution de la command SQL
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int NbrAvion = (int)reader["Nombre_davions"];
                    listNbrAvion.Add(NbrAvion);
                }
                reader.Close();

                // Fermeture de la connexion
                this.CloseConnection();

                //return list to be displayed
                return listNbrAvion;
            }
            else
            {
                return listNbrAvion;
            }
        }
        //Select des Commandes
        public List<string> SelectCommandes()
        {

            //Create a list to store the result
            List<string> listCommandes = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Creation d'un commande SQL 
                MySqlCommand cmd = this.connection.CreateCommand();
                //Requête SQL
                cmd.CommandText = "SELECT Commandes from avions";
                // Execution de la command SQL
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int commandes = (int)reader["Commandes"];
                    string commande = ""+commandes;
                    listCommandes.Add(commande);
                }
                reader.Close();

                // Fermeture de la connexion
                this.CloseConnection();

                //return list to be displayed
                return listCommandes;
            }
            else
            {
                return listCommandes;
            }
        }
        //Select des Passagers
        public List<int> SelectPassager()
        {

            //Create a list to store the result
            List<int> listPassagers = new List<int>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Creation d'un commande SQL 
                MySqlCommand cmd = this.connection.CreateCommand();
                //Requête SQL
                cmd.CommandText = "SELECT Passagers from avions WHERE Passagers IS NOT NULL";
                // Execution de la command SQL
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                        int passager = (int)reader["Passagers"];
                        listPassagers.Add(passager);                        
                }
                reader.Close();

                // Fermeture de la connexion
                this.CloseConnection();

                //return list to be displayed
                return listPassagers;
            }
            else
            {
                return listPassagers;
            }
        }
        //Select des Premiere
        /*public List<string> SelectPremiere()
        {

            //Create a list to store the result
            List<string> listPremiere = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Creation d'un commande SQL 
                MySqlCommand cmd = this.connection.CreateCommand();
                //Requête SQL
                cmd.CommandText = "SELECT Premiere from avions";
                // Execution de la command SQL
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string premiere = reader["Premiere"].ToString();
                    listPremiere.Add(premiere);
                }
                reader.Close();

                // Fermeture de la connexion
                this.CloseConnection();

                //return list to be displayed
                return listPremiere;
            }
            else
            {
                return listPremiere;
            }
        }
    //Select des Business
        public List<int> SelectBusiness()
        {

            //Create a list to store the result
            List<int> listBusiness = new List<int>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Creation d'un commande SQL 
                MySqlCommand cmd = this.connection.CreateCommand();
                //Requête SQL
                cmd.CommandText = "SELECT Business from avions";
                // Execution de la command SQL
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int business = (int)reader["Business"];
                    listBusiness.Add(business);
                }
                reader.Close();

                // Fermeture de la connexion
                this.CloseConnection();

                //return list to be displayed
                return listBusiness;
            }
            else
            {
                return listBusiness;
            }
        }
        //Select des Premium
        public List<int> SelectPremium()
        {

            //Create a list to store the result
            List<int> listPremium = new List<int>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Creation d'un commande SQL 
                MySqlCommand cmd = this.connection.CreateCommand();
                //Requête SQL
                cmd.CommandText = "SELECT Premium_Eco from avions";
                // Execution de la command SQL
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int premium = (int)reader["Premium_Eco"];
                    listPremium.Add(premium);
                }
                reader.Close();

                // Fermeture de la connexion
                this.CloseConnection();

                //return list to be displayed
                return listPremium;
            }
            else
            {
                return listPremium;
            }
        }
        //Select des economy
        public List<int> SelectEconomy()
        {

            //Create a list to store the result
            List<int> listEconomy = new List<int>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Creation d'un commande SQL 
                MySqlCommand cmd = this.connection.CreateCommand();
                //Requête SQL
                cmd.CommandText = "SELECT Economy from avions";
                // Execution de la command SQL
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int economy = (int)reader["Economy"];
                    listEconomy.Add(economy);
                }
                reader.Close();

                // Fermeture de la connexion
                this.CloseConnection();

                //return list to be displayed
                return listEconomy;
            }
            else
            {
                return listEconomy;
            }
        }
        //Select des capacite
        public List<int> SelectCapacite()
        {

            //Create a list to store the result
            List<int> listCapacite = new List<int>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Creation d'un commande SQL 
                MySqlCommand cmd = this.connection.CreateCommand();
                //Requête SQL
                cmd.CommandText = "SELECT Capacite from avions";
                // Execution de la command SQL
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int capacite = (int)reader["Capacite"];
                    listCapacite.Add(capacite);
                }
                reader.Close();

                // Fermeture de la connexion
                this.CloseConnection();

                //return list to be displayed
                return listCapacite;
            }
            else
            {
                return listCapacite;
            }
        }
        //Select des Type
        public List<string> SelectType()
        {

            //Create a list to store the result
            List<string> listType = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Creation d'un commande SQL 
                MySqlCommand cmd = this.connection.CreateCommand();
                //Requête SQL
                cmd.CommandText = "SELECT Type from avions";
                // Execution de la command SQL
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string type = (string)reader["Type"];
                    listType.Add(type);
                }
                reader.Close();

                // Fermeture de la connexion
                this.CloseConnection();

                //return list to be displayed
                return listType;
            }
            else
            {
                return listType;
            }
        }*/

    //Count statement
    public int Count()
        {
            string query = "SELECT Count(*) FROM avions";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }
}

