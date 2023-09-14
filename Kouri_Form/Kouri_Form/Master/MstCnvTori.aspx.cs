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
    public partial class MstCnvTori : System.Web.UI.Page
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
            this.KM42DDataExistenceCheck(1);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!(InputKM42DValueInsertUpdateCheck()))
            {
                return;
            }

            ltMsg.Text = "";
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!(KM42DDataExistenceCheck(0)))
            {
                return;
            }

            ltMsg.Text = "";
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

        private bool InputKM42DValueSearchCheck()
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

            if (string.IsNullOrEmpty(txtPriToriCd.Text.TrimEnd()))
            {
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "プライベート取引先を入力して下さい。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtPriToriCd.Focus();
                return false;
            }

            byte[] byte_PriToriCd = System.Text.Encoding.GetEncoding(932).GetBytes(txtPriToriCd.Text.TrimEnd());
            if (byte_PriToriCd.Length != txtPriToriCd.Text.TrimEnd().Length)
            {
                /*全角が含まれていた場合はエラーメッセージを表示*/
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "半角文字でプライベート取引先を入力して下さい。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtPriToriCd.Focus();
                return false;
            }
            return true;
        }

        private bool InputKM42DValueInsertUpdateCheck()
        {
            if (!(InputKM42DValueSearchCheck()))
            {
                return false;
            }

            ltMsg.Text = "";
            if (string.IsNullOrEmpty(txtTorCd.Text.TrimEnd()))
            {
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "小売店・統一コードを入力して下さい。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtTorCd.Focus();
                return false;
            }

            int num = 0;
            if (!(int.TryParse(txtTorCd.Text.TrimEnd(), out num)))
            {
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "半角数字で小売店・統一コードを入力して下さい。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtTorCd.Focus();
                return false;
            }

            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.KM01D_TOR_CD, txtTorCd.Text.TrimEnd());
            if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectKM01D().ToString(), paramDict, ref dt)) > 0)
            {
                return true;
            }
            else
            {
                /*卸店コードがKM01Dにも存在しない場合エラーメッセージを表示*/
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "入力いたしました小売店・統一コードは、小売店マスタには存在しません。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtTorCd.Focus();
                return false;
            }
        }

        private bool KM42DDataExistenceCheck(int nScreenSetJudg)
        {
            if (!(InputKM42DValueSearchCheck()))
            {
                return false;
            }

            ltMsg.Text = "";
            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.KM42D_OROSI_TEN, txtOrositenCd.Text.TrimEnd());
            paramDict.Add(constSql.KM42D_PRV_TORI, txtPriToriCd.Text.TrimEnd());
            if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectKM42D().ToString(), paramDict, ref dt)) > 0)
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
                ltMsg.Text = ltMsg.Text + "取引先ＣＶＴマスタが存在しません。" + "</BR>";
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