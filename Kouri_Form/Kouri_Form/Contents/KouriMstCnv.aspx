<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KouriMstCnv.aspx.cs" Inherits="Kouri_Form.Contents.KouriMstCnv" %>

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
                <asp:Label ID="lblTitle" runat="server" Text="ＣＶＴマスタ更新処理　画面"></asp:Label>
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
                        <asp:TextBox ID="txtFilePath" runat="server" Visible="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        <asp:Button ID="btnUpdate" runat="server" Text="取 込 処 理" class="btn-square-shadow" OnClick="btnUpdate_Click" />
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
