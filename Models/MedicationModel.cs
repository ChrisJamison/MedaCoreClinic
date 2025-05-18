using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models // Replace with your project namespace
{
    public class Medication
    {
        [Key] // Primary Key
        public int Id { get; set; } // Primary Key

        [Display(Name = "Tên thuốc")]
        public string Name { get; set; } // Tên thuốc

        [Display(Name = "Đơn vị")]
        public string Unit { get; set; } // Đơn vị

        [Display(Name = "Giá thuốc")]
        public decimal Price { get; set; } // Giá thuốc

        [Display(Name = "Cách sử dụng")]
        public string HowToUse { get; set; } // Cách sử dụng

        [Display(Name = "Hoạt chất")]
        public string ActiveIngredient { get; set; } // Hoạt chất

        [Display(Name = "Hàm lượng")]
        public string Concentration { get; set; } // Hàm lượng

        [Display(Name = "Quy cách đóng gói")]
        public string Packaging { get; set; } // Quy cách đóng gói

        [Display(Name = "Đơn vị sản xuất")]
        public string Manufacturer { get; set; } // Đơn vị sản xuất

        [Display(Name = "Đơn vị kê khai")]
        public string Declarer { get; set; } // Đơn vị kê khai
    }
}