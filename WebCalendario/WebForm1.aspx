<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebCalendario.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 58%;
        }
        .auto-style2 {
            width: 154px;
        }
        .auto-style5 {
            width: 279px;
        }
        .auto-style6 {
            width: 154px;
            margin-left: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Selecione a sua data de nascimento: 
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px" OnSelectionChanged="Calendar1_SelectionChanged">
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                <TodayDayStyle BackColor="#CCCCCC" />
            </asp:Calendar>
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Button2" runat="server" Text="Carregar Data" Width="123px" OnClick="Button2_Click" />
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Mês</td>
                    <td class="auto-style2">Dia</td>
                    <td class="auto-style2">Ano</td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        <asp:DropDownList ID="DropDownListDia" runat="server" Height="16px" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="DropDownListMes" runat="server" Height="16px" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="DropDownListAno" runat="server" Height="16px" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style5">
                        <asp:Button ID="Button3" runat="server" Text="Carregar Data" Width="187px" OnClick="Button3_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Calcular Idade" Width="174px" OnClick="Button1_Click" />
            &nbsp;<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Image ID="Image1" runat="server" />
            <br />
            <br />
            Signo:
            <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
