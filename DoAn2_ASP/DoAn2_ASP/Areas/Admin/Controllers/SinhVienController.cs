using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAn2_ASP.Models;
using PagedList.Core;
using Microsoft.AspNetCore.Http;

namespace DoAn2_ASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SinhVienController : Controller
    {
        private readonly QL_ThuVienContext _context;

        public SinhVienController(QL_ThuVienContext context)
        {
            _context = context;
        }
        public bool XacNhanRole()
        {
            var taikhoanID = HttpContext.Session.GetString("StMaSinhVien");
            if (_context.TblTaiKhoan.Where(t => t.StMaSinhVien == taikhoanID).Where(b => b.InMaQuyenHan == 1).Count() > 0)
            {
                return true;
            }
            else return false;
        }
        // GET: Admin/SinhVien
        public IActionResult Index(int? page)
        {
            if (XacNhanRole() == true)
            {
                var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                var pageSize = 20;
                var lsSinhVien = _context.TblSinhVien.AsNoTracking().Include(x => x.StMaKhoaNavigation).OrderByDescending(x => x.StMaSinhVien);
                PagedList<TblSinhVien> models = new PagedList<TblSinhVien>(lsSinhVien, pageNumber, pageSize);
                ViewBag.CurrentPage = pageNumber;
                return View(models);
            }
            return NotFound();
            
        }

        // GET: Admin/SinhVien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (XacNhanRole() == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblSinhVien = await _context.TblSinhVien
                    .Include(t => t.StMaKhoaNavigation)
                    .FirstOrDefaultAsync(m => m.StMaSinhVien == id);
                if (tblSinhVien == null)
                {
                    return NotFound();
                }

                return View(tblSinhVien);
            }
            return NotFound();
            
        }

        // GET: Admin/SinhVien/Create
        public IActionResult Create()
        {
            if (XacNhanRole() == true)
            {
                ViewData["StMaKhoa"] = new SelectList(_context.TblKhoa, "StMaKhoa", "StTenKhoa");
                return View();
            }
            return NotFound();
            
        }

        // POST: Admin/SinhVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StMaSinhVien,StTenSinhVien,StMaKhoa,InSoLanBiPhat,InSoDienThoai,StGmail,StSoDienThoai")] TblSinhVien tblSinhVien)
        {
            if (XacNhanRole() == true)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(tblSinhVien);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["StMaKhoa"] = new SelectList(_context.TblKhoa, "StMaKhoa", "StTenKhoa", tblSinhVien.StMaKhoa);
                return View(tblSinhVien);
            }
            return NotFound();
            
        }

        // GET: Admin/SinhVien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (XacNhanRole() == true)
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
                return View(tblSinhVien);
            }
            return NotFound();
            
        }

        // POST: Admin/SinhVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StMaSinhVien,StTenSinhVien,StMaKhoa,InSoLanBiPhat,InSoDienThoai,StGmail,StSoDienThoai")] TblSinhVien tblSinhVien)
        {
            if (XacNhanRole() == true)
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
                return View(tblSinhVien);
            }
            return NotFound();
            
        }

        // GET: Admin/SinhVien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (XacNhanRole() == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblSinhVien = await _context.TblSinhVien
                    .Include(t => t.StMaKhoaNavigation)
                    .FirstOrDefaultAsync(m => m.StMaSinhVien == id);
                if (tblSinhVien == null)
                {
                    return NotFound();
                }

                return View(tblSinhVien);
            }
            return NotFound();
            
        }

        // POST: Admin/SinhVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (XacNhanRole() == true)
            {
                var tblSinhVien = await _context.TblSinhVien.FindAsync(id);
                _context.TblSinhVien.Remove(tblSinhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
            
        }

        private bool TblSinhVienExists(string id)
        {
            return _context.TblSinhVien.Any(e => e.StMaSinhVien == id);
        }
    }
}
