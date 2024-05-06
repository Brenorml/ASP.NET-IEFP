using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebInquerito
{
    
    public class DBConnect
    {
        private SQLiteConnection conn;

        public DBConnect()
        {
            Initialize();
        }        

        private void Initialize()
        {
            string connString, path;

            path = AppDomain.CurrentDomain.BaseDirectory + "bin\\";
            connString = "Data Source= " + path + "inquerito.db; Version = 3;";
            conn = new SQLiteConnection(connString);
        }

        private bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Insert(string nome, string distrito, string comida, string clube)
        {
            try
            {
                string query = "INSERT INTO dados (nome, distrito, comida, clube) VALUES ('" + nome + "','" + distrito + "','" + comida + "','" + clube + "')";

                if(this.OpenConnection() == true)
                {
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);

                    cmd.ExecuteNonQuery();
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

        //public void Update()
        //{

        //}

        //public void Delete()
        //{

        //}

        public int Count()
        {
            int count = -1;
            try
            {
                string query = "SELECT Count(*) FROM dados";

                if(this.OpenConnection() == true)
                {
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    count = int.Parse(cmd.ExecuteScalar() + "");
                    this.CloseConnection();
                }
                else
                {
                    return count;
                }
            }
            catch (SQLiteException ex)
            {

            }
            return count;
        }
    }

    
}