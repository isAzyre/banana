using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebMySQL01;
using static System.Net.Mime.MediaTypeNames;

namespace Form1
{
    public partial class Insere : System.Web.UI.Page
    {
        static int id_banda = 0;
        static int id_gen = 0;
        static int id_albuns = 0;

        DBconnect ligacao = new DBconnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            { 
                ligacao.CarregarAlbuns(ref ddl_albuns);
                ligacao.CarregarGeneros(ref ddl_genero);
                ligacao.CarregarBandas(ref ddl_bandas);
            }
        }

        protected void goBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }


        protected void ddl_genero_SelectedIndexChanged(object sender, EventArgs e)
        {
            string string_do_gen = ddl_genero.SelectedItem.Text;
            id_gen = Convert.ToInt32(string_do_gen.Substring(0, string_do_gen.IndexOf('-')));     
        }
        protected void ddl_albuns_SelectedIndexChanged(object sender, EventArgs e)
        {
            string string_do_id = ddl_albuns.SelectedItem.Text;
            id_albuns = Convert.ToInt32( string_do_id.Substring(0, string_do_id.IndexOf('-') ));
            
        }
        protected void ddl_bandas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string string_do_id_banda = ddl_bandas.SelectedItem.Text;
            id_banda = Convert.ToInt32(string_do_id_banda.Substring(0,string_do_id_banda.IndexOf('-')));
        }

        protected void submit_banda_Click(object sender, EventArgs e)
        {
            if (ligacao.InserirBanda(txt_nomebanda.Text.Trim(), Convert.ToInt32( txt_nummembros.Text.TrimStart().TrimEnd())))
            {
                lblSucesso.Text = "Inseriu com sucesso.";
                ligacao.CarregarBandas(ref ddl_bandas);
            }
            else
            {
                lblSucesso.Text = "Erro na inserção.";
            }
        }

        protected void submit_album_Click(object sender, EventArgs e)
        {
            
            string nome_album= txt_nome_album.Text.Trim();
            int num_musicas= Convert.ToInt32(txt_numr_musicas.Text.Trim());

            if (ligacao.InserirAlbum(nome_album,num_musicas,id_banda,id_gen))
            {
                lblSucesso.Text = "Inseriu com sucesso.";
                ligacao.CarregarAlbuns(ref ddl_albuns);
            }
            else 
            {
                lblSucesso.Text = "Erro na inserção.";
            }
            
        }

        protected void submit_musica_Click(object sender, EventArgs e)
        {

            if (ligacao.InserirMusica(txt_nomemusica.Text,id_banda))
            {
                lblSucesso.Text = "Inseriu com sucesso.";
            }
            else
            {
                lblSucesso.Text = "Erro na inserção.";
            }

        }
    }
}