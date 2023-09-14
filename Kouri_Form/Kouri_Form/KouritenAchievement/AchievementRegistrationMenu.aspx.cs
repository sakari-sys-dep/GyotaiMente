using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kouri_Form.Models
{
    public partial class AchievementRegistrationMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 手書実績　入力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnHandwrittenRecordEntry_Click(object sender, EventArgs e)
        {
            Response.Redirect("KouritenRegistrationAchievements.aspx");
        }
        /// <summary>
        /// 手書実績　修正　削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("KouritenCorrectionDeleteAchievements.aspx");
        }
    }
}