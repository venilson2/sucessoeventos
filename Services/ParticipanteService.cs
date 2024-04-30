using Microsoft.EntityFrameworkCore;
using SucessoEventos.Interfaces;
using SucessoEventos.Models;

namespace SucessoEventos.Services;

public class ParticipanteService : IParticipanteService
{
    private readonly AppDbContext _dbContextt;

    public ParticipanteService(AppDbContext dbContex)
    {
        _dbContextt = dbContex;
    }
    
    public async Task<IEnumerable<ParticipanteModel>> GetAll()
    {
        return await _dbContextt.Participantes.ToListAsync();
    }
    
    public async Task<int> Create(ParticipanteModel entity)
    {
        var entry = await _dbContextt.Participantes.AddAsync(entity);
        await _dbContextt.SaveChangesAsync();
        return entry.Entity.CodPar;
    }
}