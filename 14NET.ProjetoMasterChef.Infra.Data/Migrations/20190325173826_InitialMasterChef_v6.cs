using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _14NET.ProjetoMasterChef.Infra.Data.Migrations
{
    public partial class InitialMasterChef_v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Receitas");

            migrationBuilder.AddColumn<string>(
                name: "FotoUrl",
                table: "Receitas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoUrl",
                table: "Receitas");

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto",
                table: "Receitas",
                type: "binary",
                nullable: false,
                defaultValue: new byte[] {  });
        }
    }
}
