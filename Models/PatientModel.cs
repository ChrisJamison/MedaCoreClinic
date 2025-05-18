using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Patient
    {
        [Key] // Primary Key
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Họ và tên là bắt buộc.")]
        [Display(Name = "Họ và tên")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
        [Display(Name = "Số điện thoại")]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Số điện thoại không hợp lệ.")]
        public string PhoneNumber { get; set; }
        
        [Display(Name = "Tên bệnh")]
        public string DiseaseName { get; set; }
       
        [Display(Name = "Giới tính")]
        public string Gender { get; set; }
       
        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }
       
        [Display(Name = "Chi Tiết Bệnh")]
        public string Details { get; set; }
       
        [Display(Name = "Ngày Sinh")]
        public string BirthDate { get; set; }
    }
}