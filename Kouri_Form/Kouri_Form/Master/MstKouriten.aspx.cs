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
    public partial class MstKouriten : System.Web.UI.Page
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
                txtTorCd.Focus();
            }
        }

        /// <summary>
        /// 検索ボタンの押下イベント
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.KM01DDataExistenceCheck(1);
        }

        /// <summary>
        /// 登録・更新ボタンの押下イベント
        /// </summary>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!(InputKM01DValueInsertUpdateCheck()))
            {
                return;
            }

            ltMsg.Text = "";
            /*登録・更新処理*/
            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();

            paramDict.Add(constSql.KM01D_TOR_CD, txtTorCd.Text.TrimEnd());
            paramDict.Add(constSql.KM01D_ADDR_A, txtAddrA.Text.TrimEnd());
            paramDict.Add(constSql.KM01D_ADDR_K, txtAddrK.Text.TrimEnd());
            paramDict.Add(constSql.KM01D_CAN_DO, txtCando.Text.TrimEnd());
            paramDict.Add(constSql.KM01D_DUP_DEL, txtDupDel.Text.TrimEnd());
            paramDict.Add(constSql.KM01D_DUP_MOTO, txtDupMoto.Text.TrimEnd());
            paramDict.Add(constSql.KM01D_FAX, txtFax.Text.TrimEnd());
            paramDict.Add(constSql.KM01D_KBN, txtKbn.Text.TrimEnd());
            paramDict.Add(constSql.KM01D_NAME_A, txtNameA.Text.TrimEnd());
            paramDict.Add(constSql.KM01D_NAME_K, txtNameK.Text.TrimEnd());
            paramDict.Add(constSql.KM01D_NEW_CD, txtNewCd.Text.TrimEnd());
            paramDict.Add(constSql.KM01D_NEW_DATE, txtNewDate.Text.TrimEnd());
            paramDict.Add(constSql.KM01D_OLD_CD, txtOldCd.Text.TrimEnd());
            paramDict.Add(constSql.KM01D_POST, txtPost.Text.TrimEnd());
            paramDict.Add(constSql.KM01D_RYAKU, txtRyaku.Text.TrimEnd());
            paramDict.Add(constSql.KM01D_TEL, txtTel.Text.TrimEnd());
            paramDict.Add(constSql.KM01D_UP_DATE, txtUpDate.Text.TrimEnd());
            paramDict.Add(constSql.KM01D_UP_TANTO, txtUpTanto.Text.TrimEnd());
            paramDict.Add(constSql.KM01D_YAGOU_A, txtYagouA.Text.TrimEnd());
            paramDict.Add(constSql.KM01D_YAGOU_K, txtYagouK.Text.TrimEnd());
            paramDict.Add(constSql.KM01D_Z_KEN_CD, txtKenCd.Text.TrimEnd());
            paramDict.Add(constSql.KM01D_Z_SIKUGUN, txtSikugun.Text.TrimEnd());
            DBManager db = new DBManager();
            try
            {
                db.Connect("dbret", -1);
                db.BeginTransaction();
                db.ExecuteNonQuery(constSql.CreateSqlUpdateKM01D().ToString(), paramDict);
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
            if (!(KM01DDataExistenceCheck(0)))
            {
                return;
            }

            ltMsg.Text = "";
            /*削除処理*/
            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.KM01D_TOR_CD, txtTorCd.Text.TrimEnd());
            DBManager db = new DBManager();
            try
            {
                db.Connect("dbret", -1);
                db.BeginTransaction();
                db.ExecuteNonQuery(constSql.CreateSqlDeleteKM01D().ToString(), paramDict);
                db.CommitTransaction();
                ltMsg.Text = ltMsg.Text + "削除処理が完了しました。 " + "</BR>";
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
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

        /// <summary>
        /// 画面のクリア
        /// </summary>
        private void screenItemClear()
        {
            txtKenCd.Text = "";
            txtSikugun.Text = "";
            txtRyaku.Text = "";
            txtYagouK.Text = "";
            txtYagouA.Text = "";
            txtNameK.Text = "";
            txtNameA.Text = "";
            txtPost.Text = "";
            txtAddrK.Text = "";
            txtAddrA.Text = "";
            txtTel.Text = "";
            txtFax.Text = "";
            txtKbn.Text = "";
            txtNewCd.Text = "";
            txtNewDate.Text = "";
            txtDupDel.Text = "";
            txtOldCd.Text = "";
            txtDupMoto.Text = "";
            txtUpTanto.Text = "";
            txtUpDate.Text = "";
            txtCando.Text = "";
            ltMsg.Text = "";
        }

        /// <summary>
        /// 画面にデータをセット
        /// </summary>
        /// <param name="dr">データレコード</param>
        private void screenItemSet(DataRow dr)
        {
            txtKenCd.Text = dr["km01d_z_ken_cd"].ToString();
            txtSikugun.Text = dr["km01d_z_sikugun"].ToString();
            txtRyaku.Text = dr["km01d_ryaku"].ToString();
            txtYagouK.Text = dr["km01d_yagou_k"].ToString();
            txtYagouA.Text = dr["km01d_yagou_a"].ToString();
            txtNameK.Text = dr["km01d_name_k"].ToString();
            txtNameA.Text = dr["km01d_name_a"].ToString();
            txtPost.Text = dr["km01d_post"].ToString();
            txtAddrK.Text = dr["km01d_addr_k"].ToString();
            txtAddrA.Text = dr["km01d_addr_a"].ToString();
            txtTel.Text = dr["km01d_tel"].ToString();
            txtFax.Text = dr["km01d_fax"].ToString();
            txtKbn.Text = dr["km01d_kbn"].ToString();
            txtNewCd.Text = dr["km01d_new_cd"].ToString();
            txtNewDate.Text = dr["km01d_new_date"].ToString();
            txtDupDel.Text = dr["km01d_dup_del"].ToString();
            txtOldCd.Text = dr["km01d_old_cd"].ToString();
            txtDupMoto.Text = dr["km01d_dup_moto"].ToString();
            txtUpTanto.Text = dr["km01d_up_tanto"].ToString();
            txtUpDate.Text = dr["km01d_up_date"].ToString();
            txtCando.Text = dr["km01d_can_cd"].ToString();

            if (dr["km01d_maint"].ToString() == "D")
            {
                ltMsg.Text = "削除済みデータです。";
            }
            else
            {
                ltMsg.Text = "";
            }
        }

        private bool InputKM01DValueSearchCheck()
        {
            ltMsg.Text = "";
            if (string.IsNullOrEmpty(txtTorCd.Text))
            {
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "取引先コードを入力して下さい。" + "</BR>";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtTorCd.Focus();
                return false;
            }

            /*数字のチェック*/
            int num = 0;
            if (!(int.TryParse(txtTorCd.Text.TrimEnd(), out num)))
            {
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "半角数字で取引先コードを入力して下さい。";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtTorCd.Focus();
                return false;
            }
            return true;
        }

        private bool InputKM01DValueInsertUpdateCheck()
        {
            if (!(InputKM01DValueSearchCheck()))
            {
                return false;
            }

            ltMsg.Text = "";
            if (txtTorCd.Text.Length < 4)
            {
                ltMsg.Text = ltMsg.Text + "<pre>";
                ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                ltMsg.Text = ltMsg.Text + "取引先コードは4桁以上の入力でお願いいたします。";
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                return false;
            }
            
            if (string.IsNullOrEmpty(txtKenCd.Text))
            {
                txtKenCd.Text = txtTorCd.Text.TrimEnd().Substring(0, 2);
            }
            else
            {
                /*数字のチェック*/
                byte num = 0;
                if (!(byte.TryParse(txtKenCd.Text.TrimEnd(), out num)))
                {
                    ltMsg.Text = ltMsg.Text + "<pre>";
                    ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                    ltMsg.Text = ltMsg.Text + "半角数字で県コードを入力して下さい。";
                    ltMsg.Text = ltMsg.Text + "</font>";
                    ltMsg.Text = ltMsg.Text + "</ pre>";
                    txtKenCd.Focus();
                    return false;
                }
            }

            if (string.IsNullOrEmpty(txtSikugun.Text))
            {
                txtSikugun.Text = txtTorCd.Text.TrimEnd().Substring(2, 2);
            }
            else
            {
                /*数字のチェック*/
                byte num = 0;
                if (!(byte.TryParse(txtSikugun.Text.TrimEnd(), out num)))
                {
                    ltMsg.Text = ltMsg.Text + "<pre>";
                    ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                    ltMsg.Text = ltMsg.Text + "半角数字で市区群コードを入力して下さい。";
                    ltMsg.Text = ltMsg.Text + "</font>";
                    ltMsg.Text = ltMsg.Text + "</ pre>";
                    txtKenCd.Focus();
                    return false;
                }
            }

            if (!(string.IsNullOrEmpty(txtKbn.Text)))
            {
                /*数字のチェック*/
                byte num = 0;
                if (!(byte.TryParse(txtKbn.Text.TrimEnd(), out num)))
                {
                    ltMsg.Text = ltMsg.Text + "<pre>";
                    ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                    ltMsg.Text = ltMsg.Text + "半角数字で酒税免許を入力して下さい。";
                    ltMsg.Text = ltMsg.Text + "</font>";
                    ltMsg.Text = ltMsg.Text + "</ pre>";
                    txtKbn.Focus();
                    return false;
                }
            }

            if (!(string.IsNullOrEmpty(txtNewCd.Text)))
            {
                /*数字のチェック*/
                int num = 0;
                if (!(int.TryParse(txtNewCd.Text.TrimEnd(), out num)))
                {
                    ltMsg.Text = ltMsg.Text + "<pre>";
                    ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                    ltMsg.Text = ltMsg.Text + "半角数字で新コードを入力して下さい。";
                    ltMsg.Text = ltMsg.Text + "</font>";
                    ltMsg.Text = ltMsg.Text + "</ pre>";
                    txtNewCd.Focus();
                    return false;
                }
            }

            if (!(string.IsNullOrEmpty(txtOldCd.Text)))
            {
                /*数字のチェック*/
                int num = 0;
                if (!(int.TryParse(txtOldCd.Text.TrimEnd(), out num)))
                {
                    ltMsg.Text = ltMsg.Text + "<pre>";
                    ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                    ltMsg.Text = ltMsg.Text + "半角数字で旧コードを入力して下さい。";
                    ltMsg.Text = ltMsg.Text + "</font>";
                    ltMsg.Text = ltMsg.Text + "</ pre>";
                    txtOldCd.Focus();
                    return false;
                }
            }

            if (!(string.IsNullOrEmpty(txtDupDel.Text)))
            {
                /*数字のチェック*/
                int num = 0;
                if (!(int.TryParse(txtDupDel.Text.TrimEnd(), out num)))
                {
                    ltMsg.Text = ltMsg.Text + "<pre>";
                    ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                    ltMsg.Text = ltMsg.Text + "半角数字で抹消重複コードを入力して下さい。";
                    ltMsg.Text = ltMsg.Text + "</font>";
                    ltMsg.Text = ltMsg.Text + "</ pre>";
                    txtDupDel.Focus();
                    return false;
                }
            }

            if (!(string.IsNullOrEmpty(txtDupMoto.Text)))
            {
                /*数字のチェック*/
                int num = 0;
                if (!(int.TryParse(txtDupMoto.Text.TrimEnd(), out num)))
                {
                    ltMsg.Text = ltMsg.Text + "<pre>";
                    ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                    ltMsg.Text = ltMsg.Text + "半角数字で重複コードを入力して下さい。";
                    ltMsg.Text = ltMsg.Text + "</font>";
                    ltMsg.Text = ltMsg.Text + "</ pre>";
                    txtDupMoto.Focus();
                    return false;
                }
            }

            if (!(string.IsNullOrEmpty(txtCando.Text)))
            {
                /*数字のチェック*/
                byte num = 0;
                if (!(byte.TryParse(txtCando.Text.TrimEnd(), out num)))
                {
                    ltMsg.Text = ltMsg.Text + "<pre>";
                    ltMsg.Text = ltMsg.Text + "<FONT color='red'>";
                    ltMsg.Text = ltMsg.Text + "半角数字で処理区分を入力して下さい。";
                    ltMsg.Text = ltMsg.Text + "</font>";
                    ltMsg.Text = ltMsg.Text + "</ pre>";
                    txtCando.Focus();
                    return false;
                }
            }

            return true;
        }


        private bool KM01DDataExistenceCheck(int nScreenSetJudg)
        {
            if (!(InputKM01DValueSearchCheck()))
            {
                return false;
            }

            ltMsg.Text = "";
            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.KM01D_TOR_CD, txtTorCd.Text.TrimEnd());
            if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectKM01D().ToString(), paramDict, ref dt)) > 0)
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
                ltMsg.Text = ltMsg.Text + "小売店マスタが存在しません。" + "</BR>";
                if (nScreenSetJudg == 1)
                {
                    ltMsg.Text = ltMsg.Text + "新規登録をお願いします。" + "</BR>";
                }
                ltMsg.Text = ltMsg.Text + "</font>";
                ltMsg.Text = ltMsg.Text + "</ pre>";
                txtTorCd.Focus();
                return false;
            }
        }
    }
}