<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MstCnvOrosi.aspx.cs" Inherits="Kouri_Form.Master.MstCnvOrosi" %>

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
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="../MstStyle.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center;">
            <h1>
                <asp:Label ID="lblTitle" runat="server" Text="＊＊　卸店マスタ　メンテナンス　＊＊"></asp:Label>
            </h1>
        </div>

        <div>
            <table id="example">
                <tr>
                    <td style="text-align: right;">
                        <label id="lblOrosiCd" for="txtOrosiCd">卸店コード</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOrosiCd" runat="server" CssClass="center3" MaxLength="3" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                    <td style="text-align: right;">
                        <label id="lblOrosiEda" for="txtOroshiEda">支店・営業所コード</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOrosiEda" runat="server" MaxLength="2" class="center2" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        <label id="lblTenCd" for="txtTenCd">小売店コード</label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtTenCd" runat="server" MaxLength="8" class="center8K" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        <label id="lblPriKbn" for="ddlPriKbn">取り扱いコード区分</label>
                    </td>
                    <td colspan="3">
                        <asp:DropDownList ID="ddlPriKbn" runat="server">
                            <asp:ListItem Selected="True" Value="0" Text="0:統一コードのみ"></asp:ListItem>
                            <asp:ListItem Value="1" Text="1:プライベートコードあり"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        <label id="lblName_k" for="txtName_k">卸店名（漢字）</label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtName_k" runat="server" MaxLength="20" CssClass="left20" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        <label id="lblBrName_k" for="txtBrName_k">支店・営業所（漢字）</label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtBrName_k" runat="server" MaxLength="20" CssClass="left20" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        <label id="lblName_a" for="txtName_a">卸店名（カナ）</label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtName_a" runat="server" MaxLength="20" CssClass="left20" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        <label id="lblBrName_a" for="txtBrName_a">支店・営業所（カナ）</label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtBrName_a" runat="server" MaxLength="20" CssClass="left20" onkeydown="nextfocus(this);"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <div style="align-items: center;">
            <table id="example">
                <tr>
                    <td>
                        <asp:Literal ID="ltMsg" runat="server" Text=""></asp:Literal>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div style="align-items: center;">
            <table id="example">
                <tr>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnSearch" runat="server" Text=" 検　索 " OnClick="btnSearch_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button1" runat="server" Text=" 更　新 " OnClick="btnUpdate_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnDelete" runat="server" Text=" 削　除 " OnClick="btnDelete_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div style="text-align: right;">
            <asp:HyperLink ID="GoMenu" runat="server" NavigateUrl="~/KouriMasterMenu.aspx?next=2">メニューに戻る</asp:HyperLink>
        </div>
    </form>
</body>
</html>
