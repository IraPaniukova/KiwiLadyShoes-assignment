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
    [Authorize(Roles = "Manager,Administrator")]


    public class UserController : Controller
    {
        private readonly FS23_Group1_ProjectContext _context;

        public UserController(FS23_Group1_ProjectContext context)
        {
            _context = context;
        }
       
        // GET: User
        // (search, pages and sorting) Victor 23/10/23
        public async Task<IActionResult> Index(string searchString, int? page, string sort) 
            
        {
            ViewData["UserSortParam"] = String.IsNullOrEmpty(sort) ? "firstname_desc" : "";
            //Check with Ahmad
            var pageNumber = page ?? 1;
            var users = from i in _context.AspNetUsers select i;
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => u.FirstName.Contains(searchString)||
                u.LastName.Contains(searchString));
                // search by First and Last name
                
            }
            //Sorting shoes by FirstName Victor 23/10/23
            users = users.OrderBy(u => u.FirstName);
            switch (sort)
            {
                case "name_desc":
                    users = users.OrderByDescending(u => u.FirstName);
                    break;
            }


            return View(users.ToPagedList(pageNumber, 7));


            return _context.AspNetUsers != null ?
                        View(await _context.AspNetUsers.ToListAsync()) :
                        Problem("Entity set 'FS23_Group1_ProjectContext.AspNetUsers'  is null.");
        }
        public string IndexAJAX(string searchString)  // Added Suggetions Search configurations Victor, 23/10/23
        {
            string sql = "SELECT * FROM AspNetUsers WHERE FirstName LIKE @p0";
            string wrapString = "%" + searchString + "%";
            List<AspNetUser> users = _context.AspNetUsers.FromSqlRaw(sql, wrapString).ToList();
            string jason = JsonConvert.SerializeObject(users);
            return jason;
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.AspNetUsers == null)
            {
                return NotFound();
            }

            var aspNetUser = await _context.AspNetUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetUser == null)
            {
                return NotFound();
            }

            return View(aspNetUser);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Birthday,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] AspNetUser aspNetUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aspNetUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aspNetUser);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.AspNetUsers == null)
            {
                return NotFound();
            }

            var aspNetUser = await _context.AspNetUsers.FindAsync(id);
            if (aspNetUser == null)
            {
                return NotFound();
            }
            return View(aspNetUser);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName,LastName,Birthday,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] AspNetUser aspNetUser)
        {
            if (id != aspNetUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aspNetUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AspNetUserExists(aspNetUser.Id))
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
            return View(aspNetUser);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.AspNetUsers == null)
            {
                return NotFound();
            }

            var aspNetUser = await _context.AspNetUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetUser == null)
            {
                return NotFound();
            }

            return View(aspNetUser);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.AspNetUsers == null)
            {
                return Problem("Entity set 'FS23_Group1_ProjectContext.AspNetUsers'  is null.");
            }
            var aspNetUser = await _context.AspNetUsers.FindAsync(id);
            if (aspNetUser != null)
            {
                _context.AspNetUsers.Remove(aspNetUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AspNetUserExists(string id)
        {
            return (_context.AspNetUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
