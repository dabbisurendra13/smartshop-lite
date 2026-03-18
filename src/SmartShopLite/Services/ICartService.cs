using SmartShopLite.Models;

namespace SmartShopLite.Services
{
    public interface ICartService
    {
        IReadOnlyList<CartItem> GetItems();
        void AddItem(Product product, int quantity = 1);
        void RemoveItem(int productId);
        void UpdateQuantity(int productId, int quantity);
        void Clear();
        decimal GetTotal();
        int GetCount();
    }
}
