using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QL_ThuVien.Models
{
    public partial class TblChiTietDonMuon
    {
        [Display(Name = "Mã đơn mượn")]
        public int StMaDonMuon { get; set; }

        [Display(Name = "Mã sách")]
        public int StMaSach { get; set; }

        [Display(Name = "Số lượng")]
        public short InSoLuong { get; set; }

        [Display(Name = "Ngày mượn")]
        public DateTime DaNgayMuon { get; set; }

        [Display(Name = "Mã ngày trả")]
        public DateTime DaNgayTra { get; set; }

        [Display(Name = "Mã đơn mượn")]
        public virtual TblDonMuonSach StMaDonMuonNavigation { get; set; }
        [Display(Name = "Mã sách")]
        public virtual TblSach StMaSachNavigation { get; set; }
    }
}
