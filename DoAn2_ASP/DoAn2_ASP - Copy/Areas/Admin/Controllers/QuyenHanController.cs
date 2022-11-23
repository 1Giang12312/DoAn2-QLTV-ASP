using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAn2_ASP.Models;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace DoAn2_ASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuyenHanController : Controller
    {
        private readonly QL_ThuVienContext _context;
        public INotyfService _notifyService { get; }
        public QuyenHanController(QL_ThuVienContext context,INotyfService notifyService)
        {
            _context = context;
            _notifyService = notifyService;
        }

        // GET: Admin/QuyenHan
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblQuyenHan.ToListAsync());
        }

        // GET: Admin/QuyenHan/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblQuyenHan = await _context.TblQuyenHan
                .FirstOrDefaultAsync(m => m.InMaQuyenHan == id);
            if (tblQuyenHan == null)
            {
                return NotFound();
            }

            return View(tblQuyenHan);
        }

        // GET: Admin/QuyenHan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/QuyenHan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InMaQuyenHan,StTenQuyenHan,StGhiChu")] TblQuyenHan tblQuyenHan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblQuyenHan);
                await _context.SaveChangesAsync();
                _notifyService.Success("Tạo mới thành công");
                return RedirectToAction(nameof(Index));
            }
            return View(tblQuyenHan);
        }

        // GET: Admin/QuyenHan/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblQuyenHan = await _context.TblQuyenHan.FindAsync(id);
            if (tblQuyenHan == null)
            {
                return NotFound();
            }
            return View(tblQuyenHan);
        }

        // POST: Admin/QuyenHan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("InMaQuyenHan,StTenQuyenHan,StGhiChu")] TblQuyenHan tblQuyenHan)
        {
            if (id != tblQuyenHan.InMaQuyenHan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblQuyenHan);
                    await _context.SaveChangesAsync();
                    _notifyService.Success("Cập nhật thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblQuyenHanExists(tblQuyenHan.InMaQuyenHan))
                    {
                        _notifyService.Success("Có lỗi xảy ra");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblQuyenHan);
        }

        // GET: Admin/QuyenHan/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblQuyenHan = await _context.TblQuyenHan
                .FirstOrDefaultAsync(m => m.InMaQuyenHan == id);
            if (tblQuyenHan == null)
            {
                return NotFound();
            }

            return View(tblQuyenHan);
        }

        // POST: Admin/QuyenHan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var tblQuyenHan = await _context.TblQuyenHan.FindAsync(id);
            _context.TblQuyenHan.Remove(tblQuyenHan);
            await _context.SaveChangesAsync();
            _notifyService.Success("Xóa quyền thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool TblQuyenHanExists(short id)
        {
            return _context.TblQuyenHan.Any(e => e.InMaQuyenHan == id);
        }
    }
}
