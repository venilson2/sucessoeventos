using SucessoEventos.Models;

namespace SucessoEventos.Interfaces;

    public interface IParticipanteService
    {
        Task<IEnumerable<ParticipanteModel>> GetAll();
        Task<int> Create(ParticipanteModel entity, List<PacoteModel> pacotes, List<AtividadeModel> atividades);
    }