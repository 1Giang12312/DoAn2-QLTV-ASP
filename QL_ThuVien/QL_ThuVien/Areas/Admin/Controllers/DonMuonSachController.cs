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
    public class DonMuonSachController : Controller
    {
        private readonly Ql_ThuVienContext _context;

        public DonMuonSachController(Ql_ThuVienContext context)
        {
            _context = context;
        }

        // GET: Admin/DonMuonSach
        public async Task<IActionResult> Index()
        {
            var ql_ThuVienContext = _context.TblDonMuonSach.Include(t => t.StMaSinhVienNavigation);
            return View(await ql_ThuVienContext.ToListAsync());
        }

        // GET: Admin/DonMuonSach/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDonMuonSach = await _context.TblDonMuonSach
                .Include(t => t.StMaSinhVienNavigation)
                .FirstOrDefaultAsync(m => m.StMaDonMuon == id);
            if (tblDonMuonSach == null)
            {
                return NotFound();
            }

            return View(tblDonMuonSach);
        }

        // GET: Admin/DonMuonSach/Create
        public IActionResult Create()
        {
            ViewData["StMaSinhVien"] = new SelectList(_context.TblSinhVien, "StMaSinhVien", "StGmail");
            return View();
        }

        // POST: Admin/DonMuonSach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StMaDonMuon,StMaSinhVien,StMaKhoa")] TblDonMuonSach tblDonMuonSach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblDonMuonSach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StMaSinhVien"] = new SelectList(_context.TblSinhVien, "StMaSinhVien", "StGmail", tblDonMuonSach.StMaSinhVien);
            return View(tblDonMuonSach);
        }

        // GET: Admin/DonMuonSach/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDonMuonSach = await _context.TblDonMuonSach.FindAsync(id);
            if (tblDonMuonSach == null)
            {
                return NotFound();
            }
            ViewData["StMaSinhVien"] = new SelectList(_context.TblSinhVien, "StMaSinhVien", "StGmail", tblDonMuonSach.StMaSinhVien);
            return View(tblDonMuonSach);
        }

        // POST: Admin/DonMuonSach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StMaDonMuon,StMaSinhVien,StMaKhoa")] TblDonMuonSach tblDonMuonSach)
        {
            if (id != tblDonMuonSach.StMaDonMuon)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblDonMuonSach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblDonMuonSachExists(tblDonMuonSach.StMaDonMuon))
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
            ViewData["StMaSinhVien"] = new SelectList(_context.TblSinhVien, "StMaSinhVien", "StGmail", tblDonMuonSach.StMaSinhVien);
            return View(tblDonMuonSach);
        }

        // GET: Admin/DonMuonSach/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDonMuonSach = await _context.TblDonMuonSach
                .Include(t => t.StMaSinhVienNavigation)
                .FirstOrDefaultAsync(m => m.StMaDonMuon == id);
            if (tblDonMuonSach == null)
            {
                return NotFound();
            }

            return View(tblDonMuonSach);
        }

        // POST: Admin/DonMuonSach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblDonMuonSach = await _context.TblDonMuonSach.FindAsync(id);
            _context.TblDonMuonSach.Remove(tblDonMuonSach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblDonMuonSachExists(int id)
        {
            return _context.TblDonMuonSach.Any(e => e.StMaDonMuon == id);
        }
    }
}
