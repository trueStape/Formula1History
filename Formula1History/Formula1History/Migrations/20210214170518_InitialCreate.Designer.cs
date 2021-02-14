﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Formula1History.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210214170518_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Entities.Peoples.DriverEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDeath")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TeamEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TeamEntityId");

                    b.ToTable("Driver");
                });

            modelBuilder.Entity("DAL.Entities.Peoples.ManagerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Manager");
                });

            modelBuilder.Entity("DAL.Entities.Race.RacePlace", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DriverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Place")
                        .HasColumnType("int");

                    b.Property<int>("Pts")
                        .HasColumnType("int");

                    b.Property<Guid?>("RaceWeekendEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("RaceWeekendEntityId");

                    b.ToTable("RacePlace");
                });

            modelBuilder.Entity("DAL.Entities.Race.RaceWeekendEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descriptions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("FastLapId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FinishWeekend")
                        .HasColumnType("datetime2");

                    b.Property<string>("RaceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RaceYearEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartWeekend")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FastLapId");

                    b.HasIndex("RaceYearEntityId");

                    b.ToTable("RaceWeekend");
                });

            modelBuilder.Entity("DAL.Entities.Race.RaceYearEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RaceYear");
                });

            modelBuilder.Entity("DAL.Entities.Team.TeamEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("NextTeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RaceWeekendEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("YearClose")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("YearFoundation")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("NextTeamId");

                    b.HasIndex("RaceWeekendEntityId");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("ManagerEntityTeamEntity", b =>
                {
                    b.Property<Guid>("ManagersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeamsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ManagersId", "TeamsId");

                    b.HasIndex("TeamsId");

                    b.ToTable("ManagerEntityTeamEntity");
                });

            modelBuilder.Entity("DAL.Entities.Peoples.DriverEntity", b =>
                {
                    b.HasOne("DAL.Entities.Team.TeamEntity", null)
                        .WithMany("Drivers")
                        .HasForeignKey("TeamEntityId");
                });

            modelBuilder.Entity("DAL.Entities.Race.RacePlace", b =>
                {
                    b.HasOne("DAL.Entities.Peoples.DriverEntity", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId");

                    b.HasOne("DAL.Entities.Race.RaceWeekendEntity", null)
                        .WithMany("Results")
                        .HasForeignKey("RaceWeekendEntityId");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("DAL.Entities.Race.RaceWeekendEntity", b =>
                {
                    b.HasOne("DAL.Entities.Peoples.DriverEntity", "FastLap")
                        .WithMany()
                        .HasForeignKey("FastLapId");

                    b.HasOne("DAL.Entities.Race.RaceYearEntity", null)
                        .WithMany("RacesWeekends")
                        .HasForeignKey("RaceYearEntityId");

                    b.Navigation("FastLap");
                });

            modelBuilder.Entity("DAL.Entities.Team.TeamEntity", b =>
                {
                    b.HasOne("DAL.Entities.Team.TeamEntity", "NextTeam")
                        .WithMany()
                        .HasForeignKey("NextTeamId");

                    b.HasOne("DAL.Entities.Race.RaceWeekendEntity", null)
                        .WithMany("Teams")
                        .HasForeignKey("RaceWeekendEntityId");

                    b.Navigation("NextTeam");
                });

            modelBuilder.Entity("ManagerEntityTeamEntity", b =>
                {
                    b.HasOne("DAL.Entities.Peoples.ManagerEntity", null)
                        .WithMany()
                        .HasForeignKey("ManagersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Team.TeamEntity", null)
                        .WithMany()
                        .HasForeignKey("TeamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Entities.Race.RaceWeekendEntity", b =>
                {
                    b.Navigation("Results");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("DAL.Entities.Race.RaceYearEntity", b =>
                {
                    b.Navigation("RacesWeekends");
                });

            modelBuilder.Entity("DAL.Entities.Team.TeamEntity", b =>
                {
                    b.Navigation("Drivers");
                });
#pragma warning restore 612, 618
        }
    }
}
