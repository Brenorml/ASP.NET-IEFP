<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebCirculo.aspx.cs" Inherits="WebApplicationProg13.WebCirculo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <h1>Área do Círculo</h1>
            <br />            
            Raio&nbsp;
            <asp:TextBox ID="txtRaio" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnCalcular" runat="server" Text="Calcular" Height="36px" Width="84px" OnClick="btnCalcular_Click" />
            &nbsp;
            <asp:Label ID="lblResultado" runat="server"></asp:Label>
            <br />
            <br />
            <asp:LinkButton ID="lbtnVoltar" runat="server" OnClick="lbtnVoltar_Click">Voltar</asp:LinkButton>
        </div>   
    </form>
</body>
</html>
