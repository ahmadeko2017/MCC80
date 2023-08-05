using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class StarWarsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}