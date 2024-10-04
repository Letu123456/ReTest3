using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AnhTu_Assig2.Context;
using AnhTu_Assig2.Models;

namespace AnhTu_Assig2.Pages.OrderCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly AnhTu_Assig2.Context.AppDBContext _context;

        public DetailsModel(AnhTu_Assig2.Context.AppDBContext context)
        {
            _context = context;
        }

        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                Order = order;
            }
            return Page();
        }
    }
}
