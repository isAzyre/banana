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
                ligacao.CarregarBandas(ref DropDownList1);
            }
        }
        protected void DDL1_Index_Change(object sender, EventArgs e)
        {
            Label1.Text = DropDownList1.SelectedItem.Text.Substring(0, DropDownList1.SelectedItem.Text.IndexOf('-'));
        }

    }
}