using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuinielaBackend.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId1 = table.Column<int>(type: "int", nullable: false),
                    TeamId2 = table.Column<int>(type: "int", nullable: false),
                    StartHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lock = table.Column<bool>(type: "bit", nullable: false),
                    JourneyNumber = table.Column<int>(type: "int", nullable: false),
                    GameTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScoreTeam1 = table.Column<int>(type: "int", nullable: true),
                    ScoreTeam2 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lock = table.Column<bool>(type: "bit", nullable: false),
                    GamesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RecordTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PredictTeam1 = table.Column<int>(type: "int", nullable: false),
                    PredictTeam2 = table.Column<int>(type: "int", nullable: false),
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecordTables_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecordTables_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecordTables_GamesId",
                table: "RecordTables",
                column: "GamesId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordTables_UsersId",
                table: "RecordTables",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_GamesId",
                table: "Teams",
                column: "GamesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecordTables");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
