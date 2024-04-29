using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SucessoEventos.Models;
using SucessoEventos.ViewModels;

namespace SucessoEventos.Controllers;

public class ParticipanteController : Controller
{
    private readonly ILogger<ParticipanteController> _logger;

    public ParticipanteController(ILogger<ParticipanteController> logger)
    {
        _logger = logger;
    }

    public IActionResult Create()
    {
        var viewModel = new DadosCadastroViewModel
        {
            Atividades =  new List<AtividadeViewModel>(),
            Pacotes = new List<PacoteViewModel>()
        };
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ParticipanteViewModel model)
    {
        if (!ModelState.IsValid){ 
            return View(model);
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
