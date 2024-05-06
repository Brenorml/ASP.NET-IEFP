using System.Data;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;


namespace Festinha.PT
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

        private void Initialize()
        {
            //VAIAVEIS E VALORES LOCAIS
            server = "127.0.0.1"; //"127.0.0.1" ou "localhost"
            database = "festinha_pt";
            uid = "Breno";
            password = "123456";
            port = "3306";

            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";Port=" + port + ";";

            connection = new MySqlConnection(connectionString);

        }

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

        public bool IniciarAplicacao(string username)
        {
            try
            {
                string query = $"CREATE TABLE proposta_{username} (id INT PRIMARY KEY AUTO_INCREMENT NOT NULL, nome VARCHAR(50) NOT NULL, descricao VARCHAR(250) NOT NULL, valor_unitario DECIMAL NOT NULL, quantidade INT NOT NULL, valor_total DECIMAL NOT NULL);"; 

                if (this.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    
                }


            }
            catch(MySqlException ex)
            {
                return false;
            }
            finally
            {
                CloseConnection();
            }
            return true;
        }

        public bool IniciarControlo(string username)
        {
            try
            { 
                string query = $"INSERT INTO tabelas_criadas (nome) VALUES ('proposta_{username}');";

                if (this.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();                    
                }
            }
            catch (MySqlException ex)
            {
                return false;
            }
            finally
            {
                CloseConnection();
            }
            return true;
        }

        public void BindProposta(ref GridView gv1, string username)
        {
            try
            {
                string query = $"SELECT * FROM proposta_{username};";
                //string query = "SELECT * FROM solicitacoes;";

                if (this.OpenConnection() == true)
                {
                    //Criar os comandos do MySQL

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    //da.Fill(ds, "solicitacoes");
                    da.Fill(ds, $"proposta_{username}");

                    //this.CloseConnection();
                    gv1.DataSource = ds.Tables[0].DefaultView;
                }
            }
            catch (MySqlException ex)
            {

            }
            finally
            {
                CloseConnection();
            }
        }

        public void CarregarItens(ref DropDownList lista, string table)
        {
            try
            {
                string query = $"SELECT id, descricao, valor FROM {table} ORDER BY id";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    lista.Items.Clear();
                    lista.Items.Add("");
                    while (reader.Read())
                    {
                        lista.Items.Add(reader.GetValue(0).ToString() + " - "
                            + reader.GetValue(1) + " - " + reader.GetValue(2).ToString());
                    }
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
        }

        public bool DevolverItens(string id, string table, ref string descricao, ref decimal valor)
        {
            try
            {
                string query = $"SELECT descricao, valor FROM {table} WHERE id = {id}";

                if (this.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        descricao = reader.GetString(0);
                        valor = reader.GetDecimal(1);
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

        public bool InsereItem(string username, string nome, string descricao, decimal valor_unitario, int quantidade, decimal valor_total)
        {
            bool flag = true;

            try
            {
                string query = $"INSERT INTO proposta_{username} (nome, descricao, valor_unitario, quantidade, valor_total) VALUES ('{nome}', '{descricao}', {valor_unitario}, {quantidade}, {valor_total});";

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

        public void BindBebidas(ref GridView gv1, string username)
        {
            try
            {
                string query = $"SELECT * FROM proposta_{username} WHERE nome = 'cerveja' OR nome = 'whisky' OR  nome = 'vinho' OR  nome = 'refrigerante' OR  nome = 'champagne' ORDER BY id;";                

                if (this.OpenConnection() == true)
                {
                    //Criar os comandos do MySQL

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    //da.Fill(ds, "solicitacoes");
                    da.Fill(ds, $"proposta_{username}");

                    //this.CloseConnection();
                    gv1.DataSource = ds.Tables[0].DefaultView;
                }
            }
            catch (MySqlException ex)
            {

            }
            finally
            {
                CloseConnection();
            }
        }

        public void BindBuffet(ref GridView gv1, string username)
        {
            try
            {
                string query = $"SELECT * FROM proposta_{username} WHERE nome = 'salgados' OR nome = 'carnes' OR  nome = 'peixe' OR  nome = 'vegetariano' OR  nome = 'sobremesas' ORDER BY id;";

                if (this.OpenConnection() == true)
                {
                    //Criar os comandos do MySQL

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    //da.Fill(ds, "solicitacoes");
                    da.Fill(ds, $"proposta_{username}");

                    //this.CloseConnection();
                    gv1.DataSource = ds.Tables[0].DefaultView;
                }
            }
            catch (MySqlException ex)
            {

            }
            finally
            {
                CloseConnection();
            }
        }

        public void BindServico(ref GridView gv1, string username)
        {
            try
            {
                string query = $"SELECT * FROM proposta_{username} WHERE nome = 'casamento' OR nome = 'festas' ORDER BY id;";

                if (this.OpenConnection() == true)
                {
                    //Criar os comandos do MySQL

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    //da.Fill(ds, "solicitacoes");
                    da.Fill(ds, $"proposta_{username}");

                    //this.CloseConnection();
                    gv1.DataSource = ds.Tables[0].DefaultView;
                }
            }
            catch (MySqlException ex)
            {

            }
            finally
            {
                CloseConnection();
            }
        }

        public bool SubmissaoProposta(string nome)
        {
            bool flag = true;

            try
            {
                string query = $"UPDATE tabelas_criadas SET status = 1 WHERE nome = 'proposta_{nome}';";
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

    }
}