using System.ComponentModel.DataAnnotations;

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
    public IEnumerable<int>? CodPac  { get; set; }
    public List<PacoteViewModel>? Pacotes  { get; set; }

    [Display(Name = "Atividades")]
    public IEnumerable<int>? CodAtv { get; set; }
    public List<AtividadeViewModel>? Atividades { get; set; }
}