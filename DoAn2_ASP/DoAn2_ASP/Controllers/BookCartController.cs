using AspNetCoreHero.ToastNotification.Abstractions;
using DoAn2_ASP.Extension;
using DoAn2_ASP.Models;
using DoAn2_ASP.ModelView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn2_ASP.Controllers
{
    public class BookCartController : Controller
    {
        public INotyfService _notyfService { get; }
        private readonly QL_ThuVienContext _context;
        public BookCartController(QL_ThuVienContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        //tao gio sach rong
        public List<CartItem> GioSach
        {
            get
            {                                                    //GioHang
                var gh = HttpContext.Session.Get<List<CartItem>>("GioSach");
                if (gh == default(List<CartItem>))
                {
                    gh = new List<CartItem>();
                }
                return gh;
            }
        }
        [HttpPost]
        public IActionResult AddToCart(int bookID, int? amount)
        {
            List<CartItem> cart = GioSach;
            //if(!User.Identity.IsAuthenticated)
           // {
           //     return new ViewResult { ViewName = @"~/Accounts/Login" };
          //  }
            try
            {
                //Them san pham vao gio
                CartItem item = cart.SingleOrDefault(p => p.book.StMaSach == bookID);
                if (item != null) // da co => cap nhat so luong
                {
                    item.amount = item.amount + amount.Value;//so luong = so luong + so luong moi
                    //luu lai session
                    HttpContext.Session.Set<List<CartItem>>("GioSach", cart);
                }
                //book chua co trong gio
                else
                {
                    TblSach hh = _context.TblSach.SingleOrDefault(p => p.StMaSach == bookID);
                    item = new CartItem
                    {
                        amount = amount.HasValue ? amount.Value : 1,
                        book = hh
                    };
                    cart.Add(item);//Them vao gio
                }

                //Luu lai Session
                HttpContext.Session.Set<List<CartItem>>("GioSach", cart);
                _notyfService.Success("Thêm sản phẩm thành công");
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
        [HttpPost]
        //xoa sach khoi gio
        public ActionResult Remove(int bookID)
        {
            try
            {
                List<CartItem> gioSach = GioSach;
                CartItem item = gioSach.SingleOrDefault(p => p.book.StMaSach == bookID);
                if (item != null)
                {
                    gioSach.Remove(item);
                }
                //luu lai session
                HttpContext.Session.Set<List<CartItem>>("GioSach", gioSach);
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
        [HttpPost]
        //[Route("api/cart/update")]
        public IActionResult UpdateCart(int bookID, int? amount)
        {
            //Lay gio hang ra de xu ly
            var cart = HttpContext.Session.Get<List<CartItem>>("GioSach");
            try
            {
                if (cart != null)
                {
                    CartItem item = cart.SingleOrDefault(p => p.book.StMaSach == bookID);
                    if (item != null && amount.HasValue) // da co -> cap nhat so luong
                    {
                        item.amount = amount.Value;
                    }
                    //Luu lai session
                    HttpContext.Session.Set<List<CartItem>>("GioSach", cart);
                }
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        public IActionResult Index()
        {
            List<int> lsBookID = new List<int>();
            var lsGioSach = GioSach;
            return View(GioSach);
        }
    }
}
