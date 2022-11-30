using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DoAn2_ASP.Models
{
    public partial class TblKeSach
    {
        public TblKeSach()
        {
            TblSach = new HashSet<TblSach>();
        }
        [Display(Name = "Mã kệ sách ")]
        public int StMaKeSach { get; set; }
        [Display(Name = "Tên kệ sách")]
        public string StTenKeSach { get; set; }

        public virtual ICollection<TblSach> TblSach { get; set; }
    }
}
