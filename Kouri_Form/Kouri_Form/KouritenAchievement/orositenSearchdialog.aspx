<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orositenSearchdialog.aspx.cs" Inherits="Kouri_Form.Models.orositenSearchdialog" %>

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
       /* .Freezing
        {
	        color:White;
	        font-weight:bold;
	        text-align:left;
	        position: relative;
	        border-width:0;
	        z-index: 10;
        }*/

        </style>
           
</head>
    <style>
    .boby_formsize{
      width:618px;
      height:503px;
    }
    .left{
      float: left;
    }
    .right{
      float: right;
    } 
    .clear{
      clear: both;
    }
    .box_fuken{
      width:200px;
      height:80px;
    }
    .box_tiku{
      width:252px;
      height:80px;
    }   
    .box_orositencode{  
      width:200px;
      height:60px;
    }
    .box_Name{
      width:252px;
      height:60px;
    }  
    .box_list{
      width:615px;
      height:213px;
    }

    .boxRight{
        width:105px;
        height:40px;
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
    
    <script runat="server">

        </script>
<body  class="boby_formsize colourAquamarine">
    <form id="form1" runat="server">
        <div>
            <div class="left box_fuken">
                <div>
                    <asp:Label ID="Label1" runat="server" Text="府県"></asp:Label>    
                </div>
                <div>
                    <asp:DropDownList ID="ddlFukenList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFukenList_SelectedIndexChanged">
                        <asp:ListItem>未選択</asp:ListItem>
                    </asp:DropDownList>
                </div>    
            </div>
            <div class="left box_tiku">              
                <div>
                    <asp:Label ID="Label2" runat="server" Text="地区"></asp:Label>
                </div>
                <div>
                    <asp:DropDownList ID="ddlTikuList" runat="server" AutoPostBack="True">
                        <asp:ListItem>未選択</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="right">
                <div class="boxRight">
                    <asp:LinkButton ID="lbtnSyoukai" runat="server" OnClick="lbtnSyoukai_Click">【照会】</asp:LinkButton>
                </div>           
                <div class="boxRight">
                    <asp:LinkButton ID="lbtnSyokiset" runat="server" OnClick="lbtnSyokiset_Click">初期状態</asp:LinkButton>
                </div>
                <div class="boxRight">
                    <asp:LinkButton ID="lbtnClose" runat="server" OnClick="lbtnClose_Click">終了</asp:LinkButton>
                </div>
            </div>
        </div>
        <div class="clear">
            <div class="left box_orositencode">
                <div>
                    <asp:Label ID="Label4" runat="server" Text="卸店コード"></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="txtOrositenCode" runat="server"></asp:TextBox>
                </div>
            </div>  
            <div class="left box_Name">
                <div>
                    <asp:Label ID="Label5" runat="server" Text="名称"></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="txtOroitenName" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class ="clear">
            <div class= "left box_list">
                 <asp:Label ID="lblkensu" runat="server" Text="0件" Font-Bold="True"></asp:Label>
                <div id="freezingDiv">
                    <asp:GridView ID="gvOrositen" runat="server" Height="99px" Width="593px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>コード</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnsOroshiCode" Text='<%# DataBinder.Eval(Container.DataItem, "km04d_orosi_cd") %>' runat="server" OnClick="lbtnsOroshiCode_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>名前</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" Text='<%# DataBinder.Eval(Container.DataItem, "oroshi_shiten_name")%>' runat="server" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" CssClass="Freezing"/>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
                </div>
            </div> 
        </div>
        <div class ="clear">
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
