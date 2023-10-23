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


namespace GyotaiMente.Pages.Kei2
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public ShohinScreen data { get; set; } = default!;
        public IList<Kei2List> kei2List { get; set; } = default!;
        public IList<ShohinNotFound> shohinNotFounds { get; set; } = default!;

        public SelectList big { get; set; } = default!;
        public SelectList small { get; set; } = default!;
        public SelectList kei1 { get; set; } = default!;
        public SelectList kei2 { get; set; } = default!;

        private ICategoryService categoryService;
        public IndexModel(ICategoryService categoryService) => this.categoryService = categoryService;


        public void OnGet()
        {
            big = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            small = new SelectList(categoryService.GetSmall(""), nameof(Models.Small.Value), nameof(Models.Small.Text));
            kei1 = new SelectList(categoryService.GetKei1(""), nameof(Models.Kei1.Value), nameof(Models.Kei1.Text));
            kei2 = new SelectList(categoryService.GetKei2(""), nameof(Models.Kei2.Value), nameof(Models.Kei2.Text));
        }

        public void OnPost()
        {
            big = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            small = new SelectList(categoryService.GetSmall(""), nameof(Models.Small.Value), nameof(Models.Small.Text));
            kei1 = new SelectList(categoryService.GetKei1(""), nameof(Models.Kei1.Value), nameof(Models.Kei1.Text));
            kei2 = new SelectList(categoryService.GetKei2(""), nameof(Models.Kei2.Value), nameof(Models.Kei2.Text));
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
            var mkei2List = new List<Kei2List>();
            var shohinNotFound = new List<ShohinNotFound>();

            big = new SelectList(categoryService.GetBig(), nameof(Models.Big.Value), nameof(Models.Big.Text));
            small = new SelectList(categoryService.GetSmall(data.code), nameof(Models.Small.Value), nameof(Models.Small.Text));
            kei1 = new SelectList(categoryService.GetKei1(data.code + data.code2), nameof(Models.Kei1.Value), nameof(Models.Kei1.Text));
            kei2 = new SelectList(categoryService.GetKei2(data.code + data.code2 + data.code3), nameof(Models.Kei2.Value), nameof(Models.Kei2.Text));

            /*パラメータの設定*/
            string QueryWhere = string.Empty;
            string QuerySort = string.Empty;
            Dictionary<string, object> paramDict = SetQueryParameters(data, out QueryWhere, out QuerySort);

            DBManager db = new DBManager();
            db.Connect(Const.CONNECTION_KEY_KOURIDB);
            SqlDataReader rdr = await db.ExecuteQueryRederAsync(ConstSql.CreateSqlKei2(QueryWhere).ToString(), paramDict);
            while (await rdr.ReadAsync())
            {
                mkei2List.Add(new Kei2List
                {
                    kbn1_cd = rdr["kbn1_cd"].ToString()!,
                    kbn2_cd = rdr["kbn2_cd"].ToString()!,
                    kei1_cd = rdr["kei1_cd"].ToString()!,
                    kei2_cd = rdr["kei2_cd"].ToString()!,
                    kei2_name = rdr["kei2_name"].ToString()!,
                });
                kei2List = mkei2List.ToList();
            }
            if (kei2List is null)
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
                queryWhere = queryWhere + " AND  A.[kbn1_cd] = @CODE ";
                paramDict.Add("@CODE", data.code);
            }
            //小業態コード
            if (!string.IsNullOrEmpty(data.code2))
            {
                queryWhere = queryWhere + " AND  A.[kbn2_cd] = @CODE2 ";
                paramDict.Add("@CODE2", data.code2);
            }
            //系列１コード
            if (!string.IsNullOrEmpty(data.code3))
            {
                queryWhere = queryWhere + " AND  A.[kei1_cd] = @CODE3 ";
                paramDict.Add("@CODE3", data.code3);
            }
            //系列１コード
            if (!string.IsNullOrEmpty(data.code4))
            {
                queryWhere = queryWhere + " AND  A.[kei2_cd] = @CODE4 ";
                paramDict.Add("@CODE4", data.code4);
            }
            //系列１名
            if (!string.IsNullOrEmpty(data.name))
            {
                queryWhere = queryWhere + " AND  A.[kei2_name] LIKE @NAME ";
                paramDict.Add("@NAME", '%' + data.name + '%');
            }
            return paramDict;
        }

        public IActionResult OnPostExcel()
        {
            int index = 0;
            string path = "系列２一覧.xlsx";


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
            SqlDataReader rdr = db.ExecuteQueryReder(ConstSql.ExcelSqlKei2(QueryWhere).ToString(), paramDict);

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
