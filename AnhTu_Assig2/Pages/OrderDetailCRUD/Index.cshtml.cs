using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AnhTu_Assig2.Context;
using AnhTu_Assig2.Models;

namespace AnhTu_Assig2.Pages.OrderDetailCRUD
{
    public class IndexModel : PageModel
    {
        private readonly AnhTu_Assig2.Context.AppDBContext _context;

        public IndexModel(AnhTu_Assig2.Context.AppDBContext context)
        {
            _context = context;
        }

        public IList<OrderDetail> OrderDetail { get;set; } = default!;

        public async Task OnGetAsync(int? id)
        {
            if (id != null)
            {
                OrderDetail = await _context.OrderDetails
                .Include(o => o.Orders)
                .Include(o => o.Products).Where(o=>o.OrderId == id).ToListAsync();
            }
            else {
                OrderDetail = await _context.OrderDetails
                .Include(o => o.Orders)
                .Include(o => o.Products).ToListAsync();
            }
            
        }
    }
}
