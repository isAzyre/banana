<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Apaga.aspx.cs" Inherits="Form1.Apaga" %>

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
    <title>Apagar?!</title>
</head>
<body>

<div class="container-fluid" align="center">
 <form id="form1" runat="server">
    
     <asp:Button ID="goBack" runat="server" Text="Index" OnClick="goBack_Click" />
    
     <h2>Apagar</h2><br />
    
     <asp:RadioButton ID="RadioButton1" runat="server" Text="Bandas" OnCheckedChanged="RadioButton1_CheckedChange" AutoPostBack="True" GroupName="Escolha"/>
     <asp:RadioButton ID="RadioButton2" runat="server" Text="Albuns" OnCheckedChanged="RadioButton2_CheckedChange" AutoPostBack="True" GroupName="Escolha" />
     <asp:RadioButton ID="RadioButton3" runat="server" Text="Musicas" OnCheckedChanged="RadioButton3_CheckedChange" AutoPostBack="True" GroupName="Escolha" />
     <br /><br />
     <asp:DropDownList ID="dropdown_apagar" runat="server" AutoPostBack="True"></asp:DropDownList>
     <br /><br />
     <asp:Button ID="btn_apagar" runat="server" Text="Apagar" OnClick="btn_apagar_Click" /><br /><br />
     <asp:Button ID="btn_Yes" Text="Yes" runat="server" Visible="false" OnClick="btn_Yes_Click" /> &nbsp&nbsp
     <asp:Button ID="btn_No" Text="No" runat="server" Visible="false" OnClick="btn_No_Click" /><br />
     <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> <br /><br />
 </form>
</div>

</body>
</html>
