using System.ComponentModel.DataAnnotations;

namespace AnhTu_Assig2.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
