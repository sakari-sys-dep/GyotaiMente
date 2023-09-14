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
    public partial class MstCnvTokui________old : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*画面のクリア*/
                this.screenItemClear();
                /*フォーカスセット*/
                txtOrositenPriCd.Focus();
            }
        }

        private void screenItemClear()
        {
            txtOrositenPriCd.Text = "";
            txtCenterCd.Text = "";
            txtOrositenCd.Text = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ltMsg.Text = "";

            if (!string.IsNullOrEmpty(txtOrositenPriCd.Text.TrimEnd()))
            {
                this.SeaechKM41D();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ltMsg.Text = "";

            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.KM41D_PRIVATE_CD, txtOrositenPriCd.Text.TrimEnd());
            paramDict.Add(constSql.KM41D_CENTER_CD, txtCenterCd.Text.TrimEnd());
            paramDict.Add(constSql.KM41D_TOKUI_CD, txtOrositenCd.Text.TrimEnd());
            DBManager db = new DBManager();
            try
            {
                db.Connect("dbret", -1);
                db.BeginTransaction();
                db.ExecuteNonQuery(constSql.CreateSqlUpdateKM41D().ToString(), paramDict);
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

            /*削除処理*/
            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.KM41D_PRIVATE_CD, txtOrositenPriCd.Text.TrimEnd());
            paramDict.Add(constSql.KM41D_CENTER_CD, txtCenterCd.Text.TrimEnd());
            DBManager db = new DBManager();
            try
            {
                db.Connect("dbret", -1);
                db.BeginTransaction();
                db.ExecuteNonQuery(constSql.CreateSqlDeleteKM41D().ToString(), paramDict);
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

        private void SeaechKM41D()
        {
            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.KM41D_PRIVATE_CD, txtOrositenPriCd.Text.TrimEnd());
            paramDict.Add(constSql.KM41D_CENTER_CD, txtCenterCd.Text.TrimEnd());
            if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectKM41D().ToString(), paramDict, ref dt)) > 0)
            {
                this.screenItemSet(dt.Rows[0]);
            }
            else
            {
                ltMsg.Text = "データがありません。";
            }
        }

        private void screenItemSet(DataRow dr)
        {
            txtOrositenPriCd.Text = dr["km41d_private_cd"].ToString();
            txtCenterCd.Text = dr["km41d_center_cd"].ToString();
            txtOrositenCd.Text = dr["km41d_tokui_cd"].ToString();
            if (dr["km41d_tokui_cd"].ToString() == "D")
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