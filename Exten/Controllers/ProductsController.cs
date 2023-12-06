using Exten.Models;
using Exten.Models.Data;
using Exten.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Exten.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppCtx _context;

        public ProductsController(AppCtx context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var appCtx = _context.Products
                .Include(a => a.CategoryProduct)
                .OrderBy(o => o.ProductName);

            return _context.Products != null ? 
                          View(await appCtx.ToListAsync()) :
                          Problem("Entity set 'AppCtx.Products'  is null.");
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["IdCategoryProduct"] = new SelectList(_context.CategoriesProduct.OrderBy(o => o.CategoryName), "Id", "CategoryName");
            return View();
        }

        // POST: AnimeTitles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (_context.Products
                .Where(f => f.ProductName == model.ProductName &&
                    f.PriceProduct == model.PriceProduct &&
                    f.IdCategoryProduct == model.IdCategoryProduct)
                .FirstOrDefault() != null)
            {
                ModelState.AddModelError("", "Введеный товар уже существует");
            }

            if (ModelState.IsValid)
            {
                Product products = new()
                {
                    ProductName = model.ProductName,
                    PriceProduct = model.PriceProduct,
                    Description = model.Description,
                    IdCategoryProduct = model.IdCategoryProduct
                };

                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdCategoryProduct"] = new SelectList(_context.CategoriesProduct.OrderBy(o => o.CategoryName), "Id", "CategoryName", model.IdCategoryProduct);
            return View(model);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("Id,ProductName,PriceProduct,Description,IdCategoryProduct")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'AppCtx.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(short id)
        {
          return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
