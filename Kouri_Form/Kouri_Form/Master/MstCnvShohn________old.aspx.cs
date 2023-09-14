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
    public partial class MstCnvShohn________old : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                /*画面のクリア*/
                this.screenClear();
                /*フォーカスのセット*/
                txtOrosiCd.Focus();
            }
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOrosiCd.Text.TrimEnd()))
            {
                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + "卸店コードを入力して下さい。";
                txtOrosiCd.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPriShohin.Text.TrimEnd()))
            {
                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + "商品プライベートコードを入力して下さい。";
                txtPriShohin.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtIrisu.Text.TrimEnd()))
            {
                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + "入数に空白は入力できません。";
                txtIrisu.Focus();
                return;
            }
            int num = 0;
            if (!int.TryParse(txtIrisu.Text.TrimEnd(), out num))
            {
                ltMsg.Text = "入数は、数字で入力して下さい。";
                txtIrisu.Focus();
                return;
            }

            /*マスタよりデータ抽出*/
            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.KM44D_OROSI_TEN, txtOrosiCd.Text.TrimEnd());
            paramDict.Add(constSql.KM44D_PRV_SHO,   txtPriShohin.Text.TrimEnd());
            paramDict.Add(constSql.KM44D_IRI_SU,    txtIrisu.Text.TrimEnd());
            if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectKM44D().ToString(), paramDict, ref dt)) > 0)
            {
                    this.screenSet(dt.Rows[0]);
            }
            else
            {
                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + "商品ＣＶＴマスタが存在しません。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "新規登録をお願いします。" + "</BR>";
                txtOrosiCd.Focus();
            }
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOrosiCd.Text.TrimEnd()))
            {
                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + "卸店コードを入力して下さい。";
                txtOrosiCd.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPriShohin.Text.TrimEnd()))
            {
                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + "商品プライベートコードを入力して下さい。";
                txtPriShohin.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtIrisu.Text.TrimEnd()))
            {
                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + "入数に空白は入力できません。";
                txtIrisu.Focus();
                return;
            }
            int num = 0;
            if (!int.TryParse(txtIrisu.Text.TrimEnd(), out num))
            {
                ltMsg.Text = "入数は、数字で入力して下さい。";
                txtIrisu.Focus();
                return;
            }

            /*更新処理*/
            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.KM44D_OROSI_TEN, txtOrosiCd.Text.TrimEnd());
            paramDict.Add(constSql.KM44D_PRV_SHO, txtPriShohin.Text.TrimEnd());
            paramDict.Add(constSql.KM44D_IRI_SU, txtIrisu.Text.TrimEnd());
            paramDict.Add(constSql.KM44D_SHOHIN_CD, txtShohinCd.Text.TrimEnd());
            DBManager db = new DBManager();
            try
            {
                db.Connect("dbret", -1);
                db.BeginTransaction();
                db.ExecuteNonQuery(constSql.CreateSqlUpdateKM44D().ToString(), paramDict);
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
            if (string.IsNullOrEmpty(txtOrosiCd.Text.TrimEnd()))
            {
                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + "卸店コードを入力して下さい。";
                txtOrosiCd.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPriShohin.Text.TrimEnd()))
            {
                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + "商品プライベートコードを入力して下さい。";
                txtPriShohin.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtIrisu.Text.TrimEnd()))
            {
                ltMsg.Text = "";
                ltMsg.Text = ltMsg.Text + "入数に空白は入力できません。";
                txtIrisu.Focus();
                return;
            }
            int num = 0;
            if (!int.TryParse(txtIrisu.Text.TrimEnd(), out num))
            {
                ltMsg.Text = "入数は、数字で入力して下さい。";
                txtIrisu.Focus();
                return;
            }

            /*更新処理*/
            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.KM44D_OROSI_TEN, txtOrosiCd.Text.TrimEnd());
            paramDict.Add(constSql.KM44D_PRV_SHO, txtPriShohin.Text.TrimEnd());
            paramDict.Add(constSql.KM44D_IRI_SU, txtIrisu.Text.TrimEnd());
            DBManager db = new DBManager();
            try
            {
                db.Connect("dbret", -1);
                db.BeginTransaction();
                db.ExecuteNonQuery(constSql.CreateSqlDeleteKM44D().ToString(), paramDict);
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
            txtPriShohin.Text = "";
            txtIrisu.Text = "0";
            txtShohinCd.Text = "";
            ltMsg.Text = "";
        }

        private void screenSet(DataRow dr)
        {
            txtOrosiCd.Text = dr["km44d_orosi_ten"].ToString();
            txtPriShohin.Text = dr["km44d_prv_sho"].ToString();
            txtIrisu.Text = dr["km44d_iri_su"].ToString();
            txtShohinCd.Text = dr["km44d_shohin_cd"].ToString();
            if (dr["km44d_maint"].ToString() == "D")
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