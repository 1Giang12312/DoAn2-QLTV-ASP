using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QL_ThuVien.Models
{
    public partial class TblTaiKhoan
    {
        public int StMaSinhVien { get; set; }
        public string StMatKhau { get; set; }
        public string StQuyenHan { get; set; }
        public bool BiTrangThai { get; set; }
        public DateTime DaNgayDangNhap { get; set; }
        public DateTime DaNgayTao { get; set; }

        public virtual TblSinhVien TblSinhVien { get; set; }
    }
}
