using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebMySQL01
{
    public partial class Login : System.Web.UI.Page
    {
        DBconnect ligacao = new DBconnect();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                lblMsg.Text = "";

                if (! ( String.IsNullOrEmpty(txt_pass.Text.Trim() ) ) )
                {
                    txt_pass.Attributes["value"] = txt_pass.Text;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //2 para testar a outra validação com a encriptação
            if (ligacao.ValidateUser(txt_user.Text, txt_pass.Text))
            // if (ligacao.ValidateUser2(txt_user.Text,txt_pass.Text))
            {
                Session["username"] = txt_user.Text;

                //estamos a passar o username e a dizer com o false
               // para nao criar um cookie com esses dados
                FormsAuthentication.RedirectFromLoginPage(txt_user.Text, false);
                Response.Redirect("index.aspx");
           
            }

            else
            {
                lblMsg.Text = "Nome ou palavra passe incorrecta";
            }
        }
      

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            if(CheckBox1.Checked)
            {
                txt_pass.TextMode = TextBoxMode.SingleLine;
            }
            else
            {
                txt_pass.TextMode = TextBoxMode.Password;
            }
        }
    }
}