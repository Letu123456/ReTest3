using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AnhTu_Assig2.Context;
using AnhTu_Assig2.Models;
using Microsoft.AspNetCore.Http;

namespace AnhTu_Assig2.Pages.OrderCRUD
{
    public class IndexModel : PageModel
    {
        private readonly AnhTu_Assig2.Context.AppDBContext _context;

        public IndexModel(AnhTu_Assig2.Context.AppDBContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
          var id=  HttpContext.Session.GetInt32("cusIDSession");
            if (HttpContext.Session.GetInt32("TypeSession") == 0)
            {
                Order= await _context.Orders
                .Include(o => o.Customers).Where(o=>o.CustomerId==id).ToListAsync();
            }
            else
            {
                Order = await _context.Orders
                .Include(o => o.Customers).ToListAsync();
            }
            
        }
    }
}
