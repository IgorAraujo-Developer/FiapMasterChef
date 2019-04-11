using Microsoft.EntityFrameworkCore.Migrations;

namespace _14NET.ProjetoMasterChef.Infra.Data.Migrations
{
    public partial class InitialMasterChef_v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ModoPreparo",
                table: "Receitas",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ingredientes",
                table: "Receitas",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ModoPreparo",
                table: "Receitas",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Ingredientes",
                table: "Receitas",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
