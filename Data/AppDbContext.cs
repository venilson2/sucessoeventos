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
    }
}