<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormInsert.aspx.cs" Inherits="WebMySQL01.WebFormInsert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 122px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            Inserir Formando<br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Nome</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Width="386px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Género</td>
                    <td>
                        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="Genero" Text="Masculino" />
&nbsp;<asp:RadioButton ID="RadioButton2" runat="server" GroupName="Genero" Text="Feminino" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Idade</td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cancelar" />
                    </td>
                    <td>
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Gravar" Width="95px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
