using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartShopLite.Models;
using SmartShopLite.Services;

namespace SmartShopLite.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public DetailsModel(IProductService productService, ICartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }

        public Product? Product { get; private set; }

        [TempData]
        public string? Message { get; set; }

        public IActionResult OnGet(int id)
        {
            Product = _productService.GetById(id);
            if (Product is null)
            {
                return NotFound();
            }

            return Page();
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

            return RedirectToPage(new { id = productId });
        }
    }
}
