using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AnhTu_Assig2.Context;
using AnhTu_Assig2.Models;

namespace AnhTu_Assig2.Pages.SuplierCRUD
{
    public class IndexModel : PageModel
    {
        private readonly AnhTu_Assig2.Context.AppDBContext _context;

        public IndexModel(AnhTu_Assig2.Context.AppDBContext context)
        {
            _context = context;
        }

        public IList<Supplier> Supplier { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Supplier = await _context.Suppliers.ToListAsync();
        }
    }
}
