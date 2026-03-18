using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartShopLite.Services;

namespace SmartShopLite.Pages.Cart
{
    public class IndexModel : PageModel
    {
        private readonly ICartService _cartService;

        public IndexModel(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IReadOnlyList<Models.CartItem> Items { get; private set; } = Array.Empty<Models.CartItem>();

        public decimal Total { get; private set; }

        public void OnGet()
        {
            Items = _cartService.GetItems();
            Total = _cartService.GetTotal();
        }

        public IActionResult OnPost([FromForm] Dictionary<int, int> quantities, [FromForm] string? action, [FromForm] int? remove)
        {
            if (action == "clear")
            {
                _cartService.Clear();
            }
            else if (remove.HasValue)
            {
                _cartService.RemoveItem(remove.Value);
            }
            else if (action == "update")
            {
                foreach (var kvp in quantities)
                {
                    _cartService.UpdateQuantity(kvp.Key, kvp.Value);
                }
            }

            return RedirectToPage();
        }
    }
}
