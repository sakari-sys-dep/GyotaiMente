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
using Microsoft.CodeAnalysis;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Office.CustomUI;

namespace GyotaiMente.Pages.Tanto
{
    public class DetailsModel : PageModel
    {

        [BindProperty]
        public ShohinScreen data { get; set; } = new ShohinScreen();

        //[BindProperty]
        public IList<TantoList> TantoList { get; set; } = default!;
        //[BindProperty]
        public IList<TantoList> NewTantoList { get; set; } = default!;
        public IList<ShohinNotFound> shohinNotFounds { get; set; } = default!;

        public SelectList kanriCategory { get; set; } = default!;
        public SelectList kanri { get; set; } = default!;
        public SelectList tanto { get; set; } = default!;

        [BindProperty]
        public string shiten { get; set; } = string.Empty;
        [BindProperty]
        public bool[]? checkboxcheck { get; set; }

        private ICategoryService categoryService;
        public DetailsModel(ICategoryService categoryService) => this.categoryService = categoryService;

        public void OnGet()
        {
            kanriCategory = new SelectList(categoryService.GetKanriCategories(""), nameof(KanriCategory.Value), nameof(KanriCategory.Text));
            kanri = new SelectList(categoryService.GetKanri(), nameof(Kanri.Value), nameof(Kanri.Text));
            tanto = new SelectList(categoryService.GetTanto(""), nameof(Models.Tanto.Value), nameof(Models.Tanto.Text));
        }

        public void OnPost()
        {
            kanriCategory = new SelectList(categoryService.GetKanriCategories(""), nameof(KanriCategory.Value), nameof(KanriCategory.Text));
            kanri = new SelectList(categoryService.GetKanri(), nameof(Kanri.Value), nameof(Kanri.Text));
            tanto = new SelectList(categoryService.GetTanto(""), nameof(Models.Tanto.Value), nameof(Models.Tanto.Text));
        }

        public JsonResult OnGetKanris(string ID)
        {
            return new JsonResult(categoryService.GetKanriCategories(ID));
        }

        public JsonResult OnGetTantos(string ID)
        {
            return new JsonResult(categoryService.GetTanto(ID));
        }

        public async Task OnPostSearch()
        {
            kanriCategory = new SelectList(categoryService.GetKanriCategories(""), nameof(KanriCategory.Value), nameof(KanriCategory.Text));
            kanri = new SelectList(categoryService.GetKanri(), nameof(Kanri.Value), nameof(Kanri.Text));
            tanto = new SelectList(categoryService.GetTanto(""), nameof(Models.Tanto.Value), nameof(Models.Tanto.Text));

            var mkei2List = new List<TantoList>();
            var shohinNotFound = new List<ShohinNotFound>();


            /*パラメータの設定*/
            string QueryWhere = string.Empty;
            string QuerySort = string.Empty;
            Dictionary<string, object> paramDict = SetQueryParameters(data, out QueryWhere, out QuerySort);

            DBManager db = new DBManager();
            db.Connect(Const.CONNECTION_KEY_KOURIDB);
            SqlDataReader rdr = await db.ExecuteQueryRederAsync(ConstSql.CreateSqlKei2(QueryWhere).ToString(), paramDict);
            while (await rdr.ReadAsync())
            {
                mkei2List.Add(new TantoList
                {
                    //checkbox_check = false,
                    kbn1_cd = rdr["kbn1_cd"].ToString()!,
                    kbn2_cd = rdr["kbn2_cd"].ToString()!,
                    kei1_cd = rdr["kei1_cd"].ToString()!,
                    kei2_cd = rdr["kei2_cd"].ToString()!,
                    kei2_name = rdr["kei2_name"].ToString()!,
                    siten_cd = rdr["siten_cd"].ToString()!,
                    siten_name = rdr["siten_name"].ToString()!,
                    buka_cd = rdr["buka_cd"].ToString()!,
                    buka_name = rdr["buka_name"].ToString()!,
                    tanto_cd = rdr["tanto_cd"].ToString()!,
                    tanto_name = rdr["tanto_name"].ToString()!,
                });
                TantoList = mkei2List.ToList();
                //viewModels.TantoLists = kei2List;
            }
            if (TantoList is null)
            {
                shohinNotFound.Add(new ShohinNotFound { メッセージ = "データが見つかりません。" });
                shohinNotFounds = shohinNotFound.ToList();
            }
            else
            {
                data.Lists.AddRange(TantoList!.ToArray());
            }
                db.Disconnect();

        }

        private Dictionary<string, object> SetQueryParameters(ShohinScreen data, out string queryWhere, out string querySort)
        {
            /*初期化*/
            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            queryWhere = string.Empty;
            querySort = string.Empty;

            //管理支店
            if (!string.IsNullOrEmpty(shiten))
            {
                queryWhere = queryWhere + " AND  [siten_cd] = @SITENCD ";
                paramDict.Add("@SITENCD", shiten);
            }
            //管理部課
            if (!string.IsNullOrEmpty(data.kanriCategory))
            {
                queryWhere = queryWhere + " AND  [buka_cd] = @BUKACD ";
                paramDict.Add("@BUKACD", data.kanriCategory);
            }
            //担当者
            if (!string.IsNullOrEmpty(data.tanto))
            {
                queryWhere = queryWhere + " AND  [tanto_cd] = @TANTOCD ";
                paramDict.Add("@TANTOCD", data.tanto);
            }

            ////支店コード
            //if (!string.IsNullOrEmpty(data.sitencd))
            //{
            //    queryWhere = queryWhere + " AND  [siten_cd] = @SITENCD ";
            //    paramDict.Add("@SITENCD", data.sitencd);
            //}
            ////支店名
            //if (!string.IsNullOrEmpty(data.sitennm))
            //{
            //    queryWhere = queryWhere + " AND  [siten_name] LIKE @SITENNM ";
            //    paramDict.Add("@SITENNM", '%' + data.sitennm + '%');
            //}
            ////部課コード
            //if (!string.IsNullOrEmpty(data.bukacd))
            //{
            //    queryWhere = queryWhere + " AND  [buka_cd] = @BUKACD ";
            //    paramDict.Add("@BUKACD", data.bukacd);
            //}
            ////部課名
            //if (!string.IsNullOrEmpty(data.bukanm))
            //{
            //    queryWhere = queryWhere + " AND  [buka_name] LIKE @BUKANM ";
            //    paramDict.Add("@BUKANM", '%' + data.bukanm + '%');
            //}
            ////担当者コード
            //if (!string.IsNullOrEmpty(data.tantocd))
            //{
            //    queryWhere = queryWhere + " AND  [tanto_cd] = @TANTOCD ";
            //    paramDict.Add("@TANTOCD", data.tantocd);
            //}
            ////担当者名
            //if (!string.IsNullOrEmpty(data.tantonm))
            //{
            //    queryWhere = queryWhere + " AND  [tanto_name] LIKE @TANTONM ";
            //    paramDict.Add("@TANTONM", '%' + data.tantonm + '%');
            //}
            return paramDict;
        }

        public async Task OnPostUpdate()
        {
            var shohinNotFound = new List<ShohinNotFound>();

            kanriCategory = new SelectList(categoryService.GetKanriCategories(""), nameof(KanriCategory.Value), nameof(KanriCategory.Text));
            kanri = new SelectList(categoryService.GetKanri(), nameof(Kanri.Value), nameof(Kanri.Text));
            tanto = new SelectList(categoryService.GetTanto(""), nameof(Models.Tanto.Value), nameof(Models.Tanto.Text));

            /*入力チェック*/
            if (data.newsitencd is not null && data.newsitennm is not null && data.newbukacd is not null && data.newbukanm is not null && data.newtantocd is not null && data.newtantonm is not null)
            {
                /*パラメータの設定*/
                string QueryWhere = string.Empty;
                string QuerySort = string.Empty;
                int flag = 0;
                Dictionary<string, object> paramDict = new Dictionary<string, object>();

                DBManager db = new DBManager();
                db.Connect(Const.CONNECTION_KEY_KOURIDB);

                //対象データを全て更新する
                foreach (var list in data.Lists)
                {
                    if (list.IsDelete) 
                    {
                        flag = 1;
                        SqlDataReader rdr = await db.ExecuteQueryRederAsync(ConstSql.UpdateSqlTanto(list.kbn1_cd, list.kbn2_cd, list.kei1_cd, list.kei2_cd, data.newsitencd, data.newsitennm, data.newbukacd, data.newbukanm, data.newtantocd, data.newtantonm).ToString(), paramDict);
                    }
                }

                if (flag == 1)
                {
                    shohinNotFound.Add(new ShohinNotFound { メッセージ = "登録が完了しました。" });
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
