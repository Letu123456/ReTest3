using System.ComponentModel.DataAnnotations;

namespace AnhTu_Assig2.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public int Type { get; set; }
    }
}
