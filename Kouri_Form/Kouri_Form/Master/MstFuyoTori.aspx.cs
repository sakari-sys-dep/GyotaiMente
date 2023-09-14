using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Kouri_Form.Class;
using System.Data;
using System.Text;

namespace Kouri_Form.Master
{
    public partial class MstFuyoTori : System.Web.UI.Page
    {
        /// <summary>
        /// ロードイベント
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*画面のクリア*/
                this.screenItemClear();
                /*フォーカスセット*/
                txtOrositenCd.Focus();
            }
        }

        /// <summary>
        /// 検索ボタンの押下イベント
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.KM43DDataExistenceCheck(1);
        }

        /// <summary>
        /// 更新ボタンの押下イベント
        /// </summary>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!(InputKM43DValueSearchCheck()))
            {
                return;
            }

            ltMsg.Text = "";
            txtKouriCd.Text = "44444444";
            /*登録・更新処理*/
            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.KM43D_OROSI_TEN, txtOrositenCd.Text.TrimEnd());
            paramDict.Add(constSql.KM43D_TORI_NM, txtFuyoToriNM.Text.TrimEnd());
            paramDict.Add(constSql.KM43D_TORI_CD, txtKouriCd.Text.TrimEnd());
            DBManager db = new DBManager();
            try
            {
                db.Connect("dbret", -1);
                db.BeginTransaction();
                db.ExecuteNonQuery(constSql.CreateSqlUpdateKM43D().ToString(), paramDict);
                db.CommitTransaction();
                ltMsg.Text = ltMsg.Text + "更新処理が完了しました。 " + "</BR>";
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();

                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + " 更新処理でエラーが発生しました。 " + "</BR>";
                ltMsg.Text = ltMsg.Text + "エラーメッセージ：" + ex.Message + "</BR>";
                ltMsg.Text = ltMsg.Text + "エラー場所      ：" + ex.Source + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                throw ex;
            }
            finally
            {
                db.Disconnect();
            }
        }

        /// <summary>
        /// 削除ボタンの押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!(KM43DDataExistenceCheck(0)))
            {
                return;
            }

            ltMsg.Text = "";
            /*削除処理*/
            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.KM43D_OROSI_TEN, txtOrositenCd.Text.TrimEnd());
            paramDict.Add(constSql.KM43D_TORI_NM, txtFuyoToriNM.Text.TrimEnd());
            DBManager db = new DBManager();
            try
            {
                db.Connect("dbret", -1);
                db.BeginTransaction();
                db.ExecuteNonQuery(constSql.CreateSqlDeleteKM43D().ToString(), paramDict);
                db.CommitTransaction();
                ltMsg.Text = ltMsg.Text + "削除処理が完了しました。 " + "</BR>";
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + " 削除処理でエラーが発生しました。 " + "</BR>";
                ltMsg.Text = ltMsg.Text + "エラーメッセージ：" + ex.Message + "</BR>";
                ltMsg.Text = ltMsg.Text + "エラー場所      ：" + ex.Source + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                throw ex;
            }
            finally
            {
                db.Disconnect();
            }
        }

        private void screenItemClear()
        {
            txtOrositenCd.Text = "";
            txtFuyoToriNM.Text = "";
        }

        private void screenSet(DataRow dr)
        {
            txtOrositenCd.Text = dr["km43d_orosi_ten"].ToString();
            txtFuyoToriNM.Text = dr["km43d_tori_nm"].ToString();
            txtKouriCd.Text = dr["km43d_tori_cd"].ToString();
            if (dr["km43d_maint"].ToString() == "D")
            {
                ltMsg.Text = ltMsg.Text + "削除済みのデータです。" + "</BR>";
            }
            else
            {
                ltMsg.Text = "";
            }

            ltMsg.Text = ltMsg.Text + "<pre>";
            ltMsg.Text = ltMsg.Text + "<FONT color='blue'>";
            ltMsg.Text = ltMsg.Text + "1件の取引先不要マスタの確認がとれました。" + "</BR>";
            ltMsg.Text = ltMsg.Text + "</font>";
            ltMsg.Text = ltMsg.Text + "</ pre>";
        }

        private bool InputKM43DValueSearchCheck()
        {
            ltMsg.Text = "";
            if (string.IsNullOrEmpty(txtOrositenCd.Text.TrimEnd()))
            {
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "卸店コード（５桁）を入力して下さい。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtOrositenCd.Focus();
                return false;
            }

            byte[] byte_OrositenCd = System.Text.Encoding.GetEncoding(932).GetBytes(txtOrositenCd.Text.TrimEnd());
            if (byte_OrositenCd.Length != txtOrositenCd.Text.TrimEnd().Length)
            {
                /*全角が含まれていた場合はエラーメッセージを表示*/
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "半角文字で卸店コード（５桁）を入力して下さい。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtOrositenCd.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtFuyoToriNM.Text.TrimEnd()))
            {
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "不要取引先名を入力して下さい。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtFuyoToriNM.Focus();
                return false;
            }
            return true;
        }

        private bool KM43DDataExistenceCheck(int nScreenSetJudg)
        {
            if (!(InputKM43DValueSearchCheck()))
            {
                return false;
            }

            ltMsg.Text = "";
            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.KM43D_OROSI_TEN, txtOrositenCd.Text.TrimEnd());
            paramDict.Add(constSql.KM43D_TORI_NM, txtFuyoToriNM.Text.TrimEnd());
            if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectKM43D().ToString(), paramDict, ref dt)) > 0)
            {
                if (nScreenSetJudg == 1)
                {
                    this.screenSet(dt.Rows[0]);
                }
                return true;
            }
            else
            {
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "取引先不要マスタが存在しません。" + "</BR>";
                if (nScreenSetJudg == 1)
                {
                    ltMsg.Text = ltMsg.Text + "新規登録をお願いします。" + "</BR>";
                }  
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtOrositenCd.Focus();
                return false;
            }
        }
    }
}