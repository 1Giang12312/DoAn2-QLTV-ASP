using DoAn2_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn2_ASP.ModelView
{
    public class BookHomeVM
    {
        public TblLoaiSach tblloaisach { get; set; }
        public List<TblSach> lsBook { get; set; }
    }
}
