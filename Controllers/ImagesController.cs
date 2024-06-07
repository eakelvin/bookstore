using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace system.Controllers
{
    public class ImagesController : Controller
    {
        public IActionResult DisplayImage(string imageName)
        {
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageName);
            var imageFileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            return new FileStreamResult(imageFileStream, "image/png");
        }
    }
}
