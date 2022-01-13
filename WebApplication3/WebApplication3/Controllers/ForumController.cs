using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace WebApplication3.Controllers
{
    public class ForumController : Controller
    {
        private readonly WebApplication3Context _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ForumController(WebApplication3Context context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Forum
        public async Task<IActionResult> Index()
        {
            var webApplication3Context = _context.Forums.Include(f => f.PostCreator);
            return View(await webApplication3Context.ToListAsync());
        }
        public async Task<List<Forum>> Edit(int id, bool like)
    {
            var forum = await _context.Forums.FindAsync(id);
            if (like)
            {
                forum.Likes++;
            }
            else
            {
                forum.Dislikes++;
            }
            _context.Update(forum);
            await _context.SaveChangesAsync();
            return _context.Forums.ToList();
    }

        // GET: Forum/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forum = await _context.Forums
                .Include(f => f.PostCreator)
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
            ViewData["PostCreatorId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: Forum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PostCreatorId,Likes,Dislikes,Title,Post,Comment")] Forum forum)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);  // will give the user's userId
            forum.PostCreatorId = userId;
            if (ModelState.IsValid)
            {
                _context.Add(forum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(forum);
        }

        // GET: Forum/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = await _context.Forums.FindAsync(id);
            var poster = post.PostCreatorId;
            string strPoster = poster.ToString();
            var userName = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

            while (userName != strPoster)
            {
                return NotFound();
            }
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Forum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PostCreatorId,Likes,Dislikes,Title,Post,Comment")] Forum forum)
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
            ViewData["PostCreatorId"] = new SelectList(_context.AspNetUsers, "Id", "Id", forum.PostCreatorId);
            return View(forum);
        }

        // GET: Forum/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Forums
                .FirstOrDefaultAsync(m => m.Id == id);
            var posterId = post.PostCreatorId;
            string strPosterId = posterId.ToString();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            while (userId != strPosterId)
            {
                return NotFound();
            }
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Forum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var forum = await _context.Forums.FindAsync(id);
            _context.Forums.Remove(forum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForumExists(int id)
        {
            return _context.Forums.Any(e => e.Id == id);
        }

    }
}
