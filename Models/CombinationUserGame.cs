using System;
using System.Collections.Generic;

namespace GameStoreASP_Net.Models
{
    public partial class CombinationUserGame
    {
        public CombinationUserGame()
        {
            Carts = new HashSet<Cart>();
        }

        public int IdCombinationUserGame { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }

        public virtual Game Game { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
