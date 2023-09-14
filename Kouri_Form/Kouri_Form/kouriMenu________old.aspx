<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kouriMenu________old.aspx.cs" Inherits="Kouri_Form.kouriMenu________old" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" type="text/css" href="./style.css" />
    <title>小売店チェックメニュー</title>
    <style type="text/css">
        .auto-style1 {
            height: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center;">
            <h1>
                <asp:Label ID="lblTitle" runat="server" Text="販売実績処理メニュー"></asp:Label>
            </h1>
        </div>
        <div style="align-items:center; ">
            <table id="example" >
                <tr>
                    <td valign="top" class="auto-style1">
                        <asp:Panel ID="pnlMenu1" runat="server" style="vertical-align:top;">
                        </asp:Panel>
                    </td>
                    <td class="auto-style1">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td class="auto-style1">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td valign="top" class="auto-style1">
                        <asp:Panel ID="pnlMenu2" runat="server" style="vertical-align:top;">
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
        <div style="text-align:right;">
            <asp:HyperLink ID="GoMenu" runat="server" NavigateUrl="~/kouriMenu.aspx?next=1">メニューに戻る</asp:HyperLink>
        </div>
    </form>
</body>
</html>
