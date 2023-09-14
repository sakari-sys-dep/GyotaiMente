using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Kouri_Form.Class;
using System.Data;
using System.Text;

namespace Kouri_Form.Test
{
    public partial class TstOutputList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*ここからデータを取得*/
                //実行するストアドプロシージャを取得する
                DataTable dt = new DataTable();
                Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
                if ((DBManager.GetTableData("dbret", this.CreateSqlSelect().ToString(), paramDict, ref dt)) > 0)
                {
                    repeater1.DataSource = dt;
                    repeater1.DataBind();
                } 
            }
        }

        private StringBuilder CreateSqlSelect()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT [商品コード] ");
            sb.AppendLine("       ,[商品名] ");
            sb.AppendLine("   FROM [obic7].[dbo].[shuzei_data] ");
            sb.AppendLine("  WHERE [年月] = 202203 ");
            sb.AppendLine("  GROUP BY[商品コード] ");
            sb.AppendLine("         ,[商品名] ");
            sb.AppendLine("  ORDER BY[商品コード] ");
            sb.AppendLine("         ,[商品名] ");
            return sb;
        }

        protected void btnST_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in repeater1.Items)
            {
                TextBox txtcd = item.FindControl("txtCD") as TextBox;
                txtcd.Text = "すべて変換する";
            }


        }

        protected void repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                DataRowView row = e.Item.DataItem as DataRowView;

                string url = string.Format("MstOroshitenMente.aspx?tencd={0:s}", row["商品コード"].ToString());
                //Type cstype = this.GetType();
                //ClientScriptManager cs = Page.ClientScript;
                //cs.RegisterStartupScript(cstype, "OpenNewWindow", "window.open('" + url + "', '_blank' );", true);
                Button bt = e.Item.FindControl("btnMei") as Button;
                //bt.Attributes.Add("OnClientClick", "window.open('" + url + "', '_blank' );");
                bt.Attributes["onclick"] = "window.open('" + url + "', '_blank' );";
                //bt.PostBackUrl = "./MstOroshitenMente.aspx?tencd=" + row["商品コード"].ToString();
            }
        }
    }
}