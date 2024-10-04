using AnhTu_Assig2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using AnhTu_Assig2.Migrations;
using Microsoft.IdentityModel.Tokens;
namespace AnhTu_Assig2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AnhTu_Assig2.Context.AppDBContext _context;

        
        public IndexModel(ILogger<IndexModel> logger, AnhTu_Assig2.Context.AppDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        

        public IList<Product> Product { get; set; } = default!;
       // public string SearchTerm { get; set; } = string.Empty;
        public async Task OnGetAsync(string searchString)
        {


            
            if(!string.IsNullOrEmpty(searchString) )
            {
                Product = await _context.Products.Include(x => x.Categories)
                .Include(x => x.Suppliers).Where(x=>x.ProductName.Contains(searchString) ).ToListAsync();

                if (Product == null)
                {
                    await _context.Products.Include(x => x.Categories)
                .Include(x => x.Suppliers).Where(x => x.Categories.CategoryName.Contains(searchString)).ToListAsync();
                }

            }
            else
            {
                Product = await _context.Products
                .Include(p => p.Categories)
                .Include(p => p.Suppliers).ToListAsync();
            }
            
        }

        
    }



}

