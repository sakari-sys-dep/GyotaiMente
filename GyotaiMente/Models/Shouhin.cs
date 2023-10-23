using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GyotaiMente.Models
{
    public partial class ShohinNotFound
    {
        public string メッセージ { get; set; } = string.Empty;
    }
    public partial class ShohinScreen
    {
        //[DisplayFormat(DataFormatString = "{0:#0.###}")]
        //[BindProperty]
        public string code { get; set; } = string.Empty;
        //[BindProperty]
        public string code2 { get; set; } = string.Empty;
        //[BindProperty]
        public string code3 { get; set; } = string.Empty;
        //[BindProperty]
        public string code4 { get; set; } = string.Empty;
        //[BindProperty]
        public string code5 { get; set; } = string.Empty;
        //[BindProperty]
        public string sitencd { get; set; } = string.Empty;
        //[BindProperty]
        public string sitennm { get; set; } = string.Empty;
        //[BindProperty]
        public string bukacd { get; set; } = string.Empty;
        //[BindProperty]
        public string bukanm { get; set; } = string.Empty;
        //[BindProperty]
        public string tantocd { get; set; } = string.Empty;
        //[BindProperty]
        public string tantonm { get; set; } = string.Empty;
        //[BindProperty]
        public string newcode { get; set; } = string.Empty;
        //[BindProperty]
        public string newcode2 { get; set; } = string.Empty;
        //[BindProperty]
        public string newcode3 { get; set; } = string.Empty;
        //[BindProperty]
        public string newcode4 { get; set; } = string.Empty;
        //[BindProperty]
        public string newcode5 { get; set; } = string.Empty;
        //[BindProperty]
        public string newsitencd { get; set; } = string.Empty;
        //[BindProperty]
        public string newsitennm { get; set; } = string.Empty;
        //[BindProperty]
        public string newbukacd { get; set; } = string.Empty;
        //[BindProperty]
        public string newbukanm { get; set; } = string.Empty;
        //[BindProperty]
        public string newtantocd { get; set; } = string.Empty;
        //[BindProperty]
        public string newtantonm { get; set; } = string.Empty;
        //[BindProperty]
        public string name { get; set; } = string.Empty;
        //[BindProperty]
        public string newname { get; set; } = string.Empty;
        //[BindProperty]
        public string kanriCategory { get; set; } = string.Empty;
        //[BindProperty]
        public string kanri { get; set; } = string.Empty;
        //[BindProperty]
        public string tanto { get; set; } = string.Empty;
        //[BindProperty]
        public string company { get; set; } = string.Empty;
        //[BindProperty]
        public string regist { get; set; } = string.Empty;
        //[BindProperty]
        public string regist2 { get; set; } = string.Empty;
        //[BindProperty]
        public string regist3 { get; set; } = string.Empty;
        //[BindProperty]
        public string regist4 { get; set; } = string.Empty;
        //[BindProperty]
        public string regist5 { get; set; } = string.Empty;
        //[BindProperty]
        public string rename { get; set; } = string.Empty;
        //[BindProperty]
        //public bool   ischecked { get; set; } = false;
        //[BindProperty]
        public List<TantoList> Lists { get; set; } = new List<TantoList>();

        public List<Ten_cdList> TenLists { get; set; } = new List<Ten_cdList>();
    }

    /// <summary>
    /// 商品検索リストのモデル
    /// </summary> 
    public partial class BigList
    {
        [Key]
        [DisplayName("大業態コード")]
        public string ms01d_big_kbn1_cd { get; set; } = string.Empty;
        [DisplayName("大業態名")]
        public string ms01d_big_kbn1_name { get; set; } = string.Empty;
    }

    public partial class SmallList
    {
        [Key]
        [DisplayName("大業態コード")]
        public string ms01d_small_kbn1_cd { get; set; } = string.Empty;
        [DisplayName("小業態コード")]
        public string ms01d_small_kbn2_cd { get; set; } = string.Empty;
        [DisplayName("名称")]
        public string ms01d_small_kbn2_name { get; set; } = string.Empty;
    }

    public partial class Kei1List
    {
        [Key]
        [DisplayName("大業態コード")]
        public string kbn1_cd { get; set; } = string.Empty;
        [DisplayName("小業態コード")]
        public string kbn2_cd { get; set; } = string.Empty;
        [DisplayName("系列１コード")]
        public string kei1_cd { get; set; } = string.Empty;
        [DisplayName("系列１名")]
        public string kei1_name { get; set; } = string.Empty;
    }

    public partial class Kei2List
    {
        [Key]
        [DisplayName("大業態コード")]
        public string kbn1_cd { get; set; } = string.Empty;
        [DisplayName("小業態コード")]
        public string kbn2_cd { get; set; } = string.Empty;
        [DisplayName("系列１コード")]
        public string kei1_cd { get; set; } = string.Empty;
        [DisplayName("系列２コード")]
        public string kei2_cd { get; set; } = string.Empty;
        [DisplayName("系列２名")]
        public string kei2_name { get; set; } = string.Empty;
    }

    public partial class TantoList
    {
        [Key]
        //[DisplayName("チェックボックス")]
        //public bool checkbox_check { get; set; } = false;
        [DisplayName("大業態コード")]
        public string kbn1_cd { get; set; } = string.Empty;
        [DisplayName("小業態コード")]
        public string kbn2_cd { get; set; } = string.Empty;
        [DisplayName("系列１コード")]
        public string kei1_cd { get; set; } = string.Empty;
        [DisplayName("系列２コード")]
        public string kei2_cd { get; set; } = string.Empty;
        [DisplayName("系列２名")]
        public string kei2_name { get; set; } = string.Empty;
        [DisplayName("支店コード")]
        public string siten_cd { get; set; } = string.Empty;
        [DisplayName("支店名")]
        public string siten_name { get; set; } = string.Empty;
        [DisplayName("部課コード")]
        public string buka_cd { get; set; } = string.Empty;
        [DisplayName("部課名")]
        public string buka_name { get; set; } = string.Empty;
        [DisplayName("担当者コード")]
        public string tanto_cd { get; set; } = string.Empty;
        [DisplayName("担当者名")]
        public string tanto_name { get; set; } = string.Empty;
        [DisplayName("フラグ")]
        public bool IsDelete { get; set; } = false;
    }

    public partial class Ten_cdList
    {
        [Key]
        [DisplayName("大業態コード")]
        public string kbn1_cd { get; set; } = string.Empty;
        [DisplayName("小業態コード")]
        public string kbn2_cd { get; set; } = string.Empty;
        [DisplayName("系列１コード")]
        public string kei1_cd { get; set; } = string.Empty;
        [DisplayName("系列２コード")]
        public string kei2_cd { get; set; } = string.Empty;
        [DisplayName("店コード")]
        public string ten_cd { get; set; } = string.Empty;
        [DisplayName("店名")]
        public string km01d_yagou_k { get; set; } = string.Empty;
        [DisplayName("フラグ")]
        public bool IsDelete { get; set; } = false;
    }
    public partial class ViewModels
    {
        public IList<TantoList> TantoLists { get; set; } = default!;
    }
}
