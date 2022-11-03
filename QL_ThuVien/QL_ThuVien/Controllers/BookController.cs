using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QL_ThuVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_ThuVien.Controllers
{
    public class BookController : Controller
    {
        private readonly Ql_ThuVienContext _context;
        public BookController(Ql_ThuVienContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            var book = _context.TblSach.Include(x => x.StMaLoaiSachNavigation).FirstOrDefault(x => x.StMaSach == id);
            if (book == null)
            {
                return RedirectToAction("Index");
            }

            return View(book);
        }
    }
}
