<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebMySQL01.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pagina de Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2> Login Page </h2>
            User :&nbsp <asp:TextBox ID="txt_user" runat="server"></asp:TextBox>
            <br />  <br />
            Password:&nbsp <asp:TextBox ID="txt_pass" runat="server" TextMode="Password"></asp:TextBox> 
            
            <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="True" />
            
            <br /><br />
            <asp:Button ID="Button1" runat="server" Text="Login" Width="72px" OnClick="Button1_Click" />
            <br /><br />
            <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
