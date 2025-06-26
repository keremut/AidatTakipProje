using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AidatTakip.Models;

namespace AidatTakip.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
