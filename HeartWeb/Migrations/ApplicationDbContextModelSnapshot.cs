﻿// <auto-generated />
using System;
using HeartWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HeartWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HeartWeb.Models.FormModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte>("AcidAlkalineState")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Apgar")
                        .HasColumnType("tinyint");

                    b.Property<byte>("ArterialPressure")
                        .HasColumnType("tinyint");

                    b.Property<bool>("Aspiration")
                        .HasColumnType("bit");

                    b.Property<byte>("AuskultativeLungPicture")
                        .HasColumnType("tinyint");

                    b.Property<byte>("AuskultativePicture")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("BirthTime")
                        .HasColumnType("datetime2");

                    b.Property<byte>("BreathFrequency")
                        .HasColumnType("tinyint");

                    b.Property<byte>("CardioDynamics")
                        .HasColumnType("tinyint");

                    b.Property<int>("ChildSex")
                        .HasColumnType("int");

                    b.Property<int>("DaysPassed")
                        .HasColumnType("int");

                    b.Property<byte>("Diurez")
                        .HasColumnType("tinyint");

                    b.Property<byte>("ECG")
                        .HasColumnType("tinyint");

                    b.Property<byte>("HeartBeatFrequency")
                        .HasColumnType("tinyint");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("LungFields")
                        .HasColumnType("tinyint");

                    b.Property<byte>("NoiseDynamics")
                        .HasColumnType("tinyint");

                    b.Property<byte>("OxygenBreathTest")
                        .HasColumnType("tinyint");

                    b.Property<byte>("PO2")
                        .HasColumnType("tinyint");

                    b.Property<byte>("PerepherialPulse")
                        .HasColumnType("tinyint");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<bool>("Prematurity")
                        .HasColumnType("bit");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte>("Rentgenography")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Saturation")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("SaveTime")
                        .HasColumnType("datetime2");

                    b.Property<byte>("SkinColor")
                        .HasColumnType("tinyint");

                    b.Property<byte>("StatusDynamics")
                        .HasColumnType("tinyint");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte>("WeightDynamics")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("FormResults");
                });

            modelBuilder.Entity("HeartWeb.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFromCity")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
