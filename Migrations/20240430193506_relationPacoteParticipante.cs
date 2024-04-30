using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SucessoEventos.Migrations
{
    /// <inheritdoc />
    public partial class relationPacoteParticipante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AxParticipantePacote_Pacotes_PacotesCodPac",
                table: "AxParticipantePacote");

            migrationBuilder.DropForeignKey(
                name: "FK_AxParticipantePacote_Participantes_ParticipantesCodPar",
                table: "AxParticipantePacote");

            migrationBuilder.RenameColumn(
                name: "ParticipantesCodPar",
                table: "AxParticipantePacote",
                newName: "CodPar");

            migrationBuilder.RenameColumn(
                name: "PacotesCodPac",
                table: "AxParticipantePacote",
                newName: "CodPac");

            migrationBuilder.RenameIndex(
                name: "IX_AxParticipantePacote_ParticipantesCodPar",
                table: "AxParticipantePacote",
                newName: "IX_AxParticipantePacote_CodPar");

            migrationBuilder.AddForeignKey(
                name: "FK_AxParticipantePacote_Pacotes_CodPac",
                table: "AxParticipantePacote",
                column: "CodPac",
                principalTable: "Pacotes",
                principalColumn: "CodPac",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AxParticipantePacote_Participantes_CodPar",
                table: "AxParticipantePacote",
                column: "CodPar",
                principalTable: "Participantes",
                principalColumn: "CodPar",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AxParticipantePacote_Pacotes_CodPac",
                table: "AxParticipantePacote");

            migrationBuilder.DropForeignKey(
                name: "FK_AxParticipantePacote_Participantes_CodPar",
                table: "AxParticipantePacote");

            migrationBuilder.RenameColumn(
                name: "CodPar",
                table: "AxParticipantePacote",
                newName: "ParticipantesCodPar");

            migrationBuilder.RenameColumn(
                name: "CodPac",
                table: "AxParticipantePacote",
                newName: "PacotesCodPac");

            migrationBuilder.RenameIndex(
                name: "IX_AxParticipantePacote_CodPar",
                table: "AxParticipantePacote",
                newName: "IX_AxParticipantePacote_ParticipantesCodPar");

            migrationBuilder.AddForeignKey(
                name: "FK_AxParticipantePacote_Pacotes_PacotesCodPac",
                table: "AxParticipantePacote",
                column: "PacotesCodPac",
                principalTable: "Pacotes",
                principalColumn: "CodPac",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AxParticipantePacote_Participantes_ParticipantesCodPar",
                table: "AxParticipantePacote",
                column: "ParticipantesCodPar",
                principalTable: "Participantes",
                principalColumn: "CodPar",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
