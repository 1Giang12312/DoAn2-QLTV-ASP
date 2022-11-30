using DoAn2_ASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn2_ASP.Controllers
{
    public class BookController : Controller
    {
        private readonly QL_ThuVienContext _context;
        public BookController(QL_ThuVienContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? page)
        {
            try
            {
                var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                var pageSize = 6;
                var lsSach = _context.TblSach.AsNoTracking().OrderByDescending(x => x.StMaSach);
                PagedList<TblSach> models = new PagedList<TblSach>(lsSach, pageNumber, pageSize);
                ViewBag.CurrentPage = pageNumber;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

        }

        //[Route("danhmuc/{StMaLoaiSach}", Name = ("ListBook"))]
        public IActionResult List(int StMaLoaiSach, int page=1)
        {
            try
            {
                var pageSize = 3;
                var danhmuc = _context.TblLoaiSach.AsNoTracking().SingleOrDefault(x => x.StMaLoaiSach == StMaLoaiSach);
                var lsTinDangs = _context.TblSach
                    .AsNoTracking()
                    .Where(x => x.StMaLoaiSach == danhmuc.StMaLoaiSach);
                PagedList<TblSach> models = new PagedList<TblSach>(lsTinDangs, page, pageSize);
                ViewBag.CurrentPage = page;
                ViewBag.CurrentCat = danhmuc;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }


        }

        //[Route("/{StMaLoaiSach}-{id}.html", Name = ("ProductDetails"))]
        public IActionResult Detail(int id)
        {
            try
            {
                var book = _context.TblSach.Include(x => x.StMaLoaiSachNavigation).FirstOrDefault(x => x.StMaSach == id);
                if (book == null)
                {
                    return RedirectToAction("Index");
                }
                var lsBook = _context.TblSach
                    .AsNoTracking()
                    .Where(x => x.StMaLoaiSach == book.StMaLoaiSach && x.StMaSach != id && x.InSoLuong > 0)
                    .Take(4)
                    .ToList();
                ViewBag.SanPham = lsBook;
                return View(book);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
