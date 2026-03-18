using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartShopLite.Models;
using SmartShopLite.Services;

namespace SmartShopLite.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly IProductService _productService;

        public DetailsModel(IProductService productService)
        {
            _productService = productService;
        }

        public Product? Product { get; private set; }

        public IActionResult OnGet(int id)
        {
            Product = _productService.GetById(id);
            if (Product is null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
