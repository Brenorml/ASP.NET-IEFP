<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormMenu.aspx.cs" Inherits="WebApplicationProg13.WebFormMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            margin-right: 0px;
        }
        .auto-style2 {
            width: 204px;
        }
        .auto-style3 {
            width: 450px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Áreas</h1>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">&nbsp;<asp:Button ID="btnRectangulo" runat="server" Text="Rectângulo" Width="200px" OnClick="btnRectangulo_Click" /></td>
                    <td class="auto-style3">&nbsp;<asp:Button ID="btnQuadrado" runat="server" Text="Quadrado" Width="200px" OnClick="btnQuadrado_Click" /></td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;<asp:Button ID="btnTriangulo" runat="server" Text="Triângulo" Width="200px" OnClick="btnTriangulo_Click" /></td>
                    <td class="auto-style3">&nbsp;<asp:Button ID="btnCirculo" runat="server" Text="Círculo" Width="200px" OnClick="btnCirculo_Click" /></td>
                </tr>
            </table>
            <br />

        </div>
    </form>
</body>
</html>
