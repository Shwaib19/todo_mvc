using Microsoft.AspNetCore.Mvc;

namespace todo_mvc.Controller;

public class TodoApiController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}