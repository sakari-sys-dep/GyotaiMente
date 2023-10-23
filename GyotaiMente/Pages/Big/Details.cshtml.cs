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
using System.Data;

namespace GyotaiMente.Pages.Big
{
    public class DetailModel : PageModel
    {

        [BindProperty]
        public ShohinScreen data { get; set; } = default!;
        public IList<BigList> bigList { get; set; } = default!;
        public IList<ShohinNotFound> shohinNotFounds { get; set; } = default!;

        private ICategoryService categoryService;
        public DetailModel(ICategoryService categoryService) => this.categoryService = categoryService;

        public SelectList big { get; set; } = default!;

        public void OnPost()
        {
            big = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
        }

        public void OnGet()
        {
            big = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
        }

            public async Task OnPostRegist()
        {
            var shohinNotFound = new List<ShohinNotFound>();

            big = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));

            /*入力チェック*/
            if (data.regist is not null && data.rename is not null)
            {
                /*パラメータの設定*/
                string QueryWhere = string.Empty;
                string QuerySort = string.Empty;
                Dictionary<string, object> paramDict = SetQueryParameters(data, out QueryWhere, out QuerySort);

                DBManager db = new DBManager();
                db.Connect(Const.CONNECTION_KEY_KOURIDB);
                SqlDataReader rdr = await db.ExecuteQueryRederAsync(ConstSql.RegistSqlBig(data.regist.PadLeft(3,'0'), data.rename.PadLeft(0)).ToString(), paramDict);
                if (rdr.RecordsAffected == 1)
                {
                    shohinNotFound.Add(new ShohinNotFound { メッセージ = "登録が完了しました。" });
                    shohinNotFounds = shohinNotFound.ToList();
                }
            }
            else
            {
                shohinNotFound.Add(new ShohinNotFound { メッセージ = "空欄があります。全て入力してください。" });
                shohinNotFounds = shohinNotFound.ToList();
            }
        }

        public async Task OnPostUpdate()
        {
            var shohinNotFound = new List<ShohinNotFound>();

            big = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));

            /*入力チェック*/
            if (data.code is not null && data.newcode is not null && data.newname is not null)
            {
                /*パラメータの設定*/
                string QueryWhere = string.Empty;
                string QuerySort = string.Empty;
                Dictionary<string, object> paramDict = SetQueryParameters(data, out QueryWhere, out QuerySort);

                DBManager db = new DBManager();
                db.Connect(Const.CONNECTION_KEY_KOURIDB);
                SqlDataReader rdr = await db.ExecuteQueryRederAsync(ConstSql.UpdateSqlBig(data.code, data.newcode.PadLeft(3, '0'), data.newname).ToString(), paramDict);
                if (rdr.RecordsAffected == 1)
                {
                    shohinNotFound.Add(new ShohinNotFound { メッセージ = "修正が完了しました。" });
                    shohinNotFounds = shohinNotFound.ToList();
                }
            }
            else
            {
                shohinNotFound.Add(new ShohinNotFound { メッセージ = "空欄があります。全て入力してください。" });
                shohinNotFounds = shohinNotFound.ToList();
            }
        }

        public async Task OnPostDelete()
        {
            var shohinNotFound = new List<ShohinNotFound>();

            big = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));

            /*入力チェック*/
            if (data.code is not null && data.name is not null)
            {
                /*パラメータの設定*/
                string QueryWhere = string.Empty;
                string QuerySort = string.Empty;
                Dictionary<string, object> paramDict = SetQueryParameters(data, out QueryWhere, out QuerySort);

                DBManager db = new DBManager();
                db.Connect(Const.CONNECTION_KEY_KOURIDB);
                SqlDataReader rdr = await db.ExecuteQueryRederAsync(ConstSql.DeleteSqlBig(data.code).ToString(), paramDict);
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
                shohinNotFound.Add(new ShohinNotFound { メッセージ = "空欄があります。全て入力してください。" });
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
                queryWhere = queryWhere + " AND  [ms01d_big_kbn1_cd] = @CODE ";
                paramDict.Add("@CODE", data.code.PadLeft(3, '0'));
            }
            //大業態名
            if (!string.IsNullOrEmpty(data.name))
            {
                queryWhere = queryWhere + " AND  [ms01d_big_kbn1_name] LIKE @NAME ";
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
