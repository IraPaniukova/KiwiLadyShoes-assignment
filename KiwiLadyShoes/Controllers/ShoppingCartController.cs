using KiwiLadyShoes.Models;
using KiwiLadyShoes.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KiwiLadyShoes.Controllers //Ira, 8/11/23 adding shopping cart
{
    public class ShoppingCartController : Controller
    {
        private readonly FS23_Group1_ProjectContext _context;
        public ShoppingCartController(FS23_Group1_ProjectContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cartItems = GetCartItems();
            return View(cartItems);

        }
        public IActionResult AddToCart(int Id)
        {
            var shoe = _context.Shoes.FirstOrDefault(p => p.ShoeId == Id);
            if (shoe != null)
            {
                var cartItems = GetCartItems();
                var cartItem = cartItems.FirstOrDefault(item => item.shoe.ShoeId == Id);
                if (cartItem != null)
                {
                    cartItem.quantity++;
                }
                else
                {
                    cartItems.Add(new CartItem { shoe = shoe, quantity = 1 });
                }
                SaveCartItems(cartItems); // Updates  cart in the session
            }
            return RedirectToAction("Index");
        }
        public IActionResult RemoveFromCart(int shoesId)
        {
            var cartItems = GetCartItems();
            var cartItem = cartItems.FirstOrDefault(item => item.shoe.ShoeId == shoesId);
            if (cartItem != null)
            {
                if (cartItem.quantity > 1)
                {
                    cartItem.quantity--;
                }
                else
                {
                    cartItems.Remove(cartItem);
                }
            }
            SaveCartItems(cartItems);
            return RedirectToAction("Index");
        }

        public IActionResult ClearCart()
        {
            SaveCartItems(new List<CartItem>());
            return RedirectToAction("Index");
        }

        private List<CartItem> GetCartItems()
        {
            var cartItems = HttpContext.Session.Get<List<CartItem>>("CartItems");
            if (cartItems == null)
            {
                cartItems = new List<CartItem>();
            }
            return cartItems;
        }
        private void SaveCartItems(List<CartItem> cartItems)
        {
            HttpContext.Session.Set("CartItems", cartItems); // Updates  cart in the session

        }
    }
}


