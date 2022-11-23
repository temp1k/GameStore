namespace GameStoreASP_Net.Models
{
    public class Carts
    {
        public List<Game> CartLines { get; set; }

        public Carts()
        {
            CartLines = new List<Game>();
        }

        public decimal FinalPrice
        {
            get
            {
                decimal sum = 0;
                foreach(Game game in CartLines)
                {
                    sum += game.Price; 
                }
                return sum;
            }
        }
    }
}
