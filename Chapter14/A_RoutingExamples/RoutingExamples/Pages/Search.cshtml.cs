using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#nullable disable

namespace RoutingExamples.Pages;

//Routing template: Search/{handler?}
public class SearchModel : PageModel
{
    private readonly LinkGenerator _link;
    private readonly ProductService _productService;

    public SearchModel
        (LinkGenerator link,
        ProductService productService)
    {
        _link = link;
        _productService = productService;
    }

    [BindProperty, Required]
    public string SearchTerm { get; set; }

    public List<Product> Results { get; private set; }

    public void OnGet()
    {
        // Demonstrates link generation 
        var url1 = Url.Page("ProductDetails/Index", new { productName = "big-widget" });
        var url2= _link.GetPathByPage("/ProductDetails/Index", values: new { productName = "big-widget" });
        var url3 = _link.GetPathByPage(HttpContext, "/ProductDetails/Index", values: new { productName = "big-widget" });
        var url4 = _link.GetUriByPage(
            page: "/ProductDetails/Index",
            handler: null,
            values: new { productName = "big-widget" },
            scheme: "https",
            host: new HostString("example.com"));
    }

    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            Results = _productService.Search(SearchTerm, StringComparison.Ordinal);
        }
    }

    public void OnPostIgnoreCase()
    {
        if (ModelState.IsValid)
        {
            Results = _productService.Search(SearchTerm, StringComparison.OrdinalIgnoreCase);
        }
    }
}