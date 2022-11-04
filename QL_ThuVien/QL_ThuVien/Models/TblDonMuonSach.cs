using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Display(Name = "Mã đơn mượn")]
        public int StMaDonMuon { get; set; }

        [Display(Name = "Mã sinh viên")]
        public int StMaSinhVien { get; set; }

        [Display(Name = "Mã khoa")]
        public string StMaKhoa { get; set; }

        [Display(Name = "Mã sinh viên")]
        public virtual TblSinhVien StMaSinhVienNavigation { get; set; }

        [Display(Name = "Chi tiết đơn")]
        public virtual ICollection<TblChiTietDonMuon> TblChiTietDonMuon { get; set; }
    }
}
