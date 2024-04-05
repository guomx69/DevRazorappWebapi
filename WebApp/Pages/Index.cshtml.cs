using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

            if(User.Identity.IsAuthenticated){
                 bool isAdmin=User.IsInRole("admin"); 
                 System.Console.WriteLine("Is User Authenticated:::: "+ isAdmin);   
            }
    }
}
