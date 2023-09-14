<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MstOroshiten.aspx.cs" Inherits="Kouri_Form.Test.MstOroshiten" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" type="text/css" href="../style.css" />
    <title></title>

    <style type="text/css">

    .Freezing
        {
            position : relative;
            top: expression(this.offsetParent.scrollTop);
            z-index : 10;
            background-color: Yellow;
        }
    .FreezingCol
        {
            z-index: 1;
            left: expression(document.getElementById("freezingDiv").scrollLeft);
            position: relative;
            background-color: black;
        }
    #freezingDiv{
            overflow: auto; 
            height: 400px; 
            width: 1000px;
        }
    #freezingDiv1{
            overflow: auto; 
            height: 145px; 
            width: 225px;
     }



    </style>
</head>
             
    <script runat="server">
         void Button2_Click(object sender, EventArgs e) {
            //lbSam.Text = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
         }
                 
        void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbSam.Text = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        }

        void sayHello() {
            lbSam.Text = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        }
       
        </script>

    
    <script type="text/javascript">
        function sayHello() {
            PageMethods.sayHello(0, onSuccess, onError);
        }

        function onSuccess(result, userContext, methodName) {
            if (result === true) {
                alert("count is 0.");
            }
        }

        function onError(result, userContext, methodName) {
            // エラー時の処理
        }
        function LinkClick() {
            //var Text = document.forms.form1.TextBox1.value;
            //var url = 'MstOroshitenMente.aspx?q=' + Text;
            //window.open(url, null);
            var url = 'TstOutputList.aspx';
            window.open(url);
        }

    </script>

    <style>
        .fixed {
            width: 100px;
            height: 80px;
            background: orange;
            position: fixed;
            top: 50px; /* 画面上から50px */
            left: 50px; /* 画面左から50px */
            z-index: -1;
          }
        
        .auto-style1 {
            width: 1055px;
            height: 218px;
        }

        .rowheader {
            text-align:right !important;
            background-image: none !important;
            background-color:lightgreen !important;
            color: blue !important;
        }
        </style>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center;">
            <h1>
                <asp:Label ID="lblTitle" runat="server" Text="卸店マスタメンテナンス"></asp:Label>
            </h1>
        </div>
        <div  class="fixed"></div>
        <div>
            <label id="lblOroshiCd" for="txtOroshiCd">卸店コード：</label>
            <input type="text" id="txtOroshiCd" class="design8"/>
        </div>
        <div>
            <input id="btnSearch" type="button" value="検索" class="btn-square-shadow"/>
        </div>
        <div>
            <asp:GridView ID="gvList" runat="server">
                <Columns>

                    <asp:TemplateField HeaderText="" InsertVisible="False" SortExpression="" FooterStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnUpdate" runat="server" Text="更新" />
                        </ItemTemplate>
                        <FooterStyle HorizontalAlign="Center" CssClass="FreezingCol" ></FooterStyle>
                        <HeaderStyle Wrap="False" Font-Size="0.8em" CssClass="FreezingCol" />
                        <ItemStyle HorizontalAlign="Center" Wrap="false" Font-Size="0.8em" CssClass="FreezingCol" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" InsertVisible="False" SortExpression="" FooterStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            
                        </ItemTemplate>
                        <FooterStyle HorizontalAlign="Center" CssClass="FreezingCol" ></FooterStyle>
                        <HeaderStyle Wrap="False" Font-Size="0.8em" CssClass="FreezingCol" />
                        <ItemStyle HorizontalAlign="Center" Wrap="false" Font-Size="0.8em" CssClass="FreezingCol" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div>
           <asp:Button ID="Button1" runat="server" Text="Gridview表示用" OnClick="Button1_Click" />    
            <asp:TextBox ID="txtSam" runat="server"></asp:TextBox>
            <asp:Label ID="lbOrosiCd" runat="server" Text="Label"></asp:Label>
            
            <div id="freezingDiv1">
                <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"  CssClass="Freezing"/>
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </div>
        </div>
        <div>
            <asp:Label ID="lbSam" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" style="height: 21px" />
            <asp:ScriptManager ID="ScriptManager1" runat="server"  EnablePageMethods="true"></asp:ScriptManager>
        </div>

        <div>
            <asp:Button ID="btnkidou" runat="server" Text="画面起動"  OnClientClick="LinkClick();" OnClick="btnkidou_Click"/>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="Button3" runat="server" Text="Button" OnClick="Button3_Click" /><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>  
        <div>

        </div>    
        <div id="freezingDiv" class="auto-style1">
            <asp:GridView ID="GridView1" runat="server" Width="372px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="km04d_ten_cd_linkbutton">                       
                        <%--<HeaderTemplate></HeaderTemplate>--%>          
                        <HeaderStyle CssClass="FreezingCol" />
                        <ItemStyle CssClass="FreezingCol" />
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" Text='<%# DataBinder.Eval(Container.DataItem, "km04d_ten_cd")%>' runat="server">LinkButton</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="km04d_br_name_a_test">
                        <%--<HeaderTemplate></HeaderTemplate>--%>         
                        <HeaderStyle CssClass="FreezingCol" />
                        <ItemStyle CssClass="FreezingCol" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox1" Text='<%# DataBinder.Eval(Container.DataItem, "km04d_br_name_a")%>' runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"  CssClass="Freezing"/>
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>
        <div>
            <div>
                <asp:Button ID="btnTest3" runat="server" Text="Button" OnClick="btnTest3_Click" />
            </div>
            <div>
                <asp:GridView ID="gvTest3" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="False">
                    <Columns>
                        <asp:TemplateField HeaderText="cal_year">
                            <ItemTemplate>
                                <asp:Label ID="lblTest31" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cal_year")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField  HeaderText="cal_month">
                            <ItemTemplate>
                                <asp:Label ID="lblTest32" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cal_month")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="cal_day">
                            <ItemTemplate>
                                <asp:Label ID="lblTest33" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cal_day")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="cal_jigyo">
                            <ItemTemplate>
                                <asp:Label ID="lblTest34" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cal_jigyo")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="cal_flg">
                            <ItemTemplate >
                                <asp:Label ID="lblTest34" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cal_flg")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div>
            <asp:Label ID="lblTest" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        </div>
    </form>
</body>
</html>
