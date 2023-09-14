<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShohinSearchdialog.aspx.cs" Inherits="Kouri_Form.Models.ShohinSearchdialog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <style type="text/css">
        a{
	        text-decoration:none;
        }
        a:hover {
	        text-decoration:underline;
        }

        .Freezing{
            position: relative;
         }
       </style>
</head>
    <style>
    .boby_formsize{
      width:727px;
      height:575px;
    }
    .left{
      float: left;
    }
    .right{
      float: right;
      height: 106px;
     } 
    .clear{
      clear: both;
      width: 584px;
     }
    .box_DropDownList{
      width:580px;
      height:90px;
    }
    .box_ShohinMeiTxt{
      width:582px;
      height:89px;
    }
    .box_GridViewList{
      width:581px;
      height:149px;
    }
    .box_Label{
      width:582px;
      height:79px;
    }
    .boxRight{
      width:105px;
      height:33px;
    }
    .colourAquamarine{
      background-color: Aquamarine;
    }
    #freezingDiv{
        overflow: auto; 
        HEIGHT: 400px; 
        width: 615px;
    }
    </style>
<body class="colourAquamarine boby_formsize">
    <form id="form1" runat="server">       
        <div class="clear">
            <div class="left box_DropDownList">
                <div>
                    <asp:Label ID="Label2" runat="server" Text="商品開始コード："></asp:Label>
                    <asp:DropDownList ID="ddlShohinCodeStart" runat="server"></asp:DropDownList>
                </div>
                <div style="height: 24px"></div>
                <div>
                    <asp:Label ID="Label3" runat="server" Text="商品終了コード："></asp:Label>
                    <asp:DropDownList ID="ddlShohinCodeEnd" runat="server"></asp:DropDownList>
                </div>
            </div>
        </div>   
        <div class="right"> 
            <div class="boxRight">
                <asp:LinkButton ID="lbtnSyoukai" runat="server" OnClick="lbtnSyoukai_Click">【照会】</asp:LinkButton>
            </div>
            <div class="boxRight">  
                <asp:LinkButton ID="lbtnInitialState" runat="server" OnClick="lbtnInitialState_Click">【初期状態】</asp:LinkButton>
            </div>
            <div class="boxRight">   
                <asp:LinkButton ID="lbtnClose" runat="server" OnClick="lbtnClose_Click">【終了】</asp:LinkButton>
            </div>
        </div>
        <div class="clear">
            <div class="left box_ShohinMeiTxt">
                <div><asp:Label ID="lblShohinNameSearch" runat="server" Text="商品名"></asp:Label></div>
                <div><asp:TextBox ID="txtShohinNameSearch" runat="server" Height="16px" Width="203px"></asp:TextBox></div>
            </div>
        </div>
        <div class="clear">
            <div class="left box_GridViewList">
                <div id="freezingDiv">
                     <asp:GridView ID="gvShohinList" runat="server" AutoGenerateColumns="False" Width="547px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                         <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>商品コード</HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnlblShohinCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "shohn_shohin_cd")%>' OnClick="lbtnlblShohinCode_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>商品名</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblShohinName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "shohn_na_25_kn")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>入数</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblShohnBoxIri" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "shohn_box_iri")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                         <FooterStyle BackColor="#CCCCCC" />
                         <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White"  CssClass="Freezing"/>
                         <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                         <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                         <SortedAscendingCellStyle BackColor="#F1F1F1" />
                         <SortedAscendingHeaderStyle BackColor="#808080" />
                         <SortedDescendingCellStyle BackColor="#CAC9C9" />
                         <SortedDescendingHeaderStyle BackColor="#383838" />
                     </asp:GridView> 
                </div>
            </div>
        </div>
        <div class="clear">
            <div  class="box_Label">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
