using SmartShopLite.Models;

namespace SmartShopLite.Services
{
    /// <summary>
    /// Provides shopping cart functionality backed by session storage.
    /// </summary>
    public interface ICartService
    {
        /// <summary>
        /// Gets the current items in the cart.
        /// </summary>
        IReadOnlyList<CartItem> GetItems();

        /// <summary>
        /// Adds a product to the cart.
        /// </summary>
        void AddItem(Product product, int quantity = 1);

        /// <summary>
        /// Removes an item from the cart.
        /// </summary>
        void RemoveItem(int productId);

        /// <summary>
        /// Updates the quantity of a specific cart item.
        /// </summary>
        void UpdateQuantity(int productId, int quantity);

        /// <summary>
        /// Empties the cart.
        /// </summary>
        void Clear();

        /// <summary>
        /// Gets the cart total value.
        /// </summary>
        decimal GetTotal();

        /// <summary>
        /// Gets the total number of items in the cart.
        /// </summary>
        int GetCount();
    }
}
