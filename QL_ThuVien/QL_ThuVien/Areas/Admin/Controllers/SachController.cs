using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QL_ThuVien.Models;

namespace QL_ThuVien.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SachController : Controller
    {
        private readonly Ql_ThuVienContext _context;

        public SachController(Ql_ThuVienContext context)
        {
            _context = context;
        }

        // GET: Admin/Sach
        public async Task<IActionResult> Index()
        {
            var ql_ThuVienContext = _context.TblSach.Include(t => t.StMaKeSachNavigation).Include(t => t.StMaLoaiSachNavigation).Include(t => t.StMaTacGiaNavigation);
            return View(await ql_ThuVienContext.ToListAsync());
        }

        // GET: Admin/Sach/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSach = await _context.TblSach
                .Include(t => t.StMaKeSachNavigation)
                .Include(t => t.StMaLoaiSachNavigation)
                .Include(t => t.StMaTacGiaNavigation)
                .FirstOrDefaultAsync(m => m.StMaSach == id);
            if (tblSach == null)
            {
                return NotFound();
            }

            return View(tblSach);
        }

        // GET: Admin/Sach/Create
        public IActionResult Create()
        {
            ViewData["StMaKeSach"] = new SelectList(_context.TblKeSach, "StMaKeSach", "StTenKeSach");
            ViewData["StMaLoaiSach"] = new SelectList(_context.TblLoaiSach, "StMaLoaiSach", "StTenSach");
            ViewData["StMaTacGia"] = new SelectList(_context.TblTacGia, "StMaTacGia", "StTenTacGia");
            return View();
        }

        // POST: Admin/Sach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file,[Bind("StMaSach,StTenSach,StMaLoaiSach,StMaTacGia,StMaKeSach,StTomTat,StTinhTrang,StAnh,InSoLuong")] TblSach tblSach)
        {
            if (ModelState.IsValid)
            {
                tblSach.StAnh = Upload(file);
                _context.Add(tblSach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StMaKeSach"] = new SelectList(_context.TblKeSach, "StMaKeSach", "StTenKeSach", tblSach.StMaKeSach);
            ViewData["StMaLoaiSach"] = new SelectList(_context.TblLoaiSach, "StMaLoaiSach", "StTenSach", tblSach.StMaLoaiSach);
            ViewData["StMaTacGia"] = new SelectList(_context.TblTacGia, "StMaTacGia", "StTenTacGia", tblSach.StMaTacGia);
            return View(tblSach);
        }

        // GET: Admin/Sach/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSach = await _context.TblSach.FindAsync(id);
            if (tblSach == null)
            {
                return NotFound();
            }
            ViewData["StMaKeSach"] = new SelectList(_context.TblKeSach, "StMaKeSach", "StTenKeSach", tblSach.StMaKeSach);
            ViewData["StMaLoaiSach"] = new SelectList(_context.TblLoaiSach, "StMaLoaiSach", "StTenSach", tblSach.StMaLoaiSach);
            ViewData["StMaTacGia"] = new SelectList(_context.TblTacGia, "StMaTacGia", "StTenTacGia", tblSach.StMaTacGia);
            return View(tblSach);
        }

        // POST: Admin/Sach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StMaSach,StTenSach,StMaLoaiSach,StMaTacGia,StMaKeSach,StTomTat,StTinhTrang,StAnh,InSoLuong")] TblSach tblSach)
        {
            if (id != tblSach.StMaSach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblSach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblSachExists(tblSach.StMaSach))
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
            ViewData["StMaKeSach"] = new SelectList(_context.TblKeSach, "StMaKeSach", "StTenKeSach", tblSach.StMaKeSach);
            ViewData["StMaLoaiSach"] = new SelectList(_context.TblLoaiSach, "StMaLoaiSach", "StTenSach", tblSach.StMaLoaiSach);
            ViewData["StMaTacGia"] = new SelectList(_context.TblTacGia, "StMaTacGia", "StTenTacGia", tblSach.StMaTacGia);
            return View(tblSach);
        }

        // GET: Admin/Sach/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSach = await _context.TblSach
                .Include(t => t.StMaKeSachNavigation)
                .Include(t => t.StMaLoaiSachNavigation)
                .Include(t => t.StMaTacGiaNavigation)
                .FirstOrDefaultAsync(m => m.StMaSach == id);
            if (tblSach == null)
            {
                return NotFound();
            }

            return View(tblSach);
        }

        // POST: Admin/Sach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblSach = await _context.TblSach.FindAsync(id);
            _context.TblSach.Remove(tblSach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblSachExists(int id)
        {
            return _context.TblSach.Any(e => e.StMaSach == id);
        }
        public string Upload(IFormFile file)
        {
            string fn = null;

            if (file != null)
            {
                fn = Guid.NewGuid().ToString() + "_" + file.FileName;
                var path = $"wwwroot\\image\\{fn}";
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            return fn;
        }
    }
}
