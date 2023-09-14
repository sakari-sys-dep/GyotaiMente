﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KouriUpdateMonthly________old.aspx.cs" Inherits="Kouri_Form.Contents.KouriUpdateMonthly________old" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" type="text/css" href="../style.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center;">
            <h1>
                <asp:Label ID="lblTitle" runat="server" Text="月次更新処理　画面"></asp:Label>
            </h1>
        </div>
        <div style="align-items:center; ">
            <table id="example">
                <tr>
                    <td>
                        <asp:Literal ID="ltFileMsg" runat="server" Text=""></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center; ">
                        <asp:Label ID="lblYYYYMM" runat="server" Text="年月（YYYYMM）： "></asp:Label>
                        <asp:TextBox ID="txtYYYYMM" runat="server" class="design6" placeholder="YYYYMM" MaxLength="6"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
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
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center; ">
                        <asp:Button ID="btnUpdate" runat="server" Text="月次更新処理" class="btn-square-shadow" OnClick="btnUpdate_Click"  />
                    </td>
                </tr>
            </table>
        </div>
        &nbsp;
        <div style="align-items:center; ">
            <table id="example">
                <tr>
                    <td>
                        <asp:Literal ID="ltMsg" runat="server" Text=""></asp:Literal>
                    </td>
                </tr>
            </table>
        </div>
        <div style="text-align:right;">
            <asp:HyperLink ID="GoMenu" runat="server" NavigateUrl="~/KouriMenu.aspx">メニューに戻る</asp:HyperLink>
        </div>
    </form>
</body>
</html>
