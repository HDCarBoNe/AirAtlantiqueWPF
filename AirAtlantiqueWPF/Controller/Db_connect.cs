using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AirAtlantiqueWPF;
using AirAtlantiqueWPF.Controller;
using MySql.Data.MySqlClient;

class Db_connect
{
    static MySqlConnection connection;
    static private string server;
    static private string database;
    static private string uid;
    static private string password;
    static private int port;


    public static MySqlConnection getConnection()
    {
        if (connection == null)
        {

            server = "localhost";
            database = "dbb";
            uid = "root";
            password = "";
            port = 3306;
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "Port=" + port + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }
        return connection;
    }



}