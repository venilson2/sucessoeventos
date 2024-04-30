using Microsoft.EntityFrameworkCore;
using SucessoEventos.Interfaces;
using SucessoEventos.Models;

namespace SucessoEventos.Services;

public class ParticipanteService : IParticipanteService
{
    private readonly AppDbContext _dbContex;

    public ParticipanteService(AppDbContext dbContex)
    {
        _dbContex = dbContex;
    }
    
    public async Task<IEnumerable<ParticipanteModel>> GetAll()
    {
        return await _dbContex.Participantes.ToListAsync();
    }
    
    public async Task<int> Create(ParticipanteModel entity)
    {
        throw new NotImplementedException();
    }
}