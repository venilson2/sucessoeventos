using Microsoft.EntityFrameworkCore;
using SucessoEventos.Interfaces;
using SucessoEventos.Models;

namespace SucessoEventos.Services;

public class PacoteService : IPacoteService
{
    private readonly AppDbContext _dbContex;

    public PacoteService(AppDbContext dbContex)
    {
        _dbContex = dbContex;
    }

    public async Task<IEnumerable<PacoteModel>> GetAll()
    {
        return await _dbContex.Pacotes.ToListAsync();
    }

    public async Task<List<PacoteModel>> GetPacotesByIds(IEnumerable<int> ids)
    {
        return await _dbContex.Pacotes.Where(p => ids.Contains(p.CodPac)).ToListAsync();
    }
}