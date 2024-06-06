using Microsoft.AspNetCore.Mvc;

namespace system.Controllers;
public class BooksController : Controller
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