using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebMySQL01
{
    public partial class WebFormActualizar : System.Web.UI.Page
    {

        DBconnect ligacao = new DBconnect();
        static string id = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Enabled = false;
            DropDownList1.Enabled = false;

            if(!this.IsPostBack)
            {
                carregarIdades();
                DropDownList1.SelectedIndex = 17;
                ligacao.CarregarBanda(ref ddlFormandos);
            }

        }

        void carregarIdades()
        {
            for (int i = 1; i <=150; i++)
            {
                DropDownList1.Items.Add(i.ToString());
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            char genero = 'M';

            if (verificarCampos())
            {
                if (RadioButton2.Checked)
                {
                    genero = 'F';
                }
                if (ligacao.Update(id, TextBox1.Text, genero, DropDownList1.SelectedItem.Text))
                {
                    Response.Redirect("index.aspx?r=Actualizou com sucesso!");
                    //lblMsg.Text = "Actualizou com sucesso!";
                }
                else
                {
                    lblMsg.Text = "ERRO na inserção!";
                }
            }
        }

        bool verificarCampos()
        {
            TextBox1.Text = TextBox1.Text.Trim();
            TextBox1.Text = Regex.Replace(TextBox1.Text, @"\s+", " ");

            if (TextBox1.Text.Length ==0)
            {
                lblMsg.Text = "Erro no campo Nome!";
                TextBox1.Focus();
                return false;
            }

            if (RadioButton1.Checked == false && RadioButton2.Checked == false)
            {
                lblMsg.Text = "Erro no campo Género!";
                return false;
            }

            return true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void ddlFormandos_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            string nome_aux = "";
            char genero = ' ';
            int idade = 0;
            id = ddlFormandos.SelectedItem.Text;

            if (id.Length > 0)
            {
                // 0 - inicio do string, IndexOf(o que quisermos encontrar) 
                id = id.Substring(0, id.IndexOf(' '));

                TextBox1.Enabled = true;
                DropDownList1.Enabled = true;

                if (ligacao.DevolverFormando(id, ref nome_aux, ref genero, ref idade))
                {
                    txtID.Text = id;
                    TextBox1.Text = nome_aux;

                    if (genero == ('F'))
                    {
                        RadioButton2.Checked = true;
                        RadioButton1.Checked = false;
                    }
                    else
                    {
                        RadioButton1.Checked = true;
                        RadioButton2.Checked = false;
                    }

                    DropDownList1.ClearSelection();
                    if (idade > 0)
                    {
                        DropDownList1.Items.FindByValue(idade.ToString()).Selected = true;
                    }

                    lblMsg.Text = "";
                }
                
                if(nome_aux.Length == 0)
                {
                    id = "";
                    lblMsg.Text = "ID invalido!";
                    DesactivarControlos();
                }

            }
            else 
            {
                DesactivarControlos();
            }
        }

        void DesactivarControlos()
        {
            TextBox1.Text = "";
            RadioButton1.Checked = false;
            RadioButton2.Checked = false;
            DropDownList1.ClearSelection();
            TextBox1.Enabled = false;
            DropDownList1.Enabled = false;

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            id=txtID.Text;
            BuscarFormando();
        }

        void BuscarFormando()
        {

            string nome_aux = "";
            char genero = ' ';
            int idade = 0;

            if (id.Length > 0)
            {
                // 0 - inicio do string, IndexOf(o que quisermos encontrar) 
             
                TextBox1.Enabled = true;
                DropDownList1.Enabled = true;

                if (ligacao.DevolverFormando(id, ref nome_aux, ref genero, ref idade))
                {
                    txtID.Text = id;
                    TextBox1.Text = nome_aux;

                    if (genero == ('F'))
                    {
                        RadioButton2.Checked = true;
                        RadioButton1.Checked = false;
                    }
                    else
                    {
                        RadioButton1.Checked = true;
                        RadioButton2.Checked = false;
                    }

                    DropDownList1.ClearSelection();
                    if (idade > 0)
                    {
                        DropDownList1.Items.FindByValue(idade.ToString()).Selected = true;
                    }

                    lblMsg.Text = "";
                }

                if (nome_aux.Length == 0)
                {
                    id = "";
                    lblMsg.Text = "ID invalido!";
                    DesactivarControlos();
                }

            }
            else
            {
                DesactivarControlos();
            }
        }
    }
}