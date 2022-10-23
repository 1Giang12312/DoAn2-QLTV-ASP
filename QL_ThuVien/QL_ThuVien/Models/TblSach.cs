using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QL_ThuVien.Models
{
    public partial class TblSach
    {
        public TblSach()
        {
            TblChiTietDonMuon = new HashSet<TblChiTietDonMuon>();
        }

        public int StMaSach { get; set; }
        public string StTenSach { get; set; }
        public int StMaLoaiSach { get; set; }
        public int StMaTacGia { get; set; }
        public int StMaKeSach { get; set; }
        public string StTomTat { get; set; }
        public string StTinhTrang { get; set; }
        public string StAnh { get; set; }
        public int InSoLuong { get; set; }

        public virtual TblKeSach StMaKeSachNavigation { get; set; }
        public virtual TblLoaiSach StMaLoaiSachNavigation { get; set; }
        public virtual TblTacGia StMaTacGiaNavigation { get; set; }
        public virtual ICollection<TblChiTietDonMuon> TblChiTietDonMuon { get; set; }
    }
}
