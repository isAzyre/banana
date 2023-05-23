using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace WebMySQL01
{
    public partial class index : System.Web.UI.Page
    {
        DBconnect ligacao = new DBconnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
            string a_sugestao = ligacao.Aleatorio();
            sugestao.Text= a_sugestao;
            Image1.ImageUrl = "~/img/"+ a_sugestao +".jpg";
            }
        }
        protected void nova_sugestao_Click(object sender, EventArgs e)
        {
            string a_sugestao = ligacao.Aleatorio();
            sugestao.Text = a_sugestao;
            Image1.ImageUrl = "~/img/" + a_sugestao + ".jpg";
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Insere.aspx");
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Consulta.aspx");
        }

        protected void btn3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Apaga.aspx");
        }
    }
}