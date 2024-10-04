using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnhTu_Assig2.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        [Display(Name = "Order")]
        [ValidateNever]
        public Order Orders { set; get; }
        [Key]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [Display(Name = "Product")]
        [ValidateNever]
        public Product Products { set; get; }
        public double? UnitPrice { get; set; }
        public int? Quantity { get; set; }
    }
}
