<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MstFuyoTori.aspx.cs" Inherits="Kouri_Form.Master.MstFuyoTori" %>

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
                <asp:Label ID="lblTitle" runat="server" Text="＊＊　取引先名　不要マスタ　登録　＊＊"></asp:Label>
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
                        <asp:Label ID="lblFuyoToriNM" runat="server" Text="不要取引先名"></asp:Label>
                    </td>
                    <td >
                        <asp:TextBox ID="txtFuyoToriNM" runat="server" CssClass="left20K" MaxLength="40" onkeydown="nextfocus(this);" ></asp:TextBox>
                    </td>
                    <td style="text-align:left;">
                        <asp:Label ID="lbl2" runat="server" Text="左記の文字が含まれる場合は、以下のコードに変更"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;">
                        <asp:Label ID="lblKouriCd" runat="server" Text="小売店・統一コード"></asp:Label>
                    </td>
                    <td >
                        <asp:TextBox ID="txtKouriCd" runat="server" CssClass="center8" MaxLength="8" onkeydown="nextfocus(this);"　 ReadOnly="True" Text="44444444"></asp:TextBox>
                    </td>
                    <td style="text-align:left;">
                        <asp:Label ID="lbl3" runat="server" Text="ＡＬＬ 4で固定(編集不可)"></asp:Label>
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
            <asp:HyperLink ID="GoMenu" runat="server" NavigateUrl="~/KouriMasterMenu.aspx?next=2">メニューに戻る</asp:HyperLink>
        </div>
    </form>
</body>
</html>
