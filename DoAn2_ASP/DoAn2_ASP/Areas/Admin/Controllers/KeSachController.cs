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
    public class KeSachController : Controller
    {
        private readonly QL_ThuVienContext _context;

        public KeSachController(QL_ThuVienContext context)
        {
            _context = context;
        }

        // GET: Admin/KeSach
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
                return View(await _context.TblKeSach.ToListAsync());
            }
            return NotFound();
            
        }

        // GET: Admin/KeSach/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (XacNhanRole() == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblKeSach = await _context.TblKeSach
                    .FirstOrDefaultAsync(m => m.StMaKeSach == id);
                if (tblKeSach == null)
                {
                    return NotFound();
                }

                return View(tblKeSach);
            }
            return NotFound();
           
        }

        // GET: Admin/KeSach/Create
        public IActionResult Create()
        {
            if (XacNhanRole() == true)
            {
                return View();
            }
            return NotFound();
            
        }

        // POST: Admin/KeSach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StMaKeSach,StTenKeSach")] TblKeSach tblKeSach)
        {
            if (XacNhanRole() == true)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(tblKeSach);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(tblKeSach);
            }
            return NotFound();
           
        }

        // GET: Admin/KeSach/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (XacNhanRole() == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblKeSach = await _context.TblKeSach.FindAsync(id);
                if (tblKeSach == null)
                {
                    return NotFound();
                }
                return View(tblKeSach);
            }
            return NotFound();
            
        }

        // POST: Admin/KeSach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StMaKeSach,StTenKeSach")] TblKeSach tblKeSach)
        {
            if (XacNhanRole() == true)
            {
                if (id != tblKeSach.StMaKeSach)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(tblKeSach);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TblKeSachExists(tblKeSach.StMaKeSach))
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
                return View(tblKeSach);
            }
            return NotFound();
            
        }

        // GET: Admin/KeSach/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (XacNhanRole() == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblKeSach = await _context.TblKeSach
                    .FirstOrDefaultAsync(m => m.StMaKeSach == id);
                if (tblKeSach == null)
                {
                    return NotFound();
                }

                return View(tblKeSach);
            }
            return NotFound();
            
        }

        // POST: Admin/KeSach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (XacNhanRole() == true)
            {
                var tblKeSach = await _context.TblKeSach.FindAsync(id);
                _context.TblKeSach.Remove(tblKeSach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
            
        }

        private bool TblKeSachExists(int id)
        {
            return _context.TblKeSach.Any(e => e.StMaKeSach == id);
        }
    }
}
