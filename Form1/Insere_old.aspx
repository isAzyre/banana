<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Insere_old.aspx.cs" Inherits="Form1.teste" %>

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
    </style>
    <title>Inserção!!</title>
</head>
<body>
<div align="center">

    <asp:Label ID="Label1" runat="server" Text="Inserir"></asp:Label><br/>
    
    <form id="form10" runat="server">
    <div>
        <asp:RadioButton ID="RadioButton1" Text="Banda" runat="server" GroupName="escolha" OnCheckedChanged="RadioButton1_CheckedChanged" AutoPostBack="True" />
        <asp:RadioButton ID="RadioButton2" Text="Album" runat="server" GroupName="escolha" OnCheckedChanged="RadioButton2_CheckedChanged" AutoPostBack="True"/>
        <asp:RadioButton ID="RadioButton3" Text="Musica" runat="server" GroupName="escolha" OnCheckedChanged="RadioButton3_CheckedChanged" AutoPostBack="true"/>
    </div>
        <br />
    <div>
        <asp:TextBox ID="TextBox1" runat="server" Width="275px"></asp:TextBox><br /><br />
        <asp:TextBox ID="TextBox2" runat="server" Width="175px"></asp:TextBox><br /><br />
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True"></asp:DropDownList><br /><br />  
        <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True"></asp:DropDownList><br />
    </div>
        <br />
        <br />
    <div>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br /><br />
        <asp:Button Text="Inserir" ID="o_submit" runat="server" OnClick="o_submit_Click" />
    </div>
    
    </form>

</div>
</body>
</html>
