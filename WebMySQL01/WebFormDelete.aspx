<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormDelete.aspx.cs" Inherits="WebMySQL01.WebFormDelete" %>

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
                    <td class="auto-style2">ID</td>
                    <td>
                        <asp:DropDownList ID="ddlFormandos" runat="server" OnSelectedIndexChanged="ddlFormandos_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Nome:</td>
                    <td>
                        <asp:Label ID="lblNome" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Idade:</td>
                    <td>
                        <asp:Label ID="lblIdade" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Género:</td>
                    <td>
                        <asp:Label ID="lblGenero" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cancelar" />
                    </td>
                    <td>
                        <asp:Button ID="Button2" runat="server" Text="Apagar" Width="93px" OnClick="Button2_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
