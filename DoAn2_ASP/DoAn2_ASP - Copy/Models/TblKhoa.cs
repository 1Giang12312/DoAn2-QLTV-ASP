using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DoAn2_ASP.Models
{
    public partial class TblKhoa
    {
        public TblKhoa()
        {
            TblSinhVien = new HashSet<TblSinhVien>();
        }

        [Display(Name = "Mã khoa")]
        public int StMaKhoa { get; set; }

        [Display(Name = "Tên khoa")]
        public string StTenKhoa { get; set; }

        public virtual ICollection<TblSinhVien> TblSinhVien { get; set; }
    }
}
