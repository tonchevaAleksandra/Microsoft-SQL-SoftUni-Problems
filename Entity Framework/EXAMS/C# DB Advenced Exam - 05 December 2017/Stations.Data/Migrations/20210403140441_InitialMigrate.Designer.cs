﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stations.Data;

namespace Stations.Data.Migrations
{
    [DbContext(typeof(StationsDbContext))]
    [Migration("20210403140441_InitialMigrate")]
    partial class InitialMigrate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Stations.Models.CustomerCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<string>("Name");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("CustomerCards");
                });

            modelBuilder.Entity("Stations.Models.SeatingClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("Abbreviation")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("SeatingClasses");
                });

            modelBuilder.Entity("Stations.Models.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("Stations.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerCardId");

                    b.Property<decimal>("Price");

                    b.Property<string>("SeatingPlace")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.Property<int>("TripId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerCardId");

                    b.HasIndex("TripId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Stations.Models.Train", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TrainNumber")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int?>("Type");

                    b.HasKey("Id");

                    b.HasIndex("TrainNumber")
                        .IsUnique();

                    b.ToTable("Trains");
                });

            modelBuilder.Entity("Stations.Models.TrainSeat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Quantity");

                    b.Property<int>("SeatingClassId");

                    b.Property<int>("TrainId");

                    b.HasKey("Id");

                    b.HasIndex("SeatingClassId");

                    b.HasIndex("TrainId");

                    b.ToTable("TrainSeats");
                });

            modelBuilder.Entity("Stations.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ArrivalTime");

                    b.Property<DateTime>("DepartureTime");

                    b.Property<int>("DestinationStationId");

                    b.Property<int>("OriginStationId");

                    b.Property<int>("Status");

                    b.Property<TimeSpan?>("TimeDifference");

                    b.Property<int>("TrainId");

                    b.HasKey("Id");

                    b.HasIndex("DestinationStationId");

                    b.HasIndex("OriginStationId");

                    b.HasIndex("TrainId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("Stations.Models.Ticket", b =>
                {
                    b.HasOne("Stations.Models.CustomerCard", "CustomerCard")
                        .WithMany("BoughtTickets")
                        .HasForeignKey("CustomerCardId");

                    b.HasOne("Stations.Models.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Stations.Models.TrainSeat", b =>
                {
                    b.HasOne("Stations.Models.SeatingClass", "SeatingClass")
                        .WithMany()
                        .HasForeignKey("SeatingClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Stations.Models.Train", "Train")
                        .WithMany("TrainSeats")
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Stations.Models.Trip", b =>
                {
                    b.HasOne("Stations.Models.Station", "DestinationStation")
                        .WithMany("TripsTo")
                        .HasForeignKey("DestinationStationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Stations.Models.Station", "OriginStation")
                        .WithMany("TripsFrom")
                        .HasForeignKey("OriginStationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Stations.Models.Train", "Train")
                        .WithMany("Trips")
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
