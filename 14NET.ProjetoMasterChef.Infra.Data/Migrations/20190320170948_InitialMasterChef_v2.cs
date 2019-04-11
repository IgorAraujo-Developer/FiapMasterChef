using Microsoft.EntityFrameworkCore.Migrations;

namespace _14NET.ProjetoMasterChef.Infra.Data.Migrations
{
    public partial class InitialMasterChef_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Foto",
                table: "Receitas",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Receitas");
        }
    }
}
