using KiwiLadyShoes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace KiwiLadyShoes.Controllers
{
    [Authorize(Roles = "Administrator")]  //-- Victor Reis - 05/11/2023
    public class ReportController : Controller  //Ira,some adjustments 7/11/23
    {

        private readonly FS23_Group1_ProjectContext _context; //-- Victor Reis - 05/11/2023
        public ReportController(FS23_Group1_ProjectContext context) //-- Victor Reis - 05/11/2023
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sales(string searchString)
        {// Added SQL Script -- Victor Reis - 05/11/2023
            var sales = from e in _context.SalesReport select e;
            if (!String.IsNullOrEmpty(searchString))

            {

                sales = sales.Where(s => s.ShoeName.Contains(searchString));

            }
            sales = sales.OrderBy(s => s.ShoeId);
            string sql = @"select sh.ShoeId,sh.Image, sh.ShoeName,SUM(sa.Quantity) as Quantity,sh.StockQuantity
                         from Shoe sh Join Sale as sa on sh.ShoeId = sa.ShoeId 
                         group by sh.ShoeId, sh.ShoeName, sh.Image, sh.StockQuantity ";
            sales = _context.SalesReport.FromSqlRaw(sql);

            if (!String.IsNullOrEmpty(searchString))

            {

                sales = sales.Where(s => s.ShoeName.Contains(searchString));

            }
            sales = sales.OrderBy(s => s.ShoeId);

            
            return View(sales.ToList());

        }
        public  async Task<IActionResult> StockPerName(string SearchString) //Ira, 10/11/23 //I am adding just search box for my report, Ira, 122/11/23
        {
            string sql = @"select sum(StockQuantity) as FullStock, ShoeName from Shoe 
                            group by ShoeName";
            //var stockPerName = _context.ReportStockPerNames.FromSqlRaw(sql);
            //return View(stockPerName.ToList());

            var stockPerName = from x in _context.ReportStockPerNames.FromSqlRaw(sql) select x;
            stockPerName = stockPerName.OrderBy(s => s.FullStock);  //I had it in the qery, but it created a problem with the search, so I moved the ordering here, Ira 12/11/23
            if (!String.IsNullOrEmpty(SearchString))
            {
                stockPerName = stockPerName.Where(y => y.ShoeName.Contains(SearchString));
            }
            
            return View(await stockPerName.ToListAsync());
        }

    }


}
