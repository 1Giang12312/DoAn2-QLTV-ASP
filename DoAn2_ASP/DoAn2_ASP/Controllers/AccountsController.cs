using DoAn2_ASP.Extension;
using DoAn2_ASP.Helpper;
using DoAn2_ASP.Models;
using DoAn2_ASP.ModelView;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoAn2_ASP.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        public INotyfService _notyfService { get; }
        private readonly QL_ThuVienContext _context;
        public AccountsController(QL_ThuVienContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        [HttpGet]
        [AllowAnonymous]
        // [Route("dang-ky.html", Name = "DangKy")]
        public IActionResult DangkyTaiKhoan()
        {
            ViewData["StMaKhoa"] = new SelectList(_context.TblKhoa, "StMaKhoa", "StTenKhoa");
            return View();
        }
        public IActionResult ValidatePhone(string Phone)
        {
            try
            {
                var sinhvien = _context.TblSinhVien.AsNoTracking().SingleOrDefault(x => x.StSoDienThoai.ToLower() == Phone.ToLower());
                if (sinhvien != null)
                    return Json(data: "Số điện thoại : " + Phone + "đã được sử dụng");

                return Json(data: true);

            }
            catch
            {
                return Json(data: true);
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ValidateEmail(string Email)
        {
            try
            {
                var sinhvien = _context.TblSinhVien.AsNoTracking().SingleOrDefault(x => x.StGmail.ToLower() == Email.ToLower());
                if (sinhvien != null)
                    return Json(data: "Email : " + Email + " đã được sử dụng");
                return Json(data: true);
            }
            catch
            {
                return Json(data: true);
            }
        }
        //[Route("tai-khoan-cua-toi.html", Name = "Dashboard")]
        public IActionResult Dashboard()
        {
            var taikhoanID = HttpContext.Session.GetString("StMaSinhVien");
            if (taikhoanID != null)
            {
                var sinhvien = _context.TblSinhVien.Include(t => t.StMaKhoaNavigation).AsNoTracking().SingleOrDefault(x => x.StMaSinhVien == taikhoanID);
                if (sinhvien != null)
                {
                    var lsDSSach = _context.TblDonMuonSach
                       .AsNoTracking()
                       .Where(x => x.StMaSinhVien == sinhvien.StMaSinhVien)
                       .OrderByDescending(x=>x.DaNgayMuon)
                       .ToList();
                   ViewBag.DonSach = lsDSSach;
                   return View(sinhvien);
                }
            }
            return RedirectToAction("Login");
        }
        [HttpPost]
        [AllowAnonymous]
        // [Route("dang-ky.html", Name = "DangKy")]
        public async Task<IActionResult> DangkyTaiKhoan(RegisterVM taikhoan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string salt = Utilities.GetRandomKey();
                    TblSinhVien sinhvien = new TblSinhVien
                    {
                        StMaSinhVien = taikhoan.StMaSinhVien,
                        StTenSinhVien = taikhoan.FullName,
                        StMaKhoa = taikhoan.StMaKhoa,
                        InSoLanBiPhat = 0,
                        StGmail = taikhoan.Email.Trim().ToLower(),
                        StSoDienThoai = taikhoan.Phone
                    };
                    TblTaiKhoan tk = new TblTaiKhoan
                    {
                        StMaSinhVien = taikhoan.StMaSinhVien,
                        StSalt = salt,
                        StMatKhau = (taikhoan.Password + salt.Trim()).ToMD5(),
                        BiTrangThai = true,
                        InMaQuyenHan = 2, //user
                        DaNgayTao = DateTime.Now,
                        DaNgayDangNhap=DateTime.Now,
                    };

                    try
                    {
                        _context.Add(sinhvien);
                        await _context.SaveChangesAsync();

                        _context.Add(tk);
                        await _context.SaveChangesAsync();

                        //Lưu Session MaKh
                        HttpContext.Session.SetString("StMaSinhVien", sinhvien.StMaSinhVien.ToString());
                        var taikhoanID = HttpContext.Session.GetString("StMaSinhVien");

                        //Identity
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,sinhvien.StTenSinhVien),
                            new Claim("StMaSinhVien", sinhvien.StMaSinhVien.ToString())
                        };
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);
                        _notyfService.Success("Đăng ký thành công");
                        return RedirectToAction("Dashboard", "Accounts");
                    }
                    catch(Exception ex)
                    {
                        _notyfService.Success("Đăng ký lỗi! kiểm tra lại thông tin");
                        return RedirectToAction("DangkyTaiKhoan", "Accounts");
                    }
                }
                else
                {
                    return View(taikhoan);
                }
            }
            catch
            {
                return View(taikhoan);
            }
        }
        [AllowAnonymous]
        //[Route("dang-nhap.html", Name = "DangNhap")]
        public IActionResult Login(string returnUrl = null)
        {
            var taikhoanID = HttpContext.Session.GetString("StMaSinhVien");
            if (taikhoanID != null)
            {
                return RedirectToAction("Dashboard", "Accounts");
            }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        //[Route("dang-nhap.html", Name = "DangNhap")]
        //customer
        public async Task<IActionResult> Login(LoginVM sv, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //bool isEmail = Utilities.IsValidEmail(customer.UserName);
                    //if (!isEmail) return View(customer);
                    //khachang
                    var taikhoan = _context.TblTaiKhoan.AsNoTracking().SingleOrDefault(x => x.StMaSinhVien.Trim() == sv.UserName);
                    var sinhvien = _context.TblSinhVien.AsNoTracking().SingleOrDefault(x => x.StMaSinhVien.Trim() == sv.UserName);
                    if (taikhoan == null)
                    {
                        _notyfService.Success("Tạo tài khoản!");
                        return RedirectToAction("DangkyTaiKhoan"); //sua duong dan
                    }
                    string pass = (sv.Password + taikhoan.StSalt.Trim()).ToMD5();
                    if (taikhoan.StMatKhau != pass)
                    {
                        _notyfService.Error("Thông tin đăng nhập chưa chính xác");
                        return View(sv);
                    }
                    //kiem tra xem account co bi disable hay khong

                    if (taikhoan.BiTrangThai == false)
                    {
                        return RedirectToAction("ThongBao", "Accounts");
                    }

                    //Luu Session
                    HttpContext.Session.SetString("StMaSinhVien", taikhoan.StMaSinhVien.ToString());
                    var taikhoanID = HttpContext.Session.GetString("StMaSinhVien");

                    //Identity
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, sinhvien.StTenSinhVien),
                        new Claim("StMaSinhVien", taikhoan.StMaSinhVien.ToString())
                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    _notyfService.Success("Đăng nhập thành công");
                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToAction("Dashboard", "Accounts");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
            }
            catch
            {
                return RedirectToAction("DangkyTaiKhoan", "Accounts");
            }
            return View(sv);
        }
        [HttpGet]
        //[Route("dang-xuat.html", Name = "DangXuat")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Remove("StMaSinhVien");
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordVM model)
         {
            try
            {
                var taikhoanID = HttpContext.Session.GetString("StMaSinhVien");//lay session
                if (taikhoanID == null)
                {
                    return RedirectToAction("Login", "Accounts");
                }
                if (ModelState.IsValid)
                {
                    var taikhoan = _context.TblTaiKhoan.Where(a=>a.StMaSinhVien==taikhoanID).Single();
                    if (taikhoan == null) return RedirectToAction("Login", "Accounts");
                    var pass = (model.PasswordNow.Trim() + taikhoan.StSalt.Trim()).ToMD5();
                    {
                        string passnew = (model.Password.Trim() + taikhoan.StSalt.Trim()).ToMD5();
                        taikhoan.StMatKhau = passnew;
                        _context.Update(taikhoan);
                        _context.SaveChanges();
                        _notyfService.Success("Đổi mật khẩu thành công");
                        return RedirectToAction("Dashboard", "Accounts");
                    }
                }
            }
            catch
            {
                _notyfService.Error("Thay đổi mật khẩu không thành công");
                return RedirectToAction("Dashboard", "Accounts");
            }
            _notyfService.Error("Thay đổi mật khẩu không thành công");
            return RedirectToAction("Dashboard", "Accounts");
        }

    }
}


