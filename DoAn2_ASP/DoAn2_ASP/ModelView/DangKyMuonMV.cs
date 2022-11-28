using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn2_ASP.ModelView
{
    public class DangKyMuonMV
    {
        public string StMaSinhVien { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Họ và Tên")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mã khoa")]
        public int MaKhoa { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập ngày mượn")]

        public DateTime NgayMuon { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày trả")]
        public DateTime NgayTra { get; set; }
    }
}
