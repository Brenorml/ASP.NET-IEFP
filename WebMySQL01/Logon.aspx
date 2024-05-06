<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="WebMySQL01.Logon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .fonte-arial{
            font-family: Arial Black, sans-serif;
            text-align: left;
        }
        .auto-style1 {
            width: 26%;
        }
        .auto-style3 {
            width: 268435408px;
        }
        .auto-style4 {
            margin-left: 47px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">        
        <div>
            <table class="auto-style1">                
                <h2 class ="fonte-arial">Logon Page</h2>
                <tr>
                    <td colspan="2" class="auto-style3">Email:</td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" Width="159px" CssClass="auto-style4"></asp:TextBox>
                    </td>                        
                </tr>
                <tr>
                    <td colspan="2" class="auto-style3">Password:</td>
                    <td>
                    <asp:TextBox ID="txtUserPass" runat="server" Width="159px" CssClass="auto-style4" TextMode="Password" OnTextChanged="CheckBox1_CheckedChanged"></asp:TextBox>
                    </td> 
                    <td>
                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <br />
                        <asp:Button ID="btnLogon" runat="server" Text="Logon" Width="113px" OnClick="btnLogon_Click" />
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
