using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using System.Diagnostics;

namespace WebInquerito
{    
    public class DBConnect
    {
        private SQLiteConnection connection;

        public DBConnect()
        {            
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            string connectionString;
            string path;

            path = AppDomain.CurrentDomain.BaseDirectory + "bin\\";
            connectionString = "Data Source= " + path + "inquerito.db; Version = 3;";
            connection = new SQLiteConnection(connectionString);
        }

        //open connection to database 
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        //close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        //Insert statement
        public bool Insert(string nome, string distrito, string comida, string clube)
        {
            try
            {
                string query = "Insert into dados (nome, distrito, comida, clube) values ('" + nome + "', '" + distrito + "','" + comida + "','" + clube + "')";

                //open connection
                if (this.OpenConnection() == true)
                {

                    //create command and assign the query and connection from the constructor
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);

                    //execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
                else
                {
                    return false;
                }
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
    }
}