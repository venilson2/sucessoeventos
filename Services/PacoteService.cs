using Microsoft.EntityFrameworkCore;
using SucessoEventos.Interfaces;
using SucessoEventos.Models;

namespace SucessoEventos.Services;

public class PacoteService : IPacoteService
{
    private readonly AppDbContext _dbContext;

    public PacoteService(AppDbContext dbContex)
    {
        _dbContext = dbContex;
    }

    public async Task<IEnumerable<PacoteModel>> GetAll()
    {
        return await _dbContext.Pacotes.ToListAsync();
    }

    public async Task<List<PacoteModel>> GetPacotesByIds(IEnumerable<int> ids)
    {
        return await _dbContext.Pacotes.Where(p => ids.Contains(p.CodPac)).ToListAsync();
    }
}