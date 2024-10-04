using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AnhTu_Assig2.Context;
using AnhTu_Assig2.Models;

namespace AnhTu_Assig2.Pages.CategoryCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly AnhTu_Assig2.Context.AppDBContext _context;

        public DeleteModel(AnhTu_Assig2.Context.AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Categories Categories { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categories = await _context.Categories.FirstOrDefaultAsync(m => m.CategoryId == id);

            if (categories == null)
            {
                return NotFound();
            }
            else
            {
                Categories = categories;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categories = await _context.Categories.FindAsync(id);
            if (categories != null)
            {
                Categories = categories;
                _context.Categories.Remove(Categories);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
