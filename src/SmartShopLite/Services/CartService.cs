using System.Text.Json;
using SmartShopLite.Models;

namespace SmartShopLite.Services
{
    /// <summary>
    /// A simple in-memory shopping cart implementation that stores cart items in session.
    /// </summary>
    public class CartService : ICartService
    {
        private const string SessionKey = "SmartShopLite.Cart";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ISession Session => _httpContextAccessor.HttpContext?.Session ?? throw new InvalidOperationException("Session is not available.");

        private List<CartItem> LoadCart()
        {
            var json = Session.GetString(SessionKey);
            if (string.IsNullOrEmpty(json))
            {
                return new List<CartItem>();
            }

            return JsonSerializer.Deserialize<List<CartItem>>(json) ?? new List<CartItem>();
        }

        private void SaveCart(List<CartItem> items)
        {
            Session.SetString(SessionKey, JsonSerializer.Serialize(items));
        }

        public IReadOnlyList<CartItem> GetItems()
        {
            return LoadCart();
        }

        public void AddItem(Product product, int quantity = 1)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            var items = LoadCart();
            var existing = items.FirstOrDefault(x => x.ProductId == product.Id);
            if (existing != null)
            {
                existing.Quantity += quantity;
            }
            else
            {
                items.Add(new CartItem
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = Math.Max(1, quantity)
                });
            }

            SaveCart(items);
        }

        public void RemoveItem(int productId)
        {
            var items = LoadCart();
            items.RemoveAll(x => x.ProductId == productId);
            SaveCart(items);
        }

        public void UpdateQuantity(int productId, int quantity)
        {
            var items = LoadCart();
            var item = items.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
            {
                if (quantity <= 0)
                {
                    items.Remove(item);
                }
                else
                {
                    item.Quantity = quantity;
                }

                SaveCart(items);
            }
        }

        public void Clear()
        {
            SaveCart(new List<CartItem>());
        }

        public decimal GetTotal()
        {
            return LoadCart().Sum(x => x.Total);
        }

        public int GetCount()
        {
            return LoadCart().Sum(x => x.Quantity);
        }
    }
}
