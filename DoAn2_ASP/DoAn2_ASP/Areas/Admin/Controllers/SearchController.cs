using DoAn2_ASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn2_ASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SearchController : Controller
    {
        private readonly QL_ThuVienContext _context;

        public SearchController(QL_ThuVienContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult FindBook(string keyword)
        {
            List<TblSach> ls = new List<TblSach>();
            if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
            {
                return PartialView("ListSachSearchPartial", null);
            }
            ls = _context.TblSach.AsNoTracking()
                                  .Include(a => a.StMaLoaiSachNavigation)
                                  .Where(x => x.StTenSach.Contains(keyword))
                                  .OrderByDescending(x => x.StTenSach)
                                  .Take(10)
                                  .ToList();
            if (ls == null)
            {
                return PartialView("ListSachSearchPartial", null);
            }
            else
            {
                return PartialView("ListSachSearchPartial", ls);
            }
        }
    }
}
