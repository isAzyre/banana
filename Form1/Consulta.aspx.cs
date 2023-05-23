using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebMySQL01;

namespace Form1
{
    public partial class Consulta : System.Web.UI.Page
    {
        DBconnect ligacao = new DBconnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ligacao.Bind(ref GridView1);
                ligacao.Bind2(ref GridView2);
                ligacao.Bind3(ref GridView3);
                GridView1.DataBind();
                GridView2.DataBind();
                GridView3.DataBind();
              
            }

        }
        protected void goBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void GridView1_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ligacao.Bind(ref GridView1);
            GridView1.DataBind();
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            ligacao.Bind2(ref GridView2);
            GridView2.DataBind();
        }
        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView3.PageIndex = e.NewPageIndex;
            ligacao.Bind3(ref GridView3);
            GridView3.DataBind();
        }
    }
}