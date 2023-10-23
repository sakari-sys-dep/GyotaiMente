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


namespace GyotaiMente.Pages.Small
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public ShohinScreen data { get; set; } = default!;
        public IList<SmallList> smallList { get; set; } = default!;
        public IList<ShohinNotFound> shohinNotFounds { get; set; } = default!;

        public SelectList big { get; set; } = default!;
        public SelectList small { get; set; } = default!;

        private ICategoryService categoryService;
        public IndexModel(ICategoryService categoryService) => this.categoryService = categoryService;


        public void OnGet()
        {
            big = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            small = new SelectList(categoryService.GetSmall(""), nameof(Models.Small.Value), nameof(Models.Small.Text));
        }

        public void OnPost()
        {
            big = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            small = new SelectList(categoryService.GetSmall(""), nameof(Models.Small.Value), nameof(Models.Small.Text));
        }

        public JsonResult OnGetSmalls(string ID)
        {
            return new JsonResult(categoryService.GetSmall(ID));
        }

        public async Task OnPostSearch()
        {
            var msmallList = new List<SmallList>();
            var shohinNotFound = new List<ShohinNotFound>();

            big = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            small = new SelectList(categoryService.GetSmall(data.code), nameof(Models.Small.Value), nameof(Models.Small.Text));

            /*パラメータの設定*/
            string QueryWhere = string.Empty;
            string QuerySort = string.Empty;
            Dictionary<string, object> paramDict = SetQueryParameters(data, out QueryWhere, out QuerySort);

            DBManager db = new DBManager();
            db.Connect(Const.CONNECTION_KEY_KOURIDB);
            SqlDataReader rdr = await db.ExecuteQueryRederAsync(ConstSql.CreateSqlSmall(QueryWhere).ToString(), paramDict);
            while (await rdr.ReadAsync())
            {
                msmallList.Add(new SmallList
                {
                    ms01d_small_kbn1_cd = rdr["ms01d_small_kbn1_cd"].ToString()!,
                    ms01d_small_kbn2_cd = rdr["ms01d_small_kbn2_cd"].ToString()!,
                    ms01d_small_kbn2_name = rdr["ms01d_small_kbn2_name"].ToString()!
                });
                smallList = msmallList.ToList();
            }
            if (smallList is null)
            {
                shohinNotFound.Add(new ShohinNotFound { メッセージ = "データが見つかりません。" });
                shohinNotFounds = shohinNotFound.ToList();
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

        public IActionResult OnPostExcel()
        {
            int index = 0;
            string path = "小業態一覧.xlsx";


            DateTime dt = DateTime.Now;
            string name = dt.ToString($"{dt:yyyyMMdd_HHmmss}");
            string pathServer = "./Excel/tmp_" + name + ".xlsx";


            var workbook = new XLWorkbook();
            workbook.Style.Font.FontName = "ＭＳ ゴシック";
            IXLWorksheet worksheet = workbook.Worksheets.Add("sheet1");

            string QueryWhere = string.Empty;
            string QuerySort = string.Empty;
            Dictionary<string, object> paramDict = SetQueryParameters(data, out QueryWhere, out QuerySort);

            DBManager db = new DBManager();
            db.Connect(Const.CONNECTION_KEY_KOURIDB);
            SqlDataReader rdr = db.ExecuteQueryReder(ConstSql.ExcelSqlSmall(QueryWhere).ToString(), paramDict);

            //ヘッダの出力
            var color = XLColor.Tan;
            int fieldcount = rdr.FieldCount;
            for (int r = 0; r < fieldcount; r++)
            {
                worksheet.Cell(index + 1, r + 1).Style.Fill.SetBackgroundColor(color);
                worksheet.Cell(index + 1, r + 1).SetValue(rdr.GetName(r).ToString());
                worksheet.Cell(index + 1, r + 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            }
            //明細の出力
            index++;

            while (rdr.Read())
            {
                for (int r = 0; r < fieldcount; r++)
                {
                    worksheet.Cell(index + 1, r + 1).SetValue(rdr[r].ToString());
                    worksheet.Cell(index + 1, r + 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }
                index++;
            }
            // 指定パスにエクセル生成
            workbook.SaveAs(pathServer);

            var file = System.IO.File.ReadAllBytes(pathServer);
            return File(file, System.Net.Mime.MediaTypeNames.Application.Octet, path);

        }

        public IActionResult OnPostClear()
        {
            return RedirectToPage("./Index");
        }
    }
}
