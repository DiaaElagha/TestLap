using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestLap.Data;
using TestLap.Models;

namespace TestLap.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AutherBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AutherBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AutherBooks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AutherBook.Include(a => a.Auther).Include(a => a.Book);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AutherBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autherBook = await _context.AutherBook
                .Include(a => a.Auther)
                .Include(a => a.Book)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autherBook == null)
            {
                return NotFound();
            }

            return View(autherBook);
        }

        // GET: AutherBooks/Create
        public IActionResult Create()
        {
            ViewData["AutherId"] = new SelectList(_context.Auther, "Id", "Name");
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Name");
            return View();
        }

        // POST: AutherBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AutherId,BookId")] AutherBook autherBook)
        {
            if (ModelState.IsValid)
            {
                autherBook.CreateAt = DateTime.Now;
                _context.Add(autherBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutherId"] = new SelectList(_context.Auther, "Id", "Name", autherBook.AutherId);
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Des", autherBook.BookId);
            return View(autherBook);
        }

        // GET: AutherBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autherBook = await _context.AutherBook.FindAsync(id);
            if (autherBook == null)
            {
                return NotFound();
            }
            ViewData["AutherId"] = new SelectList(_context.Auther, "Id", "Name", autherBook.AutherId);
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Des", autherBook.BookId);
            return View(autherBook);
        }

        // POST: AutherBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AutherId,BookId")] AutherBook autherBook)
        {
            if (id != autherBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autherBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutherBookExists(autherBook.Id))
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
            ViewData["AutherId"] = new SelectList(_context.Auther, "Id", "Name", autherBook.AutherId);
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Des", autherBook.BookId);
            return View(autherBook);
        }

        // GET: AutherBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autherBook = await _context.AutherBook
                .Include(a => a.Auther)
                .Include(a => a.Book)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autherBook == null)
            {
                return NotFound();
            }

            return View(autherBook);
        }

        // POST: AutherBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autherBook = await _context.AutherBook.FindAsync(id);
            _context.AutherBook.Remove(autherBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutherBookExists(int id)
        {
            return _context.AutherBook.Any(e => e.Id == id);
        }
    }
}
