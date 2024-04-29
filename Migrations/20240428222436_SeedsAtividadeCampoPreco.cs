using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SucessoEventos.Migrations
{
    /// <inheritdoc />
    public partial class SeedsAtividadeCampoPreco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Atividades",
                keyColumn: "CodAtv",
                keyValue: 1,
                column: "Preco",
                value: 10.0m);

            migrationBuilder.UpdateData(
                table: "Atividades",
                keyColumn: "CodAtv",
                keyValue: 2,
                column: "Preco",
                value: 20.0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Atividades",
                keyColumn: "CodAtv",
                keyValue: 1,
                column: "Preco",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Atividades",
                keyColumn: "CodAtv",
                keyValue: 2,
                column: "Preco",
                value: 0m);
        }
    }
}
