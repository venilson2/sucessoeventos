
namespace SucessoEventos.Models;
public class AtividadeParticipanteModel
{
    public int CodPar { get; set; }
    public ParticipanteModel Participante { get; set; }

    public int CodAtv { get; set; }
    public AtividadeModel Atividade { get; set; }
}