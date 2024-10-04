namespace AnhTu_Assig2.Models
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int? Quantity { get; set; }
    }

    public class ShoppingCart
    {
        public List<CartItem> Items { get; private set; } = new List<CartItem>();

        public void AddItem(Product product, int? quantity)
        {
            var existingItem = Items.FirstOrDefault(i => i.Product.ProductId == product.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new CartItem { Product = product, Quantity = quantity });
            }
        }

        public void RemoveItem(int productId)
        {
            var item = Items.FirstOrDefault(i => i.Product.ProductId == productId);
            if (item != null)
            {
                Items.Remove(item);
            }
        }

        public double? GetTotalPrice()
        {
            return Items.Sum(i => i.Product.UnitPrice * i.Quantity);
        }
    }
}
