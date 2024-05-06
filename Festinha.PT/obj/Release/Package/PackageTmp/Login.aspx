<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Festinha.PT.Logon" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">    
    <title>Login</title>
    <link href="css/style.css" rel="stylesheet" type="text/css"/>      
    <style type="text/css">
        .auto-style23 {
            position: absolute;
            left: 50%;
            transform: translate(-50%, -50%);
            border-radius: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="image">
            <asp:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/image/Festinha.png" BorderStyle="None" Height="400px" Width="800px"/>
        </div>
        <div class="centerLogin">
            <table class="auto-style1">
                <tr>
                    <td class="titles" colspan="3">
                        <h2 colspan="2" style="padding-top: 20px">Login Page</h2>
                    </td>                    
                </tr>                
                <tr>                    
                    <td colspan="2">Email:</td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" Width="159px" CssClass="auto-style4"></asp:TextBox>
                    </td>                        
                </tr>
                <tr>
                    <td colspan="2">Password:</td>
                    <td>
                    <asp:TextBox ID="txtUserPass" runat="server" Width="159px" CssClass="auto-style4" TextMode="Password" OnTextChanged="CbMostrar_CheckedChanged"></asp:TextBox>&nbsp;<asp:CheckBox ID="cbMostrar" runat="server" AutoPostBack="True" OnCheckedChanged="CbMostrar_CheckedChanged" Text="Mostrar" />
                    </td>                  
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <br />
                        <asp:Button class="button" ID="btnLogon" runat="server" Text="Logon" Width="113px" OnClick="btnLogon_Click" />
                        <br />
                        <br />
                        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                    </td>           
                </tr>                
            </table>
        </div>
    </form>
</body>
</html>
