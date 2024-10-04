using System.ComponentModel.DataAnnotations;

namespace AnhTu_Assig2.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        [Display(Name = "Thể loại")]
        [StringLength(20,MinimumLength =6)]
        public string CategoryName { get; set; }
        [Display(Name ="Mô tả")]
        public string Description { get; set; }
    }
}
