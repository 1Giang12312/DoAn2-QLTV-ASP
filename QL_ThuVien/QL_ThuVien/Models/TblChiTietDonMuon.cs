using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QL_ThuVien.Models
{
    public partial class TblChiTietDonMuon
    {
        public int StMaDonMuon { get; set; }
        public int StMaSach { get; set; }
        public short InSoLuong { get; set; }
        public DateTime DaNgayMuon { get; set; }
        public DateTime DaNgayTra { get; set; }

        public virtual TblDonMuonSach StMaDonMuonNavigation { get; set; }
        public virtual TblSach StMaSachNavigation { get; set; }
    }
}
