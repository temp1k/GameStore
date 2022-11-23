using System;
using System.Collections.Generic;

namespace GameStoreASP_Net.Models
{
    public partial class Language
    {
        public Language()
        {
            Settings = new HashSet<Setting>();
        }

        public int IdLanguage { get; set; }
        public string NameLanguage { get; set; } = null!;

        public virtual ICollection<Setting> Settings { get; set; }
    }
}
