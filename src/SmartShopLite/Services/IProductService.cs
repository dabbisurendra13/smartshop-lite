using SmartShopLite.Models;

namespace SmartShopLite.Services
{
    /// <summary>
    /// Provides access to product catalog data.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets all available products.
        /// </summary>
        IEnumerable<Product> GetAll();

        /// <summary>
        /// Gets a single product by identifier.
        /// </summary>
        Product? GetById(int id);
    }
}
