﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using jewelryapi;

namespace jewelryapi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20190620172922_ArbitraryName")]
    partial class ArbitraryName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("jewelryapi.models.Locations", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("ManagerName");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("jewelryapi.models.Model", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("LocationId");

                    b.Property<DateTime>("dateordered");

                    b.Property<string>("description");

                    b.Property<string>("name");

                    b.Property<int>("price");

                    b.Property<int>("sku");

                    b.Property<int>("stock");

                    b.HasKey("id");

                    b.HasIndex("LocationId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("jewelryapi.models.Model", b =>
                {
                    b.HasOne("jewelryapi.models.Locations", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");
                });
#pragma warning restore 612, 618
        }
    }
}
