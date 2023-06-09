﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcEvidence.Data;

#nullable disable

namespace MvcEvidence.Migrations
{
    [DbContext(typeof(MvcOsobaContext))]
    [Migration("20230512122317_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("MvcEvidence.Models.Osoba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Jmeno")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Pojistovna")
                        .HasColumnType("TEXT");

                    b.Property<string>("Prijmeni")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("Telefon")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Vek")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Osoba");
                });
#pragma warning restore 612, 618
        }
    }
}
