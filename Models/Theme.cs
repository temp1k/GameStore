using System;
using System.Collections.Generic;

namespace GameStoreASP_Net.Models
{
    public partial class Theme
    {
        public Theme()
        {
            Settings = new HashSet<Setting>();
        }

        public int IdTheme { get; set; }
        public string NameTheme { get; set; } = null!;

        public virtual ICollection<Setting> Settings { get; set; }
    }
}
