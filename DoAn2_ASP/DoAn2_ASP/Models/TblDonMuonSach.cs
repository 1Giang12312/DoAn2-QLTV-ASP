using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DoAn2_ASP.Models
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
        public string StMaSinhVien { get; set; }
        [Display(Name = "Mã khoa")]
        public string StMaKhoa { get; set; }
        [Display(Name = "Ngày mượn")]
        public DateTime? DaNgayMuon { get; set; }
        [Display(Name = "Ngày trả")]
        public DateTime DaNgayTra { get; set; }
        [Display(Name = "Trạng thái")]
        public bool BiTrangThai { get; set; }
        [Display(Name = "Mã sinh viên")]
        public virtual TblSinhVien StMaSinhVienNavigation { get; set; }
        public virtual ICollection<TblChiTietDonMuon> TblChiTietDonMuon { get; set; }
    }
}
