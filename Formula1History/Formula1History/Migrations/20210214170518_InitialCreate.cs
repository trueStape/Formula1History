using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Formula1History.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaceYear",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceYear", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RacePlace",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Place = table.Column<int>(type: "int", nullable: false),
                    Pts = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RaceWeekendEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacePlace", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaceWeekend",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RaceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartWeekend = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishWeekend = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FastLapId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RaceYearEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceWeekend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceWeekend_RaceYear_RaceYearEntityId",
                        column: x => x.RaceYearEntityId,
                        principalTable: "RaceYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearFoundation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YearClose = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RaceWeekendEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_RaceWeekend_RaceWeekendEntityId",
                        column: x => x.RaceWeekendEntityId,
                        principalTable: "RaceWeekend",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Team_Team_NextTeamId",
                        column: x => x.NextTeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarNumber = table.Column<int>(type: "int", nullable: false),
                    TeamEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDeath = table.Column<DateTime>(type: "datetime2", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Driver_Team_TeamEntityId",
                        column: x => x.TeamEntityId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManagerEntityTeamEntity",
                columns: table => new
                {
                    ManagersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerEntityTeamEntity", x => new { x.ManagersId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_ManagerEntityTeamEntity_Manager_ManagersId",
                        column: x => x.ManagersId,
                        principalTable: "Manager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManagerEntityTeamEntity_Team_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Driver_TeamEntityId",
                table: "Driver",
                column: "TeamEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerEntityTeamEntity_TeamsId",
                table: "ManagerEntityTeamEntity",
                column: "TeamsId");

            migrationBuilder.CreateIndex(
                name: "IX_RacePlace_DriverId",
                table: "RacePlace",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_RacePlace_RaceWeekendEntityId",
                table: "RacePlace",
                column: "RaceWeekendEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceWeekend_FastLapId",
                table: "RaceWeekend",
                column: "FastLapId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceWeekend_RaceYearEntityId",
                table: "RaceWeekend",
                column: "RaceYearEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_NextTeamId",
                table: "Team",
                column: "NextTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_RaceWeekendEntityId",
                table: "Team",
                column: "RaceWeekendEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_RacePlace_Driver_DriverId",
                table: "RacePlace",
                column: "DriverId",
                principalTable: "Driver",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RacePlace_RaceWeekend_RaceWeekendEntityId",
                table: "RacePlace",
                column: "RaceWeekendEntityId",
                principalTable: "RaceWeekend",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RaceWeekend_Driver_FastLapId",
                table: "RaceWeekend",
                column: "FastLapId",
                principalTable: "Driver",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Team_TeamEntityId",
                table: "Driver");

            migrationBuilder.DropTable(
                name: "ManagerEntityTeamEntity");

            migrationBuilder.DropTable(
                name: "RacePlace");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "RaceWeekend");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "RaceYear");
        }
    }
}
