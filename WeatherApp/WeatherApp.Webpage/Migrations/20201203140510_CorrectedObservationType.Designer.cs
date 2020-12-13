﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherApp.WebSite.Models;

namespace WeatherApp.WebSite.Migrations
{
    [DbContext(typeof(ObservationsContext))]
    [Migration("20201203140510_CorrectedObservationType")]
    partial class CorrectedObservationType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WeatherApp.WebSite.Models.Observation", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Observations");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            City = "Budapest",
                            Description = "It is very hot and sunny here",
                            TimeStamp = new DateTime(2020, 11, 14, 9, 28, 0, 0, DateTimeKind.Unspecified),
                            UserName = "User"
                        },
                        new
                        {
                            ID = 2L,
                            City = "Budapest",
                            Description = "Freezing cold",
                            TimeStamp = new DateTime(2020, 10, 14, 9, 28, 0, 0, DateTimeKind.Unspecified),
                            UserName = "Jane"
                        },
                        new
                        {
                            ID = 3L,
                            City = "Madrid",
                            Description = "Beach time!",
                            TimeStamp = new DateTime(2020, 6, 14, 9, 28, 0, 0, DateTimeKind.Unspecified),
                            UserName = "Pablo"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
