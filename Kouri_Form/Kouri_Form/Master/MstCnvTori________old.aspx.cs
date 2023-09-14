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
    public partial class MstCnvTori________old : System.Web.UI.Page
    {
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ltMsg.Text = "";

            if (string.IsNullOrEmpty(txtOrositenCd.Text.TrimEnd()))
            {
                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + "卸店コード（５桁）を入力して下さい。";
                txtOrositenCd.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPriToriCd.Text.TrimEnd()))
            {
                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + "プライベート取引先を入力して下さい。";
                txtPriToriCd.Focus();
                return;
            }

            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.KM42D_OROSI_TEN, txtOrositenCd.Text.TrimEnd());
            paramDict.Add(constSql.KM42D_PRV_TORI,  txtPriToriCd.Text.TrimEnd());
            if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectKM42D().ToString(), paramDict, ref dt)) > 0)
            {
                this.screenSet(dt.Rows[0]);
            }
            else
            {
                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + "取引先ＣＶＴマスタが存在しません。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "新規登録をお願いします。" + "</BR>";
                txtOrositenCd.Focus();
            }

        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ltMsg.Text = "";

            if (string.IsNullOrEmpty(txtOrositenCd.Text.TrimEnd()))
            {
                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + "卸店コード（５桁）を入力して下さい。";
                txtOrositenCd.Focus();
            }

            if (string.IsNullOrEmpty(txtPriToriCd.Text.TrimEnd()))
            {
                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + "プライベート取引先を入力して下さい。";
                txtPriToriCd.Focus();
            }

            /*更新処理*/
            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.KM42D_OROSI_TEN, txtOrositenCd.Text.TrimEnd());
            paramDict.Add(constSql.KM42D_PRV_TORI,  txtPriToriCd.Text.TrimEnd());
            paramDict.Add(constSql.KM42D_TORI_CD,   txtTorCd.Text.TrimEnd());
            DBManager db = new DBManager();
            try
            {
                db.Connect("dbret", -1);
                db.BeginTransaction();
                db.ExecuteNonQuery(constSql.CreateSqlUpdateKM42D().ToString(), paramDict);
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

            if (string.IsNullOrEmpty(txtOrositenCd.Text.TrimEnd()))
            {
                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + "卸店コード（５桁）を入力して下さい。";
                txtOrositenCd.Focus();
            }

            if (string.IsNullOrEmpty(txtPriToriCd.Text.TrimEnd()))
            {
                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + "プライベート取引先を入力して下さい。";
                txtPriToriCd.Focus();
            }

            /*削除処理*/
            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.KM42D_OROSI_TEN, txtOrositenCd.Text.TrimEnd());
            paramDict.Add(constSql.KM42D_PRV_TORI, txtPriToriCd.Text.TrimEnd());
            DBManager db = new DBManager();
            try
            {
                db.Connect("dbret", -1);
                db.BeginTransaction();
                db.ExecuteNonQuery(constSql.CreateSqlDeleteKM42D().ToString(), paramDict);
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

        private void screenItemClear()
        {
            txtOrositenCd.Text = "";
            txtPriToriCd.Text = "";
            txtTorCd.Text = "";
        }

        private void screenSet(DataRow dr)
        {
            txtOrositenCd.Text = dr["km42d_orosi_ten"].ToString();
            txtPriToriCd.Text  = dr["km42d_prv_tori"].ToString();
            txtTorCd.Text = dr["km42d_tori_cd"].ToString();
            if (dr["km42d_maint"].ToString() == "D")
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