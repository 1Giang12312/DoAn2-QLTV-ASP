using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAn2_ASP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace DoAn2_ASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class TaiKhoanController : Controller
    {
        private readonly QL_ThuVienContext _context;

        public TaiKhoanController(QL_ThuVienContext context)
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

        // GET: Admin/TaiKhoan
        public async Task<IActionResult> Index()
        {
            if (XacNhanRole() == true)
            {
                var qL_ThuVienContext = _context.TblTaiKhoan.Include(t => t.InMaQuyenHanNavigation).Include(t => t.StMaSinhVienNavigation).ThenInclude(t=>t.StMaKhoaNavigation);
                return View(await qL_ThuVienContext.ToListAsync());
            }
            return NotFound();
        }

        // GET: Admin/TaiKhoan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTaiKhoan = await _context.TblTaiKhoan
                .Include(t => t.InMaQuyenHanNavigation)
                .Include(t => t.StMaSinhVienNavigation)
                .FirstOrDefaultAsync(m => m.InMaTaiKhoan == id);
            if (tblTaiKhoan == null)
            {
                return NotFound();
            }
            if (XacNhanRole() == true)
            {
                return View(tblTaiKhoan);
            }
            return NotFound();
        }

        // GET: Admin/TaiKhoan/Create
        public IActionResult Create()
        {
            if (XacNhanRole() == true)
            {
                ViewData["InMaQuyenHan"] = new SelectList(_context.TblQuyenHan, "InMaQuyenHan", "StGhiChu");
                ViewData["StMaSinhVien"] = new SelectList(_context.TblSinhVien, "StMaSinhVien", "StMaSinhVien");
                return View();
            }
            return NotFound();
            
        }

        // POST: Admin/TaiKhoan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InMaTaiKhoan,StMaSinhVien,StMatKhau,InMaQuyenHan,BiTrangThai,DaNgayDangNhap,DaNgayTao,StSalt")] TblTaiKhoan tblTaiKhoan)
        {
            if (XacNhanRole() == true)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(tblTaiKhoan);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["InMaQuyenHan"] = new SelectList(_context.TblQuyenHan, "InMaQuyenHan", "StGhiChu", tblTaiKhoan.InMaQuyenHan);
                ViewData["StMaSinhVien"] = new SelectList(_context.TblSinhVien, "StMaSinhVien", "StMaSinhVien", tblTaiKhoan.StMaSinhVien);
                return View(tblTaiKhoan);
            }
            return NotFound();
            
        }

        // GET: Admin/TaiKhoan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (XacNhanRole() == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblTaiKhoan = await _context.TblTaiKhoan.FindAsync(id);
                if (tblTaiKhoan == null)
                {
                    return NotFound();
                }
                ViewData["InMaQuyenHan"] = new SelectList(_context.TblQuyenHan, "InMaQuyenHan", "StGhiChu", tblTaiKhoan.InMaQuyenHan);
                ViewData["StMaSinhVien"] = new SelectList(_context.TblSinhVien, "StMaSinhVien", "StMaSinhVien", tblTaiKhoan.StMaSinhVien);
                return View(tblTaiKhoan);
            }
            return NotFound();
            
        }

        // POST: Admin/TaiKhoan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InMaTaiKhoan,StMaSinhVien,StMatKhau,InMaQuyenHan,BiTrangThai,DaNgayDangNhap,DaNgayTao,StSalt")] TblTaiKhoan tblTaiKhoan)
        {
            if (id != tblTaiKhoan.InMaTaiKhoan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblTaiKhoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblTaiKhoanExists(tblTaiKhoan.InMaTaiKhoan))
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
            ViewData["InMaQuyenHan"] = new SelectList(_context.TblQuyenHan, "InMaQuyenHan", "StGhiChu", tblTaiKhoan.InMaQuyenHan);
            ViewData["StMaSinhVien"] = new SelectList(_context.TblSinhVien, "StMaSinhVien", "StMaSinhVien", tblTaiKhoan.StMaSinhVien);
            return View(tblTaiKhoan);
        }

        // GET: Admin/TaiKhoan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (XacNhanRole() == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblTaiKhoan = await _context.TblTaiKhoan
                    .Include(t => t.InMaQuyenHanNavigation)
                    .Include(t => t.StMaSinhVienNavigation)
                    .FirstOrDefaultAsync(m => m.InMaTaiKhoan == id);
                if (tblTaiKhoan == null)
                {
                    return NotFound();
                }

                return View(tblTaiKhoan);
            }
            return NotFound();
            
        }

        // POST: Admin/TaiKhoan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (XacNhanRole() == true)
            {
                var tblTaiKhoan = await _context.TblTaiKhoan.FindAsync(id);
                _context.TblTaiKhoan.Remove(tblTaiKhoan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
            
        }

        private bool TblTaiKhoanExists(int id)
        {
            return _context.TblTaiKhoan.Any(e => e.InMaTaiKhoan == id);
        }
    }
}
