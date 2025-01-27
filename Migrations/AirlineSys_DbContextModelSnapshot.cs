﻿// <auto-generated />
using System;
using AirlineReservationApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirlineReservationApp.Migrations
{
    [DbContext(typeof(AirlineSys_DbContext))]
    partial class AirlineSys_DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AirlineReservationApp.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"));

                    b.Property<string>("AdminMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CPassword")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("AirlineReservationApp.Models.Aeroplane", b =>
                {
                    b.Property<int>("PlaneID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaneID"));

                    b.Property<int?>("AeroplaneImageImageID")
                        .HasColumnType("int");

                    b.Property<string>("AeroplaneName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AirlineCompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SeatingCapacity")
                        .HasColumnType("int");

                    b.HasKey("PlaneID");

                    b.HasIndex("AeroplaneImageImageID");

                    b.HasIndex("AirlineCompanyId");

                    b.ToTable("Aeroplanes");
                });

            modelBuilder.Entity("AirlineReservationApp.Models.AeroplaneImage", b =>
                {
                    b.Property<int>("ImageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageID"));

                    b.Property<int>("AeroplaneId")
                        .HasColumnType("int");

                    b.Property<string>("ImageData")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImageID");

                    b.HasIndex("AeroplaneId");

                    b.ToTable("AeroplaneImages");
                });

            modelBuilder.Entity("AirlineReservationApp.Models.AirlineCompany", b =>
                {
                    b.Property<int>("AirlineCompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AirlineCompanyId"));

                    b.Property<string>("AirlineCompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AirlineCompanyId");

                    b.ToTable("AirlineCompanies");
                });

            modelBuilder.Entity("AirlineReservationApp.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<string>("ArrivalAirport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartureAirport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DepartureDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("FligthId")
                        .HasColumnType("int");

                    b.Property<int>("Passport")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TicketPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("FligthId");

                    b.HasIndex("UserId");

                    b.ToTable("Boookings");
                });

            modelBuilder.Entity("AirlineReservationApp.Models.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightId"));

                    b.Property<string>("AircraftType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArrivalAirport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AvailableSeats")
                        .HasColumnType("int");

                    b.Property<string>("DepartureAirport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DepartureDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PlaneID")
                        .HasColumnType("int");

                    b.Property<int?>("SeatingCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FlightId");

                    b.HasIndex("PlaneID");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("AirlineReservationApp.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("CPassword")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AirlineReservationApp.Models.Aeroplane", b =>
                {
                    b.HasOne("AirlineReservationApp.Models.AeroplaneImage", null)
                        .WithMany("Aeroplanes")
                        .HasForeignKey("AeroplaneImageImageID");

                    b.HasOne("AirlineReservationApp.Models.AirlineCompany", "AirlineCompanyNavigationKey")
                        .WithMany("Aeroplanes")
                        .HasForeignKey("AirlineCompanyId")
                        .HasConstraintName("FK_Aeroplanes_ACompanies");

                    b.Navigation("AirlineCompanyNavigationKey");
                });

            modelBuilder.Entity("AirlineReservationApp.Models.AeroplaneImage", b =>
                {
                    b.HasOne("AirlineReservationApp.Models.Aeroplane", "Aeroplane")
                        .WithMany("AeroplaneImages")
                        .HasForeignKey("AeroplaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aeroplane");
                });

            modelBuilder.Entity("AirlineReservationApp.Models.Booking", b =>
                {
                    b.HasOne("AirlineReservationApp.Models.Flight", "Flight")
                        .WithMany("Bookings")
                        .HasForeignKey("FligthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirlineReservationApp.Models.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AirlineReservationApp.Models.Flight", b =>
                {
                    b.HasOne("AirlineReservationApp.Models.Aeroplane", "Aeroplane")
                        .WithMany("Flights")
                        .HasForeignKey("PlaneID");

                    b.Navigation("Aeroplane");
                });

            modelBuilder.Entity("AirlineReservationApp.Models.Aeroplane", b =>
                {
                    b.Navigation("AeroplaneImages");

                    b.Navigation("Flights");
                });

            modelBuilder.Entity("AirlineReservationApp.Models.AeroplaneImage", b =>
                {
                    b.Navigation("Aeroplanes");
                });

            modelBuilder.Entity("AirlineReservationApp.Models.AirlineCompany", b =>
                {
                    b.Navigation("Aeroplanes");
                });

            modelBuilder.Entity("AirlineReservationApp.Models.Flight", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("AirlineReservationApp.Models.User", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
