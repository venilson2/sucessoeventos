using System.Diagnostics;
using System.Globalization;
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
        if(model.CodPacSelecionados != null){
            var pacotes = await _pacoteService.GetPacotesByIds(model.CodPacSelecionados);

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
        try
        {
            ParticipanteModel participante = new ParticipanteModel
            {
                Nome = model.Nome,
                Telefone = model.Telefone,
                DataNascimento = DateTime.ParseExact(model.DataNascimento, "dd/MM/yyyy", CultureInfo.InvariantCulture),
            };

            var pacotes = new List<PacoteModel>();
            foreach (var pacote in model.Pacotes)
            {
                pacotes.Add(new PacoteModel
                {
                    CodPac = pacote.CodPac,
                    Descricao = pacote.Descricao,
                    Preco = pacote.Preco
                });
            }

            var atividades = new List<AtividadeModel>();
            foreach (var atividade in model.Atividades)
            {
                atividades.Add(new AtividadeModel
                {
                    CodAtv = atividade.CodAtv,
                    DescAtv = atividade.DescAtv,
                    Vagas = atividade.Vagas,
                    Preco = atividade.Preco
                });
            }

            await _participanteService.Create(participante, pacotes, atividades);
            
            TempData["ToastSuccess"] = "Dados salvos com sucesso!";

            return RedirectToAction("Form");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Error", "Home");
        }
    }
}
