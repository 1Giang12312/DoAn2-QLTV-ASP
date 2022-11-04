using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QL_ThuVien.Models
{
    public partial class TblTacGia
    {
        public TblTacGia()
        {
            TblSach = new HashSet<TblSach>();
        }
        [Display(Name = "Mã tác giả")]
        public int StMaTacGia { get; set; }

        [Display(Name = "Tên tác giả")]
        public string StTenTacGia { get; set; }
       
        public virtual ICollection<TblSach> TblSach { get; set; }
    }
}
