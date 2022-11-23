using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAn2_ASP.Models;

namespace DoAn2_ASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KhoaController : Controller
    {
        private readonly QL_ThuVienContext _context;

        public KhoaController(QL_ThuVienContext context)
        {
            _context = context;
        }

        // GET: Admin/Khoa
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblKhoa.ToListAsync());
        }

        // GET: Admin/Khoa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblKhoa = await _context.TblKhoa
                .FirstOrDefaultAsync(m => m.StMaKhoa == id);
            if (tblKhoa == null)
            {
                return NotFound();
            }

            return View(tblKhoa);
        }

        // GET: Admin/Khoa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Khoa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StMaKhoa,StTenKhoa")] TblKhoa tblKhoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblKhoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblKhoa);
        }

        // GET: Admin/Khoa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblKhoa = await _context.TblKhoa.FindAsync(id);
            if (tblKhoa == null)
            {
                return NotFound();
            }
            return View(tblKhoa);
        }

        // POST: Admin/Khoa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StMaKhoa,StTenKhoa")] TblKhoa tblKhoa)
        {
            if (id != tblKhoa.StMaKhoa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblKhoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblKhoaExists(tblKhoa.StMaKhoa))
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
            return View(tblKhoa);
        }

        // GET: Admin/Khoa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblKhoa = await _context.TblKhoa
                .FirstOrDefaultAsync(m => m.StMaKhoa == id);
            if (tblKhoa == null)
            {
                return NotFound();
            }

            return View(tblKhoa);
        }

        // POST: Admin/Khoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblKhoa = await _context.TblKhoa.FindAsync(id);
            _context.TblKhoa.Remove(tblKhoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblKhoaExists(int id)
        {
            return _context.TblKhoa.Any(e => e.StMaKhoa == id);
        }
    }
}
