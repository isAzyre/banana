<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Insere.aspx.cs" Inherits="Form100.Insere_teste" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="css/bootstrap.min.css" type="text/css" />
    <link rel="icon" href="img/icon/fav_icon.png" type="text/x-component" />
    <style>
        body
        {
            background-image: url(img/background/song.jpg);
        }
        div
        {
            display:block;
           
        }
    </style>
    <title>Inserção!!</title>
</head>
<body>

<div class="container" align="center">


        <asp:Label ID="Label10" runat="server" Text="Inserir"></asp:Label><br/>
    
        <form id="form100" runat="server">
        <div>
            <asp:RadioButton ID="RadioButton10" Text="Banda" runat="server" GroupName="escolha" OnCheckedChanged="RadioButton10_CheckedChanged" AutoPostBack="True" />
            <asp:RadioButton ID="RadioButton20" Text="Album" runat="server" GroupName="escolha" OnCheckedChanged="RadioButton20_CheckedChanged" AutoPostBack="True"/>
            <asp:RadioButton ID="RadioButton30" Text="Musica" runat="server" GroupName="escolha" OnCheckedChanged="RadioButton30_CheckedChanged" AutoPostBack="true"/>
        </div>
            <br />
        <div>
            <asp:Label Text="text" runat="server" id="lbl1"/><br />
            <asp:TextBox ID="TextBox10" runat="server" Width="275px"></asp:TextBox><br /><br />
       
            <asp:Label Text="text" runat="server" id="lbl2"/><br />
            <asp:TextBox ID="TextBox20" runat="server" Width="175px"></asp:TextBox><br /><br />
        
            <asp:Label Text="text" runat="server" id="lbl3"/><br />
            <asp:DropDownList ID="DropDownList20" runat="server" AutoPostBack="True"></asp:DropDownList><br /><br />  
        
            <asp:Label Text="text" runat="server" id="lbl4"/><br />
            <asp:DropDownList ID="DropDownList30" runat="server" AutoPostBack="True"></asp:DropDownList><br />
        </div>
            <br />
            <br />
        <div>
            <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>
            <br /><br />
            <asp:Button Text="Inserir" ID="o_submit" runat="server" OnClick="o_submit_Click1" />
        </div>
            <br /><br />
        <div align="center">
            <asp:GridView ID="GridView50" runat="server" AllowPaging="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnPageIndexChanging="GridView50_PageIndexChanging" PageSize="6">
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </div>
    </form>

</div>
</body>
</html>
