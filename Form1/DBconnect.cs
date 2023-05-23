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
using Microsoft.SqlServer.Server;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Crypto.Digests;

namespace WebMySQL01
{
    public class DBconnect
    {
        private MySqlConnection connection;

        private string server;
        private string database;
        private string uid;
        private string port;
        private string password;

        public DBconnect()
        {
            Initialize();
        }


        //Initialize values 
        private void Initialize()
        {
            string connectionString;

            server = "localhost";
            database = "bd_musica";
            uid = "user";
            port = "3306";
            password = "musica1!";

            connectionString = "Server =" + server + ";Port =" + port +
            ";Database =" + database + ";Uid =" + uid + ";Pwd =" + password + ";";

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

        //Três binds para as três grelhas para consultar
        public void Bind(ref GridView gv1)
        {
            try
            {
                string query = "SELECT nome,num_membros as 'nº de membros' FROM bandas";


                if (this.OpenConnection())
                {
                    //Grelha 1
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "bandas");
                    gv1.DataSource = ds;
                    //supostamente garante que a vista default da grelha comece na posição 0 
                    gv1.DataSource = ds.Tables[0].DefaultView;
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Bind2(ref GridView gv2)
        {
            string query2 = "select albuns.nome_album as 'Album', albuns.num_musicas as 'Nº de musicas', bandas.nome as 'Banda', generos.nome_genero as 'Genero Musical' \r\nfrom albuns \r\ninner join bandas on albuns.id_banda=bandas.id_banda \r\ninner join generos on albuns.id_genero_album=generos.id;";

            //Grelha 2
            MySqlCommand cmd2 = new MySqlCommand(query2, connection);
            MySqlDataAdapter da2 = new MySqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2, "albuns");
            gv2.DataSource = ds2;
            //supostamente garante que a vista default da grelha comece na posição 0 
            gv2.DataSource = ds2.Tables[0].DefaultView;

        }
        public void Bind3(ref GridView gv3)
        {
            string query3 = "select musicas.nome_musicas as 'Musica',albuns.nome_album 'Album' from musicas inner join albuns on musicas.album = albuns.id_albuns;";

            //Grelha 3
            MySqlCommand cmd3 = new MySqlCommand(query3, connection);
            MySqlDataAdapter da3 = new MySqlDataAdapter(cmd3);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3, "bandas");
            gv3.DataSource = ds3;
            //supostamente garante que a vista default da grelha comece na posição 0 
            gv3.DataSource = ds3.Tables[0].DefaultView;
        }


        //Os Carregar(nome da tabela) para as drop down lists teres conteudo
        public void CarregarAlbuns(ref DropDownList lista)
        {
            try
            {
                string query = "Select id_albuns, nome_album, num_musicas, id_banda,id_genero_album From albuns order by id_albuns";

                if (this.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    //Clear limpa a lista para garantir que está vazia
                    lista.Items.Clear();

                    lista.Items.Add("");
                    while (reader.Read())
                    {
                        //concatenar o ID e o nome 
                        lista.Items.Add(reader.GetValue(0).ToString() + " - " + reader.GetValue(1));
                    }
                    this.CloseConnection();
                }
            }
            catch (MySqlException ex)
            {

            }
        }

        public void CarregarGeneros(ref DropDownList lista)
        {
            try
            {
                string query = "Select id, nome_genero From generos order by id";

                if (this.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    //Clear limpa a lista para garantir que está vazia
                    lista.Items.Clear();

                    lista.Items.Add("");
                    while (reader.Read())
                    {
                        //concatenar o ID e o nome 
                        lista.Items.Add(reader.GetValue(0).ToString() + " - " + reader.GetValue(1));
                    }
                    this.CloseConnection();
                }
            }
            catch (MySqlException ex)
            {

            }
        }

        public void CarregarBandas(ref DropDownList lista)
        {
            try
            {
                string query = "Select id_banda,nome,num_membros From bandas order by id_banda";

                if (this.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    //Clear limpa a lista para garantir que está vazia
                    lista.Items.Clear();

                    lista.Items.Add("");
                    while (reader.Read())
                    {
                        //concatenar o ID e o nome 
                        lista.Items.Add(reader.GetValue(0).ToString() + " - " + reader.GetValue(1));
                    }
                    this.CloseConnection();
                }
            }
            catch (MySqlException ex)
            {

            }
        }
        public void CarregarMusicas(ref DropDownList lista)
        {
            try
            {
                string query = "select musicas.id_musicas as 'ID', musicas.nome_musicas as 'Musica',albuns.nome_album 'Album' from musicas inner join albuns on musicas.album = albuns.id_albuns";

                if (this.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    //Clear limpa a lista para garantir que está vazia
                    lista.Items.Clear();

                    lista.Items.Add("");
                    while (reader.Read())
                    {
                        //concatenar o ID, o nome e o album
                        lista.Items.Add(reader.GetValue(0).ToString() + " - " + reader.GetValue(1) + " - " + reader.GetValue(2));
                    }
                    this.CloseConnection();
                }
            }
            catch (MySqlException ex)
            {

            }
        }
        public bool InserirBanda(string nome_banda, int num_membros)
        {
            string query = "Insert into bandas(nome,num_membros) values('" + nome_banda + "'," + num_membros + ")";
            if (OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
                finally
                {
                    this.CloseConnection();

                }
            }
            else
            {
                return false;
            }
        }

        public bool InserirAlbum(string nome_album, int num_musicas, int id_banda, int id_genero)
        {
            string query = "Insert into albuns(nome_album,num_musicas,id_banda,id_genero_album) values('" + nome_album + "'," + num_musicas + "," + id_banda + "," + id_genero + ")";
            if (OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
                finally
                {
                    this.CloseConnection();
                }
            }
            else { return false; }
        }
        public bool InserirMusica(string nome_musica, int id_album)
        {
            string query = "Insert into musicas(nome_musicas,album) values('" + nome_musica + "'," + id_album + ")";
            if (OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
                finally
                {
                    this.CloseConnection();
                }
            }
            else { return false; }
        }

        public bool ApagarDados(string tabela, string nome_id, int id)
        {
            string query = "Delete from " + tabela + " where " + nome_id + " like " + id;

            if (OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
                finally
                {
                    this.CloseConnection();
                }
            }
            else
            {
                return false;
            }
        }
        public int Quantossao(string tabela)
        {
            int max = 0;
            if (OpenConnection())
            {
                switch (tabela)
                {
                    case "albuns":
                        string conta = "Select max(id_albuns) from albuns";
                        MySqlCommand cmd = new MySqlCommand(conta, connection);
                        max = Convert.ToInt32(cmd.ExecuteScalar());
                        break;

                    case "bandas":
                        string conta1 = "Select max(id_banda) from bandas";
                        MySqlCommand cmd1 = new MySqlCommand(conta1, connection);
                        max = Convert.ToInt32(cmd1.ExecuteScalar());
                        break;
                }
            }
            return (max + 1);
            // +1 pois não chega ao valor inserido só ao numero antes do mesmo,
            // logo mais 1 para encompassar a lista toda
        }

        public string Aleatorio()
        {
            string dados = "";

            while (dados == "")
            {
                try
                {

                    //Rand vai de 0 a 2 e atribui o nome de uma das tabelas ao string
                    Random rand = new Random();
                    int num = rand.Next(2);
                    string tabela_principal = "";
                    tabela_principal = num == 0 ? "albuns" : "bandas";

                    //Uma vez decidida a tabela temos de saber quantos campos tem para tal, passa-se o nome da tabela para a função Quantossao()
                    int maximo = Quantossao(tabela_principal);

                    //Randomizar outro numero de 0 ao maximo adquirido pela função Quantossao para gerar um numero de 0 ao numero maior da lista
                    Random rand2 = new Random();
                    int num2 = rand2.Next(1, maximo);

                    string tabela_sec = tabela_principal == "albuns" ? "nome_album" : "nome";
                    string id_tabela = tabela_principal == "albuns" ? "id_albuns" : "id_banda";

                    //O query Select (nome da coluna) from (nome da tabela) where (o id da tabela) like (numero gerado entre 0 e o que o Count devolveu)
                    string query = "Select " + tabela_sec + " from " + tabela_principal + " where " + id_tabela + " like " + num2;

                    MySqlCommand aleat = new MySqlCommand(query, connection);
                    MySqlDataReader reader = aleat.ExecuteReader();
                    while (reader.Read())
                    {
                        dados = reader.GetValue(0).ToString();
                    }
                    reader.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return dados = "Erro";
                }
                finally { CloseConnection(); }
            }

            return dados;
        }
    }
}


 

