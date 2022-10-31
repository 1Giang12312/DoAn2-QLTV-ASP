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
    public class ChiTietDonMuonController : Controller
    {
        private readonly Ql_ThuVienContext _context;

        public ChiTietDonMuonController(Ql_ThuVienContext context)
        {
            _context = context;
        }

        // GET: Admin/ChiTietDonMuon
        public async Task<IActionResult> Index()
        {
            var ql_ThuVienContext = _context.TblChiTietDonMuon.Include(t => t.StMaDonMuonNavigation).Include(t => t.StMaSachNavigation);
            return View(await ql_ThuVienContext.ToListAsync());
        }

        // GET: Admin/ChiTietDonMuon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblChiTietDonMuon = await _context.TblChiTietDonMuon
                .Include(t => t.StMaDonMuonNavigation)
                .Include(t => t.StMaSachNavigation)
                .FirstOrDefaultAsync(m => m.StMaDonMuon == id);
            if (tblChiTietDonMuon == null)
            {
                return NotFound();
            }

            return View(tblChiTietDonMuon);
        }

        // GET: Admin/ChiTietDonMuon/Create
        public IActionResult Create()
        {
            ViewData["StMaDonMuon"] = new SelectList(_context.TblDonMuonSach, "StMaDonMuon", "StMaKhoa");
            ViewData["StMaSach"] = new SelectList(_context.TblSach, "StMaSach", "StTenSach");
            return View();
        }

        // POST: Admin/ChiTietDonMuon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StMaDonMuon,StMaSach,InSoLuong,DaNgayMuon,DaNgayTra")] TblChiTietDonMuon tblChiTietDonMuon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblChiTietDonMuon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StMaDonMuon"] = new SelectList(_context.TblDonMuonSach, "StMaDonMuon", "StMaKhoa", tblChiTietDonMuon.StMaDonMuon);
            ViewData["StMaSach"] = new SelectList(_context.TblSach, "StMaSach", "StTenSach", tblChiTietDonMuon.StMaSach);
            return View(tblChiTietDonMuon);
        }

        // GET: Admin/ChiTietDonMuon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblChiTietDonMuon = await _context.TblChiTietDonMuon.FindAsync(id);
            if (tblChiTietDonMuon == null)
            {
                return NotFound();
            }
            ViewData["StMaDonMuon"] = new SelectList(_context.TblDonMuonSach, "StMaDonMuon", "StMaKhoa", tblChiTietDonMuon.StMaDonMuon);
            ViewData["StMaSach"] = new SelectList(_context.TblSach, "StMaSach", "StTenSach", tblChiTietDonMuon.StMaSach);
            return View(tblChiTietDonMuon);
        }

        // POST: Admin/ChiTietDonMuon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StMaDonMuon,StMaSach,InSoLuong,DaNgayMuon,DaNgayTra")] TblChiTietDonMuon tblChiTietDonMuon)
        {
            if (id != tblChiTietDonMuon.StMaDonMuon)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblChiTietDonMuon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblChiTietDonMuonExists(tblChiTietDonMuon.StMaDonMuon))
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
            ViewData["StMaDonMuon"] = new SelectList(_context.TblDonMuonSach, "StMaDonMuon", "StMaKhoa", tblChiTietDonMuon.StMaDonMuon);
            ViewData["StMaSach"] = new SelectList(_context.TblSach, "StMaSach", "StTenSach", tblChiTietDonMuon.StMaSach);
            return View(tblChiTietDonMuon);
        }

        // GET: Admin/ChiTietDonMuon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblChiTietDonMuon = await _context.TblChiTietDonMuon
                .Include(t => t.StMaDonMuonNavigation)
                .Include(t => t.StMaSachNavigation)
                .FirstOrDefaultAsync(m => m.StMaDonMuon == id);
            if (tblChiTietDonMuon == null)
            {
                return NotFound();
            }

            return View(tblChiTietDonMuon);
        }

        // POST: Admin/ChiTietDonMuon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblChiTietDonMuon = await _context.TblChiTietDonMuon.FindAsync(id);
            _context.TblChiTietDonMuon.Remove(tblChiTietDonMuon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblChiTietDonMuonExists(int id)
        {
            return _context.TblChiTietDonMuon.Any(e => e.StMaDonMuon == id);
        }
    }
}
