using System;
using System.Collections.Generic;

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

        public string StMaSinhVien { get; set; }
        public string StTenSinhVien { get; set; }
        public int StMaKhoa { get; set; }
        public short InSoLanBiPhat { get; set; }
        public string StGmail { get; set; }
        public string StSoDienThoai { get; set; }

        public virtual TblKhoa StMaKhoaNavigation { get; set; }
        public virtual ICollection<TblDonMuonSach> TblDonMuonSach { get; set; }
        public virtual ICollection<TblTaiKhoan> TblTaiKhoan { get; set; }
    }
}
