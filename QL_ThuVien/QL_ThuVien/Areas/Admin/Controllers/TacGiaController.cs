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
    public class TacGiaController : Controller
    {
        private readonly Ql_ThuVienContext _context;

        public TacGiaController(Ql_ThuVienContext context)
        {
            _context = context;
        }

        // GET: Admin/TacGia
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblTacGia.ToListAsync());
        }

        // GET: Admin/TacGia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTacGia = await _context.TblTacGia
                .FirstOrDefaultAsync(m => m.StMaTacGia == id);
            if (tblTacGia == null)
            {
                return NotFound();
            }

            return View(tblTacGia);
        }

        // GET: Admin/TacGia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TacGia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StMaTacGia,StTenTacGia")] TblTacGia tblTacGia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblTacGia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblTacGia);
        }

        // GET: Admin/TacGia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTacGia = await _context.TblTacGia.FindAsync(id);
            if (tblTacGia == null)
            {
                return NotFound();
            }
            return View(tblTacGia);
        }

        // POST: Admin/TacGia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StMaTacGia,StTenTacGia")] TblTacGia tblTacGia)
        {
            if (id != tblTacGia.StMaTacGia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblTacGia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblTacGiaExists(tblTacGia.StMaTacGia))
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
            return View(tblTacGia);
        }

        // GET: Admin/TacGia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTacGia = await _context.TblTacGia
                .FirstOrDefaultAsync(m => m.StMaTacGia == id);
            if (tblTacGia == null)
            {
                return NotFound();
            }

            return View(tblTacGia);
        }

        // POST: Admin/TacGia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblTacGia = await _context.TblTacGia.FindAsync(id);
            _context.TblTacGia.Remove(tblTacGia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblTacGiaExists(int id)
        {
            return _context.TblTacGia.Any(e => e.StMaTacGia == id);
        }
    }
}
