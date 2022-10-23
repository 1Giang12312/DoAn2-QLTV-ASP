using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QL_ThuVien.Models
{
    public partial class TblKhoa
    {
        public TblKhoa()
        {
            TblSinhVien = new HashSet<TblSinhVien>();
        }

        public int StMaKhoa { get; set; }
        public string StTenKhoa { get; set; }

        public virtual ICollection<TblSinhVien> TblSinhVien { get; set; }
    }
}
