using System;
using System.Collections.Generic;

namespace GameStoreASP_Net.Models
{
    public partial class User
    {
        public User()
        {
            CombinationUserGames = new HashSet<CombinationUserGame>();
            Settings = new HashSet<Setting>();
        }

        public int IdUser { get; set; }
        public string LoginUser { get; set; } = null!;
        public string PasswordUser { get; set; } = null!;
        public string? ImageUser { get; set; }

        public virtual ICollection<CombinationUserGame> CombinationUserGames { get; set; }
        public virtual ICollection<Setting> Settings { get; set; }
    }
}
