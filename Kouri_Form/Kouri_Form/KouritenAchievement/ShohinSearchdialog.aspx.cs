using Kouri_Form.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kouri_Form.Models
{
    public class Shohin
    {
        public string ShohinnCode { get; set; }//商品コード
        public string ShohinnnName { get; set; }//商品名
    }

    public partial class ShohinSearchdialog : System.Web.UI.Page
    {
        public const string sUnselected = "未選択";

        public List<Shohin> ShohinList;

        public string sStartCode;

        public string sEndCode;
        public int index;

        public string sShohinCodeReference { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ScreenReset();
                lblMessage.Text = "";
                Session["sShohinCodeReference"] = null;

                ddlShohinCodeStart.Items.Clear();
                ddlShohinCodeEnd.Items.Clear();

                ddlShohinCodeStart.Items.Add(sUnselected);
                ddlShohinCodeEnd.Items.Add(sUnselected);

                ShohinList = new List<Shohin>();

                Shohin shn;

                DataTable dt = new DataTable();
                Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
                if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelecteSHOHN().ToString(), ref dt)) > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        shn = new Shohin();
                        shn.ShohinnCode= dr[0].ToString();
                        shn.ShohinnnName = dr[1].ToString();
                        ShohinList.Add(shn);
                        ddlShohinCodeStart.Items.Add(shn.ShohinnCode + "：" + shn.ShohinnnName);
                        ddlShohinCodeEnd.Items.Add(shn.ShohinnCode + "：" + shn.ShohinnnName);
                    }

                    Session["ShohinList"] = ShohinList;
                }
                else
                {
                    lblMessage.Text += "商品マスタの商品コードと商品名がございません。";
                    lblMessage.Text += "登録をお願いいたします。";
                }
            }
        }

        /// <summary>
        /// 照会リンクボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnSyoukai_Click(object sender, EventArgs e)
        {
            sStartCode = "";
            sEndCode = "";
            lblMessage.Text = "";

            int nStartCode = 0;
            int nEndCode = 0;

            //gvShohinList.DataSource = null;

            gvShohinList.ShowHeaderWhenEmpty = true;
            gvShohinList.DataSource = new List<object>();
            gvShohinList.DataBind();

            if (ddlShohinCodeStart.SelectedValue.ToString() != sUnselected)
            {
                //コード取得  
                string StartCode = ddlShohinCodeStart.SelectedValue.ToString();
                sStartCode = StartCode.Split('：')[0];
            }
            else
            {
                sStartCode = "";
            }

            if (ddlShohinCodeEnd.SelectedValue.ToString() != sUnselected)
            {
                //コード取得
                string EndCode = ddlShohinCodeEnd.SelectedValue.ToString();
                sEndCode = EndCode.Split('：')[0];
            }
            else
            {
                sEndCode = "";
            }

            if (sStartCode == "" && sEndCode == "")
            {
                if (string.IsNullOrEmpty(txtShohinNameSearch.Text))
                {
                    lblMessage.Text += "リストを選択するかテキストに文字を入力してください。" + "</BR>";
                }
                else
                {
                    DataTable dt = new DataTable();
                    Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
                    paramDict.Add(constSql.SHOHN_NA_25_KN, "%" + txtShohinNameSearch.Text + "%".TrimEnd());
                    if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelecteSHOHNTextSearch().ToString(), paramDict, ref dt)) > 0)
                    {
                        gvShohinList.DataSource = dt;
                        gvShohinList.DataBind();
                    }
                    else
                    {
                        lblMessage.Text += "データがございませんでした。" + "</BR>";
                    }
                }
            }
            else
            { 
                if (sStartCode != "")
                {
                    if (NumberCheck(sStartCode, ref nStartCode) == true)
                    {
                        nStartCode= int.Parse(sStartCode);
                    }
                    else
                    {
                        return;
                    }
                }

                if (sEndCode != "")
                {
                    if (NumberCheck(sEndCode, ref nEndCode) == true)
                    {
                        nEndCode = int.Parse(sEndCode);
                    }
                    else
                    {
                        return;
                    }
                }
            
                if (sStartCode != "" && sEndCode != "")
                {
                   if (nStartCode > nEndCode)
                    {
                        lblMessage.Text += "開始コード："+sStartCode+"より終了コード："+ sEndCode +"の数値が少ないです。"+ "</BR>";
                        return;
                    }

                    DataTable dt = new DataTable();
                    Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
                    paramDict.Add(constSql.SHOHN_SHOHIN_SHOHIN_CD_srt, sStartCode.TrimEnd());
                    paramDict.Add(constSql.SHOHN_SHOHIN_SHOHIN_CD_end, sEndCode.TrimEnd());
                    paramDict.Add(constSql.SHOHN_NA_25_KN, "%" + txtShohinNameSearch.Text + "%".TrimEnd());
                    if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelecteSHOHNAllItemSearch().ToString(), paramDict, ref dt)) > 0)
                    {
                        gvShohinList.DataSource = dt;
                        gvShohinList.DataBind();
                    }
                    else
                    {
                        lblMessage.Text += "データがございませんでした。" + "</BR>";
                    }
                   
                }
                else if (sStartCode != "" && sEndCode == "")
                {
                    DataTable dt = new DataTable();
                    Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
                    paramDict.Add(constSql.SHOHN_SHOHIN_SHOHIN_CD_srt, sStartCode.TrimEnd());
                    paramDict.Add(constSql.SHOHN_NA_25_KN, "%" + txtShohinNameSearch.Text + "%".TrimEnd());
                    if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelecteSHOHNStartItemSearch().ToString(), paramDict, ref dt)) > 0)
                    {
                        gvShohinList.DataSource = dt;
                        gvShohinList.DataBind();
                    }
                    else
                    {
                        lblMessage.Text += "データがございませんでした。" + "</BR>";
                    }
                }
                else if (sStartCode == "" && sEndCode != "")
                {
                    DataTable dt = new DataTable();
                    Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
                    paramDict.Add(constSql.SHOHN_SHOHIN_SHOHIN_CD_end, sEndCode.TrimEnd());
                    paramDict.Add(constSql.SHOHN_NA_25_KN, "%" + txtShohinNameSearch.Text + "%".TrimEnd());
                    if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelecteSHOHNEndItemSearch().ToString(), paramDict, ref dt)) > 0)
                    {
                        gvShohinList.DataSource = dt;
                        gvShohinList.DataBind();
                    }
                    else
                    {
                        lblMessage.Text += "データがございませんでした。" + "</BR>";
                    }
                }
            }
        }

        /// <summary>
        /// 初期状態
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnInitialState_Click(object sender, EventArgs e)
        {
            ScreenReset();
        }

        /// <summary>
        /// 終了リンクボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("KouritenRegistrationAchievements.aspx");
        }
        /// <summary>
        /// 商品コードリンクラベル()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnlblShohinCode_Click(object sender, EventArgs e)
        {
            sShohinCodeReference = ((LinkButton)sender).Text.TrimEnd();
            Session["sShohinCodeReference"] = sShohinCodeReference;

            Response.Redirect("KouritenRegistrationAchievements.aspx");
        }
        /// <summary>
        /// 初期化
        /// </summary>
        private void ScreenReset()
        {
            lblMessage.Text = "";
            txtShohinNameSearch.Text = "";

            ddlShohinCodeStart.SelectedIndex= 0;
            ddlShohinCodeEnd.SelectedIndex= 0;

            gvShohinList.ShowHeaderWhenEmpty = true;
            gvShohinList.DataSource = new List<object>();
            gvShohinList.DataBind();
        }

        /// <summary>
        /// 数値入力チェック
        /// </summary>
        /// <param name="num">文字列型数値</param>
        /// <returns></returns>
        private bool NumberCheck(string sNum, ref int nNum)
        {
            int number;
            if (int.TryParse(sNum, out number))
            {
                if (number >= 0)
                {
                    nNum = number;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

       
    }
}