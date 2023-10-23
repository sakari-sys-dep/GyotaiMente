﻿using System;
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


namespace GyotaiMente.Pages.Kei1
{
    public class DetailsModel : PageModel
    {

        [BindProperty]
        public ShohinScreen data { get; set; } = default!;
        public IList<Kei1List> kei1List { get; set; } = default!;
        public IList<ShohinNotFound> shohinNotFounds { get; set; } = default!;

        public SelectList big { get; set; } = default!;
        public SelectList small { get; set; } = default!;
        public SelectList kei1 { get; set; } = default!;

        private ICategoryService categoryService;
        public DetailsModel(ICategoryService categoryService) => this.categoryService = categoryService;

        public void OnGet()
        {
            big = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            small = new SelectList(categoryService.GetSmall(""), nameof(Models.Small.Value), nameof(Models.Small.Text));
            kei1 = new SelectList(categoryService.GetKei1(""), nameof(Models.Kei1.Value), nameof(Models.Kei1.Text));
        }

        public void OnPost()
        {
            big = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            small = new SelectList(categoryService.GetSmall(""), nameof(Models.Small.Value), nameof(Models.Small.Text));
            kei1 = new SelectList(categoryService.GetKei1(""), nameof(Models.Kei1.Value), nameof(Models.Kei1.Text));
        }

        public JsonResult OnGetSmalls(string ID)
        {
            return new JsonResult(categoryService.GetSmall(ID));
        }

        public JsonResult OnGetKei1s(string ID)
        {
            return new JsonResult(categoryService.GetKei1(ID));
        }

        //登録ボタン押す
        public async Task OnPostRegist()
        {
            var shohinNotFound = new List<ShohinNotFound>();

            big = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            small = new SelectList(categoryService.GetSmall(data.code), nameof(Models.Small.Value), nameof(Models.Small.Text));
            kei1 = new SelectList(categoryService.GetKei1(data.code + data.code2), nameof(Models.Kei1.Value), nameof(Models.Kei1.Text));

            /*入力チェック*/
            if (data.regist is not null && data.regist2 is not null && data.regist3 is not null && data.rename is not null)
            {
                /*パラメータの設定*/
                string QueryWhere = string.Empty;
                string QuerySort = string.Empty;
                Dictionary<string, object> paramDict = SetQueryParameters(data, out QueryWhere, out QuerySort);

                DBManager db = new DBManager();
                db.Connect(Const.CONNECTION_KEY_KOURIDB);
                SqlDataReader rdr = await db.ExecuteQueryRederAsync(ConstSql.RegistSqlKei1(data.regist.PadLeft(3, '0'), data.regist2.PadLeft(3, '0'), data.regist3.PadLeft(3, '0'), data.rename).ToString(), paramDict);
                //while (await rdr.ReadAsync())
                //{
                //}
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

        public async Task OnPostUpdate()
        {
            var shohinNotFound = new List<ShohinNotFound>();

            big = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            small = new SelectList(categoryService.GetSmall(data.code), nameof(Models.Small.Value), nameof(Models.Small.Text));
            kei1 = new SelectList(categoryService.GetKei1(data.code + data.code2), nameof(Models.Kei1.Value), nameof(Models.Kei1.Text));

            /*入力チェック*/
            if (data.code is not null && data.code2 is not null && data.code3 is not null && data.newcode is not null && data.newcode2 is not null && data.newcode3 is not null && data.name is not null)
            {
                /*パラメータの設定*/
                string QueryWhere = string.Empty;
                string QuerySort = string.Empty;
                Dictionary<string, object> paramDict = SetQueryParameters(data, out QueryWhere, out QuerySort);

                DBManager db = new DBManager();
                db.Connect(Const.CONNECTION_KEY_KOURIDB);
                SqlDataReader rdr = await db.ExecuteQueryRederAsync(ConstSql.UpdateSqlKei1(data.code, data.code2, data.code3, data.newcode, data.newcode2, data.newcode3, data.name).ToString(), paramDict);
                //while (await rdr.ReadAsync())
                //{
                //}
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

        public async Task OnPostDelete()
        {
            var shohinNotFound = new List<ShohinNotFound>();

            big = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            small = new SelectList(categoryService.GetSmall(data.code), nameof(Models.Small.Value), nameof(Models.Small.Text));
            kei1 = new SelectList(categoryService.GetKei1(data.code + data.code2), nameof(Models.Kei1.Value), nameof(Models.Kei1.Text));

            /*入力チェック*/
            if (data.code is not null && data.code2 is not null && data.code3 is not null)
            {
                /*パラメータの設定*/
                string QueryWhere = string.Empty;
                string QuerySort = string.Empty;
                Dictionary<string, object> paramDict = SetQueryParameters(data, out QueryWhere, out QuerySort);

                DBManager db = new DBManager();
                db.Connect(Const.CONNECTION_KEY_KOURIDB);
                SqlDataReader rdr = await db.ExecuteQueryRederAsync(ConstSql.DeleteSqlKei1(data.code, data.code2, data.code3).ToString(), paramDict);
                //while (await rdr.ReadAsync())
                //{
                ////}
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
            //小業態コード
            if (!string.IsNullOrEmpty(data.code2))
            {
                queryWhere = queryWhere + " AND  [ms01d_small_kbn2_cd] = @CODE2 ";
                paramDict.Add("@CODE2", data.code2);
            }
            //系列１コード
            if (!string.IsNullOrEmpty(data.code3))
            {
                queryWhere = queryWhere + " AND  [ms01d_small_kbn2_cd] = @CODE3 ";
                paramDict.Add("@CODE3", data.code3);
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
        //public void OnPostClear()
        {
            //data = default!;
            //var httpContext = HttpContext.Current;
            return RedirectToPage("./Details");
            //return Redirect("./Shohin/Index");
            //HttpContext.curre Server.TransferRequest(this.Url, true);

        }
    }
}
