using Microsoft.AspNetCore.Mvc;

namespace Site.EndPoint.Controllers;

public class AccountController : Controller
{
    // GET
    public IActionResult Login()
    {
        return View();
    }
}