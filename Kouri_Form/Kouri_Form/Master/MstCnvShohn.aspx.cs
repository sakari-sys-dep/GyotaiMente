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
    public partial class MstCnvShohn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*画面のクリア*/
                this.screenClear();
                /*フォーカスのセット*/
                txtOrosiCd.Focus();
            }
        }

        /// <summary>
        /// 検索ボタンの押下イベント
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.KM44DDataExistenceCheck(1);
        }

        /// <summary>
        /// 登録・更新ボタンの押下イベント
        /// </summary>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!(InputKM44DValueInsertUpdateCheck()))
            {
                return;
            }

            ltMsg.Text = "";
            /*登録・更新処理*/
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
            if (!(KM44DDataExistenceCheck(0)))
            {
                return;
            }

            ltMsg.Text = "";
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

        private bool InputKM44DValueSearchCheck()
        {
            ltMsg.Text = "";
            /*検索時はキー項目の入力チェック*/
            if (!(string.IsNullOrEmpty(txtOrosiCd.Text.TrimEnd())))
            {
                byte[] byte_OrosiCd = System.Text.Encoding.GetEncoding(932).GetBytes(txtOrosiCd.Text.TrimEnd());
                if (byte_OrosiCd.Length != txtOrosiCd.Text.TrimEnd().Length)
                {
                    /*全角が含まれていた場合はエラーメッセージを表示*/
                    ltMsg.Text = ltMsg.Text + "<pre>";
                    ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                    ltMsg.Text = ltMsg.Text + "卸店コードを入力する場合は、半角文字で入力してください。" + "</BR>";
                    ltMsg.Text = ltMsg.Text + "</font>";
                    ltMsg.Text = ltMsg.Text + "</ pre>";
                    txtOrosiCd.Focus();
                    return false;
                }
            }

            if (string.IsNullOrEmpty(txtPriShohin.Text.TrimEnd()))
            {
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "商品プライベートコードを入力して下さい。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtPriShohin.Focus();
                return false;
            }

            byte[] byte_PriShohin = System.Text.Encoding.GetEncoding(932).GetBytes(txtPriShohin.Text.TrimEnd());
            if (byte_PriShohin.Length != txtPriShohin.Text.TrimEnd().Length)
            {
                /*全角が含まれていた場合はエラーメッセージを表示*/
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "半角文字で商品プライベートコードを入力して下さい。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtPriShohin.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtIrisu.Text.TrimEnd()))
            {
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "入数に空白は入力できません。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtIrisu.Focus();
                return false;
            }

            int num = 0;
            if (!(int.TryParse(txtIrisu.Text.TrimEnd(), out num)))
            {
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "半角数字で入数を入力して下さい。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtIrisu.Focus();
                return false;
            }
            return true;
        }

        private bool InputKM44DValueInsertUpdateCheck()
        {
            if (!(InputKM44DValueSearchCheck()))
            {
                return false;
            }

            ltMsg.Text = "";
            if (string.IsNullOrEmpty(txtShohinCd.Text.TrimEnd()))
            {
                /*空白の場合はエラーメッセージを表示*/
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "商品コードを入力して下さい。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtShohinCd.Focus();
                return false;
            }

            /*数字のチェック*/
            int num = 0;
            if (!(int.TryParse(txtShohinCd.Text.TrimEnd(), out num)))
            {
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "半角数字で商品コードで入力して下さい。";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtShohinCd.Focus();
                return false;
            }

            return true;
        }


        private bool KM44DDataExistenceCheck(int nScreenSetJudg)
        {
            if (!(InputKM44DValueSearchCheck()))
            {
                return false;
            }

            ltMsg.Text = "";
            /*マスタよりデータ抽出*/
            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.KM44D_OROSI_TEN, txtOrosiCd.Text.TrimEnd());
            paramDict.Add(constSql.KM44D_PRV_SHO, txtPriShohin.Text.TrimEnd());
            paramDict.Add(constSql.KM44D_IRI_SU, txtIrisu.Text.TrimEnd());
            if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectKM44D().ToString(), paramDict, ref dt)) > 0)
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
                ltMsg.Text = ltMsg.Text + "商品ＣＶＴマスタが存在しません。" + "</BR>";
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