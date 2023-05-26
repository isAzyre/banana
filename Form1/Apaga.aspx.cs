using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebMySQL01;

namespace Form1
{
    public partial class Apaga : System.Web.UI.Page
    {
        DBconnect ligacao = new DBconnect();
        string nome_id = "", tabela = "";
        int num_id = 0; 

        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
        }
        public void RadioButton1_CheckedChange(object sender, EventArgs e)
        {
            ligacao.CarregarBandas(ref dropdown_apagar);
        }
        public void RadioButton2_CheckedChange(object sender, EventArgs e)
        {
            ligacao.CarregarAlbuns(ref dropdown_apagar);
        }
        public void RadioButton3_CheckedChange(object sender, EventArgs e)
        {
            ligacao.CarregarMusicas(ref dropdown_apagar);
        }

        protected void goBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void btn_apagar_Click(object sender, EventArgs e)
        {
            btn_Yes.Visible = true;
            btn_No.Visible = true;
            Label1.ForeColor = Color.Red;
            Label1.Text = "Tem a certeza? <br />Ao eliminar um artista pode eliminar os albuns agregados<br />E ao eliminar um album elimina as musicas do album";
        }


        protected void btn_Yes_Click(object sender, EventArgs e)
        {
            try
            {
                num_id = Convert.ToInt32(dropdown_apagar.Text.Substring(0, dropdown_apagar.Text.IndexOf('-')));

                if (RadioButton1.Checked == true)
                {
                    tabela = "bandas";
                    nome_id = "id_banda";
                }
                else if (RadioButton2.Checked == true)
                {
                    tabela = "albuns";
                    nome_id = "id_albuns";
                }
                else if (RadioButton3.Checked == true)
                {
                    tabela = "musicas";
                    nome_id = "id_musicas";
                }

                if (ligacao.ApagarDados(tabela, nome_id, num_id))
                {
                    btn_Yes.Visible = false;
                    btn_No.Visible = false;
                    Label1.ForeColor = Color.Green;
                    Label1.Text = "Apagou com sucesso";
                }
                else
                {
                    Label1.ForeColor = Color.Red;
                    Label1.Text = "Erro";
                }

            }
            catch
            {
                Label1.Text = "Escolha uma opção";
            }
        }
      
        protected void btn_No_Click(object sender, EventArgs e)
        {
            Label1.Text = "Operação cancelada";
            btn_Yes.Visible = false;
            btn_No.Visible = false;
        }
    }
}