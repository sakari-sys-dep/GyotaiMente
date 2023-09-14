<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KouriManual.aspx.cs" Inherits="Kouri_Form.Manual.KouriManual" %>

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
                <asp:Label ID="lblTitle" runat="server" Text="手入力小売店"></asp:Label>
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
                        <asp:Button ID="btnTorikomi" runat="server" Text="取 込 処 理 開 始" class="btn-square-shadow" OnClick="btnTorikomi_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center; ">
                        <asp:Button ID="btnUpdate" runat="server" Text="更 新 処 理 開 始" class="btn-square-shadow" OnClick="btnUpdate_Click" />
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
            <asp:HyperLink ID="GoMenu" runat="server" NavigateUrl="~/KouriManualMenu.aspx">メニューに戻る</asp:HyperLink>
        </div>
    </form>
</body>
</html>
