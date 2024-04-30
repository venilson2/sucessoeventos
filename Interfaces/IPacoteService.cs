using SucessoEventos.Models;

namespace SucessoEventos.Interfaces;

    public interface IPacoteService
    {
        Task<IEnumerable<PacoteModel>> GetAll();
        Task<List<PacoteModel>> GetPacotesByIds(int[] ids);
    }