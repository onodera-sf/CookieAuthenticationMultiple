using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookieAuthenticationMultipleMvc.Controllers
{
  [Authorize(AuthenticationSchemes = "FirstAuth")]
  public class HomeFirstController : Controller
  {
    public IActionResult Index() => View();
  }
}