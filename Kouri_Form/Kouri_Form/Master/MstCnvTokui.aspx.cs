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
    public partial class MstCnvTokui : System.Web.UI.Page
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

        /*検索ボタン押下イベント*/
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            this.KM41DDataExistenceCheck(1);
        }

        /*更新ボタン押下イベント*/
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!(InputKM41DValueInsertUpdateCheck()))
            {
                return;
            }

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

        /*削除ボタン押下イベント*/
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            /*KM41D存在チェック*/
            if (!(KM41DDataExistenceCheck(0)))
            {
                return;
            }

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
            txtOrositenPriCd.Text = "";
            txtCenterCd.Text = "";
            txtOrositenCd.Text = "";
        }

        private void screenItemSet(DataRow dr)
        {
            txtOrositenPriCd.Text = dr["km41d_private_cd"].ToString();
            txtCenterCd.Text = dr["km41d_center_cd"].ToString();
            txtOrositenCd.Text = dr["km41d_tokui_cd"].ToString();
            if (dr["km41d_maint"].ToString() == "D")
            {
                ltMsg.Text = "削除済みのデータです。";
            }
            else
            {
                ltMsg.Text = "";
            }
        }

        private bool InputKM41DValueSearchCheck()
        {
            ltMsg.Text = "";
            if (string.IsNullOrEmpty(txtOrositenPriCd.Text.TrimEnd()))
            {
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "卸店プライベートコードを入力して下さい。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtOrositenPriCd.Focus();
                return false;
            }

            byte[] byte_OrositenPriCd = System.Text.Encoding.GetEncoding(932).GetBytes(txtOrositenPriCd.Text.TrimEnd());
            if (byte_OrositenPriCd.Length != txtOrositenPriCd.Text.TrimEnd().Length)
            {
                /*全角が含まれていた場合はエラーメッセージを表示*/
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "半角文字で卸店プライベートコードを入力して下さい。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtOrositenPriCd.Focus();
                return false;
            }

            if (!(string.IsNullOrEmpty(txtCenterCd.Text.TrimEnd())))
            {
                byte[] byte_CenterCd = System.Text.Encoding.GetEncoding(932).GetBytes(txtCenterCd.Text.TrimEnd());
                if (byte_CenterCd.Length != txtCenterCd.Text.TrimEnd().Length)
                {
                    /*全角が含まれていた場合はエラーメッセージを表示*/
                    ltMsg.Text = ltMsg.Text + "<pre>";
                    ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                    ltMsg.Text = ltMsg.Text + "センターコードを入力する場合は半角文字で入力して下さい。" + "</BR>";
                    ltMsg.Text = ltMsg.Text + "</font>";
                    ltMsg.Text = ltMsg.Text + "</ pre>";
                    txtCenterCd.Focus();
                    return false;
                }
            }
            return true;
        }

        private bool InputKM41DValueInsertUpdateCheck()
        {
            if (!(InputKM41DValueSearchCheck()))
            {
                return false;
            }

            ltMsg.Text = "";
            if (string.IsNullOrEmpty(txtOrositenCd.Text.TrimEnd()))
            {
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "卸店コードを入力して下さい。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtOrositenCd.Focus();
                return false;
            }

            int num = 0;
            if (!(int.TryParse(txtOrositenCd.Text.TrimEnd(), out num)))
            {
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "半角数字で卸店コードを入力して下さい。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtOrositenCd.Focus();
                return false;
            }

            /*マスタよりデータ抽出*/
            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.KM04D_TEN_CD, txtOrositenCd.Text.TrimEnd());
            if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectKM04D().ToString(), paramDict, ref dt)) > 0)
            { 
                return true;
            }
            else
            {
                /*卸店コードがKM04Dにも存在しない場合エラーメッセージを表示*/
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "入力いたしました卸店コードは、卸店マスタには存在しません。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtOrositenCd.Focus();
                return false;
            }
        }

        private bool KM41DDataExistenceCheck(int nScreenSetJudg)
        {
            if (!(InputKM41DValueSearchCheck()))
            {
                return false;
            }

            ltMsg.Text = "";
            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.KM41D_PRIVATE_CD, txtOrositenPriCd.Text.TrimEnd());
            paramDict.Add(constSql.KM41D_CENTER_CD, txtCenterCd.Text.TrimEnd());
            if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectKM41D().ToString(), paramDict, ref dt)) > 0)
            {
                if (nScreenSetJudg == 1)
                {
                    this.screenItemSet(dt.Rows[0]);
                }
                return true;
            }
            else
            {
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "卸店プライベートマスタが存在しません。" + "</BR>";
                if (nScreenSetJudg == 1)
                {
                    ltMsg.Text = ltMsg.Text + "新規登録をお願いします。" + "</BR>";
                }
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtOrositenPriCd.Focus();
                return false;
            }
        }
    }
}