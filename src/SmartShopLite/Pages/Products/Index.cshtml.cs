using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartShopLite.Models;
using SmartShopLite.Services;

namespace SmartShopLite.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public IndexModel(IProductService productService, ICartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }

        public IReadOnlyList<Product> Products { get; private set; } = Array.Empty<Product>();

        [BindProperty(SupportsGet = true)]
        public string? SearchQuery { get; set; }

        [TempData]
        public string? Message { get; set; }

        public void OnGet()
        {
            var products = _productService.GetAll();

            if (!string.IsNullOrWhiteSpace(SearchQuery))
            {
                SearchQuery = SearchQuery.Trim();
                Products = products
                    .Where(p => p.Name.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)
                                || p.Description.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            else
            {
                Products = products.ToList();
            }
        }

        public IActionResult OnPost(int productId)
        {
            var product = _productService.GetById(productId);
            if (product is null)
            {
                return NotFound();
            }

            _cartService.AddItem(product);
            Message = "Added to cart.";

            return RedirectToPage();
        }
    }
}
