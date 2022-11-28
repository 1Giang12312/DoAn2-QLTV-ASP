using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DoAn2_ASP.Models
{
    public partial class TblTacGia
    {
        public TblTacGia()
        {
            TblSach = new HashSet<TblSach>();
        }

        public int StMaTacGia { get; set; }
        public string StTenTacGia { get; set; }

        public virtual ICollection<TblSach> TblSach { get; set; }
    }
}
