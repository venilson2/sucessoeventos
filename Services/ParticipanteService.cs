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
    
    public async Task<int> Create(ParticipanteModel entity, List<PacoteModel> pacotes, List<AtividadeModel> atividades)
    {
        using (var transaction = await _dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                var participante = await _dbContext.Participantes.AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                foreach (var pacote in pacotes)
                {
                    var pacoteParticipante = new PacoteParticipanteModel
                    {
                        CodPac = pacote.CodPac,
                        CodPar = participante.Entity.CodPar
                    };
                    await _dbContext.PacoteParticipante.AddAsync(pacoteParticipante);
                }

                foreach (var atividade in atividades)
                {
                    var atividadeParticipante = new AtividadeParticipanteModel
                    {
                        CodAtv = atividade.CodAtv,
                        CodPar = participante.Entity.CodPar
                    };
                    await _dbContext.AtividadeParticipante.AddAsync(atividadeParticipante);
                }

                await _dbContext.SaveChangesAsync();
                transaction.Commit();

                return participante.Entity.CodPar;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }

}