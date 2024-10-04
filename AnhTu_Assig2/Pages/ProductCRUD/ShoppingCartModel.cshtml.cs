using AnhTu_Assig2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnhTu_Assig2.Pages.ProductCRUD
{
    public class ShoppingCartModelModel : PageModel
    {
        private readonly AnhTu_Assig2.Context.AppDBContext _context;

        public ShoppingCartModelModel(AnhTu_Assig2.Context.AppDBContext context)
        {
            _context = context;
        }

        public ShoppingCart Cart { get; set; } = new ShoppingCart();
        
       

        public IActionResult OnGet()
        {
            Cart = GetCart();
            return Page();
        }

        public IActionResult OnPostAddToCart(int productId,int? quatity)
        {
            if (HttpContext.Session.GetInt32("cusIDSession") == null)
            {
                return RedirectToPage("/CustomerCRUD/Login");
            }

            var product = _context.Products.Find(productId);
            if (product == null)
            {
                return NotFound();
            }
            if(quatity!=null) {
                var cart = GetCart();
                cart.AddItem(product, quatity);
                SaveCart(cart);
            }
            else
            {
                var cart = GetCart();
                cart.AddItem(product, 1 );
                SaveCart(cart);

            }

            return RedirectToPage("/Index");
        }

        public IActionResult OnPostCheckout()
        {
            var cart = GetCart();
            Random rand = new Random();
            int random = rand.Next(10000,50000);
           double? total = cart.GetTotalPrice();
            if (cart.Items.Count == 0)
            {
                return RedirectToPage();
            }
            var cusId = HttpContext.Session.GetInt32("cusIDSession");
            var address = HttpContext.Session.GetString("AddressSession");
            // Create a new order
            var order = new Order
            {
                CustomerId = (int)cusId,
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now.AddDays(7),
                ShippedDate = DateTime.Now.AddDays(3),
                Freight =random , // Example value
                ShipAddress = address
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            // Add order details
            foreach (var item in cart.Items)
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = order.OrderId,
                    ProductId = item.Product.ProductId,
                    UnitPrice = total,
                    Quantity = item.Quantity
                };

                _context.OrderDetails.Add(orderDetail);
            }

            _context.SaveChanges();

            // Clear the cart
            HttpContext.Session.Remove("Cart");

            return RedirectToPage("/Index");
        }

        private ShoppingCart GetCart()
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart");
            if (cart == null)
            {
                cart = new ShoppingCart();
            }
            return cart;
        }

        private void SaveCart(ShoppingCart cart)
        {
            HttpContext.Session.SetObjectAsJson("Cart", cart);
        }
    }
}

