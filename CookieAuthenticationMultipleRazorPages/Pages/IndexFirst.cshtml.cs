using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookieAuthenticationMultipleRazorPages.Pages
{
  [Authorize(AuthenticationSchemes = "FirstAuth")]
  public class IndexFirstModel : PageModel
  {
    private readonly ILogger<IndexFirstModel> _logger;

    public IndexFirstModel(ILogger<IndexFirstModel> logger)
    {
      _logger = logger;
    }

    public void OnGet() { }
  }
}