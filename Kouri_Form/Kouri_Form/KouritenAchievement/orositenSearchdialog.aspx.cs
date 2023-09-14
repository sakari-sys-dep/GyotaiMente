using Kouri_Form.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Collections;

namespace Kouri_Form.Models
{
    public class Todoufuken
    {
        public string FukenCode { get; set; }//都道府県コード
        public string sFukenName { get; set; }//都道府県名
    }
    public class Tiku
    {
        public string Tikicode { get; set; }//地域コード
        public string TikuName { get; set; }//地区名
        public string TikicodeSearch { get; set; } //検索用地域コード

    }
    public class TENPO    
    {
        public string km04d_orosi_cd { get; set; }//卸店コード
        public string km04d_name_k { get; set; }
        public string km04d_br_name_k { get; set; }
    }

    public partial class orositenSearchdialog : System.Web.UI.Page
    {
        public bool bOSDStartup = false;
        public List<Todoufuken> TodoufukenList;
        public List<Tiku> TikuList;

        public string sFukencode;
        public string sTikicode;
        public string sFukencodeSearch;
        public string sTikicodeSearch;

        public const string listtext = "未選択";

        public string sOrosicode { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ScreenReset();
                lblMessage.Text = "";
                ddlTikuList.Items.Clear();
                ddlTikuList.Items.Add(listtext);

                //府県のデータの表示
                TodoufukenList = new List<Todoufuken>();
                Todoufuken tf;
                //都道府県List表示
                ddlFukenList.Items.Clear();
                DataTable dt = new DataTable();
                Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
                if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelecteKM31dTodoufuken().ToString(), ref dt)) > 0)
                {
                    ddlFukenList.Items.Add(listtext);
                    foreach (DataRow dr in dt.Rows)
                    {
                        tf = new Todoufuken();
                        tf.FukenCode = dr[0].ToString();
                        tf.sFukenName = dr[1].ToString();
                        TodoufukenList.Add(tf);
                        ddlFukenList.Items.Add(tf.FukenCode + "：" + tf.sFukenName);
                    }
                    Session["TodoufukenList"] = TodoufukenList;
                }
                else
                {
                    lblMessage.Text += "地域マスタの府県がございません。";
                    lblMessage.Text += "登録をお願いいたします。";
                }
            }
        }
        /// <summary>
        /// 府県リストから選択されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlFukenList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFukenList.SelectedValue.ToString() == listtext)
            {
                ddlFukenList.SelectedIndex = 0;
                return;
            }
            //コード取得
            string Fuken = ddlFukenList.SelectedValue.ToString();
            sFukencode = Fuken.Split('：')[0];

            TikuList = new List<Tiku>();
            Tiku tk;
            ddlTikuList.Items.Clear();

            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.TIKIMASTER_TODOUHUKEN_CD, sFukencode.TrimEnd());
            if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelecteKM31dTiku().ToString(), paramDict, ref dt)) > 0)
            {
                ddlTikuList.Items.Add(listtext);
                foreach (DataRow dr in dt.Rows)
                {
                    tk = new Tiku();
                    tk.Tikicode = dr[0].ToString();
                    tk.TikuName = dr[1].ToString();
                    tk.TikicodeSearch = dr[2].ToString();
                    TikuList.Add(tk);
                    ddlTikuList.Items.Add(tk.Tikicode + "：" + tk.TikuName);
                }
                ddlTikuList.SelectedIndex = 1;
            }
            else
            {
                lblMessage.Text += "地域マスタの地区がございません。";
                lblMessage.Text += "登録をお願いいたします。";

            }
            Session["TikuList"] = TikuList;
        }

        /// <summary>
        /// 照会ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnSyoukai_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            //未選択の有無
            if (ddlFukenList.SelectedValue.ToString() == listtext && ddlTikuList.SelectedValue.ToString() == listtext)
            {
                //未入力の場合
                if (string.IsNullOrEmpty(txtOrositenCode.Text.TrimEnd()) && string.IsNullOrEmpty(txtOroitenName.Text.TrimEnd()))
                {
                    lblMessage.Text += "リストを選択するかテキストを入力してください。" + "</BR>";
                    return;
                }

                DataTable dt = new DataTable();
                Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
                paramDict.Add(constSql.KM04D_OROSI_CD, "%" + txtOrositenCode.Text + "%".TrimEnd());
                paramDict.Add(constSql.OROSHI_SHITEN_NAME, "%" + txtOroitenName.Text + "%".TrimEnd());
                if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectekm04dShitenTextSearch().ToString(), paramDict, ref dt)) > 0)
                {
                    gvOrositen.DataSource = dt;
                    gvOrositen.DataBind();
                    lblkensu.Text = dt.Rows.Count.ToString() + "件";
                }
            }
            else
            {
                //府県のみの選択の有無
                if (ddlFukenList.SelectedValue.ToString() != listtext
                && ddlTikuList.SelectedValue.ToString() == listtext)
                {
                    string Fuken = ddlFukenList.SelectedValue.ToString();
                    sFukencode = Fuken.Split('：')[0];

                    DataTable dt = new DataTable();
                    Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
                    paramDict.Add(constSql.KM31D_FUKEN, sFukencode.TrimEnd());
                    paramDict.Add(constSql.KM04D_OROSI_CD, "%" + txtOrositenCode.Text + "%".TrimEnd());
                    paramDict.Add(constSql.OROSHI_SHITEN_NAME, "%" + txtOroitenName.Text + "%".TrimEnd());
                    if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectkm04dfukenListSearch().ToString(), paramDict, ref dt)) > 0)
                    {
                        gvOrositen.DataSource = dt;
                        gvOrositen.DataBind();
                        lblkensu.Text = dt.Rows.Count.ToString() + "件";
                    }
                    else
                    {
                        lblMessage.Text += "以下の条件内容で検索することができませんでした" + "</BR>";
                        lblMessage.Text += "府県：" + sFukencode.TrimEnd() + "</BR>";
                        lblMessage.Text += "卸店コード" + txtOrositenCode.Text + "</BR>";
                        lblMessage.Text += "名称：" + txtOroitenName.Text + "</BR>";
                    }
                }
                else
                {
                    if (ddlFukenList.SelectedValue.ToString() == listtext)
                    {
                        ddlTikuList.SelectedIndex = 0;
                        return;
                    }

                    string Fuken = ddlFukenList.SelectedValue.ToString();
                    sFukencode = Fuken.Split('：')[0];
 
                    TikuList = (List<Tiku>)Session["TikuList"];
                    string Tiku = ddlTikuList.SelectedValue.ToString();
                    sTikicode = Tiku.Split('：')[0];

                    for (int i = 0; i < TikuList.Count; i++)
                    {
                        Tiku TikuRow = TikuList.ElementAt(i);
                        if (TikuRow.Tikicode == sTikicode)
                        {
                            sTikicodeSearch = TikuRow.TikicodeSearch;
                            break;
                        }
                    }
                    DataTable dt = new DataTable();
                    Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
                    paramDict.Add(constSql.KM31D_FUKEN, sFukencode.TrimEnd());
                    paramDict.Add(constSql.KM31D_CHIKU, sTikicodeSearch.TrimEnd());
                    paramDict.Add(constSql.KM04D_OROSI_CD, "%" + txtOrositenCode.Text + "%".TrimEnd());
                    paramDict.Add(constSql.OROSHI_SHITEN_NAME, "%" + txtOroitenName.Text + "%".TrimEnd());

                    if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectkm04dShitenListSearch().ToString(), paramDict, ref dt)) > 0)
                    {
                        gvOrositen.DataSource = dt;
                        gvOrositen.DataBind();
                        lblkensu.Text = dt.Rows.Count.ToString() + "件";
                    }
                    else
                    {
                        lblMessage.Text += "以下の条件内容で検索することができませんでした"+ "</BR>";
                        lblMessage.Text += "府県："+ sFukencode.TrimEnd() + "</BR>";
                        lblMessage.Text += "地区："+ sTikicodeSearch.TrimEnd() + "</BR>";
                        lblMessage.Text += "卸店コード"+ txtOrositenCode.Text + "</BR>";
                        lblMessage.Text += "名称：" + txtOroitenName.Text + "</BR>";
                    }
                }
            }
        }

        /// <summary>
        /// 初期状態
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnSyokiset_Click(object sender, EventArgs e)
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
        /// GridView内のリンクボタン押下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnsOroshiCode_Click(object sender, EventArgs e)
        {
            sOrosicode = ((LinkButton)sender).Text.TrimEnd();
            Session["sOrosicode"] = sOrosicode;

            Response.Redirect("KouritenRegistrationAchievements.aspx");
        }
        
        /// <summary>
        /// 初期状態
        /// </summary>
        private void ScreenReset()
        {
            lblkensu.Text = "0件";
            txtOrositenCode.Text = "";
            txtOroitenName.Text = "";
            lblMessage.Text = "";

            ddlFukenList.SelectedIndex = 0;

            ddlTikuList.Items.Clear();
            ddlTikuList.Items.Add(listtext);

            gvOrositen.ShowHeaderWhenEmpty = true;
            gvOrositen.DataSource = new List<object>();
            gvOrositen.DataBind();
        }
    }
}