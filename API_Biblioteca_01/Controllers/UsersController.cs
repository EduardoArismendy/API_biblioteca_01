using Microsoft.AspNetCore.Mvc;

namespace API_Biblioteca_01.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
