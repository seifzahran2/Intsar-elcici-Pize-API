using Microsoft.EntityFrameworkCore.Migrations;

namespace Intsar_Project_API.Migrations.AppDb
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "compRegs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BankAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    ProjectNum = table.Column<int>(type: "int", nullable: false),
                    CompNum = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    project_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Educational_level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    educational_system = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    IsprojecSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compRegs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriveLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "degComps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectIdea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExecutionQuality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gui = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentQuality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    complexity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectBbenefit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    language_Tools = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasteringTheTools = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InfrastructureUsed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverallRating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    compRegId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_degComps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_degComps_compRegs_compRegId",
                        column: x => x.compRegId,
                        principalTable: "compRegs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_degComps_compRegId",
                table: "degComps",
                column: "compRegId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "degComps");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "compRegs");
        }
    }
}
