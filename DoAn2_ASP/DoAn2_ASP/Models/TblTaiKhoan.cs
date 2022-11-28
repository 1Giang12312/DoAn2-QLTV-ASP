using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DoAn2_ASP.Models
{
    public partial class TblTaiKhoan
    {
        public int InMaTaiKhoan { get; set; }
        public string StMaSinhVien { get; set; }
        public string StMatKhau { get; set; }
        public short InMaQuyenHan { get; set; }
        public bool BiTrangThai { get; set; }
        public DateTime? DaNgayDangNhap { get; set; }
        public DateTime DaNgayTao { get; set; }
        public string StSalt { get; set; }

        public virtual TblQuyenHan InMaQuyenHanNavigation { get; set; }
        public virtual TblSinhVien StMaSinhVienNavigation { get; set; }
    }
}
