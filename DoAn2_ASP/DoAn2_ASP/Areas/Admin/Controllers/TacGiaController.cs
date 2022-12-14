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
    public class TacGiaController : Controller
    {
        private readonly QL_ThuVienContext _context;
        
        public TacGiaController(QL_ThuVienContext context)
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
        // GET: Admin/TacGia
        public async Task<IActionResult> Index()
        {
            if (XacNhanRole() == true)
            {
                return View(await _context.TblTacGia.ToListAsync());
            }
            return NotFound();
            
        }

        // GET: Admin/TacGia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (XacNhanRole() == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblTacGia = await _context.TblTacGia
                    .FirstOrDefaultAsync(m => m.StMaTacGia == id);
                if (tblTacGia == null)
                {
                    return NotFound();
                }

                return View(tblTacGia);
            }
            return NotFound();
           
        }

        // GET: Admin/TacGia/Create
        public IActionResult Create()
        {
            if (XacNhanRole() == true)
            {
                return View();
            }
            return NotFound();
            
        }

        // POST: Admin/TacGia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StMaTacGia,StTenTacGia")] TblTacGia tblTacGia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblTacGia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblTacGia);
        }

        // GET: Admin/TacGia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (XacNhanRole() == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblTacGia = await _context.TblTacGia.FindAsync(id);
                if (tblTacGia == null)
                {
                    return NotFound();
                }
                return View(tblTacGia);
            }
            return NotFound();
           
        }

        // POST: Admin/TacGia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StMaTacGia,StTenTacGia")] TblTacGia tblTacGia)
        {
            if (id != tblTacGia.StMaTacGia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblTacGia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblTacGiaExists(tblTacGia.StMaTacGia))
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
            return View(tblTacGia);
        }

        // GET: Admin/TacGia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (XacNhanRole() == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblTacGia = await _context.TblTacGia
                    .FirstOrDefaultAsync(m => m.StMaTacGia == id);
                if (tblTacGia == null)
                {
                    return NotFound();
                }

                return View(tblTacGia);
            }
            return NotFound();
            
        }

        // POST: Admin/TacGia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (XacNhanRole() == true)
            {
                var tblTacGia = await _context.TblTacGia.FindAsync(id);
                _context.TblTacGia.Remove(tblTacGia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
            
        }

        private bool TblTacGiaExists(int id)
        {
            return _context.TblTacGia.Any(e => e.StMaTacGia == id);
        }
    }
}
