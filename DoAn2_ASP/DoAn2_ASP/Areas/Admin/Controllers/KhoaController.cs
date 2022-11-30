using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAn2_ASP.Models;
using Microsoft.AspNetCore.Http;

namespace DoAn2_ASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KhoaController : Controller
    {
        private readonly QL_ThuVienContext _context;

        public KhoaController(QL_ThuVienContext context)
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
        // GET: Admin/Khoa
        public async Task<IActionResult> Index()
        {
            if (XacNhanRole() == true)
            {
                return View(await _context.TblKhoa.ToListAsync());
            }
            return NotFound();
            
        }

        // GET: Admin/Khoa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (XacNhanRole() == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblKhoa = await _context.TblKhoa
                    .FirstOrDefaultAsync(m => m.StMaKhoa == id);
                if (tblKhoa == null)
                {
                    return NotFound();
                }

                return View(tblKhoa);
            }
            return NotFound();
            
        }

        // GET: Admin/Khoa/Create
        public IActionResult Create()
        {
            if (XacNhanRole() == true)
            {
                return View();
            }
            return NotFound();
            
        }

        // POST: Admin/Khoa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StMaKhoa,StTenKhoa")] TblKhoa tblKhoa)
        {
            if (XacNhanRole() == true)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(tblKhoa);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(tblKhoa);
            }
            return NotFound();
            
        }

        // GET: Admin/Khoa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (XacNhanRole() == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblKhoa = await _context.TblKhoa.FindAsync(id);
                if (tblKhoa == null)
                {
                    return NotFound();
                }
                return View(tblKhoa);
            }
            return NotFound();
            
        }

        // POST: Admin/Khoa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StMaKhoa,StTenKhoa")] TblKhoa tblKhoa)
        {
            if (XacNhanRole() == true)
            {
                if (id != tblKhoa.StMaKhoa)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(tblKhoa);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TblKhoaExists(tblKhoa.StMaKhoa))
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
                return View(tblKhoa);
            }
            return NotFound();
            
        }

        // GET: Admin/Khoa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (XacNhanRole() == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblKhoa = await _context.TblKhoa
                    .FirstOrDefaultAsync(m => m.StMaKhoa == id);
                if (tblKhoa == null)
                {
                    return NotFound();
                }

                return View(tblKhoa);
            }
            return NotFound();
           
        }

        // POST: Admin/Khoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (XacNhanRole() == true)
            {
                var tblKhoa = await _context.TblKhoa.FindAsync(id);
                _context.TblKhoa.Remove(tblKhoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
            
        }

        private bool TblKhoaExists(int id)
        {
            return _context.TblKhoa.Any(e => e.StMaKhoa == id);
        }
    }
}
