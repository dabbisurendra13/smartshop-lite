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

        public void OnGet()
        {
            Products = _productService.GetAll().ToList();
        }
    }
}
