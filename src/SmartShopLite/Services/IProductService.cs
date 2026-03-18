using SmartShopLite.Models;

namespace SmartShopLite.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
    }
}
