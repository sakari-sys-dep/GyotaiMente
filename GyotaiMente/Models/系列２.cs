using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GyotaiMente.Models
{
    public partial class 系列２
    {
        [Key]
        public string kbn1_cd { get; set; } = string.Empty;
        public string kbn2_cd { get; set; } = string.Empty;
        public string kei1_cd { get; set; } = string.Empty;
        public string kei2_cd { get; set; } = string.Empty;
        public string? kei2_name { get; set; } = string.Empty;
        public string? siten_cd { get; set; } = string.Empty;
        public string? siten_name { get; set; } = string.Empty;
        public string? buka_cd { get; set; } = string.Empty;
        public string? buka_name { get; set; } = string.Empty;
        public string? tanto_cd { get; set; } = string.Empty;
        public string? tanto_name { get; set; } = string.Empty;
    }
}
