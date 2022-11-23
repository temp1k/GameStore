using System;
using System.Collections.Generic;

namespace GameStoreASP_Net.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Games = new HashSet<Game>();
        }

        public int IdGenre { get; set; }
        public string NameGenre { get; set; } = null!;

        public virtual ICollection<Game> Games { get; set; }
    }
}
