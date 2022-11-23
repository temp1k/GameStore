using System;
using System.Collections.Generic;

namespace GameStoreASP_Net.Models
{
    public partial class Setting
    {
        public int IdSettings { get; set; }
        public int UserId { get; set; }
        public int LanguageId { get; set; }
        public int ThemeId { get; set; }

        public virtual Language Language { get; set; } = null!;
        public virtual Theme Theme { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
