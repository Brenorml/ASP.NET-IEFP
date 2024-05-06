﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebRectangulo.aspx.cs" Inherits="WebApplicationProg13.WebRectangulo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Área do Rectângulo</h1>
            <br />
            <br />
            Largura&nbsp;
            <asp:TextBox ID="txtLargura" runat="server"></asp:TextBox>
            <br />
            <br />
            Comprimento&nbsp;
            <asp:TextBox ID="txtComprimento" runat="server"></asp:TextBox>
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
