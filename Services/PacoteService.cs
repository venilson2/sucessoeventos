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
    public async Task<int> Create(PacoteModel entity)
    {
        throw new NotImplementedException();
    }

    public async Task<int> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<PacoteModel>> GetAll()
    {
        return await _dbContex.Pacotes.ToListAsync();
    }

    public async Task<PacoteModel> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<PacoteModel>> GetPacotesByIds(int[] ids)
    {
        return await _dbContex.Pacotes.Where(p => ids.Contains(p.CodPac)).ToListAsync();
    }

    public Task<int> Update(PacoteModel entity)
    {
        throw new NotImplementedException();
    }
}