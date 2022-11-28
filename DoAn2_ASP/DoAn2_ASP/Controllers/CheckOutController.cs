using AspNetCoreHero.ToastNotification.Abstractions;
using DoAn2_ASP.Extension;
using DoAn2_ASP.Models;
using DoAn2_ASP.ModelView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn2_ASP.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly QL_ThuVienContext _context;
        public INotyfService _notyfService { get; }
        public CheckOutController(QL_ThuVienContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        public List<CartItem> GioHang
        {
            get
            {
                var gh = HttpContext.Session.Get<List<CartItem>>("GioSach");
                if (gh == default(List<CartItem>))
                {
                    gh = new List<CartItem>();
                }
                return gh;
            }
        }
        public IActionResult Index(string returnUrl = null)
        {
            //Lay gio hang ra de xu ly
            var cart = HttpContext.Session.Get<List<CartItem>>("GioSach");
            var taikhoanID = HttpContext.Session.GetString("StMaSinhVien");
            DangKyMuonMV model = new DangKyMuonMV();
            if (taikhoanID != null)
            {
                var sinhvien = _context.TblSinhVien.AsNoTracking().SingleOrDefault(x => x.StMaSinhVien == taikhoanID);
                model.StMaSinhVien = sinhvien.StMaSinhVien;
                model.FullName = sinhvien.StTenSinhVien;
                model.Email = sinhvien.StGmail;
                model.Phone = sinhvien.StSoDienThoai;
                model.MaKhoa = sinhvien.StMaKhoa;
            }

            ViewBag.GioSach = cart;
            return View(model);
        }
        [HttpPost]
        //[Route("checkout.html", Name = "Checkout")]
        public IActionResult Index(DangKyMuonMV donMuon)
        {
            //Lay ra gio hang de xu ly
            var cart = HttpContext.Session.Get<List<CartItem>>("GioSach");
            var taikhoanID = HttpContext.Session.GetString("StMaSinhVien");
            DangKyMuonMV model = new DangKyMuonMV();
            if (taikhoanID != null)
            {
                var sinhvien = _context.TblSinhVien.AsNoTracking().SingleOrDefault(x => x.StMaSinhVien == taikhoanID);
                model.StMaSinhVien = sinhvien.StMaSinhVien;
                model.FullName = sinhvien.StTenSinhVien;
                model.Email = sinhvien.StGmail;
                model.Phone = sinhvien.StSoDienThoai;
                model.MaKhoa = sinhvien.StMaKhoa;
            }
            try
            {
                if (ModelState.IsValid)
                {
                    //Khoi tao don
                    TblDonMuonSach donmuon = new TblDonMuonSach();
                    donmuon.StMaSinhVien = model.StMaSinhVien;
                    donmuon.StMaKhoa = Convert.ToString(model.MaKhoa);
                    donmuon.DaNgayMuon = donMuon.NgayMuon;
                    donmuon.DaNgayTra = donMuon.NgayTra;
                    donmuon.BiTrangThai = false;
                    _context.Add(donmuon);
                    _context.SaveChanges();
                    //tao danh sach don hang
                    foreach (var item in cart)
                    {

                        TblChiTietDonMuon chitiet = new TblChiTietDonMuon();
                        chitiet.StMaDonMuon = donmuon.StMaDonMuon;
                        chitiet.StMaSach = item.book.StMaSach;
                        chitiet.InSoLuong = (short)item.amount;
                        //chitiet.BiTrangThai = false;
                        _context.Add(chitiet);
                    }
                    _context.SaveChanges();
                    //clear gio hang
                    HttpContext.Session.Remove("GioSach");
                    //Xuat thong bao
                    _notyfService.Success("Đơn hàng đặt thành công");
                    //cap nhat thong tin khach hang
                    return RedirectToAction("Success");
                }
            }
            catch (Exception ex)
            {
                ViewBag.GioSach = cart;
                return View(model);
            }
            ViewBag.GioSach = cart;
            return View(model);

        }
        //[Route("dat-hang-thanh-cong.html",Name = "Success")]
        public IActionResult Success()
        {
            try
            {
                var taikhoanID = HttpContext.Session.GetString("StMaSinhVien");
                if (string.IsNullOrEmpty(taikhoanID))
                {
                    return RedirectToAction("Login", "Accounts", new { returnUrl = "/Success" });
                }
                var sinhvien = _context.TblSinhVien.AsNoTracking().SingleOrDefault(x => x.StMaSinhVien == taikhoanID);
                var donhang = _context.TblDonMuonSach
                    .Where(x => x.StMaSinhVien ==taikhoanID)
                    .FirstOrDefault();

                DangKyMuonMV dkMuon = new DangKyMuonMV();
                dkMuon.StMaSinhVien = sinhvien.StMaSinhVien;
                dkMuon.FullName = sinhvien.StTenSinhVien;
                dkMuon.Email = sinhvien.StGmail;
                dkMuon.Phone = sinhvien.StSoDienThoai;
                dkMuon.NgayMuon = (DateTime)donhang.DaNgayMuon;
                dkMuon.NgayTra = donhang.DaNgayTra;
                return View(dkMuon);
            }
            catch
            {
                return View();
            }
        }
    }

}
