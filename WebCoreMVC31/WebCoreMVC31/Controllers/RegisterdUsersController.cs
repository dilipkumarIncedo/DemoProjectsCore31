using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCoreMVC31.Models;

namespace WebCoreMVC31.Controllers
{
    public class RegisterdUsersController : Controller
    {
        private readonly Coredb31Context _context;

        public RegisterdUsersController(Coredb31Context context)
        {
            _context = context;
        }

        // GET: RegisterdUsers
        public async Task<IActionResult> Index()
        {
            var coredb31Context = _context.RegisterdUsers.Include(r => r.Role).Include(r => r.User);
            return View(await coredb31Context.ToListAsync());
        }

        // GET: RegisterdUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerdUser = await _context.RegisterdUsers
                .Include(r => r.Role)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registerdUser == null)
            {
                return NotFound();
            }

            return View(registerdUser);
        }

        // GET: RegisterdUsers/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "RoleName");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: RegisterdUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,RoleId")] RegisterdUser registerdUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registerdUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "RoleName", registerdUser.RoleId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", registerdUser.UserId);
            return View(registerdUser);
        }

        // GET: RegisterdUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerdUser = await _context.RegisterdUsers.FindAsync(id);
            if (registerdUser == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "RoleName", registerdUser.RoleId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", registerdUser.UserId);
            return View(registerdUser);
        }

        // POST: RegisterdUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,RoleId")] RegisterdUser registerdUser)
        {
            if (id != registerdUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registerdUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterdUserExists(registerdUser.Id))
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
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "RoleName", registerdUser.RoleId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", registerdUser.UserId);
            return View(registerdUser);
        }

        // GET: RegisterdUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerdUser = await _context.RegisterdUsers
                .Include(r => r.Role)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registerdUser == null)
            {
                return NotFound();
            }

            return View(registerdUser);
        }

        // POST: RegisterdUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registerdUser = await _context.RegisterdUsers.FindAsync(id);
            _context.RegisterdUsers.Remove(registerdUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterdUserExists(int id)
        {
            return _context.RegisterdUsers.Any(e => e.Id == id);
        }
    }
}
