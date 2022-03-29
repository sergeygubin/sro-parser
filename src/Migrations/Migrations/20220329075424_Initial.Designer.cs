﻿// <auto-generated />
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Migrations.Migrations
{
    [DbContext(typeof(SroParserDbContext))]
    [Migration("20220329075424_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SroParser.Domain.Entities.SroMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("full_name");

                    b.Property<long>("IdentificationNumber")
                        .HasColumnType("bigint")
                        .HasColumnName("identification_number");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("short_name");

                    b.HasKey("Id")
                        .HasName("id");

                    b.ToTable("sro_member", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
