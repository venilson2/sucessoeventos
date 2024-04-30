using System.ComponentModel.DataAnnotations;

namespace SucessoEventos.Models;
public class PacoteParticipanteModel
{
    public int CodPar { get; set; }
    public ParticipanteModel Participante { get; set; }

    public int CodPac { get; set; }
    public PacoteModel Pacote { get; set; }
}