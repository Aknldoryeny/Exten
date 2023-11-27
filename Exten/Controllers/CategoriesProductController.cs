using Exten.Models;
using Exten.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exten.Controllers
{
    public class CategoriesProductController : Controller
    {
        private readonly AppCtx _context;

        public CategoriesProductController(AppCtx context)
        {
            _context = context;
        }

        // GET: CategoriesProduct
        public async Task<IActionResult> Index()
        {
            var appCtx = _context.CategoriesProduct
                .OrderBy(f => f.CategoryName);

            return _context.CategoriesProduct != null ? 
                        View(await _context.CategoriesProduct.ToListAsync()) :
                        Problem("Entity set 'AppCtx.CategoriesProduct'  is null.");
        }

        // GET: CategoriesProduct/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null || _context.CategoriesProduct == null)
            {
                return NotFound();
            }

            var categoryProduct = await _context.CategoriesProduct
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryProduct == null)
            {
                return NotFound();
            }

            return View(categoryProduct);
        }

        // GET: CategoriesProduct/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriesProduct/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryName")] CategoryProduct categoryProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoryProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryProduct);
        }

        // GET: CategoriesProduct/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null || _context.CategoriesProduct == null)
            {
                return NotFound();
            }

            var categoryProduct = await _context.CategoriesProduct.FindAsync(id);
            if (categoryProduct == null)
            {
                return NotFound();
            }
            return View(categoryProduct);
        }

        // POST: CategoriesProduct/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("Id,CategoryName")] CategoryProduct categoryProduct)
        {
            if (id != categoryProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryProductExists(categoryProduct.Id))
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
            return View(categoryProduct);
        }

        // GET: CategoriesProduct/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null || _context.CategoriesProduct == null)
            {
                return NotFound();
            }

            var categoryProduct = await _context.CategoriesProduct
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryProduct == null)
            {
                return NotFound();
            }

            return View(categoryProduct);
        }

        // POST: CategoriesProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            if (_context.CategoriesProduct == null)
            {
                return Problem("Entity set 'AppCtx.CategoriesProduct'  is null.");
            }
            var categoryProduct = await _context.CategoriesProduct.FindAsync(id);
            if (categoryProduct != null)
            {
                _context.CategoriesProduct.Remove(categoryProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryProductExists(short id)
        {
          return (_context.CategoriesProduct?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
