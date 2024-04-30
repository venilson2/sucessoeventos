using Microsoft.EntityFrameworkCore;
using SucessoEventos.Interfaces;
using SucessoEventos.Models;

namespace SucessoEventos.Services;

public class ParticipanteService : IParticipanteService
{
    private readonly AppDbContext _dbContext;

    public ParticipanteService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<ParticipanteModel>> GetAll()
    {
        return await _dbContext.Participantes.ToListAsync();
    }
    
    public async Task<int> Create(ParticipanteModel entity)
    {
        var entry = await _dbContext.Participantes.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entry.Entity.CodPar;
    }
}