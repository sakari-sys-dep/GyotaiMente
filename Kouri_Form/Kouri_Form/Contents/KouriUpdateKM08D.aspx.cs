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
    public partial class KouriUpdateKM08D : System.Web.UI.Page
    {
        /// <summary>
        /// ロードイベント
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*初期値を前月を設定*/
                InitialScreenSet();
            }
        }
        /// <summary>
        /// 年月ボタン押下イベント
        /// </summary>
        protected void btnMonth_Click(object sender, EventArgs e)
        {
            string sMonthNum = ((Button)sender).Text.ToString().Substring(0, 2);
            txtYYYYMM.Text = lblDisYear.Text.Trim() + sMonthNum;
        }

        /// <summary>
        /// 年移動ボタン押下イベント
        /// </summary>
        protected void btnNextReturnYear_Click(object sender, EventArgs e)
        {
            if (((Button)sender).ID == "btnNextYear")
            {
                YearAdd(1);
            }
            else
            {
                YearAdd(-1);
            }
        }
        /// <summary>
        /// 月間更新処理ボタンの押下イベント
        /// </summary
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ltMsg.Text = "";
            /*ストアドの実行を行う*/
            try
            {
                //実行するストアドプロシージャを取得する
                DataTable dt = new DataTable();
                Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
                if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectUpdateKM08DProc().ToString(), paramDict, ref dt)) > 0)
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
                        ltMsg.Text = ltMsg.Text + "テーブル [DBRET].[dbo].[mst_conversion_for_kouri] (定義番号：15020 / キー：UPDATE_KM08D) を確認して下さい。" + "</BR>";
                        ltMsg.Text = ltMsg.Text + "</font>";
                        ltMsg.Text = ltMsg.Text + "</ pre>";
                        return;
                    }
                    //ストアドプロシージャの実行
                    paramDict = new Dictionary<string, Object>();
                    //paramDict.Add("@YMD_FROM", txtYYYYMM.Text);
                    //paramDict.Add("@YMD_TO", txtYYYYMM.Text);
                    paramDict.Add("@YYYYMM", txtYYYYMM.Text);
                    DBManager db = new DBManager();
                    try
                    {
                        db.Connect("Kouridb", -1);
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
                    ltMsg.Text = ltMsg.Text + "更新処理が終了しました。" + "</BR>";
                    ltMsg.Text = ltMsg.Text + "</ pre>";
                }
                else
                {
                    ltMsg.Text = ltMsg.Text + "<pre>";
                    ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                    ltMsg.Text = ltMsg.Text + "実行するストアドプロシージャが取得できませんでした。" + "</BR>";
                    ltMsg.Text = ltMsg.Text + "テーブル [DBRET].[dbo].[mst_conversion_for_kouri] (定義番号：15020 / キー：UPDATE_KM08D) を確認して下さい。" + "</BR>";
                    ltMsg.Text = ltMsg.Text + "</font>";
                    ltMsg.Text = ltMsg.Text + "</ pre>";
                    return;
                }
            }
            catch (Exception ex)
            {
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "エラーメッセージ：" + ex.Message + "</BR>";
                ltMsg.Text = ltMsg.Text + "エラーソース    ：" + ex.Source + "</BR>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
            }
        }

        /// <summary>
        /// クリアボタンの押下イベント
        /// </summary
        protected void btnClear_Click(object sender, EventArgs e)
        {
            InitialScreenSet();
        }
        /// <summary>
        /// 初期値
        /// </summary>
        private void InitialScreenSet()
        {
            ltMsg.Text = "";
            DateTime last_month = DateTime.Now.AddMonths(-1); 

            Session["dTimeSelectYear"] = last_month;
            txtYYYYMM.Text = last_month.ToString("yyyyMM");
            lblDisYear.Text = last_month.ToString("yyyy");
            YearSelectMonthDis(last_month);
        }

        private void YearAdd(int YearNum)
        {
            DateTime dtNow = DateTime.Now;

            DateTime dTimeSelect = (DateTime)Session["dTimeSelectYear"];
            dTimeSelect = dTimeSelect.AddYears(YearNum);

            if(dtNow.AddYears(2).Year == dTimeSelect.Year)
            {
                dTimeSelect = dTimeSelect.AddYears(-1);
            }

            if(dTimeSelect.Year ==1900)
            {
                dTimeSelect = dTimeSelect.AddYears(1);
            }

            Session["dTimeSelectYear"] = dTimeSelect;

            lblDisYear.Text = dTimeSelect.ToString("yyyy");

            YearSelectMonthDis(dTimeSelect);
        }

        private void YearSelectMonthDis(DateTime dTimeYear)
        {
            DateTime dtNow = DateTime.Now;

            Button[] btnMonth__array = new Button[12];
            btnMonth__array[0] = this.btnJanuary;
            btnMonth__array[1] = this.btnFebruary;
            btnMonth__array[2] = this.btnMarch;
            btnMonth__array[3] = this.btnApril;
            btnMonth__array[4] = this.btnMay;
            btnMonth__array[5] = this.btnJune;
            btnMonth__array[6] = this.btnJuly;
            btnMonth__array[7] = this.btnAugust;
            btnMonth__array[8] = this.btnSeptember;
            btnMonth__array[9] = this.btnOctober;
            btnMonth__array[10] = this.btnNovember;
            btnMonth__array[11] = this.btnDecember;

            if (dTimeYear.Year == dtNow.Year)
            {
                for (int i = 0; i < btnMonth__array.Length; i++)
                {
                    string sMonthNum = btnMonth__array[i].Text.ToString().Substring(0, 2);
                    byte nNum = byte.Parse(sMonthNum);

                    if ((byte)dtNow.Month <= nNum)
                    {
                        btnMonth__array[i].Enabled = false;
                    }
                    else
                    {
                        btnMonth__array[i].Enabled = true;
                    }
                }
            }
            else if (dTimeYear.Year > dtNow.Year)
            {
                for (int i = 0; i < btnMonth__array.Length; i++)
                {
                    btnMonth__array[i].Enabled = false;
                }
            }
            else
            {
                for (int i = 0; i < btnMonth__array.Length; i++)
                {
                    btnMonth__array[i].Enabled = true;
                }
            }
        }
    }
}