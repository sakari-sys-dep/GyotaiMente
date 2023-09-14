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
    public partial class MstCnvOrosi________old : System.Web.UI.Page
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


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ltMsg.Text = "";
            /*検索時はキー項目の入力チェック*/
            if (string.IsNullOrEmpty(txtTenCd.Text.TrimEnd()))
            {
                /*空白の場合はエラーメッセージを表示*/
                ltMsg.Text = "小売店コードを入力して下さい。";
                txtTenCd.Focus();
                return;
            }

            /*マスタよりデータ抽出*/
            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.KM04D_TEN_CD, txtTenCd.Text.TrimEnd());
            if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectKM04D().ToString(), paramDict, ref dt)) > 0)
            {
                this.screenSet(dt.Rows[0]);
            }
            else
            {
                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + "卸店マスタが存在しません。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "新規登録をお願いします。" + "</BR>";
                txtOrosiCd.Focus();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ltMsg.Text = "";
            /*更新時はキー項目の入力チェック*/
            if (string.IsNullOrEmpty(txtTenCd.Text.TrimEnd()))
            {
                /*空白の場合はエラーメッセージを表示*/
                ltMsg.Text = "小売店コードを入力して下さい。";
                txtTenCd.Focus();
                return;
            }

            /*更新処理*/
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
                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + "更新処理が完了しました。 " + "</BR>";
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();

                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + " 更新処理でエラーが発生しました。 " + "</BR>";
                ltMsg.Text = ltMsg.Text + "エラーメッセージ：" + ex.Message + "</BR>";
                ltMsg.Text = ltMsg.Text + "エラー場所      ：" + ex.Source + "</BR>";
                throw ex;
            }
            finally
            {
                db.Disconnect();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ltMsg.Text = "";
            /*削除時はキー項目の入力チェック*/
            if (string.IsNullOrEmpty(txtTenCd.Text.TrimEnd()))
            {
                /*空白の場合はエラーメッセージを表示*/
                ltMsg.Text = "小売店コードを入力して下さい。";
                txtTenCd.Focus();
                return;
            }

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
                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + "削除処理が完了しました。 " + "</BR>";
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();

                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + " 削除処理でエラーが発生しました。 " + "</BR>";
                ltMsg.Text = ltMsg.Text + "エラーメッセージ：" + ex.Message + "</BR>";
                ltMsg.Text = ltMsg.Text + "エラー場所      ：" + ex.Source + "</BR>";
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
    }
}