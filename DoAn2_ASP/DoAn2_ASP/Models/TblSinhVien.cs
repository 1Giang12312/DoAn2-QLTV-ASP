using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DoAn2_ASP.Models
{
    public partial class TblSinhVien
    {
        public TblSinhVien()
        {
            TblDonMuonSach = new HashSet<TblDonMuonSach>();
            TblTaiKhoan = new HashSet<TblTaiKhoan>();
        }
        [Display(Name = "Mã sinh viên")]
        public string StMaSinhVien { get; set; }
        [Display(Name = "Tên sinh viên")]
        public string StTenSinhVien { get; set; }
        [Display(Name = "Mã khoa")]
        public int StMaKhoa { get; set; }
        [Display(Name = "Số lần bị phạt")]
        public short InSoLanBiPhat { get; set; }
        [Display(Name = "Mail")]
        public string StGmail { get; set; }
        [Display(Name = "Số điện thoại")]
        public string StSoDienThoai { get; set; }
        [Display(Name = "Mã khoa")]
        public virtual TblKhoa StMaKhoaNavigation { get; set; }
        public virtual ICollection<TblDonMuonSach> TblDonMuonSach { get; set; }
        public virtual ICollection<TblTaiKhoan> TblTaiKhoan { get; set; }
    }
}
