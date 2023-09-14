using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kouri_Form.Test
{
    public partial class WebForm1TEST : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string format = "yyyyMMdd";

            try 
            {
                DateTime dTime_from = DateTime.ParseExact("dddddssssaaa", format, null);
            }
            catch
            {
                Label2.Text = "ダメ";
               
            }
           
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

            Label2.Text = Calendar1.SelectedDate.ToString("yyyy/MM/dd hh:mm:ss");
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            DateTime Last_dateDay = DateTime.Now;
            Last_dateDay = Last_dateDay.AddDays(-1);

            if(e.Day.Date > Last_dateDay)
            {
                e.Cell.Font.Italic = true;
               //e.Cell.Font.Size = FontUnit.XLarge;
                e.Cell.Font.Strikeout = true;//取り消し線
                e.Day.IsSelectable = false;//非活性
                e.Cell.BackColor = System.Drawing.Color.LightGray;//背景色
                //e.Cell.Font.Name = "Courier New Baltic";
            }
        }
    }
}