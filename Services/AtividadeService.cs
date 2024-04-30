using Microsoft.EntityFrameworkCore;
using SucessoEventos.Interfaces;
using SucessoEventos.Models;

namespace SucessoEventos.Services;

public class AtividadeService : IAtividadeService
{
    private readonly AppDbContext _dbContex;

    public AtividadeService(AppDbContext dbContex)
    {
        _dbContex = dbContex;
    }

    public async Task<IEnumerable<AtividadeModel>> GetAll()
    {
        return await _dbContex.Atividades.ToListAsync();
    }

    public async Task<List<AtividadeModel>> GetAtividadeByIds(int[] ids)
    {
        return await _dbContex.Atividades.Where(p => ids.Contains(p.CodAtv)).ToListAsync();
    }
}