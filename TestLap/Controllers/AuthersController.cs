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
    public class AuthersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Authers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Auther.ToListAsync());
        }

        // GET: Authers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auther = await _context.Auther
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auther == null)
            {
                return NotFound();
            }

            return View(auther);
        }

        // GET: Authers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Auther auther)
        {
            if (ModelState.IsValid)
            {
                auther.CreateAt = DateTime.Now;
                _context.Add(auther);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auther);
        }

        // GET: Authers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auther = await _context.Auther.FindAsync(id);
            if (auther == null)
            {
                return NotFound();
            }
            return View(auther);
        }

        // POST: Authers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Auther auther)
        {
            if (id != auther.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auther);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutherExists(auther.Id))
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
            return View(auther);
        }

        // GET: Authers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auther = await _context.Auther
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auther == null)
            {
                return NotFound();
            }

            return View(auther);
        }

        // POST: Authers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auther = await _context.Auther.FindAsync(id);
            _context.Auther.Remove(auther);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutherExists(int id)
        {
            return _context.Auther.Any(e => e.Id == id);
        }
    }
}
