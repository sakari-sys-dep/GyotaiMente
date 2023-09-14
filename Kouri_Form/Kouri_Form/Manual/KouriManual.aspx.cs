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
    public partial class KouriManual : System.Web.UI.Page
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
                /*取込済みのファイルが存在するかどうかのチェック*/
                this.Torikomi_Data_Check(0);
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
            if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectManualFile().ToString(), paramDict, ref dt)) > 0)
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

                    /*ファイル情報の出力*/
                    ltFileMsg.Text = "";
                    ltFileMsg.Text = ltFileMsg.Text + "<pre>";
                    ltFileMsg.Text = ltFileMsg.Text + "・取込ファイル名　：" + fileInfo.FullName.ToString() + "</BR>";
                    ltFileMsg.Text = ltFileMsg.Text + "・最終更新日　　　：" + fileInfo.LastWriteTime.ToString() + "</BR>";
                    ltFileMsg.Text = ltFileMsg.Text + "・バイト数　　　　：" + fileInfo.Length.ToString() + " バイト"+" </BR>";
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
                    ltFileMsg.Text = ltFileMsg.Text + "定義番号：15010　/　キー：IMPORT_FILE が 空白で設定されています。" + "</BR>";
                    ltFileMsg.Text = ltFileMsg.Text + "定義番号：15010　/　キー：IMPORT_FILE を 設定して下さい。" + "</BR>";
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
                ltFileMsg.Text = ltFileMsg.Text + "定義番号：15010　/　キー：IMPORT_FILE が 設定されていません。" + "</BR>";
                ltFileMsg.Text = ltFileMsg.Text + "定義番号：15010　/　キー：IMPORT_FILE を 設定して下さい。" + "</BR>";
                ltFileMsg.Text = ltFileMsg.Text + "</font>";
                ltFileMsg.Text = ltFileMsg.Text + "</ pre>";
            }

        }

        /// <summary>
        /// 取込済みデータのチェック
        /// </summary>
        /// <param name="flg">初回フラグ</param>
        private void Torikomi_Data_Check(int flg)
        {
            /*取込済みのデータが存在するかどうかを確認する*/
            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectManualTorikomiCheck().ToString(), paramDict, ref dt)) > 0)
            {
                /*取込済みデータが存在する場合は、取込済みデータの情報を出力する*/
                ltFileMsg.Text = ltFileMsg.Text + "<pre>";
                ltFileMsg.Text = ltFileMsg.Text + "</BR>";
                if (flg == 0)
                {
                    ltFileMsg.Text = ltFileMsg.Text + "取込済みかつ未更新のデータが存在します。";
                    ltFileMsg.Text = ltFileMsg.Text + "</BR>";
                    ltFileMsg.Text = ltFileMsg.Text + "取込済みデータを更新する場合は、更新処理開始のボタンを押して下さい。";
                    ltFileMsg.Text = ltFileMsg.Text + "</BR>";
                    ltFileMsg.Text = ltFileMsg.Text + "</BR>";
                }
                else
                {
                    ltFileMsg.Text = ltFileMsg.Text + "</BR>";
                    ltFileMsg.Text = ltFileMsg.Text + "取込データを更新する場合は、更新処理開始のボタンを押して下さい。";
                    ltFileMsg.Text = ltFileMsg.Text + "</BR>";
                    ltFileMsg.Text = ltFileMsg.Text + "</BR>";
                }

                ltFileMsg.Text = ltFileMsg.Text + "<TABLE border='1'>";

                ltFileMsg.Text = ltFileMsg.Text + "<tr>";
                ltFileMsg.Text = ltFileMsg.Text + "<td align='center'>";
                ltFileMsg.Text = ltFileMsg.Text + "　年月　";
                ltFileMsg.Text = ltFileMsg.Text + "</td>";

                ltFileMsg.Text = ltFileMsg.Text + "<td align='center'>";
                ltFileMsg.Text = ltFileMsg.Text + "　卸店コード　";
                ltFileMsg.Text = ltFileMsg.Text + "</td>";

                ltFileMsg.Text = ltFileMsg.Text + "<td align='center'>";
                ltFileMsg.Text = ltFileMsg.Text + "　卸店名　　";
                ltFileMsg.Text = ltFileMsg.Text + "</td>";

                ltFileMsg.Text = ltFileMsg.Text + "<td align='center'>";
                ltFileMsg.Text = ltFileMsg.Text + "　レコード件数　";
                ltFileMsg.Text = ltFileMsg.Text + "</td>";

                ltFileMsg.Text = ltFileMsg.Text + "</tr>";

                foreach (DataRow dr in dt.Rows)
                {
                    ltFileMsg.Text = ltFileMsg.Text + "<tr>";

                    ltFileMsg.Text = ltFileMsg.Text + "<td align='center'>";
                    ltFileMsg.Text = ltFileMsg.Text + dr["INP_DATE"].ToString();
                    ltFileMsg.Text = ltFileMsg.Text + "</td>";

                    ltFileMsg.Text = ltFileMsg.Text + "<td align='center'>";
                    ltFileMsg.Text = ltFileMsg.Text + dr["INP_OROSI"].ToString();
                    ltFileMsg.Text = ltFileMsg.Text + "</td>";

                    ltFileMsg.Text = ltFileMsg.Text + "<td align='left'>";
                    ltFileMsg.Text = ltFileMsg.Text + dr["km04d_name_k"].ToString();
                    ltFileMsg.Text = ltFileMsg.Text + "</td>";

                    ltFileMsg.Text = ltFileMsg.Text + "<td align='right'>";
                    ltFileMsg.Text = ltFileMsg.Text + dr["REC_COUNT"].ToString() + "件";
                    ltFileMsg.Text = ltFileMsg.Text + "</td>";

                    ltFileMsg.Text = ltFileMsg.Text + "</tr>";

                }
                ltFileMsg.Text = ltFileMsg.Text + "</TABLE>";
                ltFileMsg.Text = ltFileMsg.Text + "</ pre>";

                /*更新ボタンを有効にする*/
                btnUpdate.Visible = true;
            }
            else
            {
                /*更新ボタンを無効にする*/
                btnUpdate.Visible = false;
            }
        }

        /// <summary>
        /// 取込処理開始ボタンの押下イベント
        /// </summary>
        protected void btnTorikomi_Click(object sender, EventArgs e)
        {
            /*ストアドの実行を行う*/
            try
            {
                //実行するストアドプロシージャを取得する
                DataTable dt = new DataTable();
                Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
                if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectManualTorikomiProc().ToString(), paramDict, ref dt)) > 0)
                {
                    /*ストアドプロシージャ名の取得*/
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
                    ltMsg.Text = ltMsg.Text + "手入力小売店の取込処理が正常に終了しました。" + "</BR>";
                    ltMsg.Text = ltMsg.Text + "続いて、更新処理を実施して下さい。" + "</BR>";
                    ltMsg.Text = ltMsg.Text + "</ pre>";
                }

                /*取込ファイルの情報を表示する*/
                this.Get_Information_ImportFile();
                /*取込済みのファイルが存在するかどうかのチェック*/
                this.Torikomi_Data_Check(2);

            }
            catch (Exception ex)
            {
                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "手入力小売店の取込処理でエラーが発生しました。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "エラーメッセージ：" + ex.Message + "</BR>";
                ltMsg.Text = ltMsg.Text + "エラーソース    ：" + ex.Source + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
            }
        }

        /// <summary>
        /// 更新処理開始ボタンの押下イベント
        /// </summary>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            /*ストアドの実行を行う*/
            try
            {
                //実行するストアドプロシージャを取得する
                DataTable dt = new DataTable();
                Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
                if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectManualUpdateProc().ToString(), paramDict, ref dt)) > 0)
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
                    ltMsg.Text = ltMsg.Text + "手入力小売店の更新処理が正常に終了しました。" + "</BR>";
                    ltMsg.Text = ltMsg.Text + "</ pre>";
                }

                /*取込ファイルの情報を表示する*/
                this.Get_Information_ImportFile();
                /*取込済みのファイルが存在するかどうかのチェック*/
                this.Torikomi_Data_Check(2);

            }
            catch (Exception ex)
            {
                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "手入力小売店の更新処理でエラーが発生しました。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "エラーメッセージ：" + ex.Message + "</BR>";
                ltMsg.Text = ltMsg.Text + "エラーソース    ：" + ex.Source + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
            }
        }
           
    }
}