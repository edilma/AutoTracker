﻿// <auto-generated />
using System;
using AutoTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutoTracker.Migrations
{
    [DbContext(typeof(AutoTrackerDbContext))]
    partial class AutoTrackerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AutoTracker.Models.Car", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentMiles")
                        .HasColumnType("int");

                    b.Property<int>("NextMaintenanceDays")
                        .HasColumnType("int");

                    b.Property<int>("NextMaintenanceMiles")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("AutoTracker.Models.Maintenance", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<int>("MaintenaceFutureDate")
                        .HasColumnType("int");

                    b.Property<int>("MaintenaceFutureMiles")
                        .HasColumnType("int");

                    b.Property<int>("MaintenacePerformedMiles")
                        .HasColumnType("int");

                    b.Property<double>("MaintenanceCost")
                        .HasColumnType("float");

                    b.Property<DateTime>("MaintenancePerformedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaintenanceTypeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CarID");

                    b.HasIndex("MaintenanceTypeID");

                    b.ToTable("Maintenances");
                });

            modelBuilder.Entity("AutoTracker.Models.MaintenanceType", b =>
                {
                    b.Property<int>("MaintenanceTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DateIntervalDays")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MilesInterval")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaintenanceTypeID");

                    b.ToTable("MaintenanceTypes");
                });

            modelBuilder.Entity("AutoTracker.Models.Mod", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<double>("ModCost")
                        .HasColumnType("float");

                    b.Property<DateTime>("ModDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CarID");

                    b.ToTable("Mods");
                });

            modelBuilder.Entity("AutoTracker.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AutoTracker.Models.Car", b =>
                {
                    b.HasOne("AutoTracker.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutoTracker.Models.Maintenance", b =>
                {
                    b.HasOne("AutoTracker.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoTracker.Models.MaintenanceType", "MaintenanceType")
                        .WithMany()
                        .HasForeignKey("MaintenanceTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutoTracker.Models.Mod", b =>
                {
                    b.HasOne("AutoTracker.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}