<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KouriManualMenu.aspx.cs" Inherits="Kouri_Form.KouriManualMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" type="text/css" href="./style.css" />
    <title></title>
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
                <asp:Label ID="lblTitle" runat="server" Text="手入力小売店メニュー"></asp:Label>
            </h1>
        </div>
        <div style="align-items:center; ">
            <table id="example">
                <tr>
                    <td>
                        <asp:HyperLink ID="hlExcel" runat="server" NavigateUrl="~/Manual/KouriManual.aspx">001. 手入力小売店</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:HyperLink ID="hlSam" runat="server" NavigateUrl="~/Manual/KouriManualSAM.aspx">002. 手入力小売店（ＳＡＭ）</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Contents/KouriUpdateKM08D.aspx" >003. 月次更新処理（手入力）</asp:HyperLink>
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
