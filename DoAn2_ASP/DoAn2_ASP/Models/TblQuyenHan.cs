using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DoAn2_ASP.Models
{
    public partial class TblQuyenHan
    {
        public TblQuyenHan()
        {
            TblTaiKhoan = new HashSet<TblTaiKhoan>();
        }
        [Display(Name = "Mã quyền hạn")]
        public short InMaQuyenHan { get; set; }
        [Display(Name = "Tên quyền hạn")]
        public string StTenQuyenHan { get; set; }
        [Display(Name = "Ghi chú")]
        public string StGhiChu { get; set; }

        public virtual ICollection<TblTaiKhoan> TblTaiKhoan { get; set; }
    }
}
