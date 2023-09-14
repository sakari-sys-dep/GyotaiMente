<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KouriUpdateMonthly.aspx.cs" Inherits="Kouri_Form.Contents.KouriUpdateMonthly" %>

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
                <asp:Label ID="lblTitle" runat="server" Text="月次更新処理　画面"></asp:Label>
            </h1>
        </div>
        <div style="align-items: center;">
            <table id="example">
                <tr>
                    <td>
                        <asp:Literal ID="ltFileMsg" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        <asp:Label ID="lblYYYYMM" runat="server" Text="年月（YYYYMM）"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        <asp:Button ID="btnReturnYear" runat="server" Text="◀" class="btn-left-right-arrow-design" OnClick="btnNextReturnYear_Click" />
                        <asp:Label ID="lblDisYear" runat="server" Text="yyyymm" Font-Bold="True"></asp:Label>
                        <asp:Label ID="Label1" runat="server" Text="年" Font-Bold="True"></asp:Label>
                        <asp:Button ID="btnNextYear" runat="server" Text="▶" class="btn-left-right-arrow-design" OnClick="btnNextReturnYear_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        <asp:Button ID="btnJanuary" runat="server" Text="01月" class="btn-calendar-month-design" OnClick="btnMonth_Click" />
                        <asp:Button ID="btnFebruary" runat="server" Text="02月" class="btn-calendar-month-design" OnClick="btnMonth_Click" />
                        <asp:Button ID="btnMarch" runat="server" Text="03月" class="btn-calendar-month-design" OnClick="btnMonth_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        <asp:Button ID="btnApril" runat="server" Text="04月" class="btn-calendar-month-design" OnClick="btnMonth_Click" />
                        <asp:Button ID="btnMay" runat="server" Text="05月" class="btn-calendar-month-design" OnClick="btnMonth_Click" />
                        <asp:Button ID="btnJune" runat="server" Text="06月" class="btn-calendar-month-design" OnClick="btnMonth_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        <asp:Button ID="btnJuly" runat="server" Text="07月" class="btn-calendar-month-design" OnClick="btnMonth_Click" />
                        <asp:Button ID="btnAugust" runat="server" Text="08月" class="btn-calendar-month-design" OnClick="btnMonth_Click" />
                        <asp:Button ID="btnSeptember" runat="server" Text="09月" class="btn-calendar-month-design" OnClick="btnMonth_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        <asp:Button ID="btnOctober" runat="server" Text="10月" class="btn-calendar-month-design" OnClick="btnMonth_Click" />
                        <asp:Button ID="btnNovember" runat="server" Text="11月" class="btn-calendar-month-design" OnClick="btnMonth_Click" />
                        <asp:Button ID="btnDecember" runat="server" Text="12月" class="btn-calendar-month-design" OnClick="btnMonth_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        <asp:TextBox ID="txtYYYYMM" runat="server" placeholder="YYYYMM" MaxLength="6" class="design6" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMonth" AssociatedControlID="cbMonth" runat="server" Text="月間分・月次更新処理起動"></asp:Label>
                        <asp:CheckBox ID="cbMonth" runat="server" Checked="true" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDay" AssociatedControlID="cbDay" runat="server" Text="日次分・月次更新処理起動"></asp:Label>
                        <asp:CheckBox ID="cbDay" runat="server" Checked="true" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        <asp:Button ID="btnUpdate" runat="server" Text="月次更新処理" class="btn-square-shadow" OnClick="btnUpdate_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">
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
            <asp:HyperLink ID="GoMenu" runat="server" NavigateUrl="~/KouriMenu.aspx">メニューに戻る</asp:HyperLink>
        </div>
    </form>
</body>
</html>
