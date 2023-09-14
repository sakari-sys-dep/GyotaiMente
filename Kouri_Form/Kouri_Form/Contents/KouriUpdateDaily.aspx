<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KouriUpdateDaily.aspx.cs" Inherits="Kouri_Form.Contents.KouriUpdateDaily" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="../style.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center;">
            <h1>
                <asp:Label ID="lblTitle" runat="server" Text="日次更新処理　画面"></asp:Label>
            </h1>
        </div>
        <div style="align-items: center;">
            <table id="example">
                <tr>
                    <td colspan="5">
                        <asp:Literal ID="ltFileMsg" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td colspan="5" style="text-align: center;">
                        <asp:Label ID="lblYYYYMMDD" runat="server" Text="転送年月日（YYYYMMDD） "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Label ID="Label4" runat="server" Text="開始日付"></asp:Label>
                    </td>
                    <td colspan="1" style="text-align: center;">
                        <asp:Label ID="Label2" runat="server" Text="～"></asp:Label>
                    </td>
                    <td colspan="2" style="text-align: center;">
                        <asp:Label ID="Label5" runat="server" Text="終了日付"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Calendar ID="cldYYYYMMDD_From" runat="server" BackColor="White" BorderColor="Black" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="165px" NextPrevFormat="ShortMonth" Width="212px" OnDayRender="cldStartDate_DayRender" OnSelectionChanged="cldStartDate_SelectionChanged" BorderStyle="Solid" CellSpacing="1">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                            <DayStyle BackColor="#CCCCCC" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="White" Font-Bold="True" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                            <TitleStyle BackColor="#333399" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" BorderStyle="Solid" />
                            <TodayDayStyle BackColor="#999999" ForeColor="White" />
                        </asp:Calendar>
                    </td>
                    <td colspan="1">&nbsp;
                    </td>
                    <td colspan="2" style="text-align: center;">
                        <asp:Calendar ID="cldYYYYMMDD_To" runat="server" BackColor="White" BorderColor="Black" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="165px" NextPrevFormat="ShortMonth" Width="212px" OnDayRender="cldEndDate_DayRender" OnSelectionChanged="cldEndDate_SelectionChanged" BorderStyle="Solid" CellSpacing="1">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                            <DayStyle BackColor="#CCCCCC" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="White" Font-Bold="True" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                            <TitleStyle BackColor="#333399" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" BorderStyle="Solid" />
                            <TodayDayStyle BackColor="#999999" ForeColor="White" />
                        </asp:Calendar>
                    </td>
                </tr>
                <tr>
                    <td colspan="5"></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:TextBox ID="txtYYYYMMDD_From" runat="server" class="design8" placeholder="YYYYMMDD" MaxLength="8" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="lblDayWeek_From" runat="server"></asp:Label>
                    </td>
                    <td colspan="1" style="text-align: center;">
                        <asp:Label ID="Label1" runat="server" Text="～"></asp:Label>
                    </td>
                    <td colspan="2" style="text-align: center;">
                        <asp:TextBox ID="txtYYYYMMDD_To" runat="server" class="design8" placeholder="YYYYMMDD" MaxLength="8" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="lblDayWeek_To" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Button ID="btnUpdate" runat="server" Text="日 次 更 新" class="btn-square-shadow" OnClick="btnUpdate_Click" />
                    </td>
                    <td colspan="1">&nbsp;
                    </td>
                    <td colspan="2" style="text-align: center;">
                        <asp:Button ID="btnClear" runat="server" Text="クリア" class="btn-square-shadow" OnClick="btnClear_Click" />
                    </td>
                </tr>
            </table>
        </div>
        &nbsp;
        <div style="align-items: center;">
            <table id="example">
                <tr>
                    <td>
                        <asp:Literal ID="ltMsg" runat="server" Text=""></asp:Literal>
                    </td>
                </tr>
            </table>
        </div>
        <div style="text-align: right;">
            <asp:HyperLink ID="GoMenu" runat="server" NavigateUrl="~/kouriMenu.aspx">メニューに戻る</asp:HyperLink>
        </div>
    </form>
</body>
</html>
