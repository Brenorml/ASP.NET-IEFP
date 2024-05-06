<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Buffet.aspx.cs" Inherits="Festinha.PT.Buffet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">      
    <title>Serviços de Catering</title>
    <link href="css/style.css" rel="stylesheet" type="text/css"/> 
</head>
<body>
    <form id="form1" runat="server">
        <div class="center">                 
            <table class="auto-style1">
                <tr>
                    <td class="titles">
                        <h2>Serviços</h2>
                        <h2>de</h2>
                        <h2>Catering</h2>
                    </td>
                    <td align="center">
                        <asp:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/image/Festinha.png" BorderStyle="None" Height="150px" Width="325px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15">Faça a sua mesa: </td>
                    <td>
                        <asp:RadioButtonList ID="rblBuffet" runat="server"  OnSelectedIndexChanged="rblBuffet_SelectedIndexChanged1" AutoPostBack="True">
                            <asp:ListItem Value="salgados">Salgados/Bolos</asp:ListItem>
                            <asp:ListItem Value="carnes">Carnes</asp:ListItem>
                            <asp:ListItem Value="peixe">Peixe</asp:ListItem>
                            <asp:ListItem Value="vegetariano">Vegetariano</asp:ListItem>
                            <asp:ListItem Value="sobremesas">Sobremesas</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15">Lista de opções:</td>
                    <td>
                        <asp:DropDownList ID="ddlOpcoes" runat="server" Height="22px" Width="347px" OnSelectedIndexChanged="ddlOpcoes_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15">
                        <br />
                        Descrição:

                    </td>
                    <td>
                        <br />
                        <asp:Label ID="lblDescricao" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15">Valor unitário:</td>
                    <td>
                        <asp:Label ID="lblPreco" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15">
                        <br />
                        Quantidade:
                    </td>
                    <td>
                        <br />
                        <asp:TextBox ID="txtQuantidade" runat="server" OnTextChanged="txtQuantidade_TextChanged" AutoPostBack="True"></asp:TextBox>
                        &nbsp;<asp:DropDownList ID="ddlQuantidadeBft" runat="server" OnSelectedIndexChanged="ddlQuantidadeBft_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15">
                        <br />
                        Valor total:
                    </td>
                    <td>
                        <br />
                        <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <table class="auto-style14">
                <tr>
                    <td colspan="1" align="center">
                        <br />
                        <asp:GridView ID="dgvBuffet" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="484px" OnPageIndexChanging="dgvBuffet_PageIndexChanging" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
                            <Columns>
                                <asp:BoundField DataField="descricao" HeaderText="Descrição" />
                                <asp:BoundField DataField="quantidade" HeaderText="Quantidade" />
                                <asp:BoundField DataField="valor_unitario" HeaderText="Valor Unitário" />
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
            </table>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style15">
                        <asp:Button class="button" ID="btnCancelar" runat="server" Text="Voltar" Width="100px" OnClick="btnCancelar_Click" />
                    </td>
                    <td class="auto-style15" align="right">
                        <asp:Button class="button" ID="btnAdicionar" runat="server" Text="Adicionar" Width="100px" OnClick="btnAdicionar_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">Status: 
                        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">Total Catering: 
                        <asp:Label ID="lblTotalCatering" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div> 
    </form>
</body>

</html>
