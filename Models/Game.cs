using System;
using System.Collections.Generic;

namespace GameStoreASP_Net.Models
{
    public partial class Game
    {
        public Game()
        {
            CombinationUserGames = new HashSet<CombinationUserGame>();
        }

        public int IdGame { get; set; }
        public string NameGame { get; set; } = null!;
        public int GenreId { get; set; }
        public string ImageGame { get; set; } = null!;
        public int Price { get; set; }
        public string? GameDescription { get; set; }

        public virtual Genre Genre { get; set; } = null!;
        public virtual ICollection<CombinationUserGame> CombinationUserGames { get; set; }
    }
}
