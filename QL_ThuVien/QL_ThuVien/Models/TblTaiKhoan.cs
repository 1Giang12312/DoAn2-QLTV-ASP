using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QL_ThuVien.Models
{
    public partial class TblTaiKhoan
    {

        [Display(Name = "Mã sinh viên")]
        public int StMaSinhVien { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        [Display(Name = "Mật khẩu")]
        public string StMatKhau { get; set; }

        [Display(Name = "Quyền hạn")]
        public string StQuyenHan { get; set; }

        [Display(Name = "Trạng thái")]
        public bool BiTrangThai { get; set; }

        [Display(Name = "Ngày đăng nhập")]
        public DateTime DaNgayDangNhap { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime DaNgayTao { get; set; }

        public virtual TblSinhVien TblSinhVien { get; set; }
    }
}
