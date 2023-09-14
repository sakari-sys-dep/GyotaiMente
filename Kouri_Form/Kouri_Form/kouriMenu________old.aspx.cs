using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Kouri_Form.Class;
using System.Data;
using System.Configuration;

namespace Kouri_Form
{
    public partial class kouriMenu________old : System.Web.UI.Page
    {
        /// <summary>
        /// ページロード
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            string q_screen_no = "";
            int screen_no = 1;

            if (!IsPostBack)
            {
                //メニュー画面で表示するメニューを取得する
                q_screen_no = Request.QueryString["next"];
                if (string.IsNullOrEmpty(q_screen_no))
                {
                    screen_no = 1;
                }
                else
                {
                    if (!Int32.TryParse(q_screen_no, out screen_no))
                    {
                        screen_no = 1;
                    }
                }
                if (screen_no == 1)
                {

                    lblTitle.Text = "販売実績 処理メニュー";
                    GoMenu.Visible = false;
                }
                else
                {
                    lblTitle.Text = "販売実績 マスタ管理メニュー";
                    GoMenu.Visible = true;
                }
                this.Initializetion(screen_no);
            }
        }

        /// <summary>
        /// 表示画面の初期設定
        /// </summary>
        private void Initializetion(int screen_no)
        {
            //小売店チェック処理
            this.SetMenuHyperLink(screen_no, 1, pnlMenu1);
            //小売店マスタ処理
            this.SetMenuHyperLink(screen_no, 2, pnlMenu2);
        }

        /// <summary>
        /// メニュー画面の作成
        /// </summary>
        /// <param name="screenNo">画面No</param>
        /// <param name="layoutKbn">レイアウトNo</param>
        /// <param name="setPanel">セットパネル</param>
        private void SetMenuHyperLink(int screenNo, int layoutKbn, Panel setPanel)
        {
            DataTable dt = new DataTable();
            Dictionary<String, Object> paramDict = new Dictionary<string, Object>();
            paramDict.Add(constSql.DB_ITEM_SCREEN_NO,  screenNo);
            paramDict.Add(constSql.DB_ITEM_LAYOUT_KBN, layoutKbn);
            if ((DBManager.GetTableData("dbret", constSql.CreateSqlSelectMenu().ToString(), paramDict, ref dt)) > 0)
            {
                //メニューを設定
                foreach (DataRow drMenu in dt.Rows)
                {
                    setPanel.Controls.Add(this.GetHyperLinkInfo(drMenu));
                    setPanel.Controls.Add(new LiteralControl("<BR>"));
                    setPanel.Controls.Add(new LiteralControl("<BR>"));
                }
            }
            else
            {
                lblTitle.Text = "";
            }
        }

        /// <summary>
        /// メニューのリンクを作成
        /// </summary>
        /// <param name="drMenu">メニューレコード</param>
        /// <returns>コントロール</returns>
        private Control GetHyperLinkInfo(DataRow drMenu)
        {
            HyperLink link = new HyperLink();
            string menu_no;
            string pg_id;
            string url = "";
            try
            {
                //テーブル項目の取得
                pg_id = drMenu["menu_pg_id"].ToString();
                menu_no = drMenu["menu_no"].ToString().PadLeft(3, '0');
                //URLの構築
                url = drMenu["menu_address"].ToString();
                if (url.Contains("?"))
                {
                    url = url + "&";
                }
                else
                {
                    url = url + "?";
                }
                url = url + "pg_id=" + pg_id;
                //リンクの設定を追加
                if (string.IsNullOrEmpty(drMenu["menu_text"].ToString()))
                {
                    link.Text = "";
                }
                else
                {
                    link.Text = menu_no + '：' + drMenu["menu_text"].ToString();
                }
                link.NavigateUrl = url;
                link.Font.Size = 12;
                link.Target = ConfigurationManager.AppSettings.Get("LinkTarget");
            }
            catch (Exception)
            {
                link.NavigateUrl = "";
            }
            return link;
        }

    }
}