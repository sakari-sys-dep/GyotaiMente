<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AchievementRegistrationMenu.aspx.cs" Inherits="Kouri_Form.Models.AchievementRegistrationMenu" %>

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
        </style>
</head>
    <style>
        .container {
          font-family: arial;
          font-size: 24px;
          margin: 25px;
          width: 895px;
          height: 512px;
          /*outline: dashed 1px black;*/
        }

        .child {
          width: 800px;
          height: 142px;
          /*background-color: red;*/
          /* 水平方向の中央揃え */
        }
        .horizontal{
           margin: 0 auto;
        }
        .center{
          text-align:center;
          /*padding:20px 0;*/
            height: 29px;
        }
        .colourblack{
            background-color: black;
        }
        .colourAquamarine{
            background-color: Aquamarine;
        }

        </style>
<body  class="colourAquamarine">
    <form id="form1" runat="server">
        <div class="container colourAquamarine">
            <div class="child horizontal">
                <div class=" center colourblack">
                    <asp:Label ID="Label1" runat="server" Text="小売店手書実績　登録" ForeColor="White"></asp:Label>
                </div>
                <div style="height: 9px"></div>
                <div  class=" ">
                    <p>〇<asp:LinkButton ID="lbtnHandwrittenRecordEntry" runat="server" OnClick="lbtnHandwrittenRecordEntry_Click">手書実績　入力</asp:LinkButton></p>
                </div>
                <div style="height: 9px"></div>
                <div>
                    <p>〇<asp:LinkButton ID="lbtn" runat="server" OnClick="lbtn_Click">手書実績　修正　削除</asp:LinkButton></p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
