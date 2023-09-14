using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Kouri_Form.Class;
using System.Data;
using System.Text;
using System.Windows.Forms;
using AjaxControlToolkit.HtmlEditor.ToolbarButtons;

namespace Kouri_Form.Master
{
    public partial class MstCnvOrosi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*画面のクリア*/
                this.screenClear();
                /*フォーカスセット*/
                txtOrosiCd.Focus();
            }
        }

        /// <summary>
        /// 検索ボタンの押下イベント
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.KM04DDataExistenceCheck(1);
        }

        /// <summary>
        /// 登録・更新ボタンの押下イベント
        /// </summary>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!(InputKM04DValueInsertUpdateCheck()))
            {
                return;
            }

            ltMsg.Text = "";
            /*登録・更新処理*/
            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.KM04D_TEN_CD,    txtTenCd.Text.TrimEnd());
            paramDict.Add(constSql.KM04D_BR_NAME_A, txtBrName_a.Text.TrimEnd());
            paramDict.Add(constSql.KM04D_BR_NAME_K, txtBrName_k.Text.TrimEnd());
            paramDict.Add(constSql.KM04D_NAME_A, txtName_a.Text.TrimEnd());
            paramDict.Add(constSql.KM04D_NAME_K, txtName_k.Text.TrimEnd());
            paramDict.Add(constSql.KM04D_OROSI_CD, txtOrosiCd.Text.TrimEnd() + txtOrosiEda.Text.TrimEnd());
            paramDict.Add(constSql.KM04D_PRI_KBN, ddlPriKbn.SelectedValue);
            paramDict.Add(constSql.KM04D_MAINT, "C");
            DBManager db = new DBManager();
            try
            {
                db.Connect("dbret", -1);
                db.BeginTransaction();
                db.ExecuteNonQuery(constSql.CreateSqlUpdateKM04D().ToString(), paramDict);
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
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!(KM04DDataExistenceCheck(0)))
            {
                return;
            }

            ltMsg.Text = "";
            /*削除処理*/
            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.KM04D_TEN_CD, txtTenCd.Text);
            DBManager db = new DBManager();
            try
            {
                db.Connect("dbret", -1);
                db.BeginTransaction();
                db.ExecuteNonQuery(constSql.CreateSqlDeleteKM04D().ToString(), paramDict);
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

        private void screenClear()
        {
            txtOrosiCd.Text = "";
            txtOrosiEda.Text = "";
            txtTenCd.Text = "";
            ddlPriKbn.SelectedValue = "0";
            txtName_k.Text = "";
            txtName_a.Text = "";
            txtBrName_k.Text = "";
            txtBrName_a.Text = "";
        }

        private void screenSet(DataRow dr)
        {
            txtOrosiCd.Text = dr["km04d_orosi_cd"].ToString();
            txtOrosiEda.Text = dr["km04d_orosi_eda"].ToString();
            txtTenCd.Text = dr["km04d_ten_cd"].ToString();
            txtName_k.Text = dr["km04d_name_k"].ToString();
            txtBrName_k.Text = dr["km04d_br_name_k"].ToString();
            txtName_a.Text = dr["km04d_name_a"].ToString();
            txtBrName_a.Text = dr["km04d_br_name_a"].ToString();
            ddlPriKbn.SelectedValue = dr["km04d_pri_kbn"].ToString();
            if (dr["km04d_maint"].ToString() == "D")
            {
                ltMsg.Text = "削除済みのデータです。";
            }
            else
            {
                ltMsg.Text = "";
            }
        }

        private bool InputKM04DValueSearchCheck()
        {
            ltMsg.Text = "";
            /*検索時はキー項目の入力チェック*/
            if (string.IsNullOrEmpty(txtTenCd.Text.TrimEnd()))
            {
                /*空白の場合はエラーメッセージを表示*/
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "小売店コードを入力して下さい。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtTenCd.Focus();
                return false;
            }

            /*数字のチェック*/
            int num = 0;
            if (!(int.TryParse(txtTenCd.Text.TrimEnd(), out num)))
            {
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "半角数字で小売店コードで入力して下さい。";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtTenCd.Focus();
                return false;
            }

            return true;
        }

        private bool InputKM04DValueInsertUpdateCheck()
        {
            if (!(InputKM04DValueSearchCheck()))
            {
                return false;
            }

            ltMsg.Text = "";
            if (string.IsNullOrEmpty(txtOrosiCd.Text.TrimEnd()))
            {
                /*空白の場合はエラーメッセージを表示*/
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "卸店コードを入力して下さい。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtOrosiCd.Focus();
                return false;
            }

            byte[] byte_OrosiCd = System.Text.Encoding.GetEncoding(932).GetBytes(txtOrosiCd.Text.TrimEnd());
            if (byte_OrosiCd.Length != txtOrosiCd.Text.TrimEnd().Length)
            {
                /*全角が含まれていた場合はエラーメッセージを表示*/
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "半角文字で卸店コードを入力して下さい。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtOrosiCd.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtOrosiEda.Text.TrimEnd()))
            {
                /*空白の場合はエラーメッセージを表示*/
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "支店・営業コードを入力して下さい。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtOrosiEda.Focus();
                return false;
            }

            byte[] byte_OrosiEda = System.Text.Encoding.GetEncoding(932).GetBytes(txtOrosiEda.Text.TrimEnd());
            if (byte_OrosiEda.Length != txtOrosiEda.Text.TrimEnd().Length)
            {
                /*全角が含まれていた場合はエラーメッセージを表示*/
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "半角文字で支店・営業コードを入力して下さい。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtOrosiEda.Focus();
                return false;
            }

            return true;
        }

        private bool KM04DDataExistenceCheck(int nScreenSetJudg)
        {
            if(!(InputKM04DValueSearchCheck()))
            {
                return false;
            }

            ltMsg.Text = "";
            /*マスタよりデータ抽出*/
            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.KM04D_TEN_CD, txtTenCd.Text.TrimEnd());
            if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectKM04D().ToString(), paramDict, ref dt)) > 0)
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
                ltMsg.Text = ltMsg.Text + "卸店マスタが存在しません。" + "</BR>";
                if (nScreenSetJudg == 1)
                {
                    ltMsg.Text = ltMsg.Text + "新規登録をお願いします。" + "</BR>";
                }
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtOrosiCd.Focus();
                return false;
            }
        }
    }
}