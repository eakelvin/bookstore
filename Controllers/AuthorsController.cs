using Microsoft.AspNetCore.Mvc;

namespace system.Controllers;

public class AuthorsController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Add()
    {
        return View();
    }
}