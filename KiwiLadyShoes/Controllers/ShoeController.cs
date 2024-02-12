using KiwiLadyShoes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;
using System.IO;
using System.IO.Pipes;
using X.PagedList;

namespace KiwiLadyShoes.Controllers
{
    public class ShoeController : Controller
    {
        private readonly FS23_Group1_ProjectContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;  //Ira, 8/11/23 added for uploading images

        public ShoeController(FS23_Group1_ProjectContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }


        public string IndexAJAX(string searchString)  //Ira, 19/10/23
        {
            string sql = "SELECT * FROM Shoe WHERE ShoeName LIKE @p0";
            string wrapString = "%" + searchString + "%";
            List<Shoe> shoes = _context.Shoes.FromSqlRaw(sql, wrapString).ToList();
            string jason = JsonConvert.SerializeObject(shoes);
            return jason;
        }


        // Ira.28/10/23/ I have a repetive piece of code that is why I am creating this function to reuse it/
        private async Task<IPagedList<Shoe>> ShoeList(string searchString, int? page, string sort, int pageN)
        {
            ViewData["PriceSortParam"] = String.IsNullOrEmpty(sort) ? "price_desc" : ""; // to sort by price, all sorting here is by Ira
            ViewData["SizeSortParam"] = sort == "size_asnd" ? "size_desc" : "size_asnd"; // to sort by size
            ViewData["QtySortParam"] = sort == "Qty_asnd" ? "Qty_desc" : "Qty_asnd"; // to sort by quantuty
            
            var pageNumber = page ?? 1;
            var shoes = from i in _context.Shoes.Include(s => s.Brand).Include(s => s.Type) select i;
            if (!String.IsNullOrEmpty(searchString))
            {
                shoes = shoes.Where(s => s.ShoeName.Contains(searchString));
            }
            switch (sort)   //Sorting shoes, Ira 19/10/23
            {
                case "price_desc":
                    shoes = shoes.OrderByDescending(s => s.Price);
                    break;
                case "size_asnd":
                    shoes = shoes.OrderBy(s => s.Size);
                    break;
                case "size_desc":
                    shoes = shoes.OrderByDescending(s => s.Size);
                    break;
                case "Qty_asnd":
                    shoes = shoes.OrderBy(s => s.StockQuantity);
                    break;
                case "Qty_desc":
                    shoes = shoes.OrderByDescending(s => s.StockQuantity);
                    break;
                default:
                    shoes = shoes.OrderBy(s => s.Price);
                    break;
            }
            return await shoes.ToPagedListAsync(pageNumber, pageN);
        }

        // GET: Shoe
        [Authorize(Roles = "Manager,Administrator")]
        public async Task<IActionResult> Index(string searchString, int? page, string sort) // (search, pages) Ira,19/10/23
        {
            var result = await ShoeList(searchString, page, sort, 7);

            return View(result);
            ////The next piece of code was repetive for Index and Public actions, that is why I created the function ShoeList to replace it    Ira 28/10/23
            //ViewData["PriceSortParam"] = String.IsNullOrEmpty(sort) ? "name_desc" : "";
            //var pageNumber = page ?? 1;
            //var shoes = from i in _context.Shoes.Include(s => s.Brand).Include(s => s.Type) select i;
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    shoes = shoes.Where(s => s.ShoeName.Contains(searchString));
            //}
            ////Sorting shoes by Price
            //shoes = shoes.OrderBy(s => s.Price);
            //switch (sort)
            //{
            //    case "name_desc":
            //        shoes = shoes.OrderByDescending(s => s.Price);
            //        break;
            //}


            //return View(shoes.ToPagedList(pageNumber, 6));
        }

        //The next action is similar to Index but will have a different View design and will be accessible to everyone   Ira, 27/10/23
        public async Task<IActionResult> Public(string searchString, int? page, string sort)
        {
            var result = await ShoeList(searchString, page, sort, 6);

            return View(result);
        }


        // GET: Shoe/Details/5
        [Authorize(Roles = "Manager,Administrator")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Shoes == null)
            {
                return NotFound();
            }

            var shoe = await _context.Shoes
                .Include(s => s.Brand)
                .Include(s => s.Type)
                .FirstOrDefaultAsync(m => m.ShoeId == id);
            if (shoe == null)
            {
                return NotFound();
            }

            return View(shoe);
        }

        // GET: Shoe/Create
        [Authorize(Roles = "Manager,Administrator")]
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName");
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "TypeName");
            return View();
        }

        // POST: Shoe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Manager,Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("ShoeId,ShoeName,Size,StockQuantity,Colour,Material,Price,Image,BrandId,TypeId")] Shoe shoe, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (!_context.Shoes.Any(s => s.ShoeName == shoe.ShoeName && s.Size == shoe.Size)) ////We cannot repeat the same Name of a shoe with the same size Ira, 10/11/23
                {
                    if (image != null)
                    {
                        string imgFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");   //Ira. 8/11/23
                        string uniqueName = Guid.NewGuid().ToString() + "_" + image.FileName;
                        string filePath = Path.Combine(imgFolder, uniqueName);
                        using (var fs = new FileStream(filePath, FileMode.Create))

                        {
                            await image.CopyToAsync(fs);
                        }
                        shoe.Image = "~/img/" + uniqueName;
                    }

                    _context.Add(shoe);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else { ViewData["ShowPopup"] = true; }  
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName", shoe.BrandId);
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "TypeName", shoe.TypeId);
            return View(shoe);
        }

        // GET: Shoe/Edit/5
        [Authorize(Roles = "Manager,Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Shoes == null)
            {
                return NotFound();
            }

            var shoe = await _context.Shoes.FindAsync(id);
            if (shoe == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName", shoe.BrandId);
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "TypeName", shoe.TypeId);
            return View(shoe);
        }

        // POST: Shoe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Manager,Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShoeId,ShoeName,Size,StockQuantity,Colour,Material,Price,Image,BrandId,TypeId")] Shoe shoe,  IFormFile image)
        {
            if (id != shoe.ShoeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (!_context.Shoes.Any(s => s.ShoeName == shoe.ShoeName && s.Size == shoe.Size && s.ShoeId != shoe.ShoeId)) ////We cannot repeat the same Name of a shoe with the same size Ira, 10/11/23
                {
                    try
                    {
                        if (image != null)
                        {
                            string imgFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");   //Ira. 8/11/23
                            string uniqueName = Guid.NewGuid().ToString() + "_" + image.FileName;
                            string filePath = Path.Combine(imgFolder, uniqueName);
                            using (var fs = new FileStream(filePath, FileMode.Create))

                            {
                                await image.CopyToAsync(fs);
                            }
                            shoe.Image = "~/img/" + uniqueName;
                        }

                        _context.Update(shoe);
                        await _context.SaveChangesAsync();

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ShoeExists(shoe.ShoeId))
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
                else { ViewData["ShowPopup"] = true; }
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName", shoe.BrandId);
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "TypeName", shoe.TypeId);
            return View(shoe);
        }

        // GET: Shoe/Delete/5
        [Authorize(Roles = "Manager,Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shoes == null)
            {
                return NotFound();
            }

            var shoe = await _context.Shoes
                .Include(s => s.Brand)
                .Include(s => s.Type)
                .FirstOrDefaultAsync(m => m.ShoeId == id);
            if (shoe == null)
            {
                return NotFound();
            }

            return View(shoe);
        }

        // POST: Shoe/Delete/
        [Authorize(Roles = "Manager,Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Shoes == null)
            {
                return Problem("Entity set 'FS23_Group1_ProjectContext.Shoes'  is null.");
            }
            var shoe = await _context.Shoes.FindAsync(id);
            if (shoe != null)
            {
                _context.Shoes.Remove(shoe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoeExists(int id)
        {
            return (_context.Shoes?.Any(e => e.ShoeId == id)).GetValueOrDefault();
        }
    }
}
