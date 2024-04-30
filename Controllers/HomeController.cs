using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SucessoEventos.Models;

namespace SucessoEventos.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
}
