using Humanizer;
using KiwiLadyShoes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace KiwiLadyShoes.Controllers
{

    //-- Controller Created to replace sales Victor Reis - 11/11/2023
    [Authorize(Roles = "Administrator")]  //-- Victor Reis - 11/11/2023
    public class OrderController : Controller
    {
        private readonly FS23_Group1_ProjectContext _context;
        public OrderController(FS23_Group1_ProjectContext context) 
 {
            _context = context;
        }

    public IActionResult Orders(string searchString)
        {
            var orders = from e in _context.OrdersVM select e;
            string sql = @"select sa.SaleId,sa.SaleDate, us.Id,sa.UserId, us.FirstName, us.LastName, sho.ShoeId,sho.ShoeName, sho.[Image], sa.Quantity, 
                            sa.TotalPrice,sho.Price ,sa.Discount, sa.PaymentId,sa.ShippingId  From Sale sa 
                            inner join  Shoe sho on sho.ShoeId = sa.ShoeId
                            inner join AspNetUsers as us on sa.UserId = us.Id";
            orders = _context.OrdersVM.FromSqlRaw(sql); // This to receive the value
            
            if (!String.IsNullOrEmpty(searchString))

            {

                orders = orders.Where(or => or.FirstName.Contains(searchString) || or.LastName.Contains(searchString));

            }
            orders = orders.OrderBy(or => or.SaleId);
            return View(orders.ToList());
        }
    }
}
