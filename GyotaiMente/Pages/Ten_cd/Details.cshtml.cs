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


namespace GyotaiMente.Pages.Ten_cd
{
    public class DetailsModel : PageModel
    {

        [BindProperty]
        public ShohinScreen data { get; set; } = default!;
        public IList<Ten_cdList> Ten_cdList { get; set; } = default!;
        public IList<ShohinNotFound> shohinNotFounds { get; set; } = default!;

        public SelectList big { get; set; } = default!;
        public SelectList small { get; set; } = default!;
        public SelectList kei1 { get; set; } = default!;
        public SelectList kei2 { get; set; } = default!;

        public SelectList nbig { get; set; } = default!;
        public SelectList nsmall { get; set; } = default!;
        public SelectList nkei1 { get; set; } = default!;
        public SelectList nkei2 { get; set; } = default!;

        private ICategoryService categoryService;
        public DetailsModel(ICategoryService categoryService) => this.categoryService = categoryService;
        
        public void OnGet()
        {
            big = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            small = new SelectList(categoryService.GetSmall(""), nameof(Models.Small.Value), nameof(Models.Small.Text));
            kei1 = new SelectList(categoryService.GetKei1(""), nameof(Models.Kei1.Value), nameof(Models.Kei1.Text));
            kei2 = new SelectList(categoryService.GetKei2(""), nameof(Models.Kei2.Value), nameof(Models.Kei2.Text));

            nbig = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            nsmall = new SelectList(categoryService.GetSmall(""), nameof(Models.Small.Value), nameof(Models.Small.Text));
            nkei1 = new SelectList(categoryService.GetKei1(""), nameof(Models.Kei1.Value), nameof(Models.Kei1.Text));
            nkei2 = new SelectList(categoryService.GetKei2(""), nameof(Models.Kei2.Value), nameof(Models.Kei2.Text));
        }

        public void OnPost()
        {
            big = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            small = new SelectList(categoryService.GetSmall(data.code), nameof(Models.Small.Value), nameof(Models.Small.Text));
            kei1 = new SelectList(categoryService.GetKei1(data.code + data.code2), nameof(Models.Kei1.Value), nameof(Models.Kei1.Text));
            kei2 = new SelectList(categoryService.GetKei2(data.code + data.code2 + data.code3), nameof(Models.Kei2.Value), nameof(Models.Kei2.Text));

            nbig = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            nsmall = new SelectList(categoryService.GetSmall(data.newcode), nameof(Models.Small.Value), nameof(Models.Small.Text));
            nkei1 = new SelectList(categoryService.GetKei1(data.newcode + data.newcode2), nameof(Models.Kei1.Value), nameof(Models.Kei1.Text));
            nkei2 = new SelectList(categoryService.GetKei2(data.newcode + data.newcode2 + data.newcode3), nameof(Models.Kei2.Value), nameof(Models.Kei2.Text));
        }

        public JsonResult OnGetSmalls(string ID)
        {
            return new JsonResult(categoryService.GetSmall(ID));
        }

        public JsonResult OnGetKei1s(string ID)
        {
            return new JsonResult(categoryService.GetKei1(ID));
        }

        public JsonResult OnGetKei2s(string ID)
        {
            return new JsonResult(categoryService.GetKei2(ID));
        }

        public async Task OnPostSearch()
        {
            var mkei2List = new List<Ten_cdList>();
            var shohinNotFound = new List<ShohinNotFound>();

            big = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            small = new SelectList(categoryService.GetSmall(data.code), nameof(Models.Small.Value), nameof(Models.Small.Text));
            kei1 = new SelectList(categoryService.GetKei1(data.code + data.code2), nameof(Models.Kei1.Value), nameof(Models.Kei1.Text));
            kei2 = new SelectList(categoryService.GetKei2(data.code + data.code2 + data.code3), nameof(Models.Kei2.Value), nameof(Models.Kei2.Text));

            nbig = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            nsmall = new SelectList(categoryService.GetSmall(data.newcode), nameof(Models.Small.Value), nameof(Models.Small.Text));
            nkei1 = new SelectList(categoryService.GetKei1(data.newcode + data.newcode2), nameof(Models.Kei1.Value), nameof(Models.Kei1.Text));
            nkei2 = new SelectList(categoryService.GetKei2(data.newcode + data.newcode2 + data.newcode3), nameof(Models.Kei2.Value), nameof(Models.Kei2.Text));

            /*パラメータの設定*/
            string QueryWhere = string.Empty;
            string QuerySort = string.Empty;
            Dictionary<string, object> paramDict = SetQueryParameters(data, out QueryWhere, out QuerySort);

            DBManager db = new DBManager();
            db.Connect(Const.CONNECTION_KEY_KOURIDB);
            SqlDataReader rdr = await db.ExecuteQueryRederAsync(ConstSql.CreateSqlTen(QueryWhere).ToString(), paramDict);
            while (await rdr.ReadAsync())
            {
                mkei2List.Add(new Ten_cdList
                {
                    kbn1_cd = rdr["kbn1_cd"].ToString()!,
                    kbn2_cd = rdr["kbn2_cd"].ToString()!,
                    kei1_cd = rdr["kei1_cd"].ToString()!,
                    kei2_cd = rdr["kei2_cd"].ToString()!,
                    ten_cd = rdr["ten_cd"].ToString()!,
                    km01d_yagou_k = rdr["km01d_yagou_k"].ToString()!,
                });
                Ten_cdList = mkei2List.ToList();
            }
            if (Ten_cdList is null)
            {
                shohinNotFound.Add(new ShohinNotFound { メッセージ = "データが見つかりません。" });
                shohinNotFounds = shohinNotFound.ToList();
            }
            else
            {
                data.TenLists.AddRange(Ten_cdList!.ToArray());
            }
                db.Disconnect();

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
                queryWhere = queryWhere + " AND  [kbn1_cd] = @CODE ";
                paramDict.Add("@CODE", data.code);
            }
            //小業態コード
            if (!string.IsNullOrEmpty(data.code2))
            {
                queryWhere = queryWhere + " AND  [kbn2_cd] = @CODE2 ";
                paramDict.Add("@CODE2", data.code2);
            }
            //系列１コード
            if (!string.IsNullOrEmpty(data.code3))
            {
                queryWhere = queryWhere + " AND  [kei1_cd] = @CODE3 ";
                paramDict.Add("@CODE3", data.code3);
            }
            //系列２コード
            if (!string.IsNullOrEmpty(data.code4))
            {
                queryWhere = queryWhere + " AND  [kei2_cd] = @CODE4 ";
                paramDict.Add("@CODE4", data.code4);
            }
            //店名
            if (!string.IsNullOrEmpty(data.code5))
            {
                queryWhere = queryWhere + " AND  [ten_cd] = @CODE5 ";
                paramDict.Add("@CODE5", data.code5);
            }

            return paramDict;
        }

        public async Task OnPostUpdate()
        {
            var shohinNotFound = new List<ShohinNotFound>();

            //ドロップダウンリスト作成
            big = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            small = new SelectList(categoryService.GetSmall(data.code), nameof(Models.Small.Value), nameof(Models.Small.Text));
            kei1 = new SelectList(categoryService.GetKei1(data.code + data.code2), nameof(Models.Kei1.Value), nameof(Models.Kei1.Text));
            kei2 = new SelectList(categoryService.GetKei2(data.code + data.code2 + data.code3), nameof(Models.Kei2.Value), nameof(Models.Kei2.Text));

            //ドロップダウンリスト作成(新)
            nbig = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            nsmall = new SelectList(categoryService.GetSmall(data.newcode), nameof(Models.Small.Value), nameof(Models.Small.Text));
            nkei1 = new SelectList(categoryService.GetKei1(data.newcode + data.newcode2), nameof(Models.Kei1.Value), nameof(Models.Kei1.Text));
            nkei2 = new SelectList(categoryService.GetKei2(data.newcode + data.newcode2 + data.newcode3), nameof(Models.Kei2.Value), nameof(Models.Kei2.Text));

            /*入力チェック*/
            if (data.TenLists is not null && data.newcode is not null && data.newcode2 is not null && data.newcode3 is not null && data.newcode4 is not null)
            {
                /*パラメータの設定*/
                string QueryWhere = string.Empty;
                string QuerySort = string.Empty;
                int flag = 0;
                Dictionary<string, object> paramDict = SetQueryParameters(data, out QueryWhere, out QuerySort);

                DBManager db = new DBManager();
                db.Connect(Const.CONNECTION_KEY_KOURIDB);

                //対象データを全て更新する
                foreach (var list in data.TenLists)
                {
                    if (list.IsDelete && list.ten_cd is not null)
                    {
                        flag = 1;
                        SqlDataReader rdr = await db.ExecuteQueryRederAsync(ConstSql.UpdateSqlTen(list.kbn1_cd, list.kbn2_cd, list.kei1_cd, list.kei2_cd, list.ten_cd, data.newcode, data.newcode2, data.newcode3, data.newcode4).ToString(), paramDict);
                    }
                }
                if (flag == 1)
                {
                    shohinNotFound.Add(new ShohinNotFound { メッセージ = data.newcode +"-"+ data.newcode2 +"-"+ data.newcode3 + "-" + data.newcode4 + "に登録が完了しました。" });
                    shohinNotFounds = shohinNotFound.ToList();
                }
                else
                {
                    shohinNotFound.Add(new ShohinNotFound { メッセージ = "対象データが０件でした。" });
                    shohinNotFounds = shohinNotFound.ToList();
                }
            }
            else
            {
                shohinNotFound.Add(new ShohinNotFound { メッセージ = "全て入力してください。" });
                shohinNotFounds = shohinNotFound.ToList();
            }
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
