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

namespace Kouri_Form.Manual
{
    public partial class KouriManualSAM : System.Web.UI.Page
    {
        /// <summary>
        /// ロードイベント
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*取込ファイルの情報を表示する*/
                this.Get_Information_ImportFile();
            }
        }

        /// <summary>
        /// 取込ファイルの情報を取得
        /// </summary>
        private void Get_Information_ImportFile()
        {
            /*取り込むファイル名を取得する*/
            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectSamFile().ToString(), paramDict, ref dt)) > 0)
            {
                /*ファイル名を取得する*/
                string filePath = dt.Rows[0]["convert_value"].ToString();

                if (!string.IsNullOrEmpty(filePath))
                {
                    var fileInfo = new FileInfo(filePath);
                    // ファイルが存在しない場合
                    if (!fileInfo.Exists)
                    {
                        // ファイルが存在しない場合
                        ltFileMsg.Text = "";
                        ltFileMsg.Text = ltFileMsg.Text + "<pre>";
                        ltFileMsg.Text = ltFileMsg.Text + "<FONT color='red'>";
                        ltFileMsg.Text = ltFileMsg.Text + "ファイル：" + filePath + "  が存在しません。" + "</BR>";
                        ltFileMsg.Text = ltFileMsg.Text + "</font>";
                        ltFileMsg.Text = ltFileMsg.Text + "</ pre>";
                        return;
                    }

                    /*ファイル名の出力*/
                    ltFileMsg.Text = "";
                    ltFileMsg.Text = ltFileMsg.Text + "<pre>";
                    ltFileMsg.Text = ltFileMsg.Text + "・取込ファイル名　：" + fileInfo.FullName.ToString() + "</BR>";
                    ltFileMsg.Text = ltFileMsg.Text + "・最終更新日　　　：" + fileInfo.LastWriteTime.ToString() + "</BR>";
                    ltFileMsg.Text = ltFileMsg.Text + "・バイト数　　　　：" + fileInfo.Length.ToString() + " バイト </BR>";
                    ltFileMsg.Text = ltFileMsg.Text + "</BR>";
                    ltFileMsg.Text = ltFileMsg.Text + "";
                    ltFileMsg.Text = ltFileMsg.Text + "</BR>";
                    ltFileMsg.Text = ltFileMsg.Text + "問題がない場合は、処理開始のボタンを押して下さい。";
                    ltFileMsg.Text = ltFileMsg.Text + "</ pre>";
                }
                else
                {
                    /*エラーメッセージを出力*/
                    ltFileMsg.Text = "";
                    ltFileMsg.Text = ltFileMsg.Text + "<pre>";
                    ltFileMsg.Text = ltFileMsg.Text + "<FONT color='red'>";
                    ltFileMsg.Text = ltFileMsg.Text + "ファイル名が取得できませんでした。" + "</BR>";
                    ltFileMsg.Text = ltFileMsg.Text + "定義番号：15010　/　キー：SAM_FILE が 空白で設定されています。" + "</BR>";
                    ltFileMsg.Text = ltFileMsg.Text + "定義番号：15010　/　キー：SAM_FILE を 設定して下さい。" + "</BR>";
                    ltFileMsg.Text = ltFileMsg.Text + "</font>";
                    ltFileMsg.Text = ltFileMsg.Text + "</ pre>";
                }
            }
            else
            {
                /*エラーメッセージを出力*/
                ltFileMsg.Text = "";
                ltFileMsg.Text = ltFileMsg.Text + "<pre>";
                ltFileMsg.Text = ltFileMsg.Text + "<FONT color='red'>";
                ltFileMsg.Text = ltFileMsg.Text + "ファイル名が取得できませんでした。" + "</BR>";
                ltFileMsg.Text = ltFileMsg.Text + "定義番号：15010　/　キー：SAM_FILE が 設定されていません。" + "</BR>";
                ltFileMsg.Text = ltFileMsg.Text + "定義番号：15010　/　キー：SAM_FILE を 設定して下さい。" + "</BR>";
                ltFileMsg.Text = ltFileMsg.Text + "</font>";
                ltFileMsg.Text = ltFileMsg.Text + "</ pre>";
            }

        }

        /// <summary>
        /// 処理開始ボタンの押下イベント
        /// </summary>
        protected void btnSam_Click(object sender, EventArgs e)
        {

            /*ストアドの実行を行う*/
            try
            {
                //実行するストアドプロシージャを取得する
                DataTable dt = new DataTable();
                Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
                if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectSamProc().ToString(), paramDict, ref dt)) > 0)
                {
                    /*ストアドの取得*/
                    /*ファイル名を取得する*/
                    string runProc = dt.Rows[0]["convert_value"].ToString();
                    if (string.IsNullOrEmpty(runProc))
                    {
                        /*空白の場合はエラーとする*/
                        ltMsg.Text = "";
                        ltMsg.Text = ltMsg.Text + "<pre>";
                        ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                        ltMsg.Text = ltMsg.Text + "実行するストアドプロシージャが取得できませんでした。" + "</BR>";
                        ltMsg.Text = ltMsg.Text + "テーブル [DBRET].[dbo].[mst_conversion_for_kouri] (15010) を確認して下さい。" + "</BR>";
                        ltMsg.Text = ltMsg.Text + "</font>";
                        ltMsg.Text = ltMsg.Text + "</ pre>";
                        return;
                    }

                    //ストアドプロシージャの実行
                    paramDict = new Dictionary<string, Object>();

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
                    ltMsg.Text = ltMsg.Text + "手入力小売店（ＳＡＭ）の更新処理が正常に終了しました。" + "</BR>";
                    ltMsg.Text = ltMsg.Text + "</ pre>";
                }
            }
            catch (Exception ex)
            {
                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "手入力小売店（ＳＡＭ）の更新処理でエラーが発生しました。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "エラーメッセージ：" + ex.Message + "</BR>";
                ltMsg.Text = ltMsg.Text + "エラーソース    ：" + ex.Source + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
            }
        }
    }
}