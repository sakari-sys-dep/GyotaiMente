using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GyotaiMente.Models
{
    public partial class 小業態マスタ
    {
        [Key]
        public string ms01d_small_kbn1_cd { get; set; } = string.Empty;
        public string ms01d_small_kbn2_cd { get; set; } = string.Empty;
        public string? ms01d_small_kbn2_name { get; set; } = string.Empty;
    }
}
