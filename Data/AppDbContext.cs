using Microsoft.EntityFrameworkCore;
using SucessoEventos.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<ParticipanteModel> Participantes { get; set; }
    public DbSet<PacoteModel> Pacotes { get; set; }
    public DbSet<AtividadeModel> Atividades { get; set; }

    public DbSet<PacoteParticipanteModel> PacoteParticipante { get; set; } 
    public DbSet<AtividadeParticipanteModel> AtividadeParticipante { get; set; }

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
            .UsingEntity<AtividadeParticipanteModel>(
            j => j.HasOne(ap => ap.Atividade).WithMany().HasForeignKey(ap => ap.CodAtv),
            j => j.HasOne(ap => ap.Participante).WithMany().HasForeignKey(ap => ap.CodPar),
            j => 
            {
                j.ToTable("AxParticipanteAtividade");
                j.Property(ap => ap.CodPar).HasColumnName("CodPar");
                j.Property(ap => ap.CodAtv).HasColumnName("CodAtv");
            });

        modelBuilder.Entity<ParticipanteModel>()
            .HasMany(par => par.Pacotes)
            .WithMany(pac => pac.Participantes)
            .UsingEntity<PacoteParticipanteModel>(
            j => j.HasOne(pp => pp.Pacote).WithMany().HasForeignKey(pp => pp.CodPac),
            j => j.HasOne(pp => pp.Participante).WithMany().HasForeignKey(pp => pp.CodPar),
            j => 
             {
                j.ToTable("AxParticipantePacote");
                j.Property(pp => pp.CodPar).HasColumnName("CodPar");
                j.Property(pp => pp.CodPac).HasColumnName("CodPac");
            }
        );

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