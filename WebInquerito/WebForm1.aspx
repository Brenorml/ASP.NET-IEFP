<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebInquerito.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Inquérito de Teste<br />
            <br />
            Nome:
            <asp:TextBox ID="TextBox1" runat="server" Width="339px"></asp:TextBox>
            <br />
            <br />
            Distrito:<br />
            <asp:ListBox ID="ListBox1" runat="server" Height="71px" Width="76px">
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
            <asp:RadioButton ID="RadioButton1" runat="server" Text="FCP" GroupName="Clube" />
&nbsp;<asp:RadioButton ID="RadioButton2" runat="server" Text="SLB" GroupName="Clube" />
&nbsp;<asp:RadioButton ID="RadioButton3" runat="server" Text="SCP" GroupName="Clube" />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Submeter" Width="94px" Height="32px" OnClick="Button1_Click" />
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
