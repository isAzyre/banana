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
            float media = ligacao.Media();
            
            lblNFormandos.Text = ligacao.Count().ToString();
            lblMedia.Text = string.Format("{0:0}", media);

            //ou em vez do format para as casas decimais
            //poderiamos fazer ligacao.Media().ToString("0.00")

            if (!Page.IsPostBack)
            {
                lblUser.Text = (string)Session["username"];
                lblMsg.Text = Request.QueryString["r"];
                ligacao.Bind(ref GridView1);
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormInsert.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormActualizar.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormDelete.aspx");
        }
        protected void logOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void GridView1_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        { 
            GridView1.PageIndex = e.NewPageIndex;
            ligacao.Bind(ref GridView1);
            GridView1.DataBind();
        }

    }
}