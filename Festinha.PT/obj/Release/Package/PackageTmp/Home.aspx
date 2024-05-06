<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Festinha.PT.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Festinha.PT</title>
    <link href="css/style.css" rel="stylesheet" type="text/css"/>    
</head>
<body>
    <form id="form1" runat="server">
        <div class="centerHome">
            <table class="auto-style1">
                <tr>
                    <td align="center">
                        <asp:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/image/Festinha.png" BorderStyle="None" Height="150px" Width="325px"/>
                    </td>
                    <td align="right">
                        <asp:Button class="button" ID="btnLogout" runat="server" Text="Logout" Width="100px" OnClick="btnLogout_Click" />
                    </td>
                </tr>                
                <tr align="right">
                    <td class="auto-style16">
                        Utilizador:
                    </td>
                    <td class="auto-style8" >
                        <asp:Label ID="lblUsername" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <table class="auto-style1">
               <tr>
                   <td>
                       <br />
                       Lista de opções:                       
                   </td>
               </tr>
            </table>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style11">
                        <asp:Button class="button" ID="btnBar" runat="server" Text="Bar" Width="100px" OnClick="btnBar_Click" />
                    </td>
                    <td class="auto-style10">
                        <asp:Button class="button" ID="btnBuffet" runat="server" Text="Buffet" Width="100px" OnClick="btnBuffet_Click" />
                    </td>
                    <td>
                        <asp:Button class="button" ID="btnAtividade" runat="server" Text="Serviços" Width="100px" OnClick="btnAtividade_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style9">
                        Satus proposta:
                    </td>
                    <td>
                        <asp:Label ID="lblProposta" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        Total Parcial:
                    </td>
                    <td>
                        <asp:Label ID="lblValorTotal" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <Table class="auto-style1">
                    <tr>
                        <td >
                            <asp:GridView ID="gdvProposta" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" OnPageIndexChanging="gdvProposta_PageIndexChanging" Width="451px" HorizontalAlign="Justify" GridLines="None" CellSpacing="1">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="ID" />
                                    <asp:BoundField DataField="nome" HeaderText="Nome" />
                                    <asp:BoundField DataField="descricao" HeaderText="Descricao" />
                                    <asp:BoundField DataField="quantidade" HeaderText="Quantidade" />
                                    <asp:BoundField DataField="valor_total" HeaderText="Total" />
                                </Columns>
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#594B9C" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#33276A" />
                            </asp:GridView>
                        </td>                    
                    </tr>
                </Table>
                <Table class="auto-style1">
                    <tr>
                        <td class="auto-style13">
                            <br />
                            <asp:Button class="button" ID="btnImprimir" runat="server" Text="Imprimir" Width="100px" OnClick="btnImprimir_Click" />
                        </td>
                        <td>
                            <br />
                            <asp:Button class="button" ID="btnSubmeter" runat="server" Text="Subtmeter" Width="100px" OnClick="btnSubmeter_Click" />

                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style13" colspan="2">
                            <asp:Label ID="lblEnvio" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </Table>
            </table>
        </div>
    </form>
</body>
</html>
