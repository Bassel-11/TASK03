using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TASK03.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DeptName" },
                values: new object[,]
                {
                    { 1, "HR" },
                    { 2, "PR" },
                    { 3, "Social Media" },
                    { 4, "Finance" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "Age", "DepartmentId", "Name" },
                values: new object[,]
                {
                    { 1, "cairoA", 22, 1, "Ramy" },
                    { 2, "CairoB", 32, 2, "Mai" },
                    { 3, "CairoC", 42, 3, "Ali" },
                    { 4, "CairoD", 52, 4, "Omar" },
                    { 5, "CairoE", 2, 1, "Mostafa" },
                    { 6, "CairoF", 38, 2, "Ahmed" },
                    { 7, "CairoG", 48, 3, "Sara" },
                    { 8, "CairoH", 26, 4, "Osama" },
                    { 9, "CairoI", 3, 1, "Mohamed" },
                    { 10, "CairoJ", 46, 2, "Nour" },
                    { 11, "CairoK", 22, 3, "Mohamed" },
                    { 12, "CairoL", 46, 4, "Nour" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentId",
                table: "Students",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
