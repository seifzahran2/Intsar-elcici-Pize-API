using Microsoft.EntityFrameworkCore.Migrations;

namespace Intsar_Project_API.Migrations.AppDb
{
    public partial class projectTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "projects");
        }
    }
}
