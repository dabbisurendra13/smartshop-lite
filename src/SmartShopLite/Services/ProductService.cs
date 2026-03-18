using SmartShopLite.Models;

namespace SmartShopLite.Services
{
    /// <summary>
    /// A simple in-memory product catalog for demo purposes.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new()
        {
            new Product
            {
                Id = 1,
                Name = "SmartShop Lite Coffee Mug",
                Description = "A sleek ceramic mug to enjoy your coffee while you code.",
                Price = 12.99m,
                ImageUrl = "https://via.placeholder.com/300x200?text=Coffee+Mug"
            },
            new Product
            {
                Id = 2,
                Name = "Wireless Keyboard",
                Description = "Compact wireless keyboard with backlight and quiet keys.",
                Price = 49.99m,
                ImageUrl = "https://via.placeholder.com/300x200?text=Wireless+Keyboard"
            },
            new Product
            {
                Id = 3,
                Name = "Noise-Cancelling Headphones",
                Description = "Over-ear headphones with active noise cancellation.",
                Price = 89.99m,
                ImageUrl = "https://via.placeholder.com/300x200?text=Headphones"
            }
        };

        /// <summary>
        /// Gets all available products.
        /// </summary>
        public IEnumerable<Product> GetAll() => _products;

        /// <summary>
        /// Gets a single product by its identifier.
        /// </summary>
        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);
    }
}
