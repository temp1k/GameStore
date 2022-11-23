using System;
using System.Collections.Generic;

namespace GameStoreASP_Net.Models
{
    public partial class Cart
    {
        public int IdCart { get; set; }
        public bool Status { get; set; }
        public int CombinationUserGameId { get; set; }

        public virtual CombinationUserGame CombinationUserGame { get; set; } = null!;
    }
}
