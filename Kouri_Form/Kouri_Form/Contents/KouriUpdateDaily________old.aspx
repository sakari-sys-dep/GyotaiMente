<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KouriUpdateDaily________old.aspx.cs" Inherits="Kouri_Form.Contents.KouriUpdateDaily________old" %>

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
                <asp:Label ID="lblTitle" runat="server" Text="日次更新処理　画面"></asp:Label>
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
                        <asp:Label ID="lblYYYYMMDD" runat="server" Text="転送年月日（YYYYMMDD）： "></asp:Label>
                        <asp:TextBox ID="txtYYYYMMDD" runat="server" class="design8" placeholder="YYYYMMDD" MaxLength="8"></asp:TextBox>
                        <asp:Label ID="Label1" runat="server" Text="　～　"></asp:Label>
                        <asp:TextBox ID="txtYYYYMMDD_To" runat="server" class="design8" placeholder="YYYYMMDD" MaxLength="8"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center; ">
                        <asp:Button ID="btnUpdate" runat="server" Text="日 次 更 新" class="btn-square-shadow" OnClick="btnUpdate_Click" />
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
            <asp:HyperLink ID="GoMenu" runat="server" NavigateUrl="~/kouriMenu.aspx">メニューに戻る</asp:HyperLink>
        </div>
    </form>
</body>
</html>
