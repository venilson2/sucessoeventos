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

    public async Task<IActionResult> Form()
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
    public async Task<IActionResult> Form(ParticipanteViewModel model)
    {
        IEnumerable<PacoteModel> pacotes = await _pacoteService.GetAll();
        IEnumerable<AtividadeModel> atividades = await _atividadeService.GetAll();

        if (!ModelState.IsValid)
        { 
            model.Pacotes = pacotes.Select(c => new PacoteViewModel {
                CodPac = c.CodPac,
                Descricao = c.Descricao,
                Preco = c.Preco
            }).ToList();
            
            model.Atividades = atividades.Select(a => new AtividadeViewModel {
                CodAtv = a.CodAtv,
                DescAtv = a.DescAtv,
                Vagas = a.Vagas,        
                Preco = a.Preco,
                Selected = false
            }).ToList();

            return View(model);
        }
        return RedirectToAction("Review", model);
    }


    public async Task<IActionResult> Review(ParticipanteViewModel model)
    {
        if(model.CodPac != null){
            var pacotes = await _pacoteService.GetPacotesByIds(model.CodPac);

            model.Pacotes = pacotes.Select(c => new PacoteViewModel {
                CodPac = c.CodPac,
                Descricao = c.Descricao,
                Preco = c.Preco
            }).ToList();
        }
        
        if(model.CodAtv != null){
            var atividades = await _atividadeService.GetAtividadeByIds(model.CodAtv);

            model.Atividades = atividades.Select(a => new AtividadeViewModel {
                CodAtv = a.CodAtv,
                DescAtv = a.DescAtv,
                Vagas = a.Vagas,        
                Preco = a.Preco,
                Selected = false
            }).ToList();
        }
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ParticipanteViewModel model)
    {
        return RedirectToAction("Form");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
