using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstPracticeUpdates.Models
{
    class ShelfContext : DbContext
    {
        public ShelfContext()
        {

        }

        public ShelfContext(DbContextOptions<ShelfContext> options) : base(options)
        {

        }

        public virtual DbSet<Shelf> Shelfs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //	Use Entity Framework to create a database called “codefirst_practice” using your models.
            if (!optionsBuilder.IsConfigured)
            {
                string connection =
                    "server=localhost;" +
                    "port=3306;" +
                    "user=root;" +
                    "database=codefirst_practice;";

                string version = "10.4.14-MariaDB";

                optionsBuilder.UseMySql(connection, x => x.ServerVersion(version));
            }

        }
        //for dababase migration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shelf>(entity =>
            {
                //create variable to hold FK name
                string keyName = "FK_" + nameof(Shelf) +
                    "_" + nameof(Shelf_Material);
                //collation only Text fields not intiger fields
                entity.Property(e => e.Name)
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.ShelfMaterialID)
                .HasName(keyName);

                entity.HasOne(thisEntity => thisEntity.Shelf_Material)
                .WithMany(parent => parent.Shelfs)
                .HasForeignKey(thisEntity => thisEntity.ShelfMaterialID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName(keyName);

                entity.HasData
                    (
                    new Shelf()
                    {
                        ID = -1,
                        Name = "Item1"
                    },
                    new Shelf()
                    {
                        ID = -2,
                        Name = "Item2"
                    },
                    new Shelf()
                    {
                        ID = -3,
                        Name = "Item3"
                    },
                    new Shelf()
                    {
                        ID = -4,
                        Name = "Item4"
                    },
                    new Shelf()
                    {
                        ID = -5,
                        Name = "Item5"
                    }
                    );
            });

        }
    }
}
