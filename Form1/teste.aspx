<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teste.aspx.cs" Inherits="Form1.teste" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<div align="center">

    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br/>
     
   
    
    <form id="form10" runat="server">

         <div>
            <table class="auto-style1", border="1">
                <tr>
                    <td class="auto-style4" colspan="2" >
                        Musica e tal
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="aleatorio" runat="server" Text="Hello"></asp:Label>
                    </td>
                </tr>
            </table>
             <br />
              <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL1_Index_Change"></asp:DropDownList>  
        </div>

    </form>

</div>
</body>
</html>
