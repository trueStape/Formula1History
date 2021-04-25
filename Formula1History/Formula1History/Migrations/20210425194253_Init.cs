using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Formula1History.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDeath = table.Column<DateTime>(type: "datetime2", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearFoundation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YearClose = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_Team_NextTeamId",
                        column: x => x.NextTeamId,
                        principalTable: "Team",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RaceWeekend",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RaceYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RaceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartWeekend = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishWeekend = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "Driver",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarNumber = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "FK_Driver_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "ConnectionTeamAndRaceWeekend",
                columns: table => new
                {
                    RaceWeekendId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RaceWeekendEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectionTeamAndRaceWeekend", x => x.RaceWeekendId);
                    table.ForeignKey(
                        name: "FK_ConnectionTeamAndRaceWeekend_RaceWeekend_RaceWeekendEntityId",
                        column: x => x.RaceWeekendEntityId,
                        principalTable: "RaceWeekend",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConnectionTeamAndRaceWeekend_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RacePlace",
                columns: table => new
                {
                    RaceWeekendId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Place = table.Column<int>(type: "int", nullable: false),
                    Pts = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RaceWeekendEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacePlace", x => x.RaceWeekendId);
                    table.ForeignKey(
                        name: "FK_RacePlace_Driver_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Driver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RacePlace_RaceWeekend_RaceWeekendEntityId",
                        column: x => x.RaceWeekendEntityId,
                        principalTable: "RaceWeekend",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionTeamAndRaceWeekend_RaceWeekendEntityId",
                table: "ConnectionTeamAndRaceWeekend",
                column: "RaceWeekendEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionTeamAndRaceWeekend_TeamId",
                table: "ConnectionTeamAndRaceWeekend",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_TeamId",
                table: "Driver",
                column: "TeamId");

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
                name: "IX_RaceWeekend_RaceYearEntityId",
                table: "RaceWeekend",
                column: "RaceYearEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_NextTeamId",
                table: "Team",
                column: "NextTeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConnectionTeamAndRaceWeekend");

            migrationBuilder.DropTable(
                name: "ManagerEntityTeamEntity");

            migrationBuilder.DropTable(
                name: "RacePlace");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "RaceWeekend");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "RaceYear");
        }
    }
}
