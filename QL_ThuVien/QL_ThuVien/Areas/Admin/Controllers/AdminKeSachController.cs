using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QL_ThuVien.Models;

namespace QL_ThuVien.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminKeSachController : Controller
    {
        private readonly Ql_ThuVienContext _context;

        public AdminKeSachController(Ql_ThuVienContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminKeSach
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblKeSach.ToListAsync());
        }

        // GET: Admin/AdminKeSach/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblKeSach = await _context.TblKeSach
                .FirstOrDefaultAsync(m => m.StMaKeSach == id);
            if (tblKeSach == null)
            {
                return NotFound();
            }

            return View(tblKeSach);
        }

        // GET: Admin/AdminKeSach/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminKeSach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StMaKeSach,StTenKeSach")] TblKeSach tblKeSach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblKeSach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblKeSach);
        }

        // GET: Admin/AdminKeSach/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblKeSach = await _context.TblKeSach.FindAsync(id);
            if (tblKeSach == null)
            {
                return NotFound();
            }
            return View(tblKeSach);
        }

        // POST: Admin/AdminKeSach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StMaKeSach,StTenKeSach")] TblKeSach tblKeSach)
        {
            if (id != tblKeSach.StMaKeSach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblKeSach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblKeSachExists(tblKeSach.StMaKeSach))
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
            return View(tblKeSach);
        }

        // GET: Admin/AdminKeSach/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblKeSach = await _context.TblKeSach
                .FirstOrDefaultAsync(m => m.StMaKeSach == id);
            if (tblKeSach == null)
            {
                return NotFound();
            }

            return View(tblKeSach);
        }

        // POST: Admin/AdminKeSach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblKeSach = await _context.TblKeSach.FindAsync(id);
            _context.TblKeSach.Remove(tblKeSach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblKeSachExists(int id)
        {
            return _context.TblKeSach.Any(e => e.StMaKeSach == id);
        }
    }
}
