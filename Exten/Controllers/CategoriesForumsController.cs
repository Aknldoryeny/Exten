using Exten.Models;
using Exten.Models.Data;
using Exten.ViewModels.CategoriesForum;
using Exten.ViewModels.CategoriesProduct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exten.Controllers
{
    public class CategoriesForumsController : Controller
    {
        private readonly AppCtx _context;

        public CategoriesForumsController(AppCtx context)
        {
            _context = context;
        }

        // GET: CategoriesForums
        public async Task<IActionResult> Index()
        {
              return _context.CategoriesForum != null ? 
                          View(await _context.CategoriesForum.ToListAsync()) :
                          Problem("Entity set 'AppCtx.CategoriesForum'  is null.");
        }

        // GET: CategoriesForums/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null || _context.CategoriesForum == null)
            {
                return NotFound();
            }

            var categoriesForum = await _context.CategoriesForum
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriesForum == null)
            {
                return NotFound();
            }

            return View(categoriesForum);
        }


        //11111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111
        // GET: CategoriesProduct/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCategoriesForumViewModel model)
        {

            if (_context.CategoriesForum
                .Where(f => f.ForumCategoryName == model.ForumCategoryName)
                .FirstOrDefault() != null
                )
            {
                ModelState.AddModelError("", "Введеная категория уже существует");
            }

            if (ModelState.IsValid)
            {
                CategoriesForum categoriesforum = new()
                {
                    ForumCategoryName = model.ForumCategoryName,
                };
                _context.Add(categoriesforum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        //11111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111
        // GET: CategoriesForums/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null || _context.CategoriesForum == null)
            {
                return NotFound();
            }

            var categoriesForum = await _context.CategoriesForum.FindAsync(id);
            if (categoriesForum == null)
            {
                return NotFound();
            }
            return View(categoriesForum);
        }

        // POST: CategoriesForums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("Id,ForumCategoryName")] CategoriesForum categoriesForum)
        {
            if (id != categoriesForum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriesForum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriesForumExists(categoriesForum.Id))
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
            return View(categoriesForum);
        }

        // GET: CategoriesForums/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null || _context.CategoriesForum == null)
            {
                return NotFound();
            }

            var categoriesForum = await _context.CategoriesForum
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriesForum == null)
            {
                return NotFound();
            }

            return View(categoriesForum);
        }

        // POST: CategoriesForums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            if (_context.CategoriesForum == null)
            {
                return Problem("Entity set 'AppCtx.CategoriesForum'  is null.");
            }
            var categoriesForum = await _context.CategoriesForum.FindAsync(id);
            if (categoriesForum != null)
            {
                _context.CategoriesForum.Remove(categoriesForum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriesForumExists(short id)
        {
          return (_context.CategoriesForum?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
