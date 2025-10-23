using Microsoft.AspNetCore.Mvc;

namespace API_Biblioteca_01.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
