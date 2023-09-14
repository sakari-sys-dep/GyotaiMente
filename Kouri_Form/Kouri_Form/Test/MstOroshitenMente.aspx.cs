using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using Kouri_Form.Class;
using System.Data;

namespace Kouri_Form.Test
{
    public partial class MstOroshitenMente : System.Web.UI.Page
    {
        //グルーバル変数
        public static string qTenCd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                qTenCd = "";
                qTenCd = Request.QueryString["tencd"];
                //qTenCd = "11532655";
                this.Initialize(qTenCd);
            }
        }

        private void Initialize(string lTenCd)
        {
            if (string.IsNullOrEmpty(lTenCd))
            {
                /*クエリストリングで小売店コードの空白の場合*/
                this.Clear();
                btnUpdate.Text = " 登　録 ";
            }
            else
            {
                //実行するストアドプロシージャを取得する
                DataTable dt = new DataTable();
                Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
                paramDict.Add(constSql.KM04D_TEN_CD, lTenCd);
                if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectKM04D().ToString(), paramDict, ref dt)) > 0)
                {
                    this.ScreenSet(dt.Rows[0]);
                    btnUpdate.Text = " 更　新 ";
                }
                else
                {
                    this.Clear();
                    txtTenCd.Text = lTenCd;
                    btnUpdate.Text = " 登　録 ";
                }
            }
        }

        private void ScreenSet(DataRow dr)
        {
            txtOroshiCd.Text = dr["km04d_orosi_cd"].ToString();
            txtOroshiEda.Text = dr["km04d_orosi_eda"].ToString(); 
            txtTenCd.Text = dr["km04d_ten_cd"].ToString();
            txtName_k.Text = dr["km04d_name_k"].ToString();
            txtBrName_k.Text = dr["km04d_br_name_k"].ToString();
            txtName_a.Text = dr["km04d_name_a"].ToString();
            txtBrName_a.Text = dr["km04d_br_name_a"].ToString();
            ddlPriKbn.SelectedValue = dr["km04d_pri_kbn"].ToString();
            if (dr["km04d_maint"].ToString() == "D")
            {
                ddlDelete.SelectedValue = "D";
            }
            else
            {
                ddlDelete.SelectedValue = "";
            }
        }

        private void Clear()
        {
            txtOroshiCd.Text = "";
            txtOroshiEda.Text = "";
            txtTenCd.Text = "";
            txtName_k.Text = "";
            txtBrName_k.Text = "";
            txtName_a.Text = "";
            txtBrName_a.Text = "";
            ddlPriKbn.SelectedIndex = 0;
            ddlDelete.SelectedIndex = 0;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            /*入力チェック*/






            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.KM04D_TEN_CD, txtTenCd.Text);
            if (ddlDelete.SelectedValue == "D")
            {
                paramDict.Add(constSql.KM04D_MAINT, "D");
            }
            else
            {
                paramDict.Add(constSql.KM04D_MAINT, "C");
            }
            paramDict.Add(constSql.KM04D_BR_NAME_A, txtBrName_a.Text);
            paramDict.Add(constSql.KM04D_BR_NAME_K, txtBrName_k.Text);
            paramDict.Add(constSql.KM04D_NAME_A, txtName_a.Text);
            paramDict.Add(constSql.KM04D_NAME_K, txtName_k.Text);
            paramDict.Add(constSql.KM04D_OROSI_CD, txtOroshiCd.Text + txtOroshiEda.Text);
            paramDict.Add(constSql.KM04D_PRI_KBN, ddlDelete.SelectedValue);

            DBManager db = new DBManager();
            try
            {
                db.Connect("dbret", -1);
                db.BeginTransaction();
                db.ExecuteNonQuery(constSql.CreateSqlUpdateKM04D().ToString(), paramDict);
                db.CommitTransaction();
            }
            catch(Exception ex)
            {
                db.RollbackTransaction();
                throw;
            }
            finally
            {
                db.Disconnect();
            }

            






        }
    }
}