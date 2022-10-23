using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QL_ThuVien.Models
{
    public partial class TblDonMuonSach
    {
        public TblDonMuonSach()
        {
            TblChiTietDonMuon = new HashSet<TblChiTietDonMuon>();
        }

        public int StMaDonMuon { get; set; }
        public int StMaSinhVien { get; set; }
        public string StMaKhoa { get; set; }

        public virtual TblSinhVien StMaSinhVienNavigation { get; set; }
        public virtual ICollection<TblChiTietDonMuon> TblChiTietDonMuon { get; set; }
    }
}
