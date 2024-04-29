using Microsoft.EntityFrameworkCore;
using SucessoEventos.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<ParticipanteModel>()
            .ToTable("Participantes")
            .HasKey(p => p.CodPar);

        modelBuilder.Entity<PacoteModel>()
            .ToTable("Pacotes")
            .HasKey(p => p.CodPac);

        modelBuilder.Entity<AtividadeModel>()
            .ToTable("Atividades")
            .HasKey(a => a.CodAtv);

        modelBuilder.Entity<ParticipanteModel>()
            .HasMany(par => par.Atividades)
            .WithMany(atv => atv.Participantes)
            .UsingEntity(x => x.ToTable("AxParticipanteAtividade"));

        modelBuilder.Entity<ParticipanteModel>()
            .HasMany(par => par.Pacotes)
            .WithMany(pac => pac.Participantes)
            .UsingEntity(x => x.ToTable("AxParticipantePacote"));

        modelBuilder.Entity<PacoteModel>().HasData(
            new PacoteModel
            {
                CodPac = 1,
                Descricao = "Pacote 1",
                Preco = 10.0M
            },
            new PacoteModel
            {
                CodPac = 2,
                Descricao = "Pacote 2",
                Preco = 20.0M
            },
            new PacoteModel
            {
                CodPac = 3,
                Descricao = "Pacote 3",
                Preco = 50.0M
            });

        modelBuilder.Entity<AtividadeModel>().HasData(
            new AtividadeModel
            {
                CodAtv = 1,
                DescAtv = "Atividade 1",
                Vagas = 10,
                Preco = 10.0M
            },
            new AtividadeModel
            {
                CodAtv = 2,
                DescAtv = "Atividade 2",
                Vagas = 20,
                Preco = 20.0M    
            }
        );
    }
}