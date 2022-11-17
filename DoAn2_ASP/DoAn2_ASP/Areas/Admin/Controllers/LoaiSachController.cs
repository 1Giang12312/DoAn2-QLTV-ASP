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
    public class LoaiSachController : Controller
    {
        private readonly QL_ThuVienContext _context;

        public LoaiSachController(QL_ThuVienContext context)
        {
            _context = context;
        }

        // GET: Admin/LoaiSach
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblLoaiSach.ToListAsync());
        }

        // GET: Admin/LoaiSach/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLoaiSach = await _context.TblLoaiSach
                .FirstOrDefaultAsync(m => m.StMaLoaiSach == id);
            if (tblLoaiSach == null)
            {
                return NotFound();
            }

            return View(tblLoaiSach);
        }

        // GET: Admin/LoaiSach/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiSach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StMaLoaiSach,StTenSach")] TblLoaiSach tblLoaiSach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblLoaiSach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblLoaiSach);
        }

        // GET: Admin/LoaiSach/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLoaiSach = await _context.TblLoaiSach.FindAsync(id);
            if (tblLoaiSach == null)
            {
                return NotFound();
            }
            return View(tblLoaiSach);
        }

        // POST: Admin/LoaiSach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StMaLoaiSach,StTenSach")] TblLoaiSach tblLoaiSach)
        {
            if (id != tblLoaiSach.StMaLoaiSach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblLoaiSach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblLoaiSachExists(tblLoaiSach.StMaLoaiSach))
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
            return View(tblLoaiSach);
        }

        // GET: Admin/LoaiSach/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLoaiSach = await _context.TblLoaiSach
                .FirstOrDefaultAsync(m => m.StMaLoaiSach == id);
            if (tblLoaiSach == null)
            {
                return NotFound();
            }

            return View(tblLoaiSach);
        }

        // POST: Admin/LoaiSach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblLoaiSach = await _context.TblLoaiSach.FindAsync(id);
            _context.TblLoaiSach.Remove(tblLoaiSach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblLoaiSachExists(int id)
        {
            return _context.TblLoaiSach.Any(e => e.StMaLoaiSach == id);
        }
    }
}
