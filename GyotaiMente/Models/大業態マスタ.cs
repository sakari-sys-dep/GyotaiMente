using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GyotaiMente.Models
{
    public partial class 大業態マスタ
    {
        [Key]
        public string ms01d_big_kbn1_cd { get; set; } = string.Empty;
        public string? ms01d_big_kbn1_name { get; set; } = string.Empty;
    }
}
