using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _14NET.ProjetoMasterChef.Infra.Data.Migrations
{
    public partial class InitialMasterChef_v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Foto",
                table: "Receitas",
                type: "binary",
                nullable: false,
                oldClrType: typeof(byte));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Foto",
                table: "Receitas",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "binary");
        }
    }
}
