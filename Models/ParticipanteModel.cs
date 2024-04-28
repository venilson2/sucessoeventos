using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SucessoEventos.Models;
public class ParticipanteModel
{
    [Key]
    public int CodPar { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public DateTime DataNascimento { get; set; }
    [Required]
    public string Telefone { get; set; }
    public virtual ICollection<AtividadeModel> Atividades { get; set; }
    public virtual ICollection<PacoteModel> Pacotes { get; set; }
}