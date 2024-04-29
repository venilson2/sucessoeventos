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
    public async Task<int> Create(AtividadeModel entity)
    {
        throw new NotImplementedException();
    }

    public async Task<int> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<AtividadeModel>> GetAll()
    {
        return await _dbContex.Atividades.ToListAsync();
    }

    public async Task<AtividadeModel> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> Update(AtividadeModel entity)
    {
        throw new NotImplementedException();
    }
}