﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SucessoEventos.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240428195247_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AtividadeModelParticipanteModel", b =>
                {
                    b.Property<int>("AtividadesCodAtv")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantesCodPar")
                        .HasColumnType("int");

                    b.HasKey("AtividadesCodAtv", "ParticipantesCodPar");

                    b.HasIndex("ParticipantesCodPar");

                    b.ToTable("AxParticipanteAtividade", (string)null);
                });

            modelBuilder.Entity("PacoteModelParticipanteModel", b =>
                {
                    b.Property<int>("PacotesCodPac")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantesCodPar")
                        .HasColumnType("int");

                    b.HasKey("PacotesCodPac", "ParticipantesCodPar");

                    b.HasIndex("ParticipantesCodPar");

                    b.ToTable("AxParticipantePacote", (string)null);
                });

            modelBuilder.Entity("SucessoEventos.Models.AtividadeModel", b =>
                {
                    b.Property<int>("CodAtv")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodAtv"));

                    b.Property<string>("DescAtv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Vagas")
                        .HasColumnType("int");

                    b.HasKey("CodAtv");

                    b.ToTable("Atividades", (string)null);
                });

            modelBuilder.Entity("SucessoEventos.Models.PacoteModel", b =>
                {
                    b.Property<int>("CodPac")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodPac"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CodPac");

                    b.ToTable("Pacotes", (string)null);
                });

            modelBuilder.Entity("SucessoEventos.Models.ParticipanteModel", b =>
                {
                    b.Property<int>("CodPar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodPar"));

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodPar");

                    b.ToTable("Participantes", (string)null);
                });

            modelBuilder.Entity("AtividadeModelParticipanteModel", b =>
                {
                    b.HasOne("SucessoEventos.Models.AtividadeModel", null)
                        .WithMany()
                        .HasForeignKey("AtividadesCodAtv")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SucessoEventos.Models.ParticipanteModel", null)
                        .WithMany()
                        .HasForeignKey("ParticipantesCodPar")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PacoteModelParticipanteModel", b =>
                {
                    b.HasOne("SucessoEventos.Models.PacoteModel", null)
                        .WithMany()
                        .HasForeignKey("PacotesCodPac")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SucessoEventos.Models.ParticipanteModel", null)
                        .WithMany()
                        .HasForeignKey("ParticipantesCodPar")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
