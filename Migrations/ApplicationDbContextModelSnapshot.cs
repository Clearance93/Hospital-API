﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkyApplication.Data;

#nullable disable

namespace ParkyApplication.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ParkyApplication.Models.NationalParkModel", b =>
                {
                    b.Property<int>("nationslParkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("nationslParkId"));

                    b.Property<DateTime>("Established")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created")
                        .HasColumnType("datetime2");

                    b.HasKey("nationslParkId");

                    b.ToTable("NationalParks");
                });

            modelBuilder.Entity("ParkyApplication.Models.TrailModels", b =>
                {
                    b.Property<int>("trailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("trailId"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<double>("Distance")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("difficulty")
                        .HasColumnType("int");

                    b.Property<int>("nationslParkId")
                        .HasColumnType("int");

                    b.HasKey("trailId");

                    b.HasIndex("nationslParkId");

                    b.ToTable("Trails");
                });

            modelBuilder.Entity("ParkyApplication.Models.TrailModels", b =>
                {
                    b.HasOne("ParkyApplication.Models.NationalParkModel", "NationalPark")
                        .WithMany()
                        .HasForeignKey("nationslParkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NationalPark");
                });
#pragma warning restore 612, 618
        }
    }
}
