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
    
    public async Task<int> Create(ParticipanteModel entity, List<PacoteModel> pacotes)
    {
        var participante = await _dbContext.Participantes.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        foreach (var pacote in pacotes){

            var pacoteparticipante = new PacoteParticipanteModel{
                CodPac = pacote.CodPac,
                CodPar = participante.Entity.CodPar
            };
            await _dbContext.PacoteParticipante.AddAsync(pacoteparticipante);
            await _dbContext.SaveChangesAsync();
        }

        return participante.Entity.CodPar;
    }
}