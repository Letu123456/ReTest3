using AnhTu_Assig2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace AnhTu_Assig2.Pages.CustomerCRUD
{
    public class LoginModel : PageModel
    {
        private readonly AnhTu_Assig2.Context.AppDBContext _context;

        public LoginModel(AnhTu_Assig2.Context.AppDBContext context)
        {
            _context = context;
        }

        public  Customer customer {  get; set; }
        public class Login()
        {
            [Display(Name ="User Name")]
            [StringLength(20,MinimumLength =4)]
            public string UserName { get; set; }
            [Display(Name ="Password")]
            [StringLength(20,MinimumLength =3)]
            public string Password { get; set; }
        }
        [BindProperty]
        public Login login { get; set; }

        public string UserSession {  get; set; }
        public IActionResult OnPost(Login login)
        {
           var custom = _context.Customers.Where(x=>x.ContactName == login.UserName && x.Password == 
           login.Password).FirstOrDefault();
            if (custom != null)
            {
                HttpContext.Session.SetString("AddressSession", custom.Address);
                HttpContext.Session.SetInt32("cusIDSession", custom.CustomerId);
                HttpContext.Session.SetInt32("TypeSession", custom.Type);
                HttpContext.Session.SetString("UserSession", custom.ContactName);
                
                //UserSession = HttpContext.Session.GetString("UserSession");

                return RedirectToPage("/Index");
            }
            else
            {
                ViewData["Message"] = "Login failes...";
                return Page();
            }

            
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");
                return RedirectToPage("/CustomerCRUD/Login");


            }
           

            return Page();
        }
    }
}
