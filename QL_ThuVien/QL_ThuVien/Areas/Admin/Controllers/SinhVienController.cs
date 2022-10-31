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
    public class SinhVienController : Controller
    {
        private readonly Ql_ThuVienContext _context;

        public SinhVienController(Ql_ThuVienContext context)
        {
            _context = context;
        }

        // GET: Admin/SinhVien
        public async Task<IActionResult> Index()
        {
            var ql_ThuVienContext = _context.TblSinhVien.Include(t => t.StMaKhoaNavigation).Include(t => t.StMaSinhVienNavigation);
            return View(await ql_ThuVienContext.ToListAsync());
        }

        // GET: Admin/SinhVien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSinhVien = await _context.TblSinhVien
                .Include(t => t.StMaKhoaNavigation)
                .Include(t => t.StMaSinhVienNavigation)
                .FirstOrDefaultAsync(m => m.StMaSinhVien == id);
            if (tblSinhVien == null)
            {
                return NotFound();
            }

            return View(tblSinhVien);
        }

        // GET: Admin/SinhVien/Create
        public IActionResult Create()
        {
            ViewData["StMaKhoa"] = new SelectList(_context.TblKhoa, "StMaKhoa", "StTenKhoa");
            ViewData["StMaSinhVien"] = new SelectList(_context.TblTaiKhoan, "StMaSinhVien", "StMatKhau");
            return View();
        }

        // POST: Admin/SinhVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StMaSinhVien,StTenSinhVien,StMaKhoa,InSoLanBiPhat,InSoDienThoai,StGmail,StSoDienThoai")] TblSinhVien tblSinhVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblSinhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StMaKhoa"] = new SelectList(_context.TblKhoa, "StMaKhoa", "StTenKhoa", tblSinhVien.StMaKhoa);
            ViewData["StMaSinhVien"] = new SelectList(_context.TblTaiKhoan, "StMaSinhVien", "StMatKhau", tblSinhVien.StMaSinhVien);
            return View(tblSinhVien);
        }

        // GET: Admin/SinhVien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSinhVien = await _context.TblSinhVien.FindAsync(id);
            if (tblSinhVien == null)
            {
                return NotFound();
            }
            ViewData["StMaKhoa"] = new SelectList(_context.TblKhoa, "StMaKhoa", "StTenKhoa", tblSinhVien.StMaKhoa);
            ViewData["StMaSinhVien"] = new SelectList(_context.TblTaiKhoan, "StMaSinhVien", "StMatKhau", tblSinhVien.StMaSinhVien);
            return View(tblSinhVien);
        }

        // POST: Admin/SinhVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StMaSinhVien,StTenSinhVien,StMaKhoa,InSoLanBiPhat,InSoDienThoai,StGmail,StSoDienThoai")] TblSinhVien tblSinhVien)
        {
            if (id != tblSinhVien.StMaSinhVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblSinhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblSinhVienExists(tblSinhVien.StMaSinhVien))
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
            ViewData["StMaKhoa"] = new SelectList(_context.TblKhoa, "StMaKhoa", "StTenKhoa", tblSinhVien.StMaKhoa);
            ViewData["StMaSinhVien"] = new SelectList(_context.TblTaiKhoan, "StMaSinhVien", "StMatKhau", tblSinhVien.StMaSinhVien);
            return View(tblSinhVien);
        }

        // GET: Admin/SinhVien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSinhVien = await _context.TblSinhVien
                .Include(t => t.StMaKhoaNavigation)
                .Include(t => t.StMaSinhVienNavigation)
                .FirstOrDefaultAsync(m => m.StMaSinhVien == id);
            if (tblSinhVien == null)
            {
                return NotFound();
            }

            return View(tblSinhVien);
        }

        // POST: Admin/SinhVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblSinhVien = await _context.TblSinhVien.FindAsync(id);
            _context.TblSinhVien.Remove(tblSinhVien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblSinhVienExists(int id)
        {
            return _context.TblSinhVien.Any(e => e.StMaSinhVien == id);
        }
    }
}
