using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SucessoEventos.Migrations
{
    /// <inheritdoc />
    public partial class relationAtividadeParticipante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AxParticipanteAtividade_Atividades_AtividadesCodAtv",
                table: "AxParticipanteAtividade");

            migrationBuilder.DropForeignKey(
                name: "FK_AxParticipanteAtividade_Participantes_ParticipantesCodPar",
                table: "AxParticipanteAtividade");

            migrationBuilder.RenameColumn(
                name: "ParticipantesCodPar",
                table: "AxParticipanteAtividade",
                newName: "CodPar");

            migrationBuilder.RenameColumn(
                name: "AtividadesCodAtv",
                table: "AxParticipanteAtividade",
                newName: "CodAtv");

            migrationBuilder.RenameIndex(
                name: "IX_AxParticipanteAtividade_ParticipantesCodPar",
                table: "AxParticipanteAtividade",
                newName: "IX_AxParticipanteAtividade_CodPar");

            migrationBuilder.AddForeignKey(
                name: "FK_AxParticipanteAtividade_Atividades_CodAtv",
                table: "AxParticipanteAtividade",
                column: "CodAtv",
                principalTable: "Atividades",
                principalColumn: "CodAtv",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AxParticipanteAtividade_Participantes_CodPar",
                table: "AxParticipanteAtividade",
                column: "CodPar",
                principalTable: "Participantes",
                principalColumn: "CodPar",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AxParticipanteAtividade_Atividades_CodAtv",
                table: "AxParticipanteAtividade");

            migrationBuilder.DropForeignKey(
                name: "FK_AxParticipanteAtividade_Participantes_CodPar",
                table: "AxParticipanteAtividade");

            migrationBuilder.RenameColumn(
                name: "CodPar",
                table: "AxParticipanteAtividade",
                newName: "ParticipantesCodPar");

            migrationBuilder.RenameColumn(
                name: "CodAtv",
                table: "AxParticipanteAtividade",
                newName: "AtividadesCodAtv");

            migrationBuilder.RenameIndex(
                name: "IX_AxParticipanteAtividade_CodPar",
                table: "AxParticipanteAtividade",
                newName: "IX_AxParticipanteAtividade_ParticipantesCodPar");

            migrationBuilder.AddForeignKey(
                name: "FK_AxParticipanteAtividade_Atividades_AtividadesCodAtv",
                table: "AxParticipanteAtividade",
                column: "AtividadesCodAtv",
                principalTable: "Atividades",
                principalColumn: "CodAtv",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AxParticipanteAtividade_Participantes_ParticipantesCodPar",
                table: "AxParticipanteAtividade",
                column: "ParticipantesCodPar",
                principalTable: "Participantes",
                principalColumn: "CodPar",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
