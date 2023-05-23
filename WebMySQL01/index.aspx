<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebMySQL01.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 47%;
        }
        .auto-style3 {
            width: 143px;
        }
        .auto-style4 {
            width: 95px;
        }
        .auto-style5 {
            height: 25px;
        }
        body{
            background-image:url(img/song.jpg)
        }
    </style>
</head>
<body>
<div align="center">
    <form id="form1" runat="server">
         <div>
           <table class="auto-style1", border="1">
                <tr>
                    <td class="auto-style4" colspan="2">
                        Musica e tal
                    </td>
                    <td align="center">
                        <asp:Button ID="logout_button" runat="server" OnClick="logOut_Click" Text="Logout" Width="50px" />
                    </td>
                </tr>
               <tr>                 
                    <td>
                        <asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label>                    
                    </td>
               </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Inserir" />
                    </td>
                    <td class="auto-style3">
                        <asp:Button ID="Button2" runat="server" Text="Atualizar" OnClick="Button2_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Apagar" />
                    </td>
                </tr>
                

                <tr>

                    <td colspan="3" class="auto-style5">
                        
                        Lista dos Formandos

                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" 
                            BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                            GridLines="Horizontal" Height="67px" Width="222px" PageSize="5" AllowPaging="True"
                            OnPageIndexChanging="GridView1_PageIndexChanging">
                       
                            <AlternatingRowStyle BackColor="#F7F7F7" />

                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="Nome" DataField="Nome" />
                            <asp:BoundField HeaderText="genero" DataField="genero" />
                            <asp:BoundField HeaderText="idade" DataField="idade" />
                        </Columns>

                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <SortedAscendingCellStyle BackColor="#F4F4FD" />
                        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                        <SortedDescendingCellStyle BackColor="#D8D8F0" />
                        <SortedDescendingHeaderStyle BackColor="#3E3277" />

                        </asp:GridView>

                        </td>
                </tr>
                </table>
        </div>
    </form>

</div>
</body>
</html>
