<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebSalarios.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>Cálculo de Salário</p>
            <asp:Label ID="Label1" runat="server" Text="Salário Bruto"></asp:Label>
            &nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="155px"></asp:TextBox>
            &nbsp;<asp:Button ID="Button1" runat="server" Text="Calcular" Width="106px" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Segurança Social"></asp:Label>            
            &nbsp;<asp:TextBox ID="TextBox2" runat="server" Width="155px"></asp:TextBox>
            <p>IRS <asp:Label ID="Label5" runat="server" Text=""></asp:Label>% Valor IRS <asp:Label ID="Label6" runat="server" Text=""></asp:Label></p>
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Salário Líquido"></asp:Label>
            &nbsp;<asp:TextBox ID="TextBox3" runat="server" Width="155px"></asp:TextBox>
        </div>
    </form>
</body>
</html>
