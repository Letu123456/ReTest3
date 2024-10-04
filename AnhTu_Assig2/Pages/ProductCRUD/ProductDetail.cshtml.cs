using AnhTu_Assig2.Context;
using AnhTu_Assig2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AnhTu_Assig2.Pages.ProductCRUD
{
    public class ProductDetailModel : PageModel
    {
        private readonly AppDBContext _context;

        public ProductDetailModel(AppDBContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Product = await _context.Products.Include(d=>d.Categories).Include(d => d.Suppliers)
                .Where(d=>d.ProductId==id).FirstOrDefaultAsync();

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
