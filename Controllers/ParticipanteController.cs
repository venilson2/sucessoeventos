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
        IEnumerable<PacoteModel> pacotes = await _pacoteService.GetAll();
        IEnumerable<AtividadeModel> atividades = await _atividadeService.GetAll();

        List<AtividadeViewModel> atividadesViewModel = atividades.Select(a => new AtividadeViewModel {
            CodAtv = a.CodAtv,
            DescAtv = a.DescAtv,
            Vagas = a.Vagas,        
            Preco = a.Preco,
            Selected = false
        }).ToList();

        List<PacoteViewModel> pacotesViewModel = pacotes.Select(c => new PacoteViewModel {
            CodPac = c.CodPac,
            Descricao = c.Descricao,
            Preco = c.Preco
        }).ToList();

        var model = new ParticipanteViewModel
        {
            Pacotes  = pacotesViewModel,
            Atividades = atividadesViewModel
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ParticipanteViewModel model)
    {
        if (!ModelState.IsValid){ 
            model.Pacotes = new List<PacoteViewModel>
            {
                new PacoteViewModel { CodPac = 10, Descricao = "Descrição 1", Preco = 10.0m },
                new PacoteViewModel { CodPac = 99, Descricao = "Descrição 2", Preco = 20.0m }
            };
            model.Atividades = new List<AtividadeViewModel>
            {
                new AtividadeViewModel {CodAtv = 5, DescAtv = "Decrição 5", Preco = 10.0m, Vagas = 10},
                new AtividadeViewModel {CodAtv = 7, DescAtv = "Decrição 7", Preco = 20.0m, Vagas = 20},
                new AtividadeViewModel {CodAtv = 50, DescAtv = "Decrição 50", Preco = 99.0m, Vagas = 11},
                new AtividadeViewModel {CodAtv = 58, DescAtv = "Decrição 58", Preco = 50.0m, Vagas = 6},
            };
            return View(model);
        }
        return RedirectToAction("Review", model);
    }

    public async Task<IActionResult> Review(ParticipanteViewModel model)
    {
        if(model.CodPac != null){
            var pacotes = await _pacoteService.GetPacotesByIds(model.CodPac);
        }
        if(model.CodAtv != null){
            var atividades = await _atividadeService.GetAtividadeByIds(model.CodAtv);
        }
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
