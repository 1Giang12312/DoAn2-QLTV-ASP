using DoAn2_ASP.Models;
using DoAn2_ASP.ModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn2_ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QL_ThuVienContext _context;
        public HomeController(ILogger<HomeController> logger,QL_ThuVienContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewVM model = new HomeViewVM();

            var lsBook = _context.TblSach.AsNoTracking()
                .Where(x => x.InSoLuong > 0)
                .ToList();

            List<BookHomeVM> lsBookView = new List<BookHomeVM>();

            var lsCats = _context.TblLoaiSach
                .AsNoTracking()
                .ToList();

            foreach (var item in lsCats)
            {
                BookHomeVM bookHome = new BookHomeVM();
                bookHome.tblloaisach = item;
                bookHome.lsBook = lsBook.Where(x => x.StMaLoaiSach == item.StMaLoaiSach).ToList();
                lsBookView.Add(bookHome);
                
            }
            model.Book = lsBookView;
            ViewBag.AllBook = lsBook;
            return View(model);
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

