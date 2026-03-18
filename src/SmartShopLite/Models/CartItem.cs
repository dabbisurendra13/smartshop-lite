namespace SmartShopLite.Models
{
    /// <summary>
    /// Represents an item in the shopping cart.
    /// </summary>
    public class CartItem
    {
        /// <summary>
        /// Gets or sets the referenced product identifier.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the display name for the cart item.
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// Gets or sets the price per unit.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the quantity ordered.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets the line total (Price * Quantity).
        /// </summary>
        public decimal Total => Price * Quantity;
    }
}
