<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MstCnvShohn________old.aspx.cs" Inherits="Kouri_Form.Master.MstCnvShohn________old" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
<link rel="stylesheet" type="text/css" href="../MstStyle.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center;">
            <h1>
                <asp:Label ID="lblTitle" runat="server" Text="＊＊　商品プライベート　ＣＶＴ　登録　＊＊"></asp:Label>
            </h1>
        </div>

        <div>
            <table id="example">
                <tr>
                    <td style="text-align:right;">
                        <label id="lblOrosiCd" for="txtOrosiCd" >卸店コード</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOrosiCd" runat="server" CssClass="center3K" MaxLength="3" onkeydown="nextfocus(this);" ></asp:TextBox>
                    </td>
                    <td>
                        <label id="lbl01" for="txtOrosiCd" >卸店コードの頭３桁</label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;">
                        <label id="lblPriShohin" for="txtPriShohin" >商品プライベートコード</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPriShohin" runat="server" maxlength="16" class="left16K" onkeydown="nextfocus(this);" ></asp:TextBox>
                    </td>
                    <td>
                        <label id="lbl02" for="txtPriShohin" >※ 左詰１６桁</label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;">
                        <label id="lblIrisu" for="txtIrisu" >入数</label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtIrisu" runat="server" maxlength="6" CssClass="right6K" onkeydown="nextfocus(this);" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;">
                        <label id="lblShohinCd" for="txtShohinCd" >商品コード</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtShohinCd" runat="server" maxlength="5" CssClass="center5" onkeydown="nextfocus(this);" ></asp:TextBox>
                    </td>
                    <td>
                        <label id="lbl03" for="txtShohinCd" >日本盛・商品コード５桁</label>
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
                        <asp:Button ID="Button1" runat="server" Text=" 更　新 " OnClick="btnUpdate_Click" />
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
