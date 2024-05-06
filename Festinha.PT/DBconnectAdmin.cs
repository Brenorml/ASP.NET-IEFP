using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web.UI.WebControls;


namespace Festinha.PT
{
    public class DBconnectAdmin
    {
        private MySqlConnection connection;

        private string server;
        private string database;
        private string uid;
        private string password;
        private string port;

        public DBconnectAdmin()
        {
            Initialize();
        }

        private void Initialize()
        {
            //VALORES LOCAIS
            server = "127.0.0.1"; //"127.0.0.1" ou "localhost"
            database = "festinha_pt";
            uid = "admin_festinha";
            password = "Qwerty12";
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

        public void CarregarTabelas(ref DropDownList lista, string table)
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

        public bool DevolverItens(string id, string table, ref string descricao, ref decimal valor, ref decimal quantidade)
        {
            try
            {
                string query = $"SELECT descricao, quantidade_CL, valor FROM {table} WHERE id = {id}";

                if (this.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        descricao = reader.GetString(0);
                        quantidade = reader.GetDecimal(1);
                        valor = reader.GetDecimal(2);
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

        public bool Update(string table, string id, string descricao, decimal quantidade, decimal valor)
        {
            bool flag = true;

            try
            {
                string query = "UPDATE " + table + " SET descricao = '" + descricao + "', quantidade_CL = " + quantidade + ", valor = " + valor + " WHERE ID = " + id + ";";
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

        public bool Delete(string id, string table)
        {
            try
            {
                string query = $"Delete From {table} where id = {id};";
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

        public bool Insert(string table, string descricao, decimal quantidade, decimal valor)
        {
            bool flag = true;

            try
            {
                string query = $"INSERT INTO {table} (descricao, quantidade_CL, valor) VALUES ('{descricao}', {quantidade}, {valor});";
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

        public void CarregarTabelas(ref DropDownList lista)
        {
            try
            {
                string query = "SELECT * FROM tabelas_criadas WHERE status = 1";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    lista.Items.Clear();
                    lista.Items.Add(""); // Adicione um item vazio se necessário
                    while (reader.Read())
                    {
                        lista.Items.Add(reader.GetValue(1).ToString());
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Lidere com a exceção, se necessário
            }
            finally
            {
                CloseConnection();
            }
        }

        public void BindProposta(ref GridView gv1, string table)
        {
            try
            {
                string query = $"SELECT * FROM {table};";
                //string query = "SELECT * FROM solicitacoes;";

                if (this.OpenConnection() == true)
                {
                    //Criar os comandos do MySQL

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    //da.Fill(ds, "solicitacoes");
                    da.Fill(ds, table);

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

        public void Approval(string tableName, ref Label status, string nomeProposta)
        {
            string emailAdress = string.Empty.Trim();
            try
            {                
                //descobrir email do dono da proposta e atribuir ao email destinatario
                if (this.OpenConnection() == true)
                {
                    //int indexUnderscore = nomeProposta.IndexOf('_');
                    //string nome = indexUnderscore != -1 ? nomeProposta.Substring(indexUnderscore + 1) : "";
                    string nome = nomeProposta.Contains('_') ? nomeProposta.Substring(nomeProposta.LastIndexOf('_') + 1) : "";
                    //string query = $"SELECT email FROM usersfestinhapt WHERE uname = {nome};";
                    //cmd = new MySqlCommand(query, connection);

                    MySqlCommand cmd = new MySqlCommand("SELECT email FROM usersfestinhapt WHERE uname = @UserName;", connection);
                    cmd.Parameters.AddWithValue("@UserName", nome);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        emailAdress = reader.GetString(0);
                    }
                }
                else
                {
                    this.CloseConnection();
                }
                // Configurações do servidor SMTP 
                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587; // Porta padrão para SMTP
                string smtpUsername = "equipa3_prog13@gmail.com"; // endereço de email
                string smtpPassword = "tfpf qrna drbk nvyb"; // senha do email

                // Destinatário do email
                string toEmail = emailAdress;

                // Criar mensagem de email
                MailMessage message = new MailMessage();
                message.From = new MailAddress(smtpUsername);
                message.To.Add(new MailAddress(toEmail));
                message.Subject = "Aprovação de proposta";
                message.Body = $"Caro Cliente,\n\n É com muito gosto que confirmamos o recebimento da sua proposta: {tableName}.\n\nAguardamos seu contacto para formalização e contrato.\n\nCom os maiores cumprimentos,\n\nEquipa Festinha.PT";

                // Configurar cliente SMTP
                SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true; // Habilitar SSL

                // Enviar email
                smtpClient.Send(message);

                // Email enviado com sucesso
                status.Text = "Aprovado e enviado";
            }
            catch (Exception ex)
            {
                // Lidar com exceção
                status.Text = $"Falha ao enviar a confirmação para {emailAdress}. Erro ao aprovar: " + ex.Message;
            }
        }

        public bool ValidateUser(string userName, string passWord)
        {
            MySqlCommand cmd;
            string lookupPassword = null;

            //Verificar por userName inválido
            //userName não pode ser nulo e deve ser entre 1 a 15 carácteres
            if ((null == userName) || (0 == userName.Length) || (userName.Length > 15))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.");
                return false;
            }

            //Verificar por passWord inválido
            //passWord não pode ser nulo e deve ser entre 1 e 25 carácteres
            if ((null == passWord) || (0 == passWord.Length) || (passWord.Length > 25))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation os password failed.");
                return false;
            }

            try
            {
                if (this.OpenConnection() == true)
                {
                    cmd = new MySqlCommand("SELECT pwd FROM usersfestinhapt WHERE uname = @userName;", connection);
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

        public bool VerifyAccess(string userName)
        {
            bool flag = false;
            try
            {
                string query = "SELECT usertype FROM usersfestinhapt WHERE uname = @UserName";

                if (this.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@UserName", userName);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string tipoPwd = reader.GetString(0);
                        if (tipoPwd == "cliente")
                        {
                            flag = true;
                        }
                    }

                    this.CloseConnection();
                }
            }
            catch (MySqlException ex)
            {
                this.CloseConnection();
                System.Diagnostics.Debug.WriteLine(ex.Message);
                flag = false;
            }
            return flag;            
        }
    }
}