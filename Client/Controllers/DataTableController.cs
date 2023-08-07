using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class DataTableController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}