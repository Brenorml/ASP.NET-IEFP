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
            width: 114px;
        }
        .auto-style4 {
            width: 100px;
        }
        .auto-style5 {
            width: 216px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>            
            <table class="auto-style1">
                <tr>
                    <td cosplan="2" class="auto-style4">
                        <h3 class="auto-style5">Gestão de Formandos</h3>
                    </td>
                    <td>
                        <asp:Button ID="btnLogout" runat="server" Text="Logout" Width="99px" OnClick="btnLogout_Click" />
                    </td>
                </tr>
                <tr>
                    <td cosplan="1">
                        <asp:Label ID="lblUser" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <table class="auto-style1">                
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
                    <td colspan="3">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">Nº de Formandos:</td>
                    <td>
                        <asp:Label ID="lblNFormandos" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">Idade Média:</td>
                    <td>
                        <asp:Label ID="lblMedia" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3"></td>
                </tr>
                <tr>
                    <td colspan="3">Lista dos Formandos</td>
                </tr> 
                <tr>
                    <td colspan="3">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="8">
                            <AlternatingRowStyle BackColor="PaleGoldenrod" />
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" />
                                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                                <asp:BoundField DataField="Genero" HeaderText="Gênero" />
                                <asp:BoundField DataField="Idade" HeaderText="Idade" />
                            </Columns>
                            <FooterStyle BackColor="Tan" />
                            <HeaderStyle BackColor="Tan" Font-Bold="True" />
                            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                            <SortedAscendingCellStyle BackColor="#FAFAE7" />
                            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                            <SortedDescendingCellStyle BackColor="#E1DB9C" />
                            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
