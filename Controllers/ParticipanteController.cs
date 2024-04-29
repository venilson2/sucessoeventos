using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SucessoEventos.Interfaces;
using SucessoEventos.Models;
using SucessoEventos.ViewModels;

namespace SucessoEventos.Controllers;

public class ParticipanteController : Controller
{
    private readonly IParticipanteService _participanteService;
    private readonly IPacoteService _pacoteService;
    private readonly IAtividadeService _atividadeService;

    public ParticipanteController(
        IParticipanteService participanteService,
        IAtividadeService atividadeService,
        IPacoteService pacoteService
    )
    {
        _participanteService = participanteService;
        _atividadeService = atividadeService;
        _pacoteService = pacoteService;
    }

    public async Task<IActionResult> Create()
    {
        // IEnumerable<PacoteModel> pacotes = await _pacoteService.GetAll();
        // IEnumerable<AtividadeModel> atividades = await _atividadeService.GetAll();

        // List<AtividadeViewModel> atividadesViewModel = atividades.Select(a => new AtividadeViewModel {
        //     CodAtv = a.CodAtv,
        //     DescAtv = a.DescAtv,
        //     Vagas = a.Vagas,        
        //     Preco = a.Preco,
        //     Selected = false
        // }).ToList();

        // List<PacoteViewModel> pacotesViewModel = pacotes.Select(c => new PacoteViewModel {
        //     CodPac = c.CodPac,
        //     Descricao = c.Descricao,
        //     Preco = c.Preco
        // }).ToList();

        var model = new ParticipanteViewModel
            {
                PacotesDisponiveis  = new List<PacoteViewModel>
                {
                    new PacoteViewModel { CodPac = 10, Descricao = "Descrição 1", Preco = 10.0m },
                    new PacoteViewModel { CodPac = 99, Descricao = "Descrição 2", Preco = 20.0m }
                }
            };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ParticipanteViewModel model)
    {
        if (!ModelState.IsValid){ 
            model.PacotesDisponiveis = new List<PacoteViewModel>
            {
                new PacoteViewModel { CodPac = 10, Descricao = "Descrição 1", Preco = 10.0m },
                new PacoteViewModel { CodPac = 99, Descricao = "Descrição 2", Preco = 20.0m }
            };
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
