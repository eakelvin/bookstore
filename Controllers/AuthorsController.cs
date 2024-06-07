using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using system.Data;
using system.Models;

namespace system.Controllers;

public class AuthorsController : Controller
{
    private readonly ApplicationDbContext dbContext;

    public AuthorsController(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(Author author)
    {
        var auth = new Author
        {
            Name = author.Name,
            Biography = author.Biography
        };
        await dbContext.Authors.AddAsync(auth);
        await dbContext.SaveChangesAsync();

        // return View();
        return RedirectToAction("List");
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var authors = await dbContext.Authors.Include(a => a.Books).ToListAsync();
        return View(authors);
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var author = await dbContext.Authors.FindAsync(id);
        if (author == null)
        {
            return NotFound();
        }
        return View(author);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Author author)
    {
        dbContext.Update(author);
        await dbContext.SaveChangesAsync();
        return RedirectToAction("List");
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var author = await dbContext.Authors.FindAsync(id);
        if (author == null)
        {
            return NotFound();
        }
        dbContext.Authors.Remove(author);
        await dbContext.SaveChangesAsync();
        return RedirectToAction("List");
    }
}