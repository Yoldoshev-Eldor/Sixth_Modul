﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NimbleCar.DataAccess;

#nullable disable

namespace NimbleCar.DataAccess.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20250428121409_TableChange")]
    partial class TableChange
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NimbleCar.DataAccess.Entities.Booking", b =>
                {
                    b.Property<long>("BookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("BookingID"));

                    b.Property<long>("CarID")
                        .HasColumnType("bigint");

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalCost")
                        .HasColumnType("float");

                    b.HasKey("BookingID");

                    b.HasIndex("CarID");

                    b.HasIndex("CustomerId");

                    b.ToTable("Booking", (string)null);
                });

            modelBuilder.Entity("NimbleCar.DataAccess.Entities.Car", b =>
                {
                    b.Property<long>("CarID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CarID"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("PricePerDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Year")
                        .HasColumnType("datetime2");

                    b.HasKey("CarID");

                    b.ToTable("Car", (string)null);
                });

            modelBuilder.Entity("NimbleCar.DataAccess.Entities.Customer", b =>
                {
                    b.Property<long>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CustomerID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("CustomerID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("NimbleCar.DataAccess.Entities.Payment", b =>
                {
                    b.Property<long>("PaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PaymentID"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<long>("BookingId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("PaymentID");

                    b.HasIndex("BookingId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("NimbleCar.DataAccess.Entities.Review", b =>
                {
                    b.Property<long>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ReviewID"));

                    b.Property<long>("CarID")
                        .HasColumnType("bigint");

                    b.PrimitiveCollection<string>("Comments")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<long>("CustomerID")
                        .HasColumnType("bigint");

                    b.Property<long?>("CustomerID1")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Rating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(3, 2)")
                        .HasDefaultValue(0m);

                    b.HasKey("ReviewID");

                    b.HasIndex("CarID");

                    b.HasIndex("CustomerID1");

                    b.HasIndex("CustomerID", "CarID");

                    b.ToTable("Reviews", (string)null);
                });

            modelBuilder.Entity("NimbleCar.DataAccess.Entities.Booking", b =>
                {
                    b.HasOne("NimbleCar.DataAccess.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NimbleCar.DataAccess.Entities.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("NimbleCar.DataAccess.Entities.Payment", b =>
                {
                    b.HasOne("NimbleCar.DataAccess.Entities.Booking", "Booking")
                        .WithMany("Payments")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("NimbleCar.DataAccess.Entities.Review", b =>
                {
                    b.HasOne("NimbleCar.DataAccess.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NimbleCar.DataAccess.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NimbleCar.DataAccess.Entities.Customer", null)
                        .WithMany("Reviews")
                        .HasForeignKey("CustomerID1");

                    b.Navigation("Car");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("NimbleCar.DataAccess.Entities.Booking", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("NimbleCar.DataAccess.Entities.Customer", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
