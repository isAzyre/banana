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

namespace Form1
{
    public partial class teste : System.Web.UI.Page
    {
        DBconnect ligacao = new DBconnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                limpacampos();
                ligacao.CarregarBandas(ref DropDownList2);
                ligacao.CarregarGeneros(ref DropDownList3);
            }
        }
        protected void DDL1_Index_Change(object sender, EventArgs e)
        {
      
        }

        protected void Botao_Click(object sender, EventArgs e)
        {
            //div_01.Visible = true;
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            limpacampos();
            TextBox2.Visible = true;
            TextBox2.ReadOnly = false;
            DropDownList2.Visible = false;
            DropDownList3.Visible = false;
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            limpacampos();
            TextBox2.Visible = true;
            TextBox2.ReadOnly = false;
            DropDownList2.Visible = true;
            DropDownList3.Visible = true;
            ligacao.CarregarBandas(ref DropDownList2);
            ligacao.CarregarGeneros(ref DropDownList3);

        }

        protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            limpacampos();
            TextBox2.Visible = false;
            TextBox2.ReadOnly = true;
            TextBox2.ReadOnly = false;
            DropDownList2.Visible = true;
            ligacao.CarregarAlbuns(ref DropDownList2);
            DropDownList3.Visible = false;

        }

        protected void o_submit_Click(object sender, EventArgs e)
        {
            if(RadioButton1.Checked) 
            {
                if (ligacao.InserirBanda(TextBox1.Text.Trim(), Convert.ToInt32(TextBox2.Text.TrimStart().TrimEnd())))
                {
                    Label2.Text = "Inseriu com sucesso.";
                    ligacao.CarregarBandas(ref DropDownList2);
                }
                else
                {
                    Label2.Text = "Erro na inserção.";
                }
            }
            else if(RadioButton2.Checked)
            {
                string nome_album = TextBox1.Text.Trim();
                int num_musicas = Convert.ToInt32(TextBox2.Text.Trim());

                int id_banda = Convert.ToInt32(DropDownList2.SelectedItem.Text.Substring(0, DropDownList2.SelectedItem.Text.IndexOf('-')));
                int id_gen = Convert.ToInt32(DropDownList3.SelectedItem.Text.Substring(0, DropDownList3.SelectedItem.Text.IndexOf('-')));
                if (ligacao.InserirAlbum(nome_album, num_musicas, id_banda, id_gen))
                {
                    Label2.Text = "Inseriu com sucesso.";
                    ligacao.CarregarAlbuns(ref DropDownList2);
                }
                else
                {
                    Label2.Text = "Erro na inserção.";
                }
            }
            else 
            {
                string nome_musica = TextBox1.Text.Trim();
                int id_album = Convert.ToInt32(DropDownList2.SelectedItem.Text.Substring(0, DropDownList2.SelectedItem.Text.IndexOf('-'))); ;
               
                if (ligacao.InserirMusica(nome_musica, id_album))
                {
                    Label2.Text = "Inseriu com sucesso.";
                }
                else
                {
                    Label2.Text = "Erro na inserção.";
                }

            }
        }

        public void limpacampos()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            Label2.Text = "";
            DropDownList2.SelectedIndex = 0;
            DropDownList3.SelectedIndex = 0;
        }
    }
}