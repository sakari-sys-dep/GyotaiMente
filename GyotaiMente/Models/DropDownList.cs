using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GyotaiMente.Models
{
    public partial class DropDownList
    {
    }

    public partial class Big
    {
        [Key]
        [BindProperty]
        public string Value { get; set; } = string.Empty;
        [BindProperty]
        public string Text { get; set; } = string.Empty;
        [BindProperty]
        public bool Checked { get; set; } = false;
    }

    public partial class Small
    {
        [Key]
        [BindProperty]
        public string Value { get; set; } = string.Empty;
        [BindProperty]
        public string Text { get; set; } = string.Empty;
        [BindProperty]
        public bool Checked { get; set; } = false;
        public string SmallValue { get; set; } = string.Empty;
    }

    public partial class Kei1
    {
        [Key]
        [BindProperty]
        public string Value { get; set; } = string.Empty;
        [BindProperty]
        public string Text { get; set; } = string.Empty;
        [BindProperty]
        public bool Checked { get; set; } = false;
        public string Key1Value { get; set; } = string.Empty;
    }

    public partial class Kei2
    {
        [Key]
        [BindProperty]
        public string Value { get; set; } = string.Empty;
        [BindProperty]
        public string Text { get; set; } = string.Empty;
        [BindProperty]
        public bool Checked { get; set; } = false;
        public string Key2Value { get; set; } = string.Empty;
    }

    public partial class KanriCategory
    {
        [Key]
        [BindProperty]
        public string Value { get; set; } = string.Empty;
        [BindProperty]
        public string Text { get; set; } = string.Empty;
        [BindProperty]
        public bool Checked { get; set; } = false;
        public string KanriCategoryValue { get; set; } = string.Empty;
    }

    public partial class Kanri
    {
        [Key]
        [BindProperty]
        public string Value { get; set; } = string.Empty;
        [BindProperty]
        public string Text { get; set; } = string.Empty;
        [BindProperty]
        public bool Checked { get; set; } = false;
    }

    public partial class Tanto
    {
        [Key]
        [BindProperty]
        public string Value { get; set; } = string.Empty;
        [BindProperty]
        public string Text { get; set; } = string.Empty;
        [BindProperty]
        public bool Checked { get; set; } = false;
        public string TantoValue { get; set; } = string.Empty;
    }

    public partial class HozinCategory
    {
        [Key]
        [BindProperty]
        public string Value { get; set; } = string.Empty;
        [BindProperty]
        public string Text { get; set; } = string.Empty;
        [BindProperty]
        public bool IsChecked { get; set; } = false;
    }
}
