<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormUpdate.aspx.cs" Inherits="WebMySQL01.WebFormUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 149px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            Apagar Formandos<br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Formando</td>
                    <td>
                        <asp:DropDownList ID="ddlFormandos" runat="server" OnSelectedIndexChanged="ddlFormandos_SelectedIndexChanged" AutoPostBack="True" Height="20px" Width="257px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">ID</td>
                    <td>
                        <asp:TextBox ID="tbID" runat="server" Width="252px"></asp:TextBox>
                    &nbsp;<asp:Button ID="btnProcurar" runat="server" Text="Procurar" Width="137px" OnClick="btnProcurar_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Nome:</td>
                    <td>                        
                        <asp:TextBox ID="tbNome" runat="server" Width="399px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Género:</td>
                    <td>
                        <asp:RadioButton ID="rbMasculino" runat="server" GroupName="Genero" Text="Masculino" />
&nbsp;<asp:RadioButton ID="rbFeminino" runat="server" GroupName="Genero" Text="Feminino" />                        
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Idade:</td>
                    <td>
                        <asp:DropDownList ID="ddlIdade" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cancelar" />
                    </td>
                    <td>
                        <asp:Button ID="Button2" runat="server" Text="Atualizar" Width="93px" OnClick="Button2_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label></td>
                </tr>
            </table>
            <br />
            <br />
        </div>
    </form>
</body>
</html>

