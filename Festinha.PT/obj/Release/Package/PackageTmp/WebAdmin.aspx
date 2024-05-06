<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebAdmin.aspx.cs" Inherits="Festinha.PT.WebAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administração</title>
    <link href="css/style.css" rel="stylesheet" type="text/css"/>     
</head>
<body>
    <form id="form1" runat="server">
        <div class="centerAdmin">
            <div>                
                <table class="auto-style1">
                    <tr>
                        <td class="titles">Administração</td>
                        <td align="center">
                            <asp:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/image/Festinha.png" BorderStyle="None" Height="150px" Width="325px"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Utilizador:
                        </td>
                        <td class="auto-style14" ">
                            <div style="float: left; margin-top: 10px"><asp:Label ID="lblLogin" runat="server" Text=""></asp:Label></div>                            
                            <div style="float: right"><asp:Button Class="button" ID="Logout" runat="server" Text="Logout" OnClick="Logout_Click" /></div>
                        </td>
                    </tr>
                    <tr>
                        <td>Tipos de Serviços:
                        </td>
                        <td class="auto-style3">
                            <asp:RadioButtonList ID="rdbTipos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdbTipos_SelectedIndexChanged">
                                <asp:ListItem Value="bar">Bar</asp:ListItem>
                                <asp:ListItem Value="buffet">Buffet</asp:ListItem>
                                <asp:ListItem Value="atividades">Atividades</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Lista de Tabelas:</td>
                        <td class="auto-style3">
                            <asp:DropDownList ID="ddlTabelas" runat="server" AutoPostBack="True" Height="20px" Width="257px" OnSelectedIndexChanged="ddlTabelas_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Lista de Itens:
                        </td>
                        <td class="auto-style3">

                            <asp:DropDownList ID="ddlItens" runat="server" AutoPostBack="True" Height="20px" Width="257px" OnSelectedIndexChanged="ddlItens_SelectedIndexChanged">
                            </asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">ID</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="txtID" runat="server" Width="252px"></asp:TextBox>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Descrição:</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="txtDescricao" runat="server" Width="399px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Embalagem:</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="txtEmbalagem" runat="server" Width="399px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Preço Unitário:</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="txtValor" runat="server" Width="399px"></asp:TextBox>
                        </td>
                    </tr>
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style22" >
                                <asp:Button class="button" ID="btnCancelar" runat="server" Text="Cancelar" Width="93px" OnClick="btnCancelar_Click" />
                            </td>
                            <td class="auto-style22">
                                <asp:Button class="button" ID="btnDeletar" runat="server" Text="Deletar" Width="93px" OnClick="btnDeletar_Click" />
                            </td>
                            <td class="auto-style22">
                                <asp:Button class="button" ID="btnAtualizar" runat="server" Text="Atualizar" Width="93px" OnClick="btnAtualizar_Click" />
                            </td>
                            <td>
                                <asp:Button class="button" ID="btnGuardar" runat="server" Text="Guardar" Width="93px" OnClick="btnGuardar_Click" />
                            </td>
                        </tr>
                    </table>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
                <table  class="auto-style1">
                    <tr>
                        <td  class="auto-style2">
                            <asp:Label ID="lblPropostas" runat="server" Text="Lista de Propostas:"></asp:Label>
                        </td>
                        <td  class="auto-style3">                            
                            <asp:DropDownList ID="ddlPropostas" runat="server" AutoPostBack="True" Height="20px" Width="257px" OnSelectedIndexChanged="ddlPropostas_SelectedIndexChanged">
                            </asp:DropDownList>                        
                        </td>
                        <tr>
                            <td>
                                <asp:Label ID="lblSubmetidas" runat="server" Text="Propostas submetidas:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                            <asp:GridView ID="gdvProposta" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" Width="451px" HorizontalAlign="Justify" GridLines="None" OnPageIndexChanging="gdvProposta_PageIndexChanging">
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
                        <tr>
                            <td>
                                <asp:Button class="button" ID="btnAprovar" runat="server" Text="Aprovar" Width="93px" OnClick="btnAprovar_Click" />
                            </td>
                        </tr>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
