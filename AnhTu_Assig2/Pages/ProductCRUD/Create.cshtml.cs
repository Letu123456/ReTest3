﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AnhTu_Assig2.Context;
using AnhTu_Assig2.Models;

namespace AnhTu_Assig2.Pages.ProductCRUD
{
    public class CreateModel : PageModel
    {
        private readonly AnhTu_Assig2.Context.AppDBContext _context;

        public CreateModel(AnhTu_Assig2.Context.AppDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryName"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
        ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
