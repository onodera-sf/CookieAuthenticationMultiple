using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookieAuthenticationMultipleMvc.Controllers
{
  [Authorize(AuthenticationSchemes = "SecondAuth")]
  public class HomeSecondController : Controller
  {
    public IActionResult Index() => View();
  }
}