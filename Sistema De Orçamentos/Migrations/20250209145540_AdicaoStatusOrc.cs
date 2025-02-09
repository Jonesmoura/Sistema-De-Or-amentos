using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaOrc.Migrations
{
    /// <inheritdoc />
    public partial class AdicaoStatusOrc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orcamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orcamentos");
        }
    }
}
