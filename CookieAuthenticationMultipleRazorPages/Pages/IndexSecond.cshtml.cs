using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookieAuthenticationMultipleRazorPages.Pages
{
  [Authorize(AuthenticationSchemes = "SecondAuth")]
  public class IndexSecondModel : PageModel
  {
    private readonly ILogger<IndexSecondModel> _logger;

    public IndexSecondModel(ILogger<IndexSecondModel> logger)
    {
      _logger = logger;
    }

    public void OnGet() { }
  }
}