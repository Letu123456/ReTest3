using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnhTu_Assig2.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Display(Name ="Tên sản phẩm")]
        [StringLength(20,MinimumLength =5)]
        public string ProductName { get; set; }

        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        [Display(Name = "Supplier")]
        [ValidateNever]
        public Supplier? Suppliers { set; get; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [Display(Name = "Category")]
        [ValidateNever]
        public Categories? Categories { set; get; }
        [Display(Name ="Số lượng sản phẩm")]
        public int QuantityPerUnit { get; set; }
        [Display(Name ="Giá")]
        public double UnitPrice { get; set; }
        [Display(Name ="Hình ảnh")]
        public string Image {  get; set; }

    }
}
