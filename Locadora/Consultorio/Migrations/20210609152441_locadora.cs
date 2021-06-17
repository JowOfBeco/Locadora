using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class locadora : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "aluguelDias",
                table: "Aluguel",
                newName: "devolucaoDias");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "devolucaoDias",
                table: "Aluguel",
                newName: "aluguelDias");
        }
    }
}
