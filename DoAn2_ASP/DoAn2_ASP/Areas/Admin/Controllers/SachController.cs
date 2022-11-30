using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAn2_ASP.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using PagedList.Core;
using DoAn2_ASP.Helpper;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace DoAn2_ASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SachController : Controller
    {
        private readonly QL_ThuVienContext _context;
        public INotyfService _notiyfService { get; }
        public SachController(QL_ThuVienContext context, INotyfService notiyfService)
        {
            _context = context;
            _notiyfService = notiyfService;
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
        // GET: Admin/Sach
        public IActionResult Index(int page = 1, int StMaLoaiSach = 0)
         {
            if (XacNhanRole() == true)
            {

                //var qL_ThuVienContext = _context.TblSach.Include(t => t.StMaKeSachNavigation).Include(t => t.StMaLoaiSachNavigation).Include(t => t.StMaTacGiaNavigation);
                var pageNumber = page; // == null || page <= 0 ? 1 : page.Value;
                var pageSize = 3;
                List<TblSach> lsSach = new List<TblSach>();
                if (StMaLoaiSach != 0)
                {
                    lsSach = _context.TblSach
                        .AsNoTracking()
                        .Where(x => x.StMaLoaiSach == StMaLoaiSach)
                        .Include(t => t.StMaKeSachNavigation)
                        .Include(t => t.StMaLoaiSachNavigation)
                        .Include(t => t.StMaTacGiaNavigation)
                        .OrderByDescending(x => x.StMaSach).ToList();
                }
                else
                {
                    lsSach = _context.TblSach.AsNoTracking()
                        .Include(t => t.StMaKeSachNavigation)
                        .Include(t => t.StMaLoaiSachNavigation)
                        .Include(t => t.StMaTacGiaNavigation)
                        .OrderByDescending(x => x.StMaSach).ToList();

                }

                PagedList<TblSach> models = new PagedList<TblSach>(lsSach.AsQueryable(), pageNumber, pageSize);
                ViewBag.CurrentPage = pageNumber;
                ViewBag.CurrentMaLoaiSach = StMaLoaiSach;
                ViewData["LoaiSach"] = new SelectList(_context.TblLoaiSach, "StMaLoaiSach", "StTenSach", StMaLoaiSach);
                return View(models);
            }
            return NotFound();

        }
        public IActionResult Filtter(int StMaLoaiSach = 0)
        {
            //int? page
            //var pageNumber = page == null || page <= 0 ? 1 : page.Value;

            var url = $"/Admin/Sach?StMaLoaiSach={StMaLoaiSach}";
            if(StMaLoaiSach==0) 
            {
                url = $"/Admin/Sach";
            }
            
            return Json(new { status = "success", redirectUrl = url });
        }
        // GET: Admin/Sach/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (XacNhanRole() == true)
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
            return NotFound();

            
        }

        // GET: Admin/Sach/Create
        public IActionResult Create()
        {
            if (XacNhanRole() == true)
            {
                ViewData["StMaKeSach"] = new SelectList(_context.TblKeSach, "StMaKeSach", "StTenKeSach");
                ViewData["StMaLoaiSach"] = new SelectList(_context.TblLoaiSach, "StMaLoaiSach", "StTenSach");
                ViewData["StMaTacGia"] = new SelectList(_context.TblTacGia, "StMaTacGia", "StTenTacGia");
                return View();
            }
            return NotFound();

            
        }

        // POST: Admin/Sach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StMaSach,StTenSach,StMaLoaiSach,StMaTacGia,StMaKeSach,StTomTat,StTinhTrang,StAnh,InSoLuong")] TblSach tblSach, IFormFile file)
        {
            if (XacNhanRole() == true)
            {
                if (ModelState.IsValid)
                {
                    if (ModelState.IsValid)
                    {

                        tblSach.StAnh = Upload(file);
                        _context.Add(tblSach);
                        await _context.SaveChangesAsync();
                        _notiyfService.Success("Thêm thành công");
                        return RedirectToAction(nameof(Index));
                    }
                }
                ViewData["StMaKeSach"] = new SelectList(_context.TblKeSach, "StMaKeSach", "StTenKeSach", tblSach.StMaKeSach);
                ViewData["StMaLoaiSach"] = new SelectList(_context.TblLoaiSach, "StMaLoaiSach", "StMaLoaiSach", tblSach.StMaLoaiSach);
                ViewData["StMaTacGia"] = new SelectList(_context.TblTacGia, "StMaTacGia", "StTenTacGia", tblSach.StMaTacGia);
                return View(tblSach);
            }
            return NotFound();

            
        }

        // GET: Admin/Sach/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (XacNhanRole() == true)
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
            return NotFound();

           
        }

        // POST: Admin/Sach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StMaSach,StTenSach,StMaLoaiSach,StMaTacGia,StMaKeSach,StTomTat,StTinhTrang,StAnh,InSoLuong")] TblSach tblSach,IFormFile file)
        {
            if (XacNhanRole() == true)
            {
                if (id != tblSach.StMaSach)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        if (file != null)
                        {
                            tblSach.StAnh = Upload(file);
                        }
                        _context.Update(tblSach);
                        _notiyfService.Success("Cập nhật thành công");
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
                ViewData["StMaLoaiSach"] = new SelectList(_context.TblLoaiSach, "StMaLoaiSach", "StMaLoaiSach", tblSach.StMaLoaiSach);
                ViewData["StMaTacGia"] = new SelectList(_context.TblTacGia, "StMaTacGia", "StTenTacGia", tblSach.StMaTacGia);
                return View(tblSach);
            }
            return NotFound();

            
        }

        // GET: Admin/Sach/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (XacNhanRole() == true)
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
            return NotFound();

            
        }

        // POST: Admin/Sach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (XacNhanRole() == true)
            {
                var tblSach = await _context.TblSach.FindAsync(id);
                _context.TblSach.Remove(tblSach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();

            
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
