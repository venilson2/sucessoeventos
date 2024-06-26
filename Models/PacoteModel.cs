using System.ComponentModel.DataAnnotations;

namespace SucessoEventos.Models;
public class PacoteModel
{
    [Key]
    public int CodPac { get; set; } // PK
    public decimal Preco { get; set; }
    public string Descricao { get; set; }
    public virtual ICollection<ParticipanteModel> Participantes { get; set; }
}