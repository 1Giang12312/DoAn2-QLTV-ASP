using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QL_ThuVien.Models
{
    public partial class TblLoaiSach
    {
        public TblLoaiSach()
        {
            TblSach = new HashSet<TblSach>();
        }

        public int StMaLoaiSach { get; set; }
        public string StTenSach { get; set; }

        public virtual ICollection<TblSach> TblSach { get; set; }
    }
}
