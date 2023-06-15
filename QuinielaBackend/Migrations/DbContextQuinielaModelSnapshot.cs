﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuinielaBackend;

#nullable disable

namespace QuinielaBackend.Migrations
{
    [DbContext(typeof(DbContextQuiniela))]
    partial class DbContextQuinielaModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QuinielaBackend.Models.Games", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("GameTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JourneyNumber")
                        .HasColumnType("int");

                    b.Property<bool>("Lock")
                        .HasColumnType("bit");

                    b.Property<Guid>("PublicKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("ScoreTeam1")
                        .HasColumnType("int");

                    b.Property<int?>("ScoreTeam2")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartHour")
                        .HasColumnType("datetime2");

                    b.Property<int>("TeamId1")
                        .HasColumnType("int");

                    b.Property<int>("TeamId2")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("QuinielaBackend.Models.RecordTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.Property<int>("PredictTeam1")
                        .HasColumnType("int");

                    b.Property<int>("PredictTeam2")
                        .HasColumnType("int");

                    b.Property<Guid>("PublicKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GamesId");

                    b.HasIndex("UsersId");

                    b.ToTable("RecordTables");
                });

            modelBuilder.Entity("QuinielaBackend.Models.Teams", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("GamesId")
                        .HasColumnType("int");

                    b.Property<string>("Img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Lock")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PublicKey")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GamesId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("QuinielaBackend.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Lock")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QuinielaBackend.Models.RecordTable", b =>
                {
                    b.HasOne("QuinielaBackend.Models.Games", "Games")
                        .WithMany("RecordsTables")
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuinielaBackend.Models.Users", "Users")
                        .WithMany("recordTables")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Games");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("QuinielaBackend.Models.Teams", b =>
                {
                    b.HasOne("QuinielaBackend.Models.Games", null)
                        .WithMany("Teams")
                        .HasForeignKey("GamesId");
                });

            modelBuilder.Entity("QuinielaBackend.Models.Games", b =>
                {
                    b.Navigation("RecordsTables");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("QuinielaBackend.Models.Users", b =>
                {
                    b.Navigation("recordTables");
                });
#pragma warning restore 612, 618
        }
    }
}