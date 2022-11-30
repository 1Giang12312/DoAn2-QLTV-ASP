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
    public class DonMuonSachController : Controller
    {
        private readonly QL_ThuVienContext _context;

        public DonMuonSachController(QL_ThuVienContext context)
        {
            _context = context;
        }

        // GET: Admin/DonMuonSach
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
                var qL_ThuVienContext = _context.TblDonMuonSach.Include(t => t.StMaSinhVienNavigation).ThenInclude(t => t.StMaKhoaNavigation);
                return View(await qL_ThuVienContext.ToListAsync());
            }
            return NotFound();
            
        }

        // GET: Admin/DonMuonSach/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (XacNhanRole() == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblDonMuonSach = await _context.TblDonMuonSach
                    .Include(t => t.StMaSinhVienNavigation)
                    .FirstOrDefaultAsync(m => m.StMaDonMuon == id);
                if (tblDonMuonSach == null)
                {
                    return NotFound();
                }
                var chitiet = _context.TblChiTietDonMuon.AsNoTracking().Include(t => t.StMaSachNavigation).Where(m => m.StMaDonMuon == id).ToList();
                ViewBag.chitiet = chitiet;
                ViewData["StMaSinhVien"] = new SelectList(_context.TblSinhVien, "StMaSinhVien", "StMaSinhVien", tblDonMuonSach.StMaSinhVien);
                return View(tblDonMuonSach);
            }
            return NotFound();
            
        }

        // GET: Admin/DonMuonSach/Create
        public IActionResult Create()
        {
            if (XacNhanRole() == true)
            {
                ViewData["StMaSinhVien"] = new SelectList(_context.TblSinhVien, "StMaSinhVien", "StMaSinhVien");
                return View();
            }
            return NotFound();
            
        }

        // POST: Admin/DonMuonSach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StMaDonMuon,StMaSinhVien,StMaKhoa,DaNgayMuon,DaNgayTra,BiTrangThai")] TblDonMuonSach tblDonMuonSach)
        {
            if (XacNhanRole() == true)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(tblDonMuonSach);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["StMaSinhVien"] = new SelectList(_context.TblSinhVien, "StMaSinhVien", "StMaSinhVien", tblDonMuonSach.StMaSinhVien);
                return View(tblDonMuonSach);
            }
            return NotFound();

            
        }

        // GET: Admin/DonMuonSach/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (XacNhanRole() == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblDonMuonSach = await _context.TblDonMuonSach.FindAsync(id);
                if (tblDonMuonSach == null)
                {
                    return NotFound();
                }
                ViewData["StMaSinhVien"] = new SelectList(_context.TblSinhVien, "StMaSinhVien", "StMaSinhVien", tblDonMuonSach.StMaSinhVien);
                return View(tblDonMuonSach);
            }
            return NotFound();
            
        }

        // POST: Admin/DonMuonSach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StMaDonMuon,StMaSinhVien,StMaKhoa,DaNgayMuon,DaNgayTra,BiTrangThai")] TblDonMuonSach tblDonMuonSach)
        {
            if (XacNhanRole() == true)
            {
                if (id != tblDonMuonSach.StMaDonMuon)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(tblDonMuonSach);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TblDonMuonSachExists(tblDonMuonSach.StMaDonMuon))
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
                ViewData["StMaSinhVien"] = new SelectList(_context.TblSinhVien, "StMaSinhVien", "StMaSinhVien", tblDonMuonSach.StMaSinhVien);
                return View(tblDonMuonSach);
            }
            return NotFound();
            
        }

        // GET: Admin/DonMuonSach/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (XacNhanRole() == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblDonMuonSach = await _context.TblDonMuonSach
                    .Include(t => t.StMaSinhVienNavigation)
                    .FirstOrDefaultAsync(m => m.StMaDonMuon == id);
                if (tblDonMuonSach == null)
                {
                    return NotFound();
                }

                return View(tblDonMuonSach);
            }
            return NotFound();
            
        }

        // POST: Admin/DonMuonSach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (XacNhanRole() == true)
            {
                var tblDonMuonSach = await _context.TblDonMuonSach.FindAsync(id);
                _context.TblDonMuonSach.Remove(tblDonMuonSach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
            
        }

        private bool TblDonMuonSachExists(int id)
        {
            return _context.TblDonMuonSach.Any(e => e.StMaDonMuon == id);
        }
    }
}
