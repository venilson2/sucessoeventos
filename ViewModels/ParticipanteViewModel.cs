using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SucessoEventos.ViewModels;
public class ParticipanteViewModel
{
    public int CodPar { get; set; }
    [StringLength(30)]
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
    [Display(Name = "Data de Nascimento")]
    public string DataNascimento { get; set; }

    [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
    public string Telefone { get; set; }

    [Display(Name = "Pacotes")]
    public int ListaPacotes { get; set; }
    public ICollection<PacoteViewModel> Pacotes { get; set; }

    // public List<string> GenerosSelecionados { get; set; }

    // public List<SelectListItem> OpcoesGenero { get; set; } = new List<SelectListItem>
    // {
    //     new SelectListItem { Text = "Masculino", Value = "M" },
    //     new SelectListItem { Text = "Feminino", Value = "F" },
    //     new SelectListItem { Text = "Outro", Value = "O" }
    // };

    // [Display(Name = "Electric Fan")]
    // public bool ElectricFan { get; set; }

    // private string electricFanRate;

    // public string ElectricFanRate
    // {
    //     get { return electricFanRate ?? (electricFanRate = "$15/month"); }
    //     set { electricFanRate = value; }
    // }
}