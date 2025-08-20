using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackathonMonolito.Migrations
{
    /// <inheritdoc />
    public partial class Add_ValorTotalPrestacao_ResultadoSimulacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "VR_TOTAL",
                table: "RESULTADO_SIMULACAO",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VR_TOTAL",
                table: "RESULTADO_SIMULACAO");
        }
    }
}
