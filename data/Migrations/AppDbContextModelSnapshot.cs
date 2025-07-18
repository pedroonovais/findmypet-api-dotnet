﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using data.Context;

#nullable disable

namespace data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("library.Model.Adocao", b =>
                {
                    b.Property<Guid>("idAdocao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)");

                    b.Property<DateTime>("dataAdocao")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<Guid>("idAnimal")
                        .HasColumnType("RAW(16)");

                    b.Property<Guid>("idPessoa")
                        .HasColumnType("RAW(16)");

                    b.Property<string>("tipoAdocao")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("NVARCHAR2(15)");

                    b.HasKey("idAdocao");

                    b.ToTable("TB_ADOCAO", (string)null);
                });

            modelBuilder.Entity("library.Model.Animal", b =>
                {
                    b.Property<Guid>("idAnimal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)");

                    b.Property<string>("especie")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("idadeEstimada")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("nomeAnimal")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("porte")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("idAnimal");

                    b.ToTable("TB_ANIMAL", (string)null);
                });

            modelBuilder.Entity("library.Model.Local", b =>
                {
                    b.Property<Guid>("idLocal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)");

                    b.Property<string>("cidade")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("dataOcorrencia")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("tipoDesastre")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("idLocal");

                    b.ToTable("TB_LOCAL", (string)null);
                });

            modelBuilder.Entity("library.Model.Pessoa", b =>
                {
                    b.Property<Guid>("idPessoa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("nomePessoa")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("tipoPessoa")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("idPessoa");

                    b.ToTable("TB_PESSOA", (string)null);
                });

            modelBuilder.Entity("library.Model.Report", b =>
                {
                    b.Property<Guid>("idReport")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)");

                    b.Property<DateTime>("dataReport")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("descricaoLocal")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)");

                    b.Property<Guid>("idAnimal")
                        .HasColumnType("RAW(16)");

                    b.Property<Guid>("idLocal")
                        .HasColumnType("RAW(16)");

                    b.Property<Guid>("idPessoa")
                        .HasColumnType("RAW(16)");

                    b.Property<Guid>("idSensor")
                        .HasColumnType("RAW(16)");

                    b.Property<string>("statusReport")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("NVARCHAR2(15)");

                    b.HasKey("idReport");

                    b.ToTable("TB_REPORT", (string)null);
                });

            modelBuilder.Entity("library.Model.Sensor", b =>
                {
                    b.Property<Guid>("idSensor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)");

                    b.Property<bool>("ativo")
                        .HasColumnType("NUMBER(1)");

                    b.Property<decimal>("latitude")
                        .HasColumnType("decimal(18,15)");

                    b.Property<decimal>("longitude")
                        .HasColumnType("decimal(18,15)");

                    b.Property<string>("tipoSensor")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("NVARCHAR2(15)");

                    b.HasKey("idSensor");

                    b.ToTable("TB_SENSOR", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
