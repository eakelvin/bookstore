using Microsoft.AspNetCore.Mvc;

namespace system.Controllers;

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}