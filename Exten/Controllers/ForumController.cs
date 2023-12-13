using Exten.Models;
using Exten.Models.Data;
using Exten.ViewModels.Forum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Exten.Controllers
{
    public class ForumController : Controller
    {
        private readonly AppCtx _context;

        public ForumController(AppCtx context)
        {
            _context = context;
        }

        // GET: Forum
        public async Task<IActionResult> Index()
        {
            var appCtx = _context.Forums
                .Include(a => a.CategoriesForum)
                .Include(a => a.User)
                .OrderBy(o => o.ForumTopic);

            return _context.Forums != null ?
                          View(await appCtx.ToListAsync()) :
                          Problem("Entity set 'AppCtx.Forums'  is null.");
        }

        // GET: Forum/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null || _context.Forums == null)
            {
                return NotFound();
            }

            var forum = await _context.Forums
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (forum == null)
            {
                return NotFound();
            }

            return View(forum);
        }

        // GET: Forum/Create
        public IActionResult Create()
        {
            ViewData["IdCategoryForum"] = new SelectList(_context.CategoriesForum.OrderBy(o => o.ForumCategoryName), "Id", "ForumCategoryName");
          
            ViewData["IdUser"] = new SelectList(_context.Users.OrderBy(o => o.Email), "Id", "Email");
            return View();
        }

        // POST: AnimeTitles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateForumViewModel model)
        {
            if (_context.Forums
                .Where(f => f.ForumTopic == model.ForumTopic &&
                    f.ForumMessage == model.ForumMessage &&
                    f.DateCreation == model.DateCreation &&
                    f.IdCategoryForum == model.IdCategoryForum &&
                    f.IdUser == model.IdUser)
                .FirstOrDefault() != null)
            {
                ModelState.AddModelError("", "Введеный товар уже существует");
            }

            if (ModelState.IsValid)
            {
                Forum forum = new()
                {
                    ForumTopic = model.ForumTopic,
                    ForumMessage = model.ForumMessage,
                    DateCreation = model.DateCreation,
                    IdCategoryForum = model.IdCategoryForum,
                    IdUser = model.IdUser
                };

                _context.Add(forum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdCategoryForum"] = new SelectList(_context.CategoriesProduct.OrderBy(o => o.CategoryName), "Id", "ForumCategoryName");

            ViewData["IdUser"] = new SelectList(_context.User.OrderBy(o => o.IdUser), "Id", "IdUser");
            return View(model);
        }
            // GET: Forum/Edit/5
            public async Task<IActionResult> Edit(short? id)
        {
            if (id == null || _context.Forums == null)
            {
                return NotFound();
            }

            var forum = await _context.Forums.FindAsync(id);
            if (forum == null)
            {
                return NotFound();
            }
            ViewData["IdUser"] = new SelectList(_context.Users, "Id", "Id", forum.IdUser);
            return View(forum);
        }

        // POST: Forum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("Id,ProductName,PriceProduct,RegistrationDate,IdCategoryProduct,IdUser")] Forum forum)
        {
            if (id != forum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForumExists(forum.Id))
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
            ViewData["IdUser"] = new SelectList(_context.Users, "Id", "Id", forum.IdUser);
            return View(forum);
        }

        // GET: Forum/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null || _context.Forums == null)
            {
                return NotFound();
            }

            var forum = await _context.Forums
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (forum == null)
            {
                return NotFound();
            }

            return View(forum);
        }

        // POST: Forum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            if (_context.Forums == null)
            {
                return Problem("Entity set 'AppCtx.Forum'  is null.");
            }
            var forum = await _context.Forums.FindAsync(id);
            if (forum != null)
            {
                _context.Forums.Remove(forum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForumExists(short id)
        {
          return (_context.Forums?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
