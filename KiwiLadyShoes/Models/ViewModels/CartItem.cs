namespace KiwiLadyShoes.Models.ViewModels
{
    public class CartItem //Ira, 8/11/23 adding shopping cart
    {

        public Shoe shoe { get; set; }
        public int quantity { get; set; }
        public string userId { get; set; }
    }
}
