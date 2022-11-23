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
    public class TaiKhoanController : Controller
    {
        private readonly QL_ThuVienContext _context;

        public TaiKhoanController(QL_ThuVienContext context)
        {
            _context = context;
        }

        // GET: Admin/TaiKhoan
        public async Task<IActionResult> Index()
        {
            ViewData["QuyenTruyCap"] = new SelectList(_context.TblQuyenHan, "InMaQuyenHan", "StTenQuyenHan");

            List<SelectListItem> lsTrangThai = new List<SelectListItem>();
            lsTrangThai.Add(new SelectListItem() { Text = "Đang hoạt động", Value = "1" });
            lsTrangThai.Add(new SelectListItem() { Text = "Khóa", Value = "0" });
            ViewData["lsTrangThai"] = lsTrangThai;

            var qL_ThuVienContext = _context.TblTaiKhoan.Include(t => t.InMaQuyenHanNavigation).Include(t => t.StMaSinhVienNavigation);
            return View(await qL_ThuVienContext.ToListAsync());
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

            return View(tblTaiKhoan);
        }

        // GET: Admin/TaiKhoan/Create
        public IActionResult Create()
        {
            ViewData["InMaQuyenHan"] = new SelectList(_context.TblQuyenHan, "InMaQuyenHan", "StGhiChu");
            ViewData["StMaSinhVien"] = new SelectList(_context.TblSinhVien, "StMaSinhVien", "StMaSinhVien");
            return View();
        }

        // POST: Admin/TaiKhoan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InMaTaiKhoan,StMaSinhVien,StMatKhau,InMaQuyenHan,BiTrangThai,DaNgayDangNhap,DaNgayTao")] TblTaiKhoan tblTaiKhoan)
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

        // GET: Admin/TaiKhoan/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        // POST: Admin/TaiKhoan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InMaTaiKhoan,StMaSinhVien,StMatKhau,InMaQuyenHan,BiTrangThai,DaNgayDangNhap,DaNgayTao")] TblTaiKhoan tblTaiKhoan)
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

        // POST: Admin/TaiKhoan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblTaiKhoan = await _context.TblTaiKhoan.FindAsync(id);
            _context.TblTaiKhoan.Remove(tblTaiKhoan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblTaiKhoanExists(int id)
        {
            return _context.TblTaiKhoan.Any(e => e.InMaTaiKhoan == id);
        }
    }
}
