using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GyotaiMente.Models
{
    public partial class 系列１
    {
        [Key]
        public string kbn1_cd { get; set; } = string.Empty;
        public string kbn2_cd { get; set; } = string.Empty;
        public string kei1_cd { get; set; } = string.Empty;
        public string? kei1_name { get; set; } = string.Empty;
    }
}
