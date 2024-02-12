using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KiwiLadyShoes.Models;
using System.Security.Claims;
using KiwiLadyShoes.Models.ViewModels;

namespace KiwiLadyShoes.Controllers
{
    public class WishController : Controller  //Made by Ira 10/11/23
    {
        private readonly FS23_Group1_ProjectContext _context;

        public WishController(FS23_Group1_ProjectContext context)
        {
            _context = context;
        }

        // GET: Wish
        public async Task<IActionResult> Index()
        { var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var fS23_Group1_ProjectContext = _context.Wish.Include(w => w.Shoe).ThenInclude(s => s.Brand).Include(w => w.Shoe).ThenInclude(t => t.Type).Include(w => w.User).Where(w => w.UserId == currentUserId); ;
            //ThenInclude allow to add additonal tables to display BrandName and TypeName later, Ira, 11/11/23
            return View(await fS23_Group1_ProjectContext.ToListAsync());
        }

      
        // GET: Wish/Create
        public IActionResult Create(int shoeId)   //I changed a lot both Create actions here, Ira 10/11/23, 11/11/23

        {
            var shoe = _context.Shoes.Include(s => s.Brand).Include(t => t.Type).FirstOrDefault(p => p.ShoeId == shoeId);
            ViewData["UserId"] = User.FindFirstValue(ClaimTypes.NameIdentifier); //it check for current user Id
            ViewData["ShoeId"] = shoeId;  //the shoe id is sent from Public View (Shoe)

            return View(shoe);
        }

        // POST: Wish/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Wish wish, int shoeId)
        {
            
            wish.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);  //finds current user id, Ira
            wish.ShoeId = shoeId;

            if (ModelState.IsValid)
            {
                var w = await _context.Wish.SingleOrDefaultAsync(w => w.ShoeId == shoeId && w.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier));
               //to avoid doubling records, I need to check if the item is already in the list for the user, if not (==null), then I will add it, Ira
                if (w == null)
                {
                    _context.Add(wish);
                    
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            return View(wish);
        }

      

        // GET: Wish/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Wish == null)
            {
                return NotFound();
            }

            var wish = await _context.Wish
                .Include(w => w.Shoe)
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.WishId == id);
            if (wish == null)
            {
                return NotFound();
            }

            return View(wish);
        }

        // POST: Wish/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Wish == null)
            {
                return Problem("Entity set 'FS23_Group1_ProjectContext.Wish'  is null.");
            }
            var wish = await _context.Wish.FindAsync(id);
            if (wish != null)
            {
                _context.Wish.Remove(wish);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // GET: Wish/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Wish == null)
            {
                return NotFound();
            }

            var wish = await _context.Wish.FindAsync(id);
            if (wish == null)
            {
                return NotFound();
            }
            ViewData["ShoeId"] = new SelectList(_context.Shoes, "ShoeId", "ShoeId", wish.ShoeId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", wish.UserId);
            return View(wish);
        }

        // POST: Wish/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WishId,ShoeId,UserId")] Wish wish)
        {
            if (id != wish.WishId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WishExists(wish.WishId))
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
            ViewData["ShoeId"] = new SelectList(_context.Shoes, "ShoeId", "ShoeId", wish.ShoeId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", wish.UserId);
            return View(wish);
        }

        // GET: Wish/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Wish == null)
            {
                return NotFound();
            }

            var wish = await _context.Wish
                .Include(w => w.Shoe)
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.WishId == id);
            if (wish == null)
            {
                return NotFound();
            }

            return View(wish);
        }


        private bool WishExists(int id)
        {
          return (_context.Wish?.Any(e => e.WishId == id)).GetValueOrDefault();
        }
    }
}
