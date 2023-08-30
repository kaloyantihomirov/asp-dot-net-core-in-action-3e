using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#nullable disable

namespace RoutingExamples.Pages.ProductDetails;

//Route template: ProductDetails/{productName}
public class IndexModel : PageModel
{
    private readonly ProductService _service;

    public IndexModel(ProductService service)
    {
        _service = service;
    }

    public Product Selected { get; set; }
  
    public IActionResult OnGet(string productName)
    {
        Selected = _service.GetProduct(productName);

        if (Selected is null)
        {
            return NotFound();
        }

        return Page();
    }

}