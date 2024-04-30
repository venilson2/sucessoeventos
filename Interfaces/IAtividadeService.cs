using SucessoEventos.Models;

namespace SucessoEventos.Interfaces;

    public interface IAtividadeService
    {
        Task<IEnumerable<AtividadeModel>> GetAll();
        Task<List<AtividadeModel>> GetAtividadeByIds(IEnumerable<int> ids);
    }