﻿// <auto-generated />
using System;
using HeartWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HeartWeb.Models.FormModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<byte>("AcidAlkalineState")
                        .HasColumnType("smallint");

                    b.Property<byte>("Apgar")
                        .HasColumnType("smallint");

                    b.Property<byte>("ArterialPressure")
                        .HasColumnType("smallint");

                    b.Property<bool>("Aspiration")
                        .HasColumnType("boolean");

                    b.Property<byte>("AuskultativeLungPicture")
                        .HasColumnType("smallint");

                    b.Property<byte>("AuskultativePicture")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("BirthTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<byte>("BreathFrequency")
                        .HasColumnType("smallint");

                    b.Property<byte>("CardioDynamics")
                        .HasColumnType("smallint");

                    b.Property<int>("ChildSex")
                        .HasColumnType("integer");

                    b.Property<int>("DaysPassed")
                        .HasColumnType("integer");

                    b.Property<byte>("Diurez")
                        .HasColumnType("smallint");

                    b.Property<byte>("ECG")
                        .HasColumnType("smallint");

                    b.Property<byte>("HeartBeatFrequency")
                        .HasColumnType("smallint");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte>("LungFields")
                        .HasColumnType("smallint");

                    b.Property<byte>("NoiseDynamics")
                        .HasColumnType("smallint");

                    b.Property<byte>("OxygenBreathTest")
                        .HasColumnType("smallint");

                    b.Property<byte>("PO2")
                        .HasColumnType("smallint");

                    b.Property<byte>("PerepherialPulse")
                        .HasColumnType("smallint");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.Property<bool>("Prematurity")
                        .HasColumnType("boolean");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<byte>("Rentgenography")
                        .HasColumnType("smallint");

                    b.Property<byte>("Saturation")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("SaveTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<byte>("SkinColor")
                        .HasColumnType("smallint");

                    b.Property<byte>("StatusDynamics")
                        .HasColumnType("smallint");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<byte>("WeightDynamics")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("FormResults");
                });

            modelBuilder.Entity("HeartWeb.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Admin")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsFromCity")
                        .HasColumnType("boolean");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
