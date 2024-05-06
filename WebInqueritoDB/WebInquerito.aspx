<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebInquerito.aspx.cs" Inherits="WebInquerito.WebInquerito" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inquérito</title>
    <link href="css/folhaestilo.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Inquérito de teste</h1>
            <br />
            Nome:
            <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            <br />
            <br />
            Distrito<br />
            <asp:ListBox ID="lstCidades" runat="server" Rows="1">
                <asp:ListItem Value="Sem Cidade">---</asp:ListItem>
                <asp:ListItem>Lisboa</asp:ListItem>
                <asp:ListItem>Porto</asp:ListItem>
                <asp:ListItem>Faro</asp:ListItem>
            </asp:ListBox>
            <br />
            <br />
            Pratos Favoritos:<br />
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Pizza" />
&nbsp;<asp:CheckBox ID="CheckBox2" runat="server" Text="Bife" />
&nbsp;<asp:CheckBox ID="CheckBox3" runat="server" Text="Refogado" />
            <br />
            <br />
            Clube:<br />
            <asp:RadioButton ID="RadioButton1" runat="server" GroupName="Clube" Text="FCP" />
&nbsp;<asp:RadioButton ID="RadioButton2" runat="server" GroupName="Clube" Text="SLB" />
&nbsp;<asp:RadioButton ID="RadioButton3" runat="server" GroupName="Clube" Text="SCP" />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Submeter" CssClass="button" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
