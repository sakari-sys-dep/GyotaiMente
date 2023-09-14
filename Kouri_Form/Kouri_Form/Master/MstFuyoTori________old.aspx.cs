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
    public partial class MstFuyoTori________old : System.Web.UI.Page
    {
        /// <summary>
        /// ロードイベント
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*フォーカスのセット*/
                this.SetFocus(txtOrositenCd, txtFuyoToriNM, txtKouriCd);

            }
        }

        private void SetFocus(TextBox txtOrositenCd, TextBox txtFuyoToriNM, TextBox txtKouriCd)
        {
            if (string.IsNullOrEmpty(txtOrositenCd.Text.TrimEnd()))
            {
                txtOrositenCd.Focus();
            }
            else if (string.IsNullOrEmpty(txtFuyoToriNM.Text.TrimEnd()))
            {
                txtFuyoToriNM.Focus();
            }
            else
            {
                txtKouriCd.Focus();
            }
        }

        /// <summary>
        /// 取引先名不要マスタよりデータ抽出
        /// </summary>
        private void SeaechKM43D(bool msgon)
        {
            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.KM43D_OROSI_TEN, txtOrositenCd.Text.TrimEnd());
            paramDict.Add(constSql.KM43D_TORI_NM, txtFuyoToriNM.Text.TrimEnd());
            if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectKM43D().ToString(), paramDict, ref dt)) > 0)
            {
                txtKouriCd.Text = dt.Rows[0]["km43d_tori_cd"].ToString();
                if (dt.Rows[0]["km43d_maint"].ToString() == "D")
                {
                    ltMsg.Text = "削除済みデータです。";
                }
            }
            else
            {
                if (msgon)
                {
                    ltMsg.Text = "取引先不要マスタに存在しません。";
                }

            }
        }

        /// <summary>
        /// 検索ボタンの押下イベント
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ltMsg.Text = "";

            /*検索前にチェック*/
            if (string.IsNullOrEmpty(txtOrositenCd.Text.TrimEnd()) | string.IsNullOrEmpty(txtFuyoToriNM.Text.TrimEnd()))
            {
                /*フォーカスのセット*/
                this.SetFocus(txtOrositenCd, txtFuyoToriNM, txtKouriCd);
                return;
            }

            /*取引先不要マスタの検索*/
            this.SeaechKM43D(true);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ltMsg.Text = "";

            /*検索前にチェック*/
            if (string.IsNullOrEmpty(txtOrositenCd.Text.TrimEnd()) | string.IsNullOrEmpty(txtFuyoToriNM.Text.TrimEnd()))
            {
                /*フォーカスのセット*/
                this.SetFocus(txtOrositenCd, txtFuyoToriNM, txtKouriCd);
                return;
            }

            //入力チェック


            //更新処理を実施
            this.UpdateKM43D("");

        }

        private void UpdateKM43D(string Flg)
        {

            if (Flg == "D")
            {
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
            else
            {
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


        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ltMsg.Text = "";

            /*検索前にチェック*/
            if (string.IsNullOrEmpty(txtOrositenCd.Text.TrimEnd()) | string.IsNullOrEmpty(txtFuyoToriNM.Text.TrimEnd()))
            {
                /*フォーカスのセット*/
                this.SetFocus(txtOrositenCd, txtFuyoToriNM, txtKouriCd);
                return;
            }

            //入力チェック


            //更新処理を実施
            this.UpdateKM43D("D");
        }
    }
}