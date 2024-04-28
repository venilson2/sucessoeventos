using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SucessoEventos.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atividades",
                columns: table => new
                {
                    CodAtv = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescAtv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vagas = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividades", x => x.CodAtv);
                });

            migrationBuilder.CreateTable(
                name: "Pacotes",
                columns: table => new
                {
                    CodPac = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacotes", x => x.CodPac);
                });

            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    CodPar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.CodPar);
                });

            migrationBuilder.CreateTable(
                name: "AxParticipanteAtividade",
                columns: table => new
                {
                    AtividadesCodAtv = table.Column<int>(type: "int", nullable: false),
                    ParticipantesCodPar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AxParticipanteAtividade", x => new { x.AtividadesCodAtv, x.ParticipantesCodPar });
                    table.ForeignKey(
                        name: "FK_AxParticipanteAtividade_Atividades_AtividadesCodAtv",
                        column: x => x.AtividadesCodAtv,
                        principalTable: "Atividades",
                        principalColumn: "CodAtv",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AxParticipanteAtividade_Participantes_ParticipantesCodPar",
                        column: x => x.ParticipantesCodPar,
                        principalTable: "Participantes",
                        principalColumn: "CodPar",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AxParticipantePacote",
                columns: table => new
                {
                    PacotesCodPac = table.Column<int>(type: "int", nullable: false),
                    ParticipantesCodPar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AxParticipantePacote", x => new { x.PacotesCodPac, x.ParticipantesCodPar });
                    table.ForeignKey(
                        name: "FK_AxParticipantePacote_Pacotes_PacotesCodPac",
                        column: x => x.PacotesCodPac,
                        principalTable: "Pacotes",
                        principalColumn: "CodPac",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AxParticipantePacote_Participantes_ParticipantesCodPar",
                        column: x => x.ParticipantesCodPar,
                        principalTable: "Participantes",
                        principalColumn: "CodPar",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AxParticipanteAtividade_ParticipantesCodPar",
                table: "AxParticipanteAtividade",
                column: "ParticipantesCodPar");

            migrationBuilder.CreateIndex(
                name: "IX_AxParticipantePacote_ParticipantesCodPar",
                table: "AxParticipantePacote",
                column: "ParticipantesCodPar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AxParticipanteAtividade");

            migrationBuilder.DropTable(
                name: "AxParticipantePacote");

            migrationBuilder.DropTable(
                name: "Atividades");

            migrationBuilder.DropTable(
                name: "Pacotes");

            migrationBuilder.DropTable(
                name: "Participantes");
        }
    }
}
