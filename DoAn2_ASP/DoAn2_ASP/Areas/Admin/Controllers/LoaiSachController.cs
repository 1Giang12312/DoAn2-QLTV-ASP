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
    public class LoaiSachController : Controller
    {
        private readonly QL_ThuVienContext _context;

        public LoaiSachController(QL_ThuVienContext context)
        {
            _context = context;
        }

        // GET: Admin/LoaiSach
        public bool XacNhanRole()
        {
            var taikhoanID = HttpContext.Session.GetString("StMaSinhVien");
            if (_context.TblTaiKhoan.Where(t => t.StMaSinhVien == taikhoanID).Where(b => b.InMaQuyenHan == 1).Count() > 0)
            {
                return true;
            }
            else return false;
        }
        public async Task<IActionResult> Index()
        {
            if (XacNhanRole() == true)
            {

                return View(await _context.TblLoaiSach.ToListAsync());
            }
            return NotFound();
        }
        
        // GET: Admin/LoaiSach/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (XacNhanRole() == true)
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
            return NotFound();

            
        }

        // GET: Admin/LoaiSach/Create
        public IActionResult Create()
        {
            if (XacNhanRole() == true)
            {
                return View();
            }
            return NotFound();

            
        }

        // POST: Admin/LoaiSach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StMaLoaiSach,StTenSach")] TblLoaiSach tblLoaiSach)
        {
            if (XacNhanRole() == true)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(tblLoaiSach);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(tblLoaiSach);
            }
            return NotFound();

            
        }

        // GET: Admin/LoaiSach/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (XacNhanRole() == true)
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
            return NotFound();

            
        }

        // POST: Admin/LoaiSach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StMaLoaiSach,StTenSach")] TblLoaiSach tblLoaiSach)
        {
            if (XacNhanRole() == true)
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
            return NotFound();

            
        }

        // GET: Admin/LoaiSach/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (XacNhanRole() == true)
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
            return NotFound();

            
        }

        // POST: Admin/LoaiSach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (XacNhanRole() == true)
            {
                var tblLoaiSach = await _context.TblLoaiSach.FindAsync(id);
                _context.TblLoaiSach.Remove(tblLoaiSach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();

            
        }

        private bool TblLoaiSachExists(int id)
        {
            return _context.TblLoaiSach.Any(e => e.StMaLoaiSach == id);
        }
    }
}
