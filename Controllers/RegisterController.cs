using Microsoft.AspNetCore.Mvc;

namespace system.Controllers;

public class RegisterController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}