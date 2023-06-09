﻿// <auto-generated />
using System;
using EnocaCase.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EnocaCase.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230509223841_addCarrierReportsTable")]
    partial class addCarrierReportsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EnocaCase.Core.Entities.CarrierConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarrierCost")
                        .HasColumnType("int");

                    b.Property<int>("CarrierId")
                        .HasColumnType("int");

                    b.Property<int>("CarrierMaxDesi")
                        .HasColumnType("int");

                    b.Property<int>("CarrierMinDesi")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarrierId");

                    b.ToTable("CarrierConfiguration", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarrierCost = 32,
                            CarrierId = 1,
                            CarrierMaxDesi = 10,
                            CarrierMinDesi = 1
                        });
                });

            modelBuilder.Entity("EnocaCase.Core.Entities.CarrierReports", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarrierId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CarrierReportDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarrierId");

                    b.ToTable("CarrierReports");
                });

            modelBuilder.Entity("EnocaCase.Core.Entities.Carriers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("CarrierIsActive")
                        .HasColumnType("bit");

                    b.Property<string>("CarrierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarrierPlusDesiCost")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Carriers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarrierIsActive = true,
                            CarrierName = "MNG",
                            CarrierPlusDesiCost = 4
                        });
                });

            modelBuilder.Entity("EnocaCase.Core.Entities.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarrierId")
                        .HasColumnType("int");

                    b.Property<decimal>("OrderCarrierCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderDesi")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarrierId");

                    b.ToTable("Orders", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarrierId = 1,
                            OrderCarrierCost = 44m,
                            OrderDate = new DateTime(2023, 5, 10, 1, 38, 41, 151, DateTimeKind.Local).AddTicks(2129),
                            OrderDesi = 13
                        });
                });

            modelBuilder.Entity("EnocaCase.Core.Entities.CarrierConfiguration", b =>
                {
                    b.HasOne("EnocaCase.Core.Entities.Carriers", "Carriers")
                        .WithMany("CarrierConfigurations")
                        .HasForeignKey("CarrierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carriers");
                });

            modelBuilder.Entity("EnocaCase.Core.Entities.CarrierReports", b =>
                {
                    b.HasOne("EnocaCase.Core.Entities.Carriers", "Carrier")
                        .WithMany()
                        .HasForeignKey("CarrierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrier");
                });

            modelBuilder.Entity("EnocaCase.Core.Entities.Orders", b =>
                {
                    b.HasOne("EnocaCase.Core.Entities.Carriers", "Carriers")
                        .WithMany("Orders")
                        .HasForeignKey("CarrierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carriers");
                });

            modelBuilder.Entity("EnocaCase.Core.Entities.Carriers", b =>
                {
                    b.Navigation("CarrierConfigurations");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
