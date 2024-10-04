using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnhTu_Assig2.Pages
{
    public class Layout : PageModel
    {
        public IActionResult GetSession()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewData["MySession"] = HttpContext.Session.GetString("UserSession").ToString();
            }
            return Page();
        }
    }
}
