using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GyotaiMente.Models
{
    public partial class 店コードマスタ
    {
        [Key]
        public string kbn1_cd { get; set; } = string.Empty;
        public string? kbn2_cd { get; set; } = string.Empty;
        public string kei1_cd { get; set; } = string.Empty;
        public string? kei2_cd { get; set; } = string.Empty;
        public string? ten_cd { get; set; } = string.Empty;
        public string? YAGOU { get; set; } = string.Empty;
    }
}
