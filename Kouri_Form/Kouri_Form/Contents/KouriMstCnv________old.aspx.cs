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
    public partial class KouriMstCnv________old : System.Web.UI.Page
    {
        /// <summary>
        /// 画面ロードイベント
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
            if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectKouriCnvFile().ToString(), paramDict, ref dt)) > 0)
            {
                /*ファイル名を取得する*/
                string filePath = dt.Rows[0]["convert_value"].ToString();

                if (!string.IsNullOrEmpty(filePath))
                {
                    /*隠し項目にファイル名を設定*/
                    txtFilePath.Text = filePath;

                    /*ファイル操作クラスの設定*/
                    var fileInfo = new FileInfo(filePath);

                    /*ファイルの存在チェック*/
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

                    /*ファイル情報の出力*/
                    ltFileMsg.Text = "";
                    ltFileMsg.Text = ltFileMsg.Text + "<pre>";
                    ltFileMsg.Text = ltFileMsg.Text + "・取込ファイル名　：" + fileInfo.FullName.ToString() + "</BR>";
                    ltFileMsg.Text = ltFileMsg.Text + "・最終更新日　　　：" + fileInfo.LastWriteTime.ToString() + "</BR>";
                    ltFileMsg.Text = ltFileMsg.Text + "・バイト数　　　　：" + fileInfo.Length.ToString() + " バイト </BR>";
                    ltFileMsg.Text = ltFileMsg.Text + "</BR>";
                    ltFileMsg.Text = ltFileMsg.Text + "";
                    ltFileMsg.Text = ltFileMsg.Text + "</BR>";
                    ltFileMsg.Text = ltFileMsg.Text + "問題がない場合は、取込処理のボタンを押して下さい。";
                    ltFileMsg.Text = ltFileMsg.Text + "</ pre>";
                }
                else
                {
                    /*エラーメッセージを出力*/
                    ltFileMsg.Text = "";
                    ltFileMsg.Text = ltFileMsg.Text + "<pre>";
                    ltFileMsg.Text = ltFileMsg.Text + "<FONT color='red'>";
                    ltFileMsg.Text = ltFileMsg.Text + "ファイル名が取得できませんでした。" + "</BR>";
                    ltFileMsg.Text = ltFileMsg.Text + "定義番号：15030　/　キー：KOURI_CNV_FILE が 空白で設定されています。" + "</BR>";
                    ltFileMsg.Text = ltFileMsg.Text + "定義番号：15030　/　キー：KOURI_CNV_FILE を 設定して下さい。" + "</BR>";
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
                ltFileMsg.Text = ltFileMsg.Text + "定義番号：15030　/　キー：KOURI_CNV_FILE が 設定されていません。" + "</BR>";
                ltFileMsg.Text = ltFileMsg.Text + "定義番号：15030　/　キー：KOURI_CNV_FILE を 設定して下さい。" + "</BR>";
                ltFileMsg.Text = ltFileMsg.Text + "</font>";
                ltFileMsg.Text = ltFileMsg.Text + "</ pre>";
            }
        }

        /// <summary>
        /// 取込処理ボタンの押下イベント
        /// </summary>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            /*隠し項目よりファイル名を取得*/
            string filePath = txtFilePath.Text.ToString();
            if (string.IsNullOrEmpty(filePath))
            {
                /*ファイル名が空白の場合は、再度ファイル名を取得する*/
                DataTable dt = new DataTable();
                Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
                if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectKouriCnvFile().ToString(), paramDict, ref dt)) > 0)
                {
                    /*ファイル名を取得する*/
                    filePath = "";
                    filePath = dt.Rows[0]["convert_value"].ToString();
                }
                else
                {
                    /*エラーメッセージを出力*/
                    ltFileMsg.Text = "";
                    ltFileMsg.Text = ltFileMsg.Text + "<pre>";
                    ltFileMsg.Text = ltFileMsg.Text + "<FONT color='red'>";
                    ltFileMsg.Text = ltFileMsg.Text + "ファイル名が取得できませんでした。" + "</BR>";
                    ltFileMsg.Text = ltFileMsg.Text + "定義番号：15030　/　キー：KOURI_CNV_FILE が 設定されていません。" + "</BR>";
                    ltFileMsg.Text = ltFileMsg.Text + "定義番号：15030　/　キー：KOURI_CNV_FILE を 設定して下さい。" + "</BR>";
                    ltFileMsg.Text = ltFileMsg.Text + "</font>";
                    ltFileMsg.Text = ltFileMsg.Text + "</ pre>";
                    return;
                }
            }

            /*ストアドプロシージャの実行*/
            try
            {
                //実行するストアドプロシージャを取得する
                DataTable dt = new DataTable();
                Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
                if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectKouriCnvProc().ToString(), paramDict, ref dt)) > 0)
                {
                    /*実行するストアドプロシージャ名の取得*/
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
                    paramDict.Add("@FILE_PATH", filePath);  /*取込ファイル名をストアドプロシージャの引数として設定する*/
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
                    ltMsg.Text = ltMsg.Text + "ＣＶＴマスタの更新処理が正常に終了しました。" + "</BR>";
                    ltMsg.Text = ltMsg.Text + "</ pre>";
                }
                else
                {
                    ltMsg.Text = "";
                    ltMsg.Text = ltMsg.Text + "<pre>";
                    ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                    ltMsg.Text = ltMsg.Text + "実行するストアドプロシージャが取得できませんでした。" + "</BR>";
                    ltMsg.Text = ltMsg.Text + "テーブル [DBRET].[dbo].[mst_conversion_for_kouri] (15010) を確認して下さい。" + "</BR>";
                    ltMsg.Text = ltMsg.Text + "</font>";
                    ltMsg.Text = ltMsg.Text + "</ pre>";
                    return;
                }
            }
            catch (Exception ex)
            {
                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "ＣＶＴマスタの更新処理でエラーが発生しました。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "エラーメッセージ：" + ex.Message + "</BR>";
                ltMsg.Text = ltMsg.Text + "エラーソース    ：" + ex.Source + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
            }
        }
    }
}