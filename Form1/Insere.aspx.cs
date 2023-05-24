using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Web.Services.Description;
using System.Web.UI.WebControls.WebParts;
using System.Drawing;
using System.Collections;
using WebMySQL01;
using System.Reflection.Emit;

namespace Form100
{
    public partial class Insere_teste : System.Web.UI.Page
    {
        DBconnect ligacao1 = new DBconnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                limpacampos1();
                ligacao1.CarregarBandas(ref DropDownList20);
                ligacao1.CarregarGeneros(ref DropDownList30);
            }
        }
        
        protected void RadioButton10_CheckedChanged(object sender, EventArgs e)
        {
            limpacampos1();
            bandas_in();
        }

        protected void RadioButton20_CheckedChanged(object sender, EventArgs e)
        {
            limpacampos1();
            album_in();

        }

        protected void RadioButton30_CheckedChanged(object sender, EventArgs e)
        {
            limpacampos1();
            musica_in();
        }

        protected void o_submit_Click1(object sender, EventArgs e)
        {
            if(RadioButton10.Checked) 
            {
                if (ligacao1.InserirBanda(TextBox10.Text.Trim(), Convert.ToInt32(TextBox20.Text.TrimStart().TrimEnd())))
                {
                    Label20.Text = "Inseriu com sucesso.";
                    ligacao1.CarregarBandas(ref DropDownList20);
                }
                else
                {
                    Label20.Text = "Erro na inserção.";
                }
            }
            else if(RadioButton20.Checked)
            {
                string nome_album = TextBox10.Text.Trim();
                int num_musicas = Convert.ToInt32(TextBox20.Text.Trim());

                int id_banda = Convert.ToInt32(DropDownList20.SelectedItem.Text.Substring(0, DropDownList20.SelectedItem.Text.IndexOf('-')));
                int id_gen = Convert.ToInt32(DropDownList30.SelectedItem.Text.Substring(0, DropDownList30.SelectedItem.Text.IndexOf('-')));
                if (ligacao1.InserirAlbum(nome_album, num_musicas, id_banda, id_gen))
                {
                    Label20.Text = "Inseriu com sucesso.";
                    ligacao1.CarregarAlbuns(ref DropDownList20);
                }
                else
                {
                    Label20.Text = "Erro na inserção.";
                }
            }
            else 
            {
                string nome_musica = TextBox10.Text.Trim();
                int id_album = Convert.ToInt32(DropDownList20.SelectedItem.Text.Substring(0, DropDownList20.SelectedItem.Text.IndexOf('-'))); ;
               
                if (ligacao1.InserirMusica(nome_musica, id_album))
                {
                    Label20.Text = "Inseriu com sucesso.";
                }
                else
                {
                    Label20.Text = "Erro na inserção.";
                }

            }
        }
        public void bandas_in()
        {
            lbl1.Text = "Nome da banda/artista";
            lbl2.Text = "Nº de membros";
            TextBox20.Visible = true;
            TextBox20.ReadOnly = false;
            DropDownList20.Visible = false;
            DropDownList30.Visible = false;
            ligacao1.Bind(ref GridView50);
            GridView50.DataBind();
        }

        public void album_in()
        {
            lbl1.Text = "Nome do album";
            lbl2.Text = "Nº de musicas";
            lbl3.Text = "Nome da banda";
            lbl4.Text = "Genero musical";
            TextBox20.Visible = true;
            TextBox20.ReadOnly = false;
            DropDownList20.Visible = true;
            DropDownList30.Visible = true;
            ligacao1.CarregarBandas(ref DropDownList20);
            ligacao1.CarregarGeneros(ref DropDownList30);
            ligacao1.Bind2(ref GridView50);
            GridView50.DataBind();
        }
        public void musica_in()
        {
            lbl1.Text = "Nome da musica";
            lbl3.Text = "Nome do album";
            TextBox20.Visible = false;
            TextBox20.ReadOnly = true;
            TextBox20.ReadOnly = false;
            DropDownList20.Visible = true;
            ligacao1.CarregarAlbuns(ref DropDownList20);
            DropDownList30.Visible = false;
            ligacao1.Bind3(ref GridView50);
            GridView50.DataBind();
        }

            public void limpacampos1()
        {
            lbl1.Text = "";
            lbl2.Text = "";
            lbl3.Text = "";
            lbl4.Text = "";
            TextBox10.Text = "";
            TextBox20.Text = "";
            Label20.Text = "";
            DropDownList20.SelectedIndex = 0;
            DropDownList30.SelectedIndex = 0;
            GridView50.DataSource=null;
        }

        protected void GridView50_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView50.PageIndex = e.NewPageIndex;
            ligacao1.Bind(ref GridView50);
            GridView50.DataBind();
        }

 
    }
}