using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KiwiLadyShoes.Models;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using X.PagedList;
using Microsoft.Data.SqlClient;
using System.Data;

namespace KiwiLadyShoes.Controllers
{

    public class SaleController : Controller
    {
        private readonly FS23_Group1_ProjectContext _context;

        public SaleController(FS23_Group1_ProjectContext context)
        {
            _context = context;
        }
        public string IndexAJAX(string searchString)  // Added Search configurations Victor, 23/10/23
        {
            string sql = "SELECT * FROM Sale WHERE ShoeId LIKE @p0";
            string wrapString = "%" + searchString + "%";
            List<AspNetUser> users = _context.AspNetUsers.FromSqlRaw(sql, wrapString).ToList();
            string jason = JsonConvert.SerializeObject(users);
            return jason;
        }


        // GET: Sale
        public async Task<IActionResult> Index(string searchString, int? page, string sortOrder) // (search, pages and sorting) Victor 23/10/23
        {
            ViewData["SalesSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var pageNumber = page ?? 1;
            var sales = from i in _context.Sales select i;
            if (!String.IsNullOrEmpty(searchString))
            {
                sales = sales.Where(s => s.SaleId.ToString().Contains(searchString));
            }
            //Sorting shoes by FirstName
            sales = sales.OrderBy(u => u.SaleDate);
            switch (sortOrder)
            {
                case "name_desc":
                    sales = sales.OrderByDescending(u => u.SaleDate);
                    break;
            }

            return View(sales.ToPagedList(pageNumber, 7));


            return _context.AspNetUsers != null ?
                        View(await _context.AspNetUsers.ToListAsync()) :
                        Problem("Entity set 'FS23_Group1_ProjectContext.AspNetUsers'  is null.");
        }

        // GET: Sale/Details

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sales == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales
                .Include(s => s.Payment)
                .Include(s => s.Shipping)
                .Include(s => s.Shoe)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.SaleId == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // GET: Sale/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sales == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            ViewData["PaymentId"] = new SelectList(_context.Payments, "PaymentId", "PaymentId", sale.PaymentId);
            ViewData["ShippingId"] = new SelectList(_context.Shippings, "ShippingId", "ShippingId", sale.ShippingId);
            ViewData["ShoeId"] = new SelectList(_context.Shoes, "ShoeId", "ShoeId", sale.ShoeId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", sale.UserId);
            return View(sale);
        }

        // POST: Sale/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaleId,SaleDate,Discount,Quantity,TotalPrice,UserId,ShoeId,PaymentId,ShippingId")] Sale sale)
        {
            if (id != sale.SaleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleExists(sale.SaleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaymentId"] = new SelectList(_context.Payments, "PaymentId", "PaymentId", sale.PaymentId);
            ViewData["ShippingId"] = new SelectList(_context.Shippings, "ShippingId", "ShippingId", sale.ShippingId);
            ViewData["ShoeId"] = new SelectList(_context.Shoes, "ShoeId", "ShoeId", sale.ShoeId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", sale.UserId);
            return View(sale);
        }

        // GET: Sale/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sales == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales
                .Include(s => s.Payment)
                .Include(s => s.Shipping)
                .Include(s => s.Shoe)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.SaleId == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // POST: Sale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sales == null)
            {
                return Problem("Entity set 'FS23_Group1_ProjectContext.Sales'  is null.");
            }
            var sale = await _context.Sales.FindAsync(id);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleExists(int id)
        {
            return (_context.Sales?.Any(e => e.SaleId == id)).GetValueOrDefault();
        }
    }
}
