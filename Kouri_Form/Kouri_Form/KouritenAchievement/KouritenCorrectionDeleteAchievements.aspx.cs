using Kouri_Form.Class;
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;
using System.Collections;

namespace Kouri_Form.Models
{
    public class SAKEHANJISSEKISYUUSEI
    {
        public string sKm08d_ymd;//年月日

        public string sKm08d_OroshiTenCode;// 卸店コード

        public string sKm08d_KotenCode;// 個店コード

        public string sSohinCode;//商品コード

        public string sSohinName;//商品名

        public string sSohinboxiri;//入数

        public string shakosu;//ケース数

        public string sHasu;//バラ数

        public string sHasuGoukei; //合計
    }

    public partial class KouritenCorrectionDeleteAchievements : System.Web.UI.Page
    {
        public DateTime dateTime = DateTime.Now;
        DataTable DTJissekiList;

        public bool ScreenSwitchingFlg = false;

        public int nStartUpYearIndex;
        public int nStartUpMonthIndex;
        public int nYearIndex;
        public int nMonthIndex;
        public string sOroshiTenCode;
        public string sKotenCode;
        public string sYmd;
        public int  ListrowIndex;

        public int ListdataRowIndex=0;

        public List<SAKEHANJISSEKISYUUSEI> JISSEKILsit;

        public bool InputValueCheck = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitialScreen();

                ddlYear.SelectedIndex = 1;
                ddlMonth.SelectedIndex = dateTime.Month - 1;

                if (Session["nStartUpYearIndex"] != null && Session["nStartUpMonthIndex"] != null)
                {
                    nStartUpYearIndex = (int)Session["nStartUPYearIndex"];
                    nStartUpMonthIndex = (int)Session["nStartUPMonthIndex"];

                    ddlYear.SelectedIndex = nStartUpYearIndex;
                    ddlMonth.SelectedIndex = nStartUpMonthIndex;
                    Session["nStartUpYearIndex"] = null;
                    Session["nStartUpMonthIndex"] = null;
                }
            }

            if (Session["sOrosicode"] != null)
            {
                txtOroshiTenCode.Text = (string)Session["sOrosicode"];
                Session["sOrosicode"] = null;
            }

            //リストのカラムの表示
            gvSakehanbaitenPerInfoList.Columns[1].Visible = true;//商品コード
            gvSakehanbaitenPerInfoList.Columns[2].Visible = true;//商品名
            gvSakehanbaitenPerInfoList.Columns[5].Visible = true;//バラ数
                                                                 
            //リストのカラムの非表示
            gvSakehanbaitenPerInfoList.Columns[3].Visible = false;//入数
            gvSakehanbaitenPerInfoList.Columns[4].Visible = false;//ケース数
            gvSakehanbaitenPerInfoList.Columns[6].Visible = false;//バラ数(合計)

            gvSakehanbaitenPerInfoList.Columns[7].Visible = false;//卸店コード(読取専用)
            gvSakehanbaitenPerInfoList.Columns[8].Visible = false;//個店コード(読取専用)
            gvSakehanbaitenPerInfoList.Columns[9].Visible = false;//日付(読取専用)
            gvSakehanbaitenPerInfoList.Columns[10].Visible = false;//商品コード(読取専用)
            gvSakehanbaitenPerInfoList.Columns[11].Visible = false;//ケース数(読取専用)
            gvSakehanbaitenPerInfoList.Columns[12].Visible = false;//バラ数(読取専用)
        }

        #region 卸店コード検索画面ボタン
        /// <summary>
        /// 卸店コード検索画面ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOroshiuritenSearch_Click(object sender, EventArgs e)
        {
            nStartUpYearIndex = ddlYear.SelectedIndex;
            nStartUpMonthIndex = ddlMonth.SelectedIndex;

            Session["nStartUpYearIndex"] = nStartUpYearIndex;
            Session["nStartUpMonthIndex"] = nStartUpMonthIndex;

            Response.Redirect("orositenSearchdialog.aspx");
        }
        #endregion

        #region 個店ボタン
        /// <summary>
        /// 個店ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnKotenSearch_Click(object sender, EventArgs e)
        {
            //使う予定がない
        }
        #endregion

        #region 確認リンクボタン
        /// <summary>
        /// 確認リンクボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnConfirm_Click(object sender, EventArgs e)
        {
            lblMeesageDis.Text = "";

            //卸店コード・個店コード入力チェック
            if (CodeDataCheck() == false) return;

            sOroshiTenCode = txtOroshiTenCode.Text.TrimEnd();
            sKotenCode = txtKotenCode.Text.TrimEnd();

            nYearIndex= ddlYear.SelectedIndex;
            nMonthIndex= ddlMonth.SelectedIndex;

            //表示する
            ListDataUpdate(sOroshiTenCode, sKotenCode, nYearIndex, nMonthIndex);
        }
        #endregion

        #region 修正リンクボタン
        /// <summary>
        /// 修正リンクボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnUpdate_Click(object sender, EventArgs e)
        {
            lblMeesageDis.Text = "";
            string sOroshiTenCodeRO = "";
            string sKotenCodeRO = "";
            string sYmdRO = "";

            if (Session["sOroshiCode"] == null ||
            Session["sKotenCode"] == null ||
            Session["nYearIndex"] == null ||
            Session["nMonthIndex"] == null)
            {
                return;
            }

            InputValueCheck = true;

            //変更処理
            for (int i = 0; i < gvSakehanbaitenPerInfoList.Rows.Count; i++)
            {
                GridViewRow rowIndex = gvSakehanbaitenPerInfoList.Rows[i];
                System.Web.UI.WebControls.Label OroshiTenCodeReadOnly = (System.Web.UI.WebControls.Label)rowIndex.FindControl("lblOroshiTenCodeReadOnly");//卸店コード
                System.Web.UI.WebControls.Label KotenCodeReadOnly = (System.Web.UI.WebControls.Label)rowIndex.FindControl("lblKotenCodeReadOnly");//個店コード
                System.Web.UI.WebControls.Label YmdReadOnly = (System.Web.UI.WebControls.Label)rowIndex.FindControl("lblYmdReadOnly");//日付
                System.Web.UI.WebControls.TextBox ShohinCd = (System.Web.UI.WebControls.TextBox)rowIndex.FindControl("txtShohinCd");//商品コード
                System.Web.UI.WebControls.Label ShohinCdReadOnly = (System.Web.UI.WebControls.Label)rowIndex.FindControl("lblShohinCdReadOnly");//商品コード(読取専用)
                System.Web.UI.WebControls.TextBox Hasu = (System.Web.UI.WebControls.TextBox)rowIndex.FindControl("txtHasu");//バラ数(テキスト)
                System.Web.UI.WebControls.Label HasuReadOnly = (System.Web.UI.WebControls.Label)rowIndex.FindControl("lblHasuReadOnly");//バラ数(読取専用)

                if (string.IsNullOrEmpty(OroshiTenCodeReadOnly.Text) &&
                    string.IsNullOrEmpty(KotenCodeReadOnly.Text) &&
                    string.IsNullOrEmpty(YmdReadOnly.Text))
                {
                    continue;
                }
                else
                {
                    sOroshiTenCodeRO = OroshiTenCodeReadOnly.Text;
                    sKotenCodeRO = KotenCodeReadOnly.Text;
                    sYmdRO = YmdReadOnly.Text;
                }

                if (string.IsNullOrEmpty(ShohinCd.Text) &&
                    string.IsNullOrEmpty(Hasu.Text)) continue;

                    if (string.IsNullOrEmpty(ShohinCd.Text)　||
                    string.IsNullOrEmpty(Hasu.Text))
                {
                    lblMeesageDis.Text += "以下の項目のうちにいくつか空白がございます。" + "</BR>";
                    lblMeesageDis.Text += "商品コード：" + ShohinCd.Text + "</BR>";
                    lblMeesageDis.Text += "バラ数：" + Hasu.Text + "</BR>";
                    lblMeesageDis.Text += "<HR>";
                    InputValueCheck = false;
                }

                int nInputNum = 0;
                if (NumberCheck(Hasu.Text, ref nInputNum) == false)
                {
                    lblMeesageDis.Text += "下記のバラ数の数値が数値ではありません。" + "</BR>";
                    lblMeesageDis.Text += "商品コード：" + ShohinCd.Text + "</BR>";
                    lblMeesageDis.Text += "バラ数：" + Hasu.Text + "</BR>";
                    lblMeesageDis.Text += "<HR>";
                    InputValueCheck = false;
                }
                else if (nInputNum <= 0)//数値チェック
                {
                    lblMeesageDis.Text += "下記のバラ数の数値が0以下です。" + "</BR>";
                    lblMeesageDis.Text += "商品コード：" + ShohinCd.Text + "</BR>";
                    lblMeesageDis.Text += "バラ数：" + Hasu.Text + "</BR>";
                    lblMeesageDis.Text += "<HR>";
                    InputValueCheck = false;
                }
                //桁数制限
                if (Hasu.Text.Length > 7)
                {
                    lblMeesageDis.Text += "下記のバラ数の数値が7桁以上です。" + "</BR>";
                    lblMeesageDis.Text += "商品コード：" + ShohinCd.Text + "</BR>";
                    lblMeesageDis.Text += "バラ数：" + Hasu.Text + "</BR>";
                    lblMeesageDis.Text += "<HR>";
                    InputValueCheck = false;
                }

                if (InputValueCheck == false) continue;

                if (Hasu.Text.TrimEnd() != HasuReadOnly.Text.TrimEnd())
                {
                    /*変更処理*/
                    //DataTable dt = new DataTable();
                    Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
                    paramDict.Add(constSql.OROSI_CD_KETUGO, OroshiTenCodeReadOnly.Text.TrimEnd());//卸店コード
                    paramDict.Add(constSql.KM08D_TEN_CD, KotenCodeReadOnly.Text.TrimEnd());//個店コード
                    paramDict.Add(constSql.KM08D_DATA_YM, YmdReadOnly.Text.TrimEnd());//日付
                    paramDict.Add(constSql.KM08D_SHO_CD, ShohinCd.Text.TrimEnd());//商品コード
                    paramDict.Add(constSql.KM08D_HASU, Hasu.Text.TrimEnd());//バラ数

                    DBManager db = new DBManager();
                    try
                    {
                        db.Connect("dbret", -1);
                        db.BeginTransaction();
                        db.ExecuteNonQuery(constSql.CreateSqlUpdatekm08d().ToString(), paramDict);
                        db.CommitTransaction();
                        lblMeesageDis.Text += "下記のバラ数が変更されました。" + "</BR>";
                        lblMeesageDis.Text += "商品コード：" + ShohinCd.Text.TrimEnd() + "</BR>";
                        lblMeesageDis.Text += "変更前：" + HasuReadOnly.Text.TrimEnd() + "</BR>";
                        lblMeesageDis.Text += "変更後：" + Hasu.Text.TrimEnd() + "</BR>";
                        lblMeesageDis.Text += "<HR>";
                        InputValueCheck = true;
                    }
                    catch (Exception ex)
                    {
                        db.RollbackTransaction();
                        lblMeesageDis.Text += "下記変更処理でエラーが発生しました。 " + "</BR>";
                        lblMeesageDis.Text += "商品コード：" + ShohinCd.Text.TrimEnd() + "</BR>";
                        lblMeesageDis.Text += "変更前：" + HasuReadOnly.Text.TrimEnd() + "</BR>";
                        lblMeesageDis.Text += "変更後：" + Hasu.Text.TrimEnd() + "</BR>";
                        lblMeesageDis.Text += "エラーメッセージ：" + ex.Message + "</BR>";
                        lblMeesageDis.Text += "エラー場所      ：" + ex.Source + "</BR>";
                        lblMeesageDis.Text += "変更処理を中断いたしました。" + "</BR>";
                        lblMeesageDis.Text += "<HR>";
                        InputValueCheck = false;
                        throw ex;
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                }
            }

            if (InputValueCheck == false)
            {
                lblMeesageDis.Text += "上記の件で修正できませんでしたのでもう一度お願いいたします。" + "</BR>";
                lblMeesageDis.Text += "<HR>";
            }

            if (string.IsNullOrEmpty(sOroshiTenCodeRO) ||
                string.IsNullOrEmpty(sKotenCodeRO) ||
                string.IsNullOrEmpty(sYmdRO))
            {
                return;
            }

            InputValueCheck = true;
            JISSEKILsit = new List<SAKEHANJISSEKISYUUSEI>();
            //追加登録処理
            for (int i = 0; i < gvSakehanbaitenPerInfoList.Rows.Count; i++)
            {
                SAKEHANJISSEKISYUUSEI shjList = new SAKEHANJISSEKISYUUSEI();
                GridViewRow rowIndex = gvSakehanbaitenPerInfoList.Rows[i];
                System.Web.UI.WebControls.Label OroshiTenCodeReadOnly = (System.Web.UI.WebControls.Label)rowIndex.FindControl("lblOroshiTenCodeReadOnly");//卸店コード(読取専用)
                System.Web.UI.WebControls.Label KotenCodeReadOnly = (System.Web.UI.WebControls.Label)rowIndex.FindControl("lblKotenCodeReadOnly");//個店コード(読取専用)
                System.Web.UI.WebControls.Label YmdReadOnly = (System.Web.UI.WebControls.Label)rowIndex.FindControl("lblYmdReadOnly");//日付(読取専用)
                System.Web.UI.WebControls.TextBox ShohinCd = (System.Web.UI.WebControls.TextBox)rowIndex.FindControl("txtShohinCd");//商品コード
               // System.Web.UI.WebControls.TextBox Hakosu = (System.Web.UI.WebControls.TextBox)rowIndex.FindControl("txtHakosu");　　//ケース数は 0で登録する。
                System.Web.UI.WebControls.TextBox Hasu = (System.Web.UI.WebControls.TextBox)rowIndex.FindControl("txtHasu");//バラ数(テキスト)

                if (string.IsNullOrEmpty(OroshiTenCodeReadOnly.Text) &&
                    string.IsNullOrEmpty(KotenCodeReadOnly.Text) &&
                    string.IsNullOrEmpty(YmdReadOnly.Text))
                {
                    if (string.IsNullOrEmpty(ShohinCd.Text) &&
                       string.IsNullOrEmpty(Hasu.Text)) continue;

                        if (string.IsNullOrEmpty(ShohinCd.Text) ||
                       string.IsNullOrEmpty(Hasu.Text))
                    {
                        lblMeesageDis.Text += "以下の項目のうち空白がございます。" + "</BR>";
                        lblMeesageDis.Text += "商品コード：" + ShohinCd.Text + "</BR>";
                        lblMeesageDis.Text += "バラ数：" + Hasu.Text + "</BR>";
                        lblMeesageDis.Text += "<HR>";

                        InputValueCheck = false;
                    }
                    else
                    {
                        //数値チェック
                        int nInputNum = 0;
                        if (NumberCheck(Hasu.Text, ref nInputNum) == false)
                        {
                            lblMeesageDis.Text += "※下記の行で数値ではないあるいはマイナスの記載がございます。※" + "</BR>";
                            lblMeesageDis.Text += (i + 1).ToString() + "行目" + "</BR>";
                            lblMeesageDis.Text += "商品コード：" + ShohinCd.Text + "</BR>";
                            lblMeesageDis.Text += "バラ数：" + Hasu.Text + "</BR>";
                            lblMeesageDis.Text += "<HR>";
                            InputValueCheck = false;

                            if (InputValueCheck == true)
                            {
                                if (nInputNum == 0)
                                {
                                    lblMeesageDis.Text += "※下記の行でバラ数を1以上入力してください。※" + "</BR>";
                                    lblMeesageDis.Text += (i + 1).ToString() + "行目" + "</BR>";
                                    lblMeesageDis.Text += "商品コード：" + ShohinCd.Text + "</BR>";
                                    lblMeesageDis.Text += "バラ数：" + Hasu.Text + "</BR>";
                                    lblMeesageDis.Text += "<HR>";
                                    InputValueCheck = false;
                                }
                            }

                            //桁数制限
                            if (InputValueCheck == true)
                            {
                                if (ShohinCd.Text.Length > 5)
                                {
                                    lblMeesageDis.Text += "※下記の行の商品コードの桁数が6桁以上超えています※" + "</BR>";
                                    lblMeesageDis.Text += (i + 1).ToString() + "行目" + "</BR>";
                                    lblMeesageDis.Text += "商品コード：" + ShohinCd.Text + "</BR>";
                                    lblMeesageDis.Text += "<HR>";
                                    InputValueCheck = false;
                                }

                                if (Hasu.Text.Length > 7)
                                {
                                    lblMeesageDis.Text += "※下記の行のバラ数の桁数が7桁以上超えています※" + "</BR>";
                                    lblMeesageDis.Text += (i + 1).ToString() + "行目" + "</BR>";
                                    lblMeesageDis.Text += "バラ数：" + Hasu.Text + "</BR>";
                                    lblMeesageDis.Text += "<HR>";
                                    InputValueCheck = false;
                                }
                            }
                        }
                    }

                    if (InputValueCheck == true)
                    {
                        //マスタの商品コードが存在しているかのチェック
                        DataTable dt = new DataTable();
                        Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
                        paramDict.Add(constSql.SHOHN_SHOHIN_CD, ShohinCd.Text.PadLeft(5, '0').TrimEnd());//日付

                        if ((DBManager.GetTableData("dbret", constSql.CreateSqlselectSHOHNshohincodeCheck().ToString(), paramDict, ref dt)) > 0)
                        {
                           //未処理
                        }
                        else
                        {
                            lblMeesageDis.Text += "商品マスタに「" + ShohinCd.Text.PadLeft(5, '0').TrimEnd() + "」が存在しません。" + "</BR>";
                            lblMeesageDis.Text += "商品マスタに新規登録するか間違っていないかの確認をお願いいたします。" + "</BR>";
                            lblMeesageDis.Text += "<HR>";
                            InputValueCheck = false;
                        }

                        if (InputValueCheck == true)
                        {
                            //実績に値がすでに登録しているかのチェック
                            dt = new DataTable();
                            paramDict = new Dictionary<string, Object>();
                            paramDict.Add(constSql.OROSI_CD_KETUGO, sOroshiTenCodeRO.PadLeft(5, '0').TrimEnd());//卸店コード
                            paramDict.Add(constSql.KM08D_TEN_CD, sKotenCodeRO.PadLeft(8, '0').TrimEnd());//個店コード
                            paramDict.Add(constSql.KM08D_DATA_YM, sYmdRO.TrimEnd());//日付
                            paramDict.Add(constSql.KM08D_SHO_CD, ShohinCd.Text.TrimEnd());//商品コード

                            if ((DBManager.GetTableData("dbret", constSql.CreateSqlselectKM08DataExistenceCheck().ToString(), paramDict, ref dt)) > 0)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    if (1 <= (int)dr[0])
                                    {
                                        lblMeesageDis.Text += "※下記の値はすでに登録されています。※" + "</BR>";
                                        lblMeesageDis.Text += (i + 1).ToString() + "行目" + "</BR>";
                                        lblMeesageDis.Text += "卸店コード：" + sOroshiTenCodeRO.TrimEnd() + "</BR>";
                                        lblMeesageDis.Text += "個店コード：" + sKotenCodeRO.TrimEnd() + "</BR>";
                                        lblMeesageDis.Text += "日付：" + sYmdRO + "</BR>";
                                        lblMeesageDis.Text += "商品コード：" + ShohinCd.Text + "</BR>";
                                        lblMeesageDis.Text += "<HR>";
                                        InputValueCheck = false;
                                    }
                                }
                            }
                        }
                    }

                    if (InputValueCheck == false) continue;

                    shjList.sKm08d_OroshiTenCode = sOroshiTenCodeRO.PadLeft(5, '0');
                    shjList.sKm08d_KotenCode = sKotenCodeRO.PadLeft(8, '0');
                    shjList.sKm08d_ymd = sYmdRO.PadLeft(6, '0');
                    shjList.sSohinCode = ShohinCd.Text.PadLeft(5, '0');
                    shjList.shakosu = "0";
                    shjList.sHasu = Hasu.Text;
                    JISSEKILsit.Add(shjList);
                }
            }
            if (JISSEKILsit == null || JISSEKILsit.Count <= 0)
            {
                return;
            }

            if (InputValueCheck ==true)
            {
                List<string> sShohinList = new List<string>();
                foreach (SAKEHANJISSEKISYUUSEI shjList in JISSEKILsit)
                {
                    sShohinList.Add(shjList.sSohinCode);
                }

                //登録しようとする商品コードが重複していないかのチェック
                Boolean isDistinct = sShohinList.GroupBy(x => x).All(g => g.Count() == 1);
                if (isDistinct == false)
                {
                    List<string> ShohinCodeResult = sShohinList.GroupBy(x => x).Where(g => g.Count() > 1).Select(x => x.Key).ToList();
                    lblMeesageDis.Text += "※下記の商品コードが重複しています。入力し直してください。※" + "</BR>";
                    lblMeesageDis.Text += "商品コード：" + String.Join(", ", ShohinCodeResult) + "</BR>";
                    lblMeesageDis.Text += "<HR>";
                    JISSEKILsit = new List<SAKEHANJISSEKISYUUSEI>();
                    return;
                }

                foreach (SAKEHANJISSEKISYUUSEI shjList in JISSEKILsit)
                {
                    //登録処理
                    DataTable dt = new DataTable();
                    Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
                    paramDict.Add(constSql.KM08D_OROSI_TEN, shjList.sKm08d_OroshiTenCode.Substring(0, 3).TrimEnd());//[km08d_orosi_ten]
                    paramDict.Add(constSql.KM08D_OROSI_BRCH, shjList.sKm08d_OroshiTenCode.Substring(3, 2).TrimEnd());//[km08d_orosi_brch]
                    paramDict.Add(constSql.KM08D_DATA_YM, shjList.sKm08d_ymd.TrimEnd());//[km08d_data_ym]
                    paramDict.Add(constSql.KM08D_HAKOSU, "0".TrimEnd()); //[km08d_hakosu]
                    paramDict.Add(constSql.KM08D_HASU, shjList.sHasu.ToString().TrimEnd());//[km08d_hasu]
                    paramDict.Add(constSql.KM08D_PRI_KBN, "0".TrimEnd());//[km08d_pri_kbn]
                    paramDict.Add(constSql.KM08D_SHO_CD, shjList.sSohinCode.TrimEnd());//[km08d_sho_cd]
                    paramDict.Add(constSql.KM08D_TEN_CD, shjList.sKm08d_KotenCode.TrimEnd());//[km08d_ten_cd]
                    paramDict.Add(constSql.KM08D_YMD, shjList.sKm08d_ymd + "99".TrimEnd());//[km08d_ymd]

                    DBManager db = new DBManager();
                    try
                    {
                        db.Connect("dbret", -1);
                        db.BeginTransaction();
                        db.ExecuteNonQuery(constSql.CreateSqlinsertkm08d().ToString(), paramDict);
                        db.CommitTransaction();
                        lblMeesageDis.Text += "下記の登録が完了いたしました。" + "</BR>";
                        lblMeesageDis.Text += "商品コード：" + shjList.sSohinCode + "</BR>";
                        lblMeesageDis.Text += "バラ数：" + shjList.sHasu + "</BR>";
                        lblMeesageDis.Text += "<HR>";
                    }
                    catch (Exception ex)
                    {
                        db.RollbackTransaction();

                        lblMeesageDis.Text += "下記登録処理でエラーが発生しました。 " + "</BR>";
                        lblMeesageDis.Text += "商品コード：" + shjList.sSohinCode + "</BR>";
                        lblMeesageDis.Text += "バラ数：" + shjList.sHasu + "</BR>";
                        lblMeesageDis.Text += "エラーメッセージ：" + ex.Message + "</BR>";
                        lblMeesageDis.Text += "エラー場所      ：" + ex.Source + "</BR>";
                        lblMeesageDis.Text += "登録処理を中断いたしました。" + "</BR>";
                        lblMeesageDis.Text += "<HR>";
                        throw ex;
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                }
            }
 
            if (InputValueCheck == false)
            {
                lblMeesageDis.Text += "上記の件で登録できませんでしたのでもう一度お願いいたします。" + "</BR>";
                lblMeesageDis.Text += "<HR>";
                return;
            }

            ListDataUpdate();
        }
        #endregion

        #region キャンセルリンクボタン
        /// <summary>
        /// キャンセルリンクボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnCancel_Click(object sender, EventArgs e)
        {
            lblMeesageDis.Text = "";
            InitialScreen();

        }
        #endregion

        #region 削除リンクボタン
        /// <summary>
        /// 削除リンクボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            lblMeesageDis.Text = "";

            if (Session["sOroshiCode"] == null || 
                Session["sKotenCode"] == null || 
                Session["nYearIndex"] == null || 
                Session["nMonthIndex"] == null)
            {
                return;
            }

            for (int i =0; i< gvSakehanbaitenPerInfoList.Rows.Count; i++)
            {
                GridViewRow rowIndex = gvSakehanbaitenPerInfoList.Rows[i];
                System.Web.UI.WebControls.CheckBox check = (System.Web.UI.WebControls.CheckBox)rowIndex.FindControl("chkDelete");

                //チェックした値のみを格納する
                if (check.Checked)
                {
                    System.Web.UI.WebControls.Label OroshiTenCode = (System.Web.UI.WebControls.Label)rowIndex.FindControl("lblOroshiTenCodeReadOnly");//卸店コード
                    System.Web.UI.WebControls.Label KotenCode = (System.Web.UI.WebControls.Label)rowIndex.FindControl("lblKotenCodeReadOnly");//個店コード
                    System.Web.UI.WebControls.Label Ymd = (System.Web.UI.WebControls.Label)rowIndex.FindControl("lblYmdReadOnly");//日付
                    System.Web.UI.WebControls.Label ShohinCdReadOnly = (System.Web.UI.WebControls.Label)rowIndex.FindControl("lblShohinCdReadOnly");//商品コード

                    if (string.IsNullOrEmpty(OroshiTenCode.Text) &&
                        string.IsNullOrEmpty(KotenCode.Text) &&
                        string.IsNullOrEmpty(Ymd.Text))
                    {
                        continue;
                    }

                    if (string.IsNullOrEmpty(ShohinCdReadOnly.Text))
                    {
                        lblMeesageDis.Text += (i+1)+ "行目の商品コードがありません。" + "</BR>";
                        lblMeesageDis.Text += "<HR>";
                        continue;
                    }

                    /*削除処理*/
                    DataTable dt = new DataTable();
                    Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
                    paramDict.Add(constSql.OROSI_CD_KETUGO, OroshiTenCode.Text.TrimEnd());//卸店コード
                    paramDict.Add(constSql.KM08D_TEN_CD, KotenCode.Text.TrimEnd());//個店コード
                    paramDict.Add(constSql.KM08D_DATA_YM, Ymd.Text.TrimEnd());//日付
                    paramDict.Add(constSql.KM08D_SHO_CD, ShohinCdReadOnly.Text.TrimEnd());//商品コード

                    DBManager db = new DBManager();
                    try
                    {
                        db.Connect("dbret", -1);
                        db.BeginTransaction();
                        db.ExecuteNonQuery(constSql.CreateSqldeleteKM08D().ToString(), paramDict);
                        db.CommitTransaction();
                        lblMeesageDis.Text +=(i+1)+"行目の"+"削除処理が完了しました。 " + "</BR>";
                        lblMeesageDis.Text += "卸店コード：" + OroshiTenCode.Text + "</BR>";
                        lblMeesageDis.Text += "個店コード：" + KotenCode.Text + "</BR>";
                        lblMeesageDis.Text += "日付：" + Ymd.Text + "</BR>";
                        lblMeesageDis.Text += "商品コード：" + ShohinCdReadOnly.Text + "</BR>";
                        lblMeesageDis.Text += "<HR>";

                        sOroshiTenCode = OroshiTenCode.Text;
                        sKotenCode = KotenCode.Text;
                    }
                    catch (Exception ex)
                    {
                        db.RollbackTransaction();

                        lblMeesageDis.Text +="下記削除処理でエラーが発生しました。 " + "</BR>";

                        lblMeesageDis.Text +="エラーメッセージ：" + ex.Message + "</BR>";
                        lblMeesageDis.Text +="エラー場所      ：" + ex.Source + "</BR>";
                        lblMeesageDis.Text +="削除処理を中断いたしました。" + "</BR>";
                        lblMeesageDis.Text += "<HR>";
                        throw ex;
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                }
            }
            ListDataUpdate();
        }
        #endregion

        #region メニューに戻る(リンクボタン)
        /// <summary>
        /// メニューに戻る(リンクボタン)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnBackMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("AchievementRegistrationMenu.aspx");
        }
        #endregion

        #region Listのテキストが入力されたときに発生
        /// <summary>
        /// Listのテキストが入力されたときに発生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtListTextInputValue_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = dtJissekiDataList();

            List<DataRow> drJissekiList = dt.AsEnumerable().ToList<DataRow>();

            DataTable dtAdd = dtJissekidataAdd();
            DataRow drAdd;
            for (int i = 0; i < drJissekiList.Count; i++)
            {
                drAdd = dtAdd.NewRow();
                if (drJissekiList.Count - 1 == i)
                {
                    if (string.IsNullOrEmpty((string)drJissekiList[i][1]) && string.IsNullOrEmpty((string)drJissekiList[i][5]))
                    {
                        continue;
                    }
                    if (!string.IsNullOrEmpty((string)drJissekiList[i][1]) && !string.IsNullOrEmpty((string)drJissekiList[i][5]))
                    {
                        drJissekiList.Add(drAdd);
                        break;
                    }
                }

                if (string.IsNullOrEmpty((string)drJissekiList[i][1]) && string.IsNullOrEmpty((string)drJissekiList[i][5]))
                {
                    drJissekiList.RemoveAt(i);
                }
            }

            DataTable dtdata = dtJissekidataDataTableChange(drJissekiList);

            gvSakehanbaitenPerInfoList.DataSource = dtdata;
            gvSakehanbaitenPerInfoList.DataBind();

            for (int i = 0; i < gvSakehanbaitenPerInfoList.Rows.Count; i++)
            {
                GridViewRow rowIndex = gvSakehanbaitenPerInfoList.Rows[i];
                System.Web.UI.WebControls.Label OroshiTenCodeReadOnly = (System.Web.UI.WebControls.Label)rowIndex.FindControl("lblOroshiTenCodeReadOnly");//卸店コード
                System.Web.UI.WebControls.Label KotenCodeReadOnly = (System.Web.UI.WebControls.Label)rowIndex.FindControl("lblKotenCodeReadOnly");//個店コード
                System.Web.UI.WebControls.Label YmdReadOnly = (System.Web.UI.WebControls.Label)rowIndex.FindControl("lblYmdReadOnly");//日付
                System.Web.UI.WebControls.TextBox ShohinCd = (System.Web.UI.WebControls.TextBox)rowIndex.FindControl("txtShohinCd");//商品コード(テキスト)

                if (!string.IsNullOrEmpty(OroshiTenCodeReadOnly.Text) &&
                !string.IsNullOrEmpty(KotenCodeReadOnly.Text) &&
                !string.IsNullOrEmpty(YmdReadOnly.Text))
                {
                    ShohinCd.Enabled = false;
                }
                else
                {
                    ShohinCd.Enabled = true;
                }
            }
        }
        #endregion

        #region 全削除用チェックボックス
        /// <summary>
        /// 全削除用チェックボックス
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void chkSelectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Boolean senderChecked = ((System.Web.UI.WebControls.CheckBox)sender).Checked;
            foreach (GridViewRow rowIndex in gvSakehanbaitenPerInfoList.Rows)
            {
                System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)(rowIndex.FindControl("chkDelete"));

                if (cb.Enabled == true)
                {
                    if (senderChecked == true)
                    {
                        cb.Checked = true;
                    }
                    else
                    {
                        cb.Checked = false;
                    }
                }
            }
        }
        #endregion

        #region 削除用チェックボックス
        protected void chkDelete_CheckedChanged(object sender, EventArgs e)
        {
            // チェックされていない場合、ヘッダのチェックをはずす
            System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)sender;
            if (cb.Checked == false && gvSakehanbaitenPerInfoList.HeaderRow != null)
            {
                System.Web.UI.WebControls.CheckBox cbh = (System.Web.UI.WebControls.CheckBox)gvSakehanbaitenPerInfoList.HeaderRow.FindControl("chkSelectAllCheckBox");
                cbh.Checked = false;
            }
        }
        #endregion

        #region 初期画面
        /// <summary>
        /// 初期画面
        /// </summary>
        private void InitialScreen()
        {
            lblkm04dnamekDis.Text = "";
            lblkm04dbrnamekDis.Text = "";

            DTJissekiList = new DataTable();

            ddlYear.Items.Clear();
            ddlYear.Items.Add((dateTime.Year - 1).ToString());
            ddlYear.Items.Add(dateTime.Year.ToString());
            ddlYear.Items.Add((dateTime.Year + 1).ToString());

            ddlMonth.Items.Clear();
            for (int i = 1; i < 13; i++)
            {
                ddlMonth.Items.Add(i.ToString("00"));
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("delete_flg");
            dt.Columns.Add("km08d_sho_cd");//商品コード
            dt.Columns.Add("shohn_na_25_kn");// 商品名
            dt.Columns.Add("shohn_box_iri");//入数
            dt.Columns.Add("km08d_hakosu");//ケース数
            dt.Columns.Add("km08d_hasu");//バラ数
            dt.Columns.Add("km08d_hasu_Goukei");//バラ数合計
            dt.Columns.Add("km08d_orshi_shiten_cd");//卸店コード
            dt.Columns.Add("km08d_ten_cd");//個店コード
            dt.Columns.Add("km08d_data_ym");//日付
            dt.Columns.Add("km08d_sho_cd_ReadOnly");//商品コード(読取専用)
            dt.Columns.Add("km08d_hakosu_ReadOnly");//ケース数(読取専用)
            dt.Columns.Add("km08d_hasu_ReadOnly");//バラ数(読取専用)

            gvSakehanbaitenPerInfoList.DataSource = dt;
            gvSakehanbaitenPerInfoList.DataBind();

            //ヘッダーのみを表示させる
            gvSakehanbaitenPerInfoList.ShowHeaderWhenEmpty = true;
            gvSakehanbaitenPerInfoList.DataSource = new List<object>();
            gvSakehanbaitenPerInfoList.DataBind();

            if (Session["nYearIndex"] != null) ddlYear.SelectedIndex = (int)Session["nYearIndex"];

            if(Session["nMonthIndex"] != null) ddlMonth.SelectedIndex = (int)Session["nMonthIndex"];

        }
        #endregion

        #region Listデータ更新
        private void ListDataUpdate()
        {
            sOroshiTenCode = (string)Session["sOroshiCode"];
            sKotenCode = (string)Session["sKotenCode"];
            nYearIndex = (int)Session["nYearIndex"];
            nMonthIndex = (int)Session["nMonthIndex"];
            ListDataUpdate(sOroshiTenCode, sKotenCode, nYearIndex, nMonthIndex);
        }
        /// <summary>
        /// Listデータ更新
        /// </summary>
        /// <param name="ot"></param>
        /// <param name="kt"></param>
        /// <param name="ymt"></param>
        private void ListDataUpdate(string otC,string ktC,int nYIdx,int nMIdx)
        {
            txtOroshiTenCode.Text = otC;
            txtKotenCode.Text = ktC;

            ddlYear.SelectedIndex = nYIdx;
            ddlMonth.SelectedIndex = nMIdx;
            string ymd = ddlYear.SelectedValue.ToString()+ ddlMonth.SelectedValue.ToString();

            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.OROSI_CD_KETUGO, otC.TrimEnd());//卸店コード
            paramDict.Add(constSql.KM08D_TEN_CD, ktC.TrimEnd());//個店コード
            paramDict.Add(constSql.KM08D_DATA_YM, ymd.TrimEnd());//日付

            //酒販店実績表示
            if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectekm08dandSHOHNSearch().ToString(), paramDict, ref dt)) > 0)
            {
                //バックアップとして残す。
                DTJissekiList = dt;
                Session["DTJissekiList"] = DTJissekiList;

                //1行追加用
                dt.Rows.Add("");
                gvSakehanbaitenPerInfoList.DataSource = dt;
                gvSakehanbaitenPerInfoList.DataBind();

                //ボタン表示
                lbtnUpdate.Visible = true;
                lbtnDelete.Visible = true;

                //リストのカラムを表示にする
                gvSakehanbaitenPerInfoList.Columns[0].Visible = true;//削除フラグ

                //リストのカラムを非表示にする。
                gvSakehanbaitenPerInfoList.Columns[3].Visible = false;//入数
                gvSakehanbaitenPerInfoList.Columns[4].Visible = false;//ケース数
                gvSakehanbaitenPerInfoList.Columns[6].Visible = false;//バラ数(合計)

                for (int i = 0; i < gvSakehanbaitenPerInfoList.Rows.Count; i++)
                {
                    GridViewRow rowIndex = gvSakehanbaitenPerInfoList.Rows[i];
                    System.Web.UI.WebControls.TextBox ShohinCd = (System.Web.UI.WebControls.TextBox)rowIndex.FindControl("txtShohinCd");
                    ShohinCd.Enabled = false;
                    if (gvSakehanbaitenPerInfoList.Rows.Count-1 == i)
                    {
                        ShohinCd.Enabled = true;
                    }
                }
            }
            else
            {
                lblMeesageDis.Text += "下記の酒販店実績（月次）のデータが存在しません。" + "</BR>";
                lblMeesageDis.Text += "卸店コード："+ otC + "</BR>";
                lblMeesageDis.Text += "個店コード："+ ktC + "</BR>";
                lblMeesageDis.Text += "日付：" + ymd + "</BR>";
                lblMeesageDis.Text += "新規登録をお願いします。" + "</BR>";
                lblMeesageDis.Text += "<HR>";
                txtOroshiTenCode.Focus();

                //ヘッダーのみを表示させる
                gvSakehanbaitenPerInfoList.ShowHeaderWhenEmpty = true;
                gvSakehanbaitenPerInfoList.DataSource = new List<object>();
                gvSakehanbaitenPerInfoList.DataBind();
            }

            Session["sOroshiCode"] = otC;
            Session["sKotenCode"] = ktC;

            Session["nYearIndex"] = nYIdx;
            Session["nMonthIndex"] = nMIdx;
            ddlYear.SelectedIndex = nYIdx;
            ddlMonth.SelectedIndex = nMIdx;
        }
        #endregion

        #region 卸店コードと個店コード値チェック
        /// <summary>
        /// 卸店コードと個店コード値チェック
        /// </summary>
        /// <returns></returns>
        private bool CodeDataCheck()
        {
            bool InputTextflg=true;
            //空白チェック
            if (string.IsNullOrEmpty(txtOroshiTenCode.Text.TrimEnd()))
            {
                lblMeesageDis.Text += "卸店コードを入力してください。" + "</BR>";
                lblMeesageDis.Text += "<HR>";
                txtOroshiTenCode.Focus();
                InputTextflg = false;
            }

            if (string.IsNullOrEmpty(txtKotenCode.Text.TrimEnd()))
            {
                lblMeesageDis.Text += "個店コードを入力してください。" + "</BR>";
                lblMeesageDis.Text += "<HR>";
                txtKotenCode.Focus();
                InputTextflg = false;
            }

            //桁数制限チェック
            if (txtOroshiTenCode.Text.Length > 5)
            {
                lblMeesageDis.Text += "卸店コードの桁数の上限は5桁です。" + "</BR>";
                lblMeesageDis.Text += "<HR>";
                txtOroshiTenCode.Focus();
                InputTextflg = false;
            }

            if (txtKotenCode.Text.Length > 8)
            {
                lblMeesageDis.Text += "個店コードの桁数の上限は8桁です。" + "</BR>";
                lblMeesageDis.Text += "<HR>";
                txtKotenCode.Focus();
                InputTextflg = false;
            }

            if (InputTextflg == false) return false;

            if (InputTextflg == true)
            {
                //マスタ未登録の場合は、エラー処理する。
                DataTable dt = new DataTable();
                Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
                paramDict.Add(constSql.KM04D_OROSI_CD, txtOroshiTenCode.Text.TrimEnd());
                paramDict.Add(constSql.KM04D_TEN_CD, txtKotenCode.Text.TrimEnd());
                if ((DBManager.GetTableData("dbret", constSql.CreateSqlselectKM04DateCheck().ToString(), paramDict, ref dt)) > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lblkm04dnamekDis.Text = dr[1].ToString();
                        //lblkm04dbrnamekDis.Text = dr[0].ToString();
                    }
                }
                else
                {
                    lblMeesageDis.Text += "入力いたしましたコードは卸店系列マスターには存在しません。(DB:km04d)" + "</BR>";
                    lblMeesageDis.Text += "卸店コード: " + txtOroshiTenCode.Text + "</BR>";
                    //lblMeesageDis.Text += "個店コード: " + txtKotenCode.Text + "</BR>";
                    lblMeesageDis.Text += "<HR>";
                    txtOroshiTenCode.Focus();
                    InputTextflg = false;
                }
                //個店コードチェック
                if (InputTextflg == true)
                {
                    if ((DBManager.GetTableData("dbret", constSql.CreateSqlselectKM01DateCheck().ToString(), paramDict, ref dt)) > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            //lblkm04dnamekDis.Text = dr[1].ToString();
                            lblkm04dbrnamekDis.Text = dr[0].ToString();
                        }
                    }
                    else
                    {
                        lblMeesageDis.Text += "入力いたしましたコードは小売店マスターには存在しません。(DB:km01d)" + "</BR>";
                        //lblMeesageDis.Text += "卸店コード: " + txtOroshiTenCode.Text + "</BR>";
                        lblMeesageDis.Text += "個店コード: " + txtKotenCode.Text + "</BR>";
                        lblMeesageDis.Text += "<HR>";
                        txtOroshiTenCode.Focus();
                        InputTextflg = false;
                    }
                }
            }

            if (InputTextflg == false) return false;

            return true;
        }
        #endregion

        #region 数値入力チェック
        private bool NumberCheck(string sNum)
        {
            int nNum=0;
            return NumberCheck(sNum, ref nNum);
        }
        /// <summary>
        /// 数値入力チェック
        /// </summary>
        /// <param name="num">文字列型数値</param>
        /// <returns></returns>
        private  bool NumberCheck(string sNum,ref int nNum)
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
        #endregion

        #region データテーブルから取得する。
        /// <summary>
        /// gridviewから直接参照
        /// </summary>
        /// <returns></returns>
        private DataTable dtJissekiDataList()
        {
            DataTable dt=new DataTable();
            dt = dtJissekidataAdd();
           
            DataRow dr;

            string sYmd = ddlYear.SelectedValue.ToString() + ddlMonth.SelectedValue.ToString();

            for (int i = 0; i < gvSakehanbaitenPerInfoList.Rows.Count; i++)
            {
                //shjList = new SAKEHANJISSEKI();
                GridViewRow rowIndex = gvSakehanbaitenPerInfoList.Rows[i];
                dr = dt.NewRow();

                //商品コード(テキスト入力)
                System.Web.UI.WebControls.TextBox ShohinCd = (System.Web.UI.WebControls.TextBox)rowIndex.FindControl("txtShohinCd");
                dr["km08d_sho_cd"] = ShohinCd.Text.ToString();

                //商品名
                System.Web.UI.WebControls.Label ShohinName = (System.Web.UI.WebControls.Label)rowIndex.FindControl("lblShohinName");
                dr["shohn_na_25_kn"] = ShohinName.Text.ToString(); 

                //入数
                System.Web.UI.WebControls.Label ShohnBoxIri = (System.Web.UI.WebControls.Label)rowIndex.FindControl("lblShohnBoxIri");
                dr["shohn_box_iri"] = ShohnBoxIri.Text.ToString();

                //ケース数
                System.Web.UI.WebControls.TextBox Hakosu = (System.Web.UI.WebControls.TextBox)rowIndex.FindControl("txtHakosu");
                dr["km08d_hakosu"] = Hakosu.Text.ToString();

                //バラ数(テキスト入力)
                System.Web.UI.WebControls.TextBox Hasu = (System.Web.UI.WebControls.TextBox)rowIndex.FindControl("txtHasu");
                dr["km08d_hasu"] = Hasu.Text.ToString();

                //卸店コード(読取専用)
                System.Web.UI.WebControls.Label OroshiTenCodeReadOnly = (System.Web.UI.WebControls.Label)rowIndex.FindControl("lblOroshiTenCodeReadOnly");
                dr["km08d_orshi_shiten_cd"] = OroshiTenCodeReadOnly.Text.ToString();

                //個店コード(読取専用)
                System.Web.UI.WebControls.Label KotenCodeReadOnly = (System.Web.UI.WebControls.Label)rowIndex.FindControl("lblKotenCodeReadOnly");
                dr["km08d_ten_cd"] = KotenCodeReadOnly.Text.ToString();

                //日付(読取専用)
                System.Web.UI.WebControls.Label YmdReadOnly = (System.Web.UI.WebControls.Label)rowIndex.FindControl("lblYmdReadOnly");
                dr["km08d_data_ym"] = YmdReadOnly.Text.ToString();


                //商品コード(読取専用)
                System.Web.UI.WebControls.Label ShohinCdReadOnly = (System.Web.UI.WebControls.Label)rowIndex.FindControl("lblShohinCdReadOnly");
                dr["km08d_sho_cd_ReadOnly"] = ShohinCdReadOnly.Text.ToString();

                //ケース数(読取専用)
                System.Web.UI.WebControls.Label HakosuReadOnly = (System.Web.UI.WebControls.Label)rowIndex.FindControl("lblHakosuReadOnly");
                dr["km08d_hakosu_ReadOnly"] = HakosuReadOnly.Text.ToString();

                //バラ数(読取専用)
                System.Web.UI.WebControls.Label HasuReadOnly = (System.Web.UI.WebControls.Label)rowIndex.FindControl("lblHasuReadOnly");
                dr["km08d_hasu_ReadOnly"] = HasuReadOnly.Text.ToString();

                dt.Rows.Add(dr);
            }
            return dt;
        }

        private DataTable dtJissekidataAdd()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("delete_flg");//削除フラグ[0]
            dt.Columns.Add("km08d_sho_cd");//商品コード[1]
            dt.Columns.Add("shohn_na_25_kn");// 商品名[2]
            dt.Columns.Add("shohn_box_iri");//入数[3]
            dt.Columns.Add("km08d_hakosu");//ケース数[4]
            dt.Columns.Add("km08d_hasu");//バラ数[5]
            dt.Columns.Add("km08d_hasu_Goukei");//バラ数合計[6]
            dt.Columns.Add("km08d_pri_kbn");//[7]
            dt.Columns.Add("km08d_orshi_shiten_cd");//卸店コード
            dt.Columns.Add("km08d_ten_cd");//個店コード
            dt.Columns.Add("km08d_data_ym");//日付
            dt.Columns.Add("km08d_sho_cd_ReadOnly");//商品コード(読取専用)
            dt.Columns.Add("km08d_hakosu_ReadOnly");//ケース数(読取専用)
            dt.Columns.Add("km08d_hasu_ReadOnly");//バラ数(読取専用)

            return dt;
        }

        #endregion

        #region List→datatable変換
        /// <summary>
        /// List→datatable変換
        /// </summary>
        /// <param name="drList"></param>
        /// <returns></returns>
        private DataTable dtJissekidataDataTableChange(List<DataRow> drList)
        {
            DataTable dtadd = dtJissekidataAdd();
            DataRow dr;
            for (int i = 0; i < drList.Count; i++)
            {
                dr = dtadd.NewRow();
                dr["km08d_sho_cd"] = drList[i][1];//商品コード(テキスト)
                dr["shohn_na_25_kn"] = drList[i][2];
                dr["shohn_box_iri"] = drList[i][3];
                dr["km08d_hakosu"] = drList[i][4];
                dr["km08d_hasu"] = drList[i][5];//バラ数(テキスト入力)
                dr["km08d_hasu_Goukei"] = drList[i][6];
                dr["km08d_pri_kbn"] = drList[i][7];
                dr["km08d_orshi_shiten_cd"] = drList[i][8];//卸店コード(読取専用)
                dr["km08d_ten_cd"] = drList[i][9];//個店コード(読取専用)
                dr["km08d_data_ym"] = drList[i][10];//日付(読取専用)
                dr["km08d_sho_cd_ReadOnly"] = drList[i][11];//商品コード(読取専用)
                dr["km08d_hakosu_ReadOnly"] = drList[i][12];//ケース数(読取専用)
                dr["km08d_hasu_ReadOnly"] = drList[i][13];//バラ数(読取専用)
                dtadd.Rows.Add(dr);
            }

            return dtadd;
        }

        #endregion

    }
}