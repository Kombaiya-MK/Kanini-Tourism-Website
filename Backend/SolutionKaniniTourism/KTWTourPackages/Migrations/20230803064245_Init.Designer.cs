﻿// <auto-generated />
using KTWTourPackages.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KTWTourPackages.Migrations
{
    [DbContext(typeof(PackageContext))]
    [Migration("20230803064245_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KTWTourPackages.Models.Itinerary", b =>
                {
                    b.Property<string>("ItineraryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ItineraryId");

                    b.HasIndex("PackId");

                    b.ToTable("Touraries");
                });

            modelBuilder.Entity("KTWTourPackages.Models.ItineraryItem", b =>
                {
                    b.Property<string>("ItemId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Activity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DayNumber")
                        .HasColumnType("int");

                    b.Property<string>("EndTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ItineraryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemId");

                    b.HasIndex("ItineraryId");

                    b.ToTable("TourariesItem");
                });

            modelBuilder.Entity("KTWTourPackages.Models.TourPackage", b =>
                {
                    b.Property<string>("PackId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("LocationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PackId");

                    b.ToTable("TourPackages");
                });

            modelBuilder.Entity("KTWTourPackages.Models.Itinerary", b =>
                {
                    b.HasOne("KTWTourPackages.Models.TourPackage", "Package")
                        .WithMany("Itiners")
                        .HasForeignKey("PackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Package");
                });

            modelBuilder.Entity("KTWTourPackages.Models.ItineraryItem", b =>
                {
                    b.HasOne("KTWTourPackages.Models.Itinerary", "Itinerary")
                        .WithMany("Items")
                        .HasForeignKey("ItineraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Itinerary");
                });

            modelBuilder.Entity("KTWTourPackages.Models.Itinerary", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("KTWTourPackages.Models.TourPackage", b =>
                {
                    b.Navigation("Itiners");
                });
#pragma warning restore 612, 618
        }
    }
}
