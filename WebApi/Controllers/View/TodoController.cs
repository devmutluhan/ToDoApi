using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.View
{
    public class TodoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
