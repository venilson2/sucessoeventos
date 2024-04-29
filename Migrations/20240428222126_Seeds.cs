using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SucessoEventos.Migrations
{
    /// <inheritdoc />
    public partial class Seeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Atividades",
                columns: new[] { "CodAtv", "DescAtv", "Preco", "Vagas" },
                values: new object[,]
                {
                    { 1, "Atividade 1", 0m, 10 },
                    { 2, "Atividade 2", 0m, 20 }
                });

            migrationBuilder.InsertData(
                table: "Pacotes",
                columns: new[] { "CodPac", "Descricao", "Preco" },
                values: new object[,]
                {
                    { 1, "Pacote 1", 10.0m },
                    { 2, "Pacote 2", 20.0m },
                    { 3, "Pacote 3", 50.0m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Atividades",
                keyColumn: "CodAtv",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Atividades",
                keyColumn: "CodAtv",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pacotes",
                keyColumn: "CodPac",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pacotes",
                keyColumn: "CodPac",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pacotes",
                keyColumn: "CodPac",
                keyValue: 3);
        }
    }
}
