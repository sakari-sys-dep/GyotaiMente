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

namespace Kouri_Form.Contents
{
    public partial class KouriUpdateMonthly________old : System.Web.UI.Page
    {
        /// <summary>
        /// ロードイベント
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*初期値を前月を設定*/
                DateTime last_month = DateTime.Now.AddMonths(-1);
                txtYYYYMM.Text = last_month.ToString("yyyyMM");

            }
        }

        /// <summary>
        /// 月次更新処理ボタンの押下イベント
        /// </summary>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            /*入力チェック*/
            if (txtYYYYMM.Text.TrimEnd() == "")
            {
                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "年月を指定して下さい。" + "</BR>";
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
                if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectKouriUpdateMonthlyProc().ToString(), paramDict, ref dt)) > 0)
                {
                    /*ストアドの取得*/
                    string runProc = dt.Rows[0]["convert_value"].ToString();
                    if (string.IsNullOrEmpty(runProc))
                    {
                        /*空白の場合はエラーとする*/
                        ltMsg.Text = "";
                        ltMsg.Text = ltMsg.Text + "<pre>";
                        ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                        ltMsg.Text = ltMsg.Text + "実行するストアドプロシージャが取得できませんでした。" + "</BR>";
                        ltMsg.Text = ltMsg.Text + "テーブル [DBRET].[dbo].[mst_conversion_for_kouri] (15060) を確認して下さい。" + "</BR>";
                        ltMsg.Text = ltMsg.Text + "</font>";
                        ltMsg.Text = ltMsg.Text + "</ pre>";
                        return;
                    }

                    //ストアドプロシージャの実行
                    paramDict = new Dictionary<string, Object>();
                    paramDict.Add("@YMD_FROM", txtYYYYMM.Text);
                    paramDict.Add("@YMD_TO", txtYYYYMM.Text);
                    if (cbMonth.Checked)
                    {
                        paramDict.Add("@MONTH_FLG", "1");
                    }
                    else
                    {
                        paramDict.Add("@MONTH_FLG", "0");
                    }
                    if (cbDay.Checked)
                    {
                        paramDict.Add("@DAY_FLG", "1");
                    }
                    else
                    {
                        paramDict.Add("@DAY_FLG", "0");
                    }
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
                    ltMsg.Text = "";
                    ltMsg.Text = ltMsg.Text + "<pre>";
                    ltMsg.Text = ltMsg.Text + "小売店データの月次更新処理が正常に終了しました。" + "</BR>";
                    ltMsg.Text = ltMsg.Text + "</ pre>";
                }

            }
            catch (Exception ex)
            {
                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "小売店データの月次更新処理でエラーが発生しました。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "エラーメッセージ：" + ex.Message + "</BR>";
                ltMsg.Text = ltMsg.Text + "エラーソース    ：" + ex.Source + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
            }

        }


    }
}