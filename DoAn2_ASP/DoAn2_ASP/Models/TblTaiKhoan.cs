using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DoAn2_ASP.Models
{
    public partial class TblTaiKhoan
    {
        [Display(Name = "Mã tài khoản")]
        public int InMaTaiKhoan { get; set; }
        [Display(Name = "Mã sinh viên")]
        public string StMaSinhVien { get; set; }
        [Display(Name = "Mật khẩu")]
        public string StMatKhau { get; set; }
        [Display(Name = "Quyền hạn")]
        public short InMaQuyenHan { get; set; }
        [Display(Name = "Trạng thái")]
        public bool BiTrangThai { get; set; }
        [Display(Name = "Ngày đăng nhập")]
        public DateTime? DaNgayDangNhap { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime DaNgayTao { get; set; }
        public string StSalt { get; set; }
        [Display(Name = "Mã quyền hạn")]
        public virtual TblQuyenHan InMaQuyenHanNavigation { get; set; }
        [Display(Name = "Mã sinh viên")]
        public virtual TblSinhVien StMaSinhVienNavigation { get; set; }
    }
}
