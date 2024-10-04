using System.ComponentModel.DataAnnotations;

namespace AnhTu_Assig2.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Display(Name = "Mật khẩu")]
        [StringLength(10, MinimumLength =4)]
        public string Password { get; set; }
        [Display(Name = "User Name")]
        [StringLength(20,MinimumLength =6)]
        public string ContactName { get; set; }
        [Display(Name ="Địa chỉ")]
        [StringLength (20, MinimumLength =6)]
        public string Address { get; set; }
        [Display(Name ="Số điện thoại")]
        [StringLength(20,MinimumLength =10)]
        public string Phone { get; set; }
        public int Type { get; set; }
    }
}
