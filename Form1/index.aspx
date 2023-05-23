<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebMySQL01.index" %>

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
    <title>Musicas?!</title>
</head>
<body>
 <div class="container-fluid" align="center">
    <form id = "form_index" runat="server">
        <br />
        Conta o que queres fazer <br /><br />
    <asp:Button ID="btn1" runat="server" Text="Inserir algo novo" OnClick="btn1_Click" /> &nbsp
    <asp:Button ID="btn2" runat="server" Text="Consultar as listas existentes" OnClick="btn2_Click" />&nbsp
    <asp:Button ID="btn3" runat="server" Text="Apagar algo" OnClick="btn3_Click" />
       
        <div align="center">
           <br />Sugestão do momento: <br /><br />
            <asp:Label ID="sugestao" runat="server" Text="Label"></asp:Label><br /><br />
            <asp:Image ID="Image1" runat="server" Width="600px" Height="600px" />
        </div>
        <div align="center">
            <br />
            <asp:Button ID="nova_sugest" runat="server" Text="Nova sugestão" OnClick="nova_sugestao_Click"/>
        </div>

    </form>
</div>
</body>
</html>
