<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MstCnvTokui.aspx.cs" Inherits="Kouri_Form.Master.MstCnvTokui" %>

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
        //var element = document.getElementById("txtOrositenCd");
        //var index = [].slice.call(n.form.elements).indexOf(element);
        //alert(index);
        for (var i = 0, f = n.form.elements; i < f.length; i++) {
            if (f[i] == n) {
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
                <asp:Label ID="lblTitle" runat="server" Text="＊＊　卸店プライベートＣＤ　登録　＊＊"></asp:Label>
            </h1>
        </div>

        <div>
            <table id="example">
                <tr>
                    <td style="text-align:right;">
                        <label id="lblOrositenPriCd" for="txtOrositenPriCd" >卸店プライベートコード</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOrositenPriCd" runat="server" CssClass="left12K" MaxLength="12" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                    <td>
                        <label id="lbl01" for="txtOrositenPriCd" >※ 左詰１２桁</label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;">
                        <label id="lblCenterCd" for="txtCenterCd" >センターコード</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCenterCd" runat="server" CssClass="center8K" MaxLength="6" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                    <td>
                        <label id="lbl02" for="txtCenterCd" >※ 未入力可（重複時入力）</label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;">
                        <label id="lblOrositenCd" for="txtOrositenCd" >卸店コード</label>
                    </td>
                    <td >
                        <asp:TextBox ID="txtOrositenCd" runat="server" CssClass="center8" MaxLength="8" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                    <td>
                        <label id="lbl03" for="txtCenterCd" >※ ＫＭ０４Ｄに存在する事</label>
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
