using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn2_ASP.ModelView
{
    public class LoginVM
    {
        [Key]
        [MaxLength(9,ErrorMessage ="Mã số sinh viên không hợp lệ")]
        [Required(ErrorMessage = ("Vui lòng nhập mã số sinh viên"))]
        [Display(Name = "Mã số sinh viên")]
        //[EmailAddress(ErrorMessage = "Sai định dạng Email")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [MinLength(5, ErrorMessage = "Bạn cần đặt mật khẩu tối thiểu 5 ký tự")]
        public string Password { get; set; }
    }
}
