using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Web.Security;

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
                string connectionString;

                server = "grandeporto.ddns.net";
                database = "Prog22094";
                uid = "User22094";
                password = "AspNET2023!";
                port = "3306";

                connectionString = "Server =" + server + ";Port =" + port +
                ";Database =" + database + ";Uid =" + uid + ";Pwd =" + password + ";";

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

            public float Media()
            {
                float count = 0.0f;
                try
                {
                    if (this.OpenConnection())
                    {
                        MySqlCommand cmd = new MySqlCommand("SELECT AVG(idade) FROM formando", connection);
                        count = float.Parse(cmd.ExecuteScalar().ToString());
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
                
                    if (this.OpenConnection()) 
                    {
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataSet ds = new DataSet();

                        da.Fill(ds, "formando");
                        gv1.DataSource = ds;
                        gv1.DataSource = ds.Tables[0].DefaultView;
                    }

                }
                catch (MySqlException ex) 
                {
                
                }
                finally 
                { 
                    this.CloseConnection(); 
                } 
            }
            public bool Update(string id, string nome, char genero, string idade)
            {
                bool flag = true;

                try
                {
                    string query = "UPDATE formando SET nome = '"+ nome +"',Genero = '"+ genero +"',Idade = '"+idade+"' WHERE id = " + id;


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


            public bool ValidateUser(string userName, string password)
            {
                MySqlCommand cmd;
                string lookupPassword = null;
            
                //Comparar os valores nulos com as variaveis fara diferença ao contrario?
                if( null == userName || 0==userName.Length || userName.Length > 15) 
                {
                    System.Diagnostics.Trace.WriteLine("[Validate User] Input validation of user name failed");
                    return false;
                }
        
                if(null == password || 0 == password.Length || password.Length > 25 )
                {
                    System.Diagnostics.Trace.WriteLine("[Validate User] Input validation of password failed");
                    return false;
                }
        
                try
                {
                    if(this.OpenConnection() == true) 
                    {
                        cmd = new MySqlCommand("SELECT pwd FROM users WHERE uname= @userName", connection);
            
                //na linha acima usamos a variavel @userName, abaixo cria-se a mesma

                        cmd.Parameters.Add("@userName", MySqlDbType.VarChar, 25);

                // Aqui atribuimos o que estiver escrito na variavel userName
               //  para a variavel que estamos a usar no query SQL
                        cmd.Parameters["@userName"].Value = userName;

             // O lookupPassword agora passa a ser o query
            //  no qual vamos procurar a password, query construido na variavel cmd   
           //   e executado atraves do ExecuteScalar(), o ExecuteScalar executa o query
          //    e devolve o valor da primeira fila na primeira coluna 
         //     dentro dos parametros estabelicidos pelo query,
        //      ignora outras colunas ou filas
                        lookupPassword = (string)cmd.ExecuteScalar();


                     //Dispose limpa os campos do comando após isso fecha-se ligação
                        cmd.Dispose();
                        this.CloseConnection();
                    }
                }

                catch(MySqlException ex) 
                {
                    System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
                }

                if (null == lookupPassword) 
                {
                    return false;
                }
            
            
               //   compara 0 com a comparação do lookupPassword e da password
              //    usando o Compare() o programa está a comparar os dois strings
             //     se forem iguais devolve 0 se o primeiro string for maior
            //      que o segundo devolve 1 se for o oposto devolve -1 
                return (0 == string.Compare(lookupPassword, password, false));
            }

            public bool ValidateUser2(string userName, string password)
            {
                bool flag = false;
                string id_user = "";
                string query = "select nome_utilizador from utilizador where binary nome_utilizador = '"
                    + userName + "' and palavra_passe = sha2('" + password + "',512) and estado = 'A';";

                try
                {
                    if (OpenConnection())
                    {
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            id_user = reader.GetString(0);
                            flag = true;
                        }

                    }
                }

                catch (MySqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    flag = false;
                }
                finally 
                {
                    CloseConnection();    
                }

                return flag;
            }

            //Para activar o procedure na bd i think?? 
            public void PUSucessLogin(string userID, string result) 
            {
                string query = "call pUSucessLogin('" + userID + "','" + result + "');";

                try
                {
                    if (OpenConnection())
                    {
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
                finally 
                {
                    CloseConnection();
                }
            }
        }
    }
 

