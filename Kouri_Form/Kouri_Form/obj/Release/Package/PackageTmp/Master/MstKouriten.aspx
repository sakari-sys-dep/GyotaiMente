<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MstKouriten.aspx.cs" Inherits="Kouri_Form.Master.MstKouriten" %>

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
                <asp:Label ID="lblTitle" runat="server" Text="＊＊　小売店マスタ　メンテナンス　＊＊"></asp:Label>
            </h1>
        </div>

        <div>
            <table id="example">
                <tr>
                    <td colspan="2" style="text-align:right;">
                        <asp:Label ID="lblTorCd" runat="server" Text="取引先コード"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTorCd" runat="server" CssClass="center8K" MaxLength="8" onkeydown="nextfocus(this);" ></asp:TextBox>
                    </td>
                    <td style="text-align:right;">
                        <asp:Label ID="lblKenCd" runat="server" Text="県コード"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtKenCd" runat="server" CssClass="center2" MaxLength="2"  onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                    <td style="text-align:right;">
                        <asp:Label ID="lblSikugun" runat="server" Text="市区群コード"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSikugun" runat="server" CssClass="center2" MaxLength="2"  onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:right;" >
                        <asp:Label ID="lblRyaku" runat="server" Text="略号"></asp:Label>
                    </td>
                    <td colspan="5" >
                        <asp:TextBox ID="txtRyaku" runat="server" CssClass="left10" MaxLength="10" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;">
                        <asp:Label ID="lbl1" runat="server" Text="屋号"></asp:Label>
                    </td>
                    <td style="text-align:right; width:90px;">
                        <asp:Label ID="lblYagouK" runat="server" Text="漢字"></asp:Label>
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtYagouK" runat="server" CssClass="left42" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td style="text-align:right;">
                        <asp:Label ID="lblYagouA" runat="server" Text="カナ"></asp:Label>
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtYagouA" runat="server" CssClass="left25" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td style="text-align:right;">
                        <asp:Label ID="lbl3" runat="server" Text="氏名"></asp:Label>
                    </td>
                    <td style="text-align:right; width:90px;">
                        <asp:Label ID="lblNameK" runat="server" Text="漢字"></asp:Label>
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtNameK" runat="server" CssClass="left42" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td style="text-align:right;">
                        <asp:Label ID="lblNameA" runat="server" Text="カナ"></asp:Label>
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtNameA" runat="server" CssClass="left25" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td style="text-align:right;">
                        <asp:Label ID="lbl2" runat="server" Text="住所"></asp:Label>
                    </td>
                    <td style="text-align:right;">
                        <asp:Label ID="lblPost" runat="server" Text="郵便番号"></asp:Label>
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtPost" runat="server" CssClass="center10" MaxLength="10" onkeydown="nextfocus(this);"></asp:TextBox>
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td style="text-align:right;">
                        <asp:Label ID="lblAddrK" runat="server" Text="漢字"></asp:Label>
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtAddrK" runat="server" CssClass="left62" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td style="text-align:right;">
                        <asp:Label ID="lblAddrA" runat="server" Text="カナ"></asp:Label>
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtAddrA" runat="server" CssClass="left35" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:right;">
                        <asp:Label ID="lblTel" runat="server" Text="電話番号"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtTel" runat="server" CssClass="left14" MaxLength="14" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                    <td style="text-align:right;">
                        <asp:Label ID="lblKbn" runat="server" Text="酒税免許"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtKbn" runat="server" CssClass="center2" MaxLength="2" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:right;">
                        <asp:Label ID="lblFax" runat="server" Text="ＦＡＸ番号"></asp:Label>
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtFax" runat="server" CssClass="left14" MaxLength="14" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:right;">
                        <asp:Label ID="lblNewCd" runat="server" Text="新コード" ></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNewCd" runat="server" CssClass="center8" MaxLength="8" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                    <td style="text-align:right;">
                        <asp:Label ID="lblNewDate" runat="server" Text="設定日"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNewDate" runat="server" CssClass="center8" MaxLength="8" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                    <td style="text-align:right;">
                        <asp:Label ID="lblDupDel" runat="server" Text="抹消重複コード" ></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDupDel" runat="server" CssClass="center8" MaxLength="8" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td colspan="2" style="text-align:right;">
                        <asp:Label ID="lblOldCd" runat="server" Text="旧コード"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOldCd" runat="server" CssClass="center8" MaxLength="8" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td style="text-align:right;">
                        <asp:Label ID="lblDupMoto" runat="server" Text="重複元コード"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDupMoto" runat="server" CssClass="center8" MaxLength="8" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td colspan="2" style="text-align:right;">
                        <asp:Label ID="lblUpTanto" runat="server" Text="更新者"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUpTanto" runat="server" CssClass="center4" MaxLength="4" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                    <td style="text-align:right;">
                        <asp:Label ID="lblUpDate" runat="server" Text="更新日"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUpDate" runat="server" CssClass="center8" MaxLength="8" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                    <td style="text-align:right;">
                        <asp:Label ID="lblCando" runat="server" Text="処理区分"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCando" runat="server" CssClass="center1" MaxLength="1" onkeydown="nextfocus(this);"></asp:TextBox>
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
