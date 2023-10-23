using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using ClosedXML.Excel;
using System.IO;
using GyotaiMente.Data;
using GyotaiMente.Class;
using GyotaiMente.Models;
using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;


namespace GyotaiMente.Pages.Small
{
    public class DetailsModel : PageModel
    {

        [BindProperty]
        public ShohinScreen data { get; set; } = default!;
        public IList<SmallList> smallList { get; set; } = default!;
        public IList<ShohinNotFound> shohinNotFounds { get; set; } = default!;

        public SelectList big { get; set; } = default!;
        public SelectList small { get; set; } = default!;

        public SelectList nbig { get; set; } = default!;
        public SelectList nsmall { get; set; } = default!;

        private ICategoryService categoryService;
        public DetailsModel(ICategoryService categoryService) => this.categoryService = categoryService;

        public void OnGet()
        {
            big = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            small = new SelectList(categoryService.GetSmall(""), nameof(Models.Small.Value), nameof(Models.Small.Text));
            nbig = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            nsmall = new SelectList(categoryService.GetSmall(""), nameof(Models.Small.Value), nameof(Models.Small.Text));
        }

        public void OnPost()
        {
            big = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            small = new SelectList(categoryService.GetSmall(data.code), nameof(Models.Small.Value), nameof(Models.Small.Text));
            nbig = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            nsmall = new SelectList(categoryService.GetSmall(data.newcode), nameof(Models.Small.Value), nameof(Models.Small.Text));

        }

        public JsonResult OnGetSmalls(string ID)
        {
            return new JsonResult(categoryService.GetSmall(ID));
        }

        //登録ボタン押す
        public async Task OnPostRegist()
        {
            var shohinNotFound = new List<ShohinNotFound>();

            big = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            small = new SelectList(categoryService.GetSmall(data.code), nameof(Models.Small.Value), nameof(Models.Small.Text));

            nbig = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            nsmall = new SelectList(categoryService.GetSmall(data.newcode), nameof(Models.Small.Value), nameof(Models.Small.Text));

            /*入力チェック*/
            if (data.regist is not null && data.regist2 is not null && data.rename is not null)
            {
                /*パラメータの設定*/
                string QueryWhere = string.Empty;
                string QuerySort = string.Empty;
                Dictionary<string, object> paramDict = SetQueryParameters(data, out QueryWhere, out QuerySort);

                DBManager db = new DBManager();
                db.Connect(Const.CONNECTION_KEY_KOURIDB);
                SqlDataReader rdr = await db.ExecuteQueryRederAsync(ConstSql.RegistSqlSmall(data.regist.PadLeft(3, '0'), data.regist2.PadLeft(3, '0'), data.rename).ToString(), paramDict);
                if (rdr.RecordsAffected == 1)
                {
                    shohinNotFound.Add(new ShohinNotFound { メッセージ = "登録が完了しました。" });
                    shohinNotFounds = shohinNotFound.ToList();
                }
            }
            else
            {
                shohinNotFound.Add(new ShohinNotFound { メッセージ = "全て入力してください。" });
                shohinNotFounds = shohinNotFound.ToList();
            }
        }

        //削除ボタン押す
        public async Task OnPostDelete()
        {
            var shohinNotFound = new List<ShohinNotFound>();

            big = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            small = new SelectList(categoryService.GetSmall(data.code), nameof(Models.Small.Value), nameof(Models.Small.Text));

            nbig = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            nsmall = new SelectList(categoryService.GetSmall(data.newcode), nameof(Models.Small.Value), nameof(Models.Small.Text));

            /*入力チェック*/
            if (data.code is not null && data.code2 is not null)
            {
                /*パラメータの設定*/
                string QueryWhere = string.Empty;
                string QuerySort = string.Empty;
                Dictionary<string, object> paramDict = SetQueryParameters(data, out QueryWhere, out QuerySort);

                DBManager db = new DBManager();
                db.Connect(Const.CONNECTION_KEY_KOURIDB);
                SqlDataReader rdr = await db.ExecuteQueryRederAsync(ConstSql.DeleteSqlSmall(data.code, data.code2).ToString(), paramDict);
                //while (await rdr.ReadAsync())
                //{
                //}
                if (rdr.RecordsAffected == 0)
                {
                    shohinNotFound.Add(new ShohinNotFound { メッセージ = "削除対象データが０件です。" });
                    shohinNotFounds = shohinNotFound.ToList();
                }
                else
                {
                    shohinNotFound.Add(new ShohinNotFound { メッセージ = "削除が完了しました。" });
                    shohinNotFounds = shohinNotFound.ToList();
                }
            }
            else
            {
                shohinNotFound.Add(new ShohinNotFound { メッセージ = "全て入力してください。" });
                shohinNotFounds = shohinNotFound.ToList();
            }
        }

        //修正ボタン押す
        public async Task OnPostUpdate()
        {
            var shohinNotFound = new List<ShohinNotFound>();

            big = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            small = new SelectList(categoryService.GetSmall(data.code), nameof(Models.Small.Value), nameof(Models.Small.Text));

            /*入力チェック*/
            if (data.code is not null && data.code2 is not null&& data.newcode is not null && data.newcode2 is not null && data.newname is not null)
            {
                /*パラメータの設定*/
                string QueryWhere = string.Empty;
                string QuerySort = string.Empty;
                Dictionary<string, object> paramDict = SetQueryParameters(data, out QueryWhere, out QuerySort);

                DBManager db = new DBManager();
                db.Connect(Const.CONNECTION_KEY_KOURIDB);
                SqlDataReader rdr = await db.ExecuteQueryRederAsync(ConstSql.UpdateSqlSmall(data.code, data.code2, data.newcode, data.newcode2, data.newname).ToString(), paramDict);
                if (rdr.RecordsAffected == 1)
                {
                    shohinNotFound.Add(new ShohinNotFound { メッセージ = "登録が完了しました。" });
                    shohinNotFounds = shohinNotFound.ToList();
                }
            }
            else
            {
                shohinNotFound.Add(new ShohinNotFound { メッセージ = "全て入力してください。" });
                shohinNotFounds = shohinNotFound.ToList();
            }
        }

        private Dictionary<string, object> SetQueryParameters(ShohinScreen data, out string queryWhere, out string querySort)
        {
            /*初期化*/
            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            queryWhere = string.Empty;
            querySort = string.Empty;

            //大業態コード
            if (!string.IsNullOrEmpty(data.code))
            {
                queryWhere = queryWhere + " AND  [ms01d_small_kbn1_cd] = @CODE ";
                paramDict.Add("@CODE", data.code);
            }
            //大業態コード
            if (!string.IsNullOrEmpty(data.code2))
            {
                queryWhere = queryWhere + " AND  [ms01d_small_kbn2_cd] = @CODE2 ";
                paramDict.Add("@CODE2", data.code2);
            }
            //大業態名
            if (!string.IsNullOrEmpty(data.name))
            {
                queryWhere = queryWhere + " AND  [ms01d_small_kbn2_name] LIKE @NAME ";
                paramDict.Add("@NAME", '%' + data.name + '%');
            }
   
            return paramDict;
        }

        public IActionResult OnPostBack()
        {
            return RedirectToPage("./Index");
        }

        public IActionResult OnPostClear()
        {
            return RedirectToPage("./Details");
        }
    }
}
