using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên tài khoản bắt buộc")]
        [Display(Name = "Tên tài khoản")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email bắt buộc")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [Display(Name = "Địa chỉ Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu bắt buộc")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải ít nhất 6 ký tự")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ngày sinh")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Quyền hạn bắt buộc")]
        [Display(Name = "Quyền hạn")]
        public string Role { get; set; }
    }
}