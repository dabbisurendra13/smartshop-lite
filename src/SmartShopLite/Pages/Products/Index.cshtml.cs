using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartShopLite.Models;
using SmartShopLite.Services;

namespace SmartShopLite.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public IReadOnlyList<Product> Products { get; private set; } = Array.Empty<Product>();

        [BindProperty(SupportsGet = true)]
        public string? SearchQuery { get; set; }

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
    }
}
