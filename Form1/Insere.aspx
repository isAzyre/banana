<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Insere.aspx.cs" Inherits="Form1.Insere" %>

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
<div align="center" border="1">
    <form id="form1" runat="server" action="insere.aspx">
        
        <asp:Button ID="goBack" runat="server" Text="Index" OnClick="goBack_Click" />
        <br /><br />
           
        <div>
            Inserir Banda <br />
            Nome:<br /> <asp:TextBox ID="txt_nomebanda" runat="server"></asp:TextBox> <br />
            Numero de membros na banda:<br /> <asp:TextBox ID="txt_nummembros" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Button ID="submit_banda" runat="server" Text="Submeter" OnClick="submit_banda_Click" />
        </div>
        <br /><br />
        <div>
            Inserir Album<br />
            Nome do album:<br /> <asp:TextBox ID="txt_nome_album" runat="server"></asp:TextBox> <br />
            Numero de musicas:<br /> <asp:TextBox ID="txt_numr_musicas" runat="server"></asp:TextBox>  <br />
            Nome da banda: <br /> <asp:DropDownList ID="ddl_bandas" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_bandas_SelectedIndexChanged"></asp:DropDownList><br /> 
            Genero de musica: <br /> <asp:DropDownList ID="ddl_genero" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_genero_SelectedIndexChanged"></asp:DropDownList>
            
            <br /><br />
            <asp:Button ID="submit_album" runat="server" Text="Submeter" OnClick="submit_album_Click" />
        </div>
        <br /><br /> 
        <div>   
            Inserir Musica<br />
            Nome:<br /> <asp:TextBox ID="txt_nomemusica" runat="server"></asp:TextBox> <br />
            Nome do album:<br /> <asp:DropDownList ID="ddl_albuns" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_albuns_SelectedIndexChanged"></asp:DropDownList>
            <br /><br />
            <asp:Button ID="submit_musica" runat="server" Text="Submeter" OnClick="submit_musica_Click" />
     </div> 
        <br />
        <asp:Label ID="lblSucesso" runat="server"></asp:Label>
    </form>
</div>
</body>
</html>
