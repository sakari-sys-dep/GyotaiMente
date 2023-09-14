<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TstOutputList.aspx.cs" Inherits="Kouri_Form.Test.TstOutputList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style3 {
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    
        <div>
            <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional" >
                <ContentTemplate>

                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="500" Height="400">

                    <table border="1">
                        <thead>
                            <tr>
                                <td></td>
                                <td>商品コード</td>
                                <td>商品名</td>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="repeater1" runat="server" OnItemDataBound="repeater1_ItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnMei" runat="server" Text="詳" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCD" runat="server" value='<%# Eval("商品コード") %>' ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtname" runat="server" value='<%# Eval("商品名") %>' ></asp:TextBox>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                
                    </asp:Panel>
                    
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnST" EventName="Click" />
                </Triggers> 
            </asp:UpdatePanel>
        </div>
    

        <div>
            <asp:Button ID="btnST" runat="server" Text="Button" OnClick="btnST_Click" />
        </div>
    </form>
</body>
</html>
