<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KouritenCorrectionDeleteAchievements.aspx.cs" Inherits="Kouri_Form.Models.KouritenCorrectionDeleteAchievements" %>

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
    <script type="text/javascript">
        
    </script>

    <style>
    .boby_formsize{
      width:949px;
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
      width: 1260px;
     }
    .box_date{
      width:600px;
      height:25px;
    }
    .box_oroshitencode{
      width:600px;
      height:30px;
    }   
    .box_koten{  
      width:600px;
      height:30px;
    }
    .box_right{
        width:126px;
        height:40px;
    }
    .colourAquamarine{
        background-color: Aquamarine;
     }
     #freezingDiv{
        overflow: auto; 
        height: 400px; 
        width: 856px;
    }
   /* #form1 {
        height: 636px;
    }*/
  </style>

<body class="boby_formsize colourAquamarine"  style="height: 640px">
    <form id="form1" runat="server">            
        <div class="left box_date">
            <div>
                <asp:Label ID="Label1" runat="server" Text="実施年月"></asp:Label>
                <asp:DropDownList ID="ddlYear" runat="server"></asp:DropDownList>
                <asp:Label ID="Label2" runat="server" Text="年"></asp:Label>
                <asp:DropDownList ID="ddlMonth" runat="server"></asp:DropDownList>
                <asp:Label ID="Label3" runat="server" Text="月"></asp:Label>
            </div>
        </div>
        <div class="clear left box_oroshitencode">  
            <asp:Label ID="Label4" runat="server" Text="卸店コード"></asp:Label>
            <asp:Button ID="btnOroshiuritenSearch" runat="server" Text="▶" Width="24px" OnClick="btnOroshiuritenSearch_Click" Height="20px" />
            <asp:TextBox ID="txtOroshiTenCode" runat="server"></asp:TextBox>
            <asp:Label ID="lblkm04dnamekDis" runat="server" Font-Bold="True"></asp:Label>
        </div>        
        <div class="clear left box_koten">
            <asp:Label ID="Label5" runat="server" Text="個店コード"></asp:Label>
            <asp:Button ID="btnKotenSearch" runat="server" Text="▶" Width="24px" OnClick="btnKotenSearch_Click" Height="20px" />
            <asp:TextBox ID="txtKotenCode" runat="server"></asp:TextBox>     
            <asp:Label ID="lblkm04dbrnamekDis" runat="server" Font-Bold="True"></asp:Label>
        </div>
        <div class="right">
            <div class="box_right"> 
                <asp:LinkButton ID="lbtnConfirm" runat="server" OnClick="lbtnConfirm_Click">【確認】</asp:LinkButton>
            </div>     
            <div class="box_right"> 
                <asp:LinkButton ID="lbtnUpdate" runat="server" OnClick="lbtnUpdate_Click">【修正】</asp:LinkButton>
            </div> 
            <div class="box_right"> 
                <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click">【削除】</asp:LinkButton>
            </div>
              <div class="box_right"> 
                <asp:LinkButton ID="lbtnCancel" runat="server" OnClick="lbtnCancel_Click">【キャンセル】</asp:LinkButton>
            </div>  
        </div>
        <div class="clear">        
            <div id="freezingDiv">
                <asp:GridView ID="gvSakehanbaitenPerInfoList" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" ShowHeaderWhenEmpty="True" >
                    <AlternatingRowStyle BackColor="White"  />
                    <Columns>
                        <asp:TemplateField>   
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkSelectAllCheckBox" runat="server" OnCheckedChanged="chkSelectAllCheckBox_CheckedChanged"  AutoPostBack="true"/>
                                削除</HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkDelete" Text='<%# DataBinder.Eval(Container.DataItem, "delete_flg") %>' runat="server"  AutoPostBack="true" OnCheckedChanged="chkDelete_CheckedChanged" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>商品コード</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtShohinCd" Text='<%# DataBinder.Eval(Container.DataItem, "km08d_sho_cd")%>' runat="server" OnTextChanged="txtListTextInputValue_TextChanged" AutoPostBack="True" Width="100"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>商品名</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblShohinName" Text='<%# DataBinder.Eval(Container.DataItem, "shohn_na_25_kn")%>' runat="server" Width="400"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>入数</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblShohnBoxIri" Text='<%# DataBinder.Eval(Container.DataItem, "shohn_box_iri")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>ケース数</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtHakosu" Text='<%# DataBinder.Eval(Container.DataItem, "km08d_hakosu")%>' runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>バラ数</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtHasu" Text='<%# DataBinder.Eval(Container.DataItem, "km08d_hasu")%>' runat="server" OnTextChanged="txtListTextInputValue_TextChanged" AutoPostBack="True" Width="100"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>                 
                            <HeaderTemplate>合計</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblKm08dHhasuGoukei" Text='<%# DataBinder.Eval(Container.DataItem, "km08d_hasu_Goukei") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>卸店コード(読取専用)</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblOroshiTenCodeReadOnly" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "km08d_orshi_shiten_cd")%>' Visible="False"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>個店コード(読取専用)</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblKotenCodeReadOnly" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "km08d_ten_cd")%>' Visible="False"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>日付(読取専用)</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblYmdReadOnly" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "km08d_data_ym")%>' Visible="False"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>商品コード(読取専用)</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblShohinCdReadOnly" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "km08d_sho_cd_ReadOnly") %>' Visible="False"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>           
                        <asp:TemplateField>           
                            <HeaderTemplate>ケース数(読取専用)</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblHakosuReadOnly" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "km08d_hakosu_ReadOnly")%>' Visible="False"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>バラ数(読取専用)</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblHasuReadOnly" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "km08d_hasu_ReadOnly")%>' Visible="False" ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"/>
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"  CssClass="Freezing"/>
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#33CC33" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </div>
        </div>  
        <div class="clear">
            <asp:Label ID="lblMeesageDis" runat="server"></asp:Label>
        </div>
        <div class="right">
            <div class="box_right">
                <asp:LinkButton ID="lbtnBackMenu" runat="server" OnClick="lbtnBackMenu_Click">メニューに戻る</asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>
