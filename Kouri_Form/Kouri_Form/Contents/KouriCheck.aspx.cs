using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using Kouri_Form.Class;
using System.Data;
using System.IO;
using System.Globalization;

namespace Kouri_Form.Contents
{
    public partial class KouriCheck : System.Web.UI.Page
    {
        /// <summary>
        /// ロードイベント
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitialScreenSet();
            }
        }

        /// <summary>
        /// カレンダーの日付選択時発生(開始日付)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cldStartDate_SelectionChanged(object sender, EventArgs e)
        {
            DateTime dTime = cldYYYYMMDD_From.SelectedDate;
            txtYYYYMMDD_From.Text = dTime.ToString("yyyyMMdd");
            lblDayWeek_From.Text = dTime.ToString("(ddd)");
            Session["dTime_from"] = dTime;
        }

        /// <summary>
        /// カレンダーの日付選択時発生(終了日付)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cldEndDate_SelectionChanged(object sender, EventArgs e)
        {
            DateTime dTime = cldYYYYMMDD_To.SelectedDate;
            txtYYYYMMDD_To.Text = dTime.ToString("yyyyMMdd");
            lblDayWeek_To.Text = dTime.ToString("(ddd)");
            Session["dTime_to"] = dTime;
        }

        /// <summary>
        /// 日付の表示中に発生(開始日付)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cldStartDate_DayRender(object sender, DayRenderEventArgs e)
        {
            DateTime last_dateDay = DateTime.Now;
            last_dateDay = last_dateDay.AddDays(-1);

            if (e.Day.Date > last_dateDay)
            {
                //e.Cell.Font.Italic = true;//斜体
                //e.Cell.Font.Strikeout = true;//取り消し線
                e.Day.IsSelectable = false;//非活性
                e.Cell.BackColor = System.Drawing.Color.DarkGray;//背景色
            }
        }

        /// <summary>
        /// 日付の表示中に発生(終了日付)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cldEndDate_DayRender(object sender, DayRenderEventArgs e)
        {
            DateTime last_dateDay = DateTime.Now;
            last_dateDay = last_dateDay.AddDays(-1);

            if (e.Day.Date > last_dateDay)
            {
                //e.Cell.Font.Italic = true;//斜体
                //e.Cell.Font.Strikeout = true;//取り消し線
                e.Day.IsSelectable = false;//非活性
                e.Cell.BackColor = System.Drawing.Color.DarkGray;//背景色
            }
        }

        /// <summary>
        /// チェック開始ボタン押下イベント
        /// </summary>
        protected void btnCheck_Click(object sender, EventArgs e)
        {
            ltMsg.Text = "";

            if((DateTime)Session["dTime_from"] > (DateTime)Session["dTime_to"])
            {
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "開始日付が終了日付より以前の日付もしくは同じ日付になるように指定してください。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                return;
            }

            /*ストアドの実行を行う*/
            try
            {
                //実行するストアドプロシージャを取得する
                DataTable dt = new DataTable();
                Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
                if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectKouriCheckProc().ToString(), paramDict, ref dt)) > 0)
                {
                    /*ストアドの取得*/
                    /*ファイル名を取得する*/
                    string runProc = dt.Rows[0]["convert_value"].ToString();
                    if (string.IsNullOrEmpty(runProc))
                    {
                        /*空白の場合はエラーとする*/
                        ltMsg.Text = ltMsg.Text + "<pre>";
                        ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                        ltMsg.Text = ltMsg.Text + "実行するストアドプロシージャが取得できませんでした。" + "</BR>";
                        ltMsg.Text = ltMsg.Text + "テーブル [DBRET].[dbo].[mst_conversion_for_kouri] (定義番号：15040 / キー：KOURI_CHECK_PROC) を確認して下さい。" + "</BR>";
                        ltMsg.Text = ltMsg.Text + "</font>";
                        ltMsg.Text = ltMsg.Text + "</ pre>";
                        return;
                    }

                    //ストアドプロシージャの実行
                    paramDict = new Dictionary<string, Object>();
                    paramDict.Add("@YMD_FROM", txtYYYYMMDD_From.Text.TrimEnd());
                    paramDict.Add("@YMD_TO", txtYYYYMMDD_To.Text.TrimEnd());
                    DBManager db = new DBManager();
                    try
                    {
                        db.Connect("dbret", -1);
                        db.ExecuteProcedureNonQuery(runProc, paramDict);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    ltMsg.Text = ltMsg.Text + "<pre>";
                    ltMsg.Text = ltMsg.Text + "小売店データのチェック処理が正常に終了しました。" + "</BR>";
                    ltMsg.Text = ltMsg.Text + "</ pre>";
                }
                else
                {
                    ltMsg.Text = ltMsg.Text + "<pre>";
                    ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                    ltMsg.Text = ltMsg.Text + "実行するストアドプロシージャが取得できませんでした。" + "</BR>";
                    ltMsg.Text = ltMsg.Text + "テーブル [DBRET].[dbo].[mst_conversion_for_kouri] (定義番号：15040 / キー：KOURI_CHECK_PROC) を確認して下さい。" + "</BR>";
                    ltMsg.Text = ltMsg.Text + "</font>";
                    ltMsg.Text = ltMsg.Text + "</ pre>";
                    return;
                }
            }
            catch (Exception ex)
            {
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "小売店データのチェック処理でエラーが発生しました。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "エラーメッセージ：" + ex.Message + "</BR>";
                ltMsg.Text = ltMsg.Text + "エラーソース    ：" + ex.Source + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
            }
        }

        /// <summary>
        /// クリアボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            InitialScreenSet();
        }

        /// <summary>
        /// 初期設定
        /// </summary>
        private void InitialScreenSet()
        {
            ltMsg.Text = "";
            cldYYYYMMDD_From.VisibleDate = new DateTime();
            cldYYYYMMDD_To.VisibleDate = new DateTime();

            DateTime last_month = DateTime.Now;
            last_month = last_month.AddDays(-1);

            DateTime dTime_from = new DateTime();
            DateTime dTime_to = new DateTime();

            bool bTimecheck = true;
            /*初期値を前日を設定*/
            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectShoriDate().ToString(), paramDict, ref dt)) > 0)
            {
                string format = "yyyyMMdd";
                try
                {
                    dTime_from = DateTime.ParseExact(dt.Rows[0]["YYYYMMDD_FROM"].ToString(), format, null);
                    dTime_to = DateTime.ParseExact(dt.Rows[0]["YYYYMMDD_TO"].ToString(), format, null);
                }
                catch
                {
                    bTimecheck = false;
                }
            }
            else
            {
                bTimecheck = false;
            }

            if (bTimecheck == false)
            {
                dTime_from = last_month;
                dTime_to = last_month;
            }

            txtYYYYMMDD_From.Text = dTime_from.ToString("yyyyMMdd");
            txtYYYYMMDD_To.Text = dTime_to.ToString("yyyyMMdd");
            lblDayWeek_From.Text = dTime_from.ToString("(ddd)");
            lblDayWeek_To.Text = dTime_to.ToString("(ddd)");
            Session["dTime_from"] = dTime_from;
            Session["dTime_to"] = dTime_to;

            cldYYYYMMDD_From.SelectedDate = dTime_from;
            cldYYYYMMDD_To.SelectedDate = dTime_to;
        }
    }
}