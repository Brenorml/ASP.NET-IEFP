<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormServicos.aspx.cs" Inherits="Festinha.PT.WebFormServicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Serviços de Eventos</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />    
</head>
<body>
    <form id="form1" runat="server">
        <div class="center">
        <table class="auto-style1">
            <tr>
                <td class="titles">
                    <h2>Serviços</h2>
                    <h2>para</h2>
                    <h2>Eventos</h2>
                </td>
                <td align="center">
                    <asp:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/image/Festinha.png" BorderStyle="None" Height="150px" Width="325px"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style15">Lista de Serviços:</td>
                <td class="auto-style15">
                    <asp:RadioButtonList ID="rdbServicos" runat="server" OnSelectedIndexChanged="rdbServicos_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Value="casamento">Casamentos</asp:ListItem>
                        <asp:ListItem Value="festas">Festas</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="auto-style15">Lista de opções:</td>
                <td>
                    <asp:DropDownList ID="ddlServico" runat="server" Height="22px" Width="347px"  OnSelectedIndexChanged="ddlServico_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>                
                <td class="auto-style15"><br />Descrição:</td>
                <td>
                    <br />
                    <asp:Label ID="lblDescServico" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style15">valor unitário:</td>
                <td>
                    <asp:Label ID="lblValorUnitario" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style15">
                    <br />
                    Quantidade:
                </td>
                <td>
                    <br />
                    <asp:TextBox ID="txtQuantidade" runat="server" OnTextChanged="txtQuantidade_TextChanged" AutoPostBack="True"></asp:TextBox> &nbsp;<asp:DropDownList ID="ddlQuantidade" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlQuantidade_SelectedIndexChanged">
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
                        <asp:GridView ID="gdvServico" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" Width="484px" AllowPaging="True" OnPageIndexChanging="gdvServico_PageIndexChanging" GridLines="None">
                            <Columns>
                                <asp:BoundField DataField="descricao" HeaderText="Descricao" />
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
                    <asp:Button class="button" ID="btnCancelar" runat="server" Text="Voltar" OnClick="btnCancelar_Click" />
                </td>
                <td class="auto-style15" align="right">
                    <asp:Button class="button" ID="btnAdicionar" runat="server" Height="26px" Text="Adicionar" OnClick="btnAdicionar_Click"/>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Status:  <asp:Label ID="lblStatus" runat="server"></asp:Label>
                </td>                
            </tr>
            <tr>
                <td colspan="2">
                         Total Bebidas:  <asp:Label ID="lblTotalGeral" runat="server" Text=""></asp:Label>
                </td>                
            </tr>
        </table>
      </div>
    </form>
</body>
</html>
