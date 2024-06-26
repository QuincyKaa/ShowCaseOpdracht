using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShowCaseZeeslag.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableVeldGrootte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VeldGroottes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grootte = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeldGroottes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VeldGroottes");
        }
    }
}
