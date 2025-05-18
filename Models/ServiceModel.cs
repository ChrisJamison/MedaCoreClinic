using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Service
    {
        [Key] // Primary Key
        public int Id { get; set; } // STT - Primary key
        [Required(ErrorMessage = "ên dịch vụ là bắt buộc.")]
        [Display(Name = "Tên dịch vụ")]
        public string Name { get; set; } // Tên dịch vụ
        [Display(Name = "Giá dịch vụ")]
        public decimal Price { get; set; } // Giá dịch vụ
        [Display(Name = "Khoa thực hiện")]
        public string Department { get; set; } // Khoa thực hiện
        [Display(Name = "Mô tả")]
        public string Description { get; set; } // Mô tả
    }
}