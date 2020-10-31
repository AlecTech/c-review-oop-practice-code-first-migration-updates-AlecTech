﻿// <auto-generated />
using System;
using CodeFirstPracticeUpdates.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodeFirstPracticeUpdates.Migrations
{
    [DbContext(typeof(ShelfContext))]
    [Migration("20201031164548_Shelf_MaterialTable")]
    partial class Shelf_MaterialTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CodeFirstPracticeUpdates.Models.Shelf", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<int>("ShelfMaterialID")
                        .HasColumnType("int(10)");

                    b.Property<int?>("Shelfs")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ShelfMaterialID")
                        .HasName("FK_Shelf_Shelf_Material");

                    b.ToTable("shelfs");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            Name = "Item1",
                            ShelfMaterialID = 0
                        },
                        new
                        {
                            ID = -2,
                            Name = "Item2",
                            ShelfMaterialID = 0
                        },
                        new
                        {
                            ID = -3,
                            Name = "Item3",
                            ShelfMaterialID = 0
                        },
                        new
                        {
                            ID = -4,
                            Name = "Item4",
                            ShelfMaterialID = 0
                        },
                        new
                        {
                            ID = -5,
                            Name = "Item5",
                            ShelfMaterialID = 0
                        });
                });

            modelBuilder.Entity("CodeFirstPracticeUpdates.Models.Shelf_Material", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(10)");

                    b.Property<string>("MaterialName")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.HasKey("ID");

                    b.ToTable("shelf_material");
                });

            modelBuilder.Entity("CodeFirstPracticeUpdates.Models.Shelf", b =>
                {
                    b.HasOne("CodeFirstPracticeUpdates.Models.Shelf_Material", "Shelf_Material")
                        .WithMany("Shelfs")
                        .HasForeignKey("ShelfMaterialID")
                        .HasConstraintName("FK_Shelf_Shelf_Material")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
