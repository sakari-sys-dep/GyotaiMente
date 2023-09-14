using Kouri_Form.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Kouri_Form.Test
{
    public class Todoufuken
    {
        public string FukenCode { get; set; }
        public string sFuken { get; set; }
        //public Todoufuken(int nfukencode, string sfuken)
        //{
        //    nFukenCode = nfukencode;
        //    sFuken = sfuken;
        //}
    }

    public partial class MstOroshiten : System.Web.UI.Page
    {
        public List<Todoufuken> TodoufukenList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //ヘッダーのみを表示させる
                gvTest3.ShowHeaderWhenEmpty = true;
                gvTest3.Columns[0].ItemStyle.Width = 100;
                gvTest3.Columns[1].ItemStyle.Width = 100;
                gvTest3.Columns[2].ItemStyle.Width = 100;
                gvTest3.Columns[3].ItemStyle.Width = 100;
                gvTest3.Columns[4].ItemStyle.Width = 100;
                //gvTest3.DataSource = new List<object>();
                gvTest3.DataBind();
            }
        }
        /// <summary>
        /// Gridview表示用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            sam();//GridView1専用
            sam1();
            //sam2();
            //sam3();
        }

        #region 値入力DBからデータ取得
        /// <summary>
        /// 値入力DBからデータ取得
        /// </summary>
        private void sam()
        {
            //if (string.IsNullOrEmpty(txtSam.Text.TrimEnd()))
            //{
            //    /*空白の場合はエラーメッセージを表示*/
            //    lbSam.Text = "卸店コードを入力して下さい。";
            //    txtSam.Focus();
            //    return;
            //}

            //DataTable dt = new DataTable();
            //Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            //paramDict.Add(constSql.KM04D_TEN_CD, txtSam.Text.TrimEnd());
            //if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectKM04DTEST().ToString(), paramDict, ref dt)) > 0)
            //{
            //    this.screenSet(dt.Rows[0]);
            //    this.GridView1.DataSource = dt;
            //    this.GridView1.DataBind();

            //    //下記[km04d_ten_cd]のデータ
            //    //13020268
            //    //13021037
            //    //13020857
            //}
            //else
            //{
            //    lbSam.Text = "";
            //    lbSam.Text = lbSam.Text + "値がないです" + "</BR>";
            //    lbSam.Text = lbSam.Text + "新規登録をお願いします。" + "</BR>";
            //    txtSam.Focus();
            //}
        }
        #endregion

        #region DBのデータ反映1
        /// <summary>
        /// DBのデータ反映1
        /// </summary>
        private void sam1()
        {
            //DataTable dt = new DataTable();
            //if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelecteKM31dTodoufuken().ToString(), ref dt)) > 0)
            //{
            //    Session["dt"] = dt;
            //    this.GridView2.DataSource = dt;
            //    this.GridView2.DataBind();

            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        ListBox1.Items.Add(dr[1].ToString());
            //        this.ListBox1.DataBind();
            //    }
            //}
            //else
            //{
            //    return;
            //}
        }
        #endregion

        #region DBのデータ反映2
        /// <summary>
        /// DBのデータ反映2
        /// </summary>
        private void sam2()
        {
            //TodoufukenList = new List<Todoufuken>();
            //Todoufuken tf = new Todoufuken();
            ////都道府県List表示
            //ListBox1.Items.Clear();
            //Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            //DataTable dt = new DataTable();
            //if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelecteKM31dTodoufuken().ToString(), ref dt)) > 0)
            //{
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        tf = new Todoufuken();
            //        tf.FukenCode = dr[0].ToString();
            //        tf.sFuken = dr[1].ToString();
            //        TodoufukenList.Add(tf);

            //        ListBox1.Items.Add(dr[0].ToString() + dr[1]);
            //    }
            //}
        }
        #endregion

        #region データ反映
        private void sam3()
        {
            GridView1.DataSource = getDataTable();
            GridView1.DataBind();
        }
        #endregion


        #region screenSet
        private void screenSet(DataRow dr)
        {
            lbOrosiCd.Text = "卸売りコードが" + dr["km04d_orosi_cd"] + dr["km04d_orosi_eda"].ToString();

            if (dr["km04d_maint"].ToString() == "D")
            {
                lbSam.Text = "削除済みのデータです。";
            }
            else
            {
                lbSam.Text = "";
            }
        }
        #endregion

        #region getDataTable
        private DataTable getDataTable()
        {
            DataTable dt;
            if (Session["dt"] != null)
            {
                dt = Session["dt"] as DataTable;
            }
            else
            {
                dt = new DataTable();
                dt.Columns.Add("Col1");
                dt.Columns.Add("Col2");
                DataRow row;
                for (int i = 0; i < 10; i++)
                {
                    row = dt.NewRow();
                    row[0] = i;
                    row[1] = "Item" + i;
                    dt.Rows.Add(row);
                }
                Session["dt"] = dt;
            }
            return dt;
        }
        #endregion

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbSam.Text = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static bool sayHello(int count)
        {
            return count == 0 ? true : false;
        }
        /// <summary>
        /// 画面起動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnkidou_Click(object sender, EventArgs e)
        {
            //string url = string.Format("TstOutputList.aspx?q={0:s}", TextBox2.Text);
            //Type cstype = this.GetType();
            //ClientScriptManager cs = Page.ClientScript;
            //cs.RegisterStartupScript(cstype, "OpenNewWindow", "window.open('" + url + "', null);", true);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Label1.Text = "t" + "<br>";
            Label1.Text += "e" + "<br>";
            Label1.Text += "s" + "<hr>";
            Label1.Text += "t" + "<br>";
        }

        protected void btnTest3_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine(" SELECT TOP (1000) [cal_year] ");
            sb.AppendLine("       ,[cal_month] ");
            sb.AppendLine("       ,[cal_day] ");
            sb.AppendLine("       ,[cal_jigyo] ");
            sb.AppendLine("       ,[cal_flg] ");
            sb.AppendLine("   FROM [UTILDB].[dbo].[Cal21] ");
           
            DataTable dt = new DataTable();
            if ((DBManager.GetTableData("dbret",sb.ToString(), ref dt)) > 0)
            {
                this.gvTest3.DataSource = dt;
                this.gvTest3.DataBind();
                lblTest.Text = "";
                lblTest.Text += "<pre>";
                lblTest.Text += "<FONT color='red'>";
                lblTest.Text += "取得できました" + "</BR>";
                lblTest.Text += "</font>";
                lblTest.Text += "</ pre>";
            }
            else
            {
                lblTest.Text = "";
                lblTest.Text += "<pre>";
                lblTest.Text += "<FONT color='red'>";
                lblTest.Text += "取得できませんでした" + "</BR>";
                lblTest.Text += "</font>";
                lblTest.Text += "</ pre>";
                return;
            }
            gvTest3.Columns[0].ItemStyle.Width = 100;
            gvTest3.Columns[1].ItemStyle.Width = 100;
            gvTest3.Columns[2].ItemStyle.Width = 100;
            gvTest3.Columns[3].ItemStyle.Width = 100;
            gvTest3.Columns[4].ItemStyle.Width = 100;

        }
    }
}