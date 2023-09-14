<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MstOroshitenMente.aspx.cs" Inherits="Kouri_Form.Test.MstOroshitenMente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" type="text/css" href="../style.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:100%;">
            <table>
                <tr>
                    <td>
                        <label id="lblOroshiCd" for="txtOroshiCd" >卸店コード：</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOroshiCd" runat="server" MaxLength="3" class="design3"></asp:TextBox>
                    </td>
                    <td>
                        <label id="lblOroshiEda" for="txtOroshiEda" >支店・営業所コード：</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOroshiEda" runat="server" maxlength="2" class="design2"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="lblTenCd" for="txtTenCd" >小売店コード：</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTenCd" runat="server" maxlength="8" class="design8"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="lblPriKbn" for="ddlPriKbn" >取り扱いコード区分：</label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPriKbn" runat="server">
                            <asp:ListItem Selected="True" Value="0" Text="0:統一コードのみ"></asp:ListItem>
                            <asp:ListItem Value="1" Text="1:プライベートコードあり"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="lblName_k" for="txtName_k" >卸店名（漢字）：</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName_k" runat="server" maxlength="20" ></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="lblBrName_k" for="txtBrName_k" >支店・営業所（漢字）：</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBrName_k" runat="server" maxlength="20"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="lblName_a" for="txtName_a" >卸店名（カナ）：</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName_a" runat="server" maxlength="20"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="lblBrName_a" for="txtBrName_a" >支店・営業所（カナ）：</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBrName_a" runat="server" maxlength="20"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="lblDelKbn" for="ddlPriKbn" >停止区分：</label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDelete" runat="server">
                            <asp:ListItem Selected="True" Value="" Text="0:有効"></asp:ListItem>
                            <asp:ListItem Value="D" Text="1:削除済み"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Button ID="btnUpdate" runat="server" Text="更　新" OnClick="btnUpdate_Click" />
                    </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
