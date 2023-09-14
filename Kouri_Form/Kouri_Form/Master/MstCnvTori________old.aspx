<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MstCnvTori________old.aspx.cs" Inherits="Kouri_Form.Master.MstCnvTori________old" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<script language="javascript" type="text/javascript">
function num_only(str) {
    var wnum = str.value;
    //alert(wnum);
    // 数値以外の入力消去
    document.getElementById("txtTorCd").value = wnum.replace(/[^\d-.]/g, '');
    //return (str);
    return false;
}
function nextfocus(n) {
    if (event.keyCode == 13) {
        for (var i = 0, f = n.form.elements; i < f.length; i++) {
            if (f[i] == n) {
                //alert(f[i]);
                (f[i + 1] || f[0]).focus();
                break;
            }
        }
        event.returnValue = false;
    }
}

</script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" type="text/css" href="../MstStyle.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center;">
            <h1>
                <asp:Label ID="lblTitle" runat="server" Text="＊＊　取引先　ＣＶＴ　マスタ　登録　＊＊"></asp:Label>
            </h1>
        </div>

        <div>
            <table id="example">
                <tr>
                    <td style="text-align:right;">
                        <asp:Label ID="lblOrositenCd" runat="server" Text="卸店コード（５桁）"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOrositenCd" runat="server" CssClass="center5K" MaxLength="5" onkeydown="nextfocus(this);" ></asp:TextBox>
                    </td>
                    <td style="text-align:left;">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;">
                        <asp:Label ID="lblPriToriCd" runat="server" Text="プライベート取引先"></asp:Label>
                    </td>
                    <td >
                        <asp:TextBox ID="txtPriToriCd" runat="server" CssClass="left12K" MaxLength="12" onkeydown="nextfocus(this);" ></asp:TextBox>
                    </td>
                    <td style="text-align:left;">
                        <asp:Label ID="Label1" runat="server" Text="※ 左詰１２桁（前ゼロ有）"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;">
                        <asp:Label ID="lblTorCd" runat="server" Text="小売店・統一コード"></asp:Label>
                    </td>
                    <td >
                        <asp:TextBox ID="txtTorCd" runat="server" CssClass="center8" MaxLength="8" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                    <td style="text-align:left;">
                        <asp:Label ID="Label2" runat="server" Text="※ ＫＭ０１Ｄに存在する事！ ＡＬＬ 4 は許可"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <div style="align-items:center; ">
            <table id="example">
                <tr>
                    <td>
                        <asp:Literal ID="ltMsg" runat="server" Text=""></asp:Literal>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div style="align-items:center; ">
            <table id="example">
                <tr>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnSearch" runat="server" Text=" 検　索 " OnClick="btnSearch_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnUpdate" runat="server" Text=" 更　新 " OnClick="btnUpdate_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnDelete" runat="server" Text=" 削　除 " OnClick="btnDelete_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div style="text-align:right;">
            <asp:HyperLink ID="GoMenu" runat="server" NavigateUrl="~/kouriMenu.aspx?next=2">メニューに戻る</asp:HyperLink>
        </div>
    </form>
</body>
</html>
