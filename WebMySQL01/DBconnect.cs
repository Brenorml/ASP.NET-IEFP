using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace WebMySQL01
{
    public class DBconnect
    {
        private MySqlConnection connection;

        private string server;
        private string database;
        private string uid;
        private string password;
        private string port;

        public DBconnect()
        {
            Initialize();
        }


        //Initialize values 
        private void Initialize()
        {

            //DADOS CONEXAO PROFESSOR
            //server = "grandeporto.ddns.net";
            ////server = "127.0.0.1";
            //database = "Prog22023";
            //uid = "programador";
            //password = "Dados@2023";
            //port = "3306";

            server = "127.0.0.1"; //"127.0.0.1" ou "localhost"
            database = "formandos2_prog13";
            uid = "Programador2024";
            password = "Programador";
            port = "3306";

            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";Port=" + port + ";";

            connection = new MySqlConnection(connectionString);

        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
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
                return false;
            }
        }

        public bool Insert(string nome, char genero, string idade)
        {
            bool flag = true;

            try
            {
                string query = "Insert into formando (Nome, Genero, Idade) values ('" +
                    nome + "','" + genero + "'," + idade + ")";
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();                    
                }
            }   
            catch (MySqlException ex) {
                flag = false;
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }

        public void CarregarFormandos(ref DropDownList lista)
        {
            try
            {
                string query = "Select ID, Nome, Genero, Idade From formando order by ID";

                if (this.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    lista.Items.Clear();
                    lista.Items.Add("");
                    while (reader.Read())
                    {
                        lista.Items.Add(reader.GetValue(0).ToString() + " - "
                            + reader.GetValue(1));
                    }
                    this.CloseConnection();
                }
            }   
            catch (MySqlException ex)
            {

            }
        }

        public bool DevolverFormando(string id, ref string nome, ref char genero, 
            ref int idade)
        {
            try
            {
                string query = "Select ID, Nome, Genero, Idade From formando where ID = " + id;

                if (this.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        nome = reader.GetString(1);
                        genero = reader.GetChar(2);
                        //genero = reader.GetString(2)[0];
                        idade = reader.GetInt16(3);
                        //idade = int.Parse(reader.GetValue(3).ToString());
                    }
                    this.CloseConnection();

                }
            } 
            catch (MySqlException ex)
            {
                this.CloseConnection();
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public bool Delete(string id)
        {
            try
            {
                string query = "Delete From formando where ID = " + id;
                if (this.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    this.CloseConnection();
                }
            }
            catch (MySqlException ex)
            {
                return false;
            }
            return true;
        }

        public int Count()
        {
            int count = -1;
            try
            {
                if (this.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand("Select Count(*) From formando", connection);
                    count = int.Parse(cmd.ExecuteScalar().ToString());
                    this.CloseConnection();
                }

            }
            catch (MySqlException ex)
            {

            }
            return count;
        }

        public void Bind(ref GridView gv1)
        {
            try
            {
                string query = "SELECT * FROM formando;";

                if(this.OpenConnection() == true)
                {
                    //Criar os comandos do MySQL

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    da.Fill(ds, "formando");

                    //this.CloseConnection();
                    gv1.DataSource = ds.Tables[0].DefaultView;
                }
            }
            catch(MySqlException ex)
            {

            }
            finally 
            { 
                CloseConnection(); 
            }
        }

        public bool Update(string id, string nome, char genero, string idade)
        {
            bool flag = true;

            try
            {
                string query = "UPDATE formando SET Nome = '" + nome + "', Genero = '" + genero + "', Idade = " + idade + " WHERE ID = " + id + ";";
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();                                        
                }
            }
            catch (MySqlException ex)
            {
                flag = false;
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }

        public float Media()
        {
            float media = -1;
            try
            {
                if (this.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand("Select avg(IDade) From formando", connection);
                    media = float.Parse(cmd.ExecuteScalar().ToString());
                    //this.CloseConnection();
                }

            }
            catch (MySqlException ex)
            {

            }
            finally
            {
                CloseConnection();
            }
            return media;
        }

        public void CarregarIdades(ref DropDownList ddl)
        {
            for(int i = 1; i <= 150; i++)
            {
                ddl.Items.Add(i.ToString());
            }
        }

        public bool ValidateUser(string userName, string passWord)
        {
            MySqlCommand cmd;
            string lookupPassword = null;

            //Verificar por userName inválido
            //userName não pode ser nulo e deve ser entre 1 a 15 carácteres
            if((null == userName) || (0 == userName.Length) || (userName.Length > 15))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.");
                return false;
            }

            //Verificar por passWord inválido
            //passWord não pode ser nulo e deve ser entre 1 e 25 carácteres
            if((null == passWord) || (0 == passWord.Length) || (passWord.Length > 25)) 
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation os password failed.");
                return false;
            }

            try
            {
                if(this.OpenConnection() == true)
                {
                    cmd = new MySqlCommand("Select pwd from usersprog13 where uname=@userName", connection);
                    cmd.Parameters.Add("@userName", MySqlDbType.VarChar, 25);
                    cmd.Parameters["@userName"].Value = userName;

                    lookupPassword = (string)cmd.ExecuteScalar();

                    cmd.Dispose();
                    this.CloseConnection();
                }
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
            }

            if (null == lookupPassword)
            {
                return false;
            }

            return (0 == string.Compare(lookupPassword, passWord, false));
        }

    }


}