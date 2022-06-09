using Microsoft.EntityFrameworkCore.Migrations;

namespace Intsar_Project_API.Migrations.AppDb
{
    public partial class DelProjectNum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectNum",
                table: "compRegs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectNum",
                table: "compRegs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
