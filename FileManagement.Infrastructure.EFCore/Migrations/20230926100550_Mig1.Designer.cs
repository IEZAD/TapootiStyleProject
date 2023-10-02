﻿// <auto-generated />
using System;
using FileManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FileManagement.Infrastructure.EFCore.Migrations
{
    [DbContext(typeof(FileContext))]
    [Migration("20230926100550_Mig1")]
    partial class Mig1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FileManagement.Domain.FileAgg.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
                        .HasMaxLength(450)
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("FileServerId")
                        .HasMaxLength(450)
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("bit");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<long>("SizeOnDisk")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("FileServerId");

                    b.ToTable("Files", (string)null);
                });

            modelBuilder.Entity("FileManagement.Domain.FileServerAgg.FileServer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Capacity")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FTPData")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HttpDomain")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("HttpPath")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("FileServers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("812e3b67-7e01-4664-a72a-2957a146da80"),
                            Capacity = 0L,
                            CreationDate = new DateTime(2023, 9, 26, 13, 35, 50, 760, DateTimeKind.Local).AddTicks(6274),
                            FTPData = "",
                            HttpDomain = "http://127.0.0.127",
                            HttpPath = "/Main",
                            IsActive = true,
                            Name = "Public"
                        });
                });

            modelBuilder.Entity("FileManagement.Domain.FileAgg.File", b =>
                {
                    b.HasOne("FileManagement.Domain.FileServerAgg.FileServer", "FileServer")
                        .WithMany("Files")
                        .HasForeignKey("FileServerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FileServer");
                });

            modelBuilder.Entity("FileManagement.Domain.FileServerAgg.FileServer", b =>
                {
                    b.Navigation("Files");
                });
#pragma warning restore 612, 618
        }
    }
}