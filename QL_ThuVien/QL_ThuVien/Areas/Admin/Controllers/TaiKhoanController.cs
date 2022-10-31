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
    public class TaiKhoanController : Controller
    {
        private readonly Ql_ThuVienContext _context;

        public TaiKhoanController(Ql_ThuVienContext context)
        {
            _context = context;
        }

        // GET: Admin/TaiKhoan
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblTaiKhoan.ToListAsync());
        }

        // GET: Admin/TaiKhoan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTaiKhoan = await _context.TblTaiKhoan
                .FirstOrDefaultAsync(m => m.StMaSinhVien == id);
            if (tblTaiKhoan == null)
            {
                return NotFound();
            }

            return View(tblTaiKhoan);
        }

        // GET: Admin/TaiKhoan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TaiKhoan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StMaSinhVien,StMatKhau,StQuyenHan,BiTrangThai,DaNgayDangNhap,DaNgayTao")] TblTaiKhoan tblTaiKhoan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblTaiKhoan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(tblTaiKhoan);
        }

        // POST: Admin/TaiKhoan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StMaSinhVien,StMatKhau,StQuyenHan,BiTrangThai,DaNgayDangNhap,DaNgayTao")] TblTaiKhoan tblTaiKhoan)
        {
            if (id != tblTaiKhoan.StMaSinhVien)
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
                    if (!TblTaiKhoanExists(tblTaiKhoan.StMaSinhVien))
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
                .FirstOrDefaultAsync(m => m.StMaSinhVien == id);
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
            return _context.TblTaiKhoan.Any(e => e.StMaSinhVien == id);
        }
    }
}
