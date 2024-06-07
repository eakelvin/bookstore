using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using system.Data;
using system.Models;

namespace system.Controllers;
public class BooksController : Controller
{
    private readonly ApplicationDbContext dbContext;

    public BooksController(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public IActionResult Index()
    {
        return View();
    }

    // public IActionResult Add()
    // {
    //     return View();
    // }

    public IActionResult Add()
    {
        ViewBag.Authors = new SelectList(dbContext.Authors, "AuthorId", "Name");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(Book book)
    {
        if (ModelState.IsValid)
        {
            var authorExists = await dbContext.Authors.AnyAsync(a => a.AuthorId == book.AuthorId);
            if (!authorExists)
            {
                ModelState.AddModelError("AuthorId", "Author does not exist.");
                ViewBag.Authors = new SelectList(dbContext.Authors, "AuthorId", "Name", book.AuthorId);
                return View(book);
            }

            var newBook = new Book
            {
                Title = book.Title,
                ISBN = book.ISBN,
                Price = book.Price,
                BorrowingDate = book.BorrowingDate,
                AuthorId = book.AuthorId
            };
            await dbContext.Books.AddAsync(newBook);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List");
        }

        ViewBag.Authors = new SelectList(dbContext.Authors, "AuthorId", "Name", book.AuthorId);
        return View(book);
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var books = await dbContext.Books.Include(b => b.Author).ToListAsync();
        return View(books);
    }


    public async Task<IActionResult> Edit(Guid id)
    {
        var book = await dbContext.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        ViewBag.Authors = new SelectList(await dbContext.Authors.ToListAsync(), "AuthorId", "Name", book.AuthorId);
        return View(book);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Guid id, Book book)
    {
        if (ModelState.IsValid)
        {
            var authorExists = await dbContext.Authors.AnyAsync(
                a => a.AuthorId == book.AuthorId
            );
            if (!authorExists)
            {
                ModelState.AddModelError("AuthorId", "Author does not exist.");
                ViewBag.Authors = new SelectList(
                    await dbContext.Authors.ToListAsync(), "AuthorId", "Name", book.AuthorId
                );
                return View(book);
            }

            var work = await dbContext.Books.FindAsync(id);
            if (work == null)
            {
                return NotFound();
            }

            work.Title = book.Title;
            work.ISBN = book.ISBN;
            work.Price = book.Price;
            work.BorrowingDate = book.BorrowingDate;
            work.AuthorId = book.AuthorId;

            await dbContext.SaveChangesAsync();
            return RedirectToAction("List");
        }
        ViewBag.Authors = new SelectList(
            await dbContext.Authors.ToListAsync(), "AuthorId", "Name", book.AuthorId
        );
        return View(book);
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var book = await dbContext.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        dbContext.Books.Remove(book);
        await dbContext.SaveChangesAsync();
        return RedirectToAction("List");
    }

}