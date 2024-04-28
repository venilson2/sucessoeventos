using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SucessoEventos.Models;
public class AtividadeModel
{
    [Key]
    public int CodAtv { get; set; } // PK
    public string DescAtv { get; set; }
    public int Vagas { get; set; }
    public decimal Preco { get; set; }
    public virtual ICollection<ParticipanteModel> Participantes { get; set; }
}