using Microsoft.EntityFrameworkCore;
using SucessoEventos.Interfaces;
using SucessoEventos.Models;

namespace SucessoEventos.Services;

public class AtividadeService : IAtividadeService
{
    private readonly AppDbContext _dbContext;

    public AtividadeService(AppDbContext dbContex)
    {
        _dbContext = dbContex;
    }

    public async Task<IEnumerable<AtividadeModel>> GetAll()
    {
        return await _dbContext.Atividades.ToListAsync();
    }

    public async Task<List<AtividadeModel>> GetAtividadeByIds(IEnumerable<int> ids)
    {
        return await _dbContext.Atividades.Where(p => ids.Contains(p.CodAtv)).ToListAsync();
    }
}