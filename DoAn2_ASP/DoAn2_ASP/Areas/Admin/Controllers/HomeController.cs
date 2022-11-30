using DoAn2_ASP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn2_ASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly QL_ThuVienContext _context;

        public HomeController(QL_ThuVienContext context)
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
        public IActionResult Index()
        {
            if (XacNhanRole() == true)
            {
                return View();
            }
            return NotFound();
            
        }
    }
}
