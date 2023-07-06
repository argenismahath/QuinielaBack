using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuinielaBackend.Migrations
{
    public partial class link : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Games");
        }
    }
}
