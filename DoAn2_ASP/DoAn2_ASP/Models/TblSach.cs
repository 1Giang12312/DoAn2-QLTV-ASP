using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DoAn2_ASP.Models
{
    public partial class TblSach
    {
        public TblSach()
        {
            TblChiTietDonMuon = new HashSet<TblChiTietDonMuon>();
        }
        [Display(Name = "Mã sách")]
        public int StMaSach { get; set; }
        [Display(Name = "Tên sách")]
        public string StTenSach { get; set; }
        [Display(Name = "Mã loại sách")]
        public int StMaLoaiSach { get; set; }
        [Display(Name = "Tác giả")]
        public int StMaTacGia { get; set; }
        [Display(Name = "Kệ sách")]
        public int StMaKeSach { get; set; }
        [Display(Name = "Tóm tắt")]
        public string StTomTat { get; set; }
        [Display(Name = "Tình trạng")]
        public string StTinhTrang { get; set; }
        [Display(Name = "Ảnh")]
        public string StAnh { get; set; }
        [Display(Name = "Số lượng")]
        public int InSoLuong { get; set; }
        [Display(Name = "Mã kệ sách")]
        public virtual TblKeSach StMaKeSachNavigation { get; set; }
        [Display(Name = "Mã loại sách")]
        public virtual TblLoaiSach StMaLoaiSachNavigation { get; set; }
        [Display(Name = "Mã tác giả")]
        public virtual TblTacGia StMaTacGiaNavigation { get; set; }
        public virtual ICollection<TblChiTietDonMuon> TblChiTietDonMuon { get; set; }
    }
}
