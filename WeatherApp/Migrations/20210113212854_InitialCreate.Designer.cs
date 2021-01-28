﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherApp;

namespace WeatherApp.Migrations
{
    [DbContext(typeof(DbContext))]
    [Migration("20210113212854_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("WeatherApp.Models.Observation", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

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
                            Description = "It is very hot and sunny here",
                            Latitude = 47.49973,
                            Longitude = 19.05508,
                            TimeStamp = new DateTime(2020, 11, 14, 9, 28, 0, 0, DateTimeKind.Unspecified),
                            UserName = "User"
                        },
                        new
                        {
                            ID = 2L,
                            Description = "Freezing cold",
                            Latitude = 47.49973,
                            Longitude = 19.05508,
                            TimeStamp = new DateTime(2020, 10, 14, 9, 28, 0, 0, DateTimeKind.Unspecified),
                            UserName = "Jane"
                        },
                        new
                        {
                            ID = 3L,
                            Description = "Beach time!",
                            Latitude = 40.419559999999997,
                            Longitude = -3.6919599999999999,
                            TimeStamp = new DateTime(2020, 6, 14, 9, 28, 0, 0, DateTimeKind.Unspecified),
                            UserName = "Pablo"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
