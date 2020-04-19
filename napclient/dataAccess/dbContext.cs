using Microsoft.EntityFrameworkCore;
using models;
using System;

namespace dataAccess
{
    public class dataContext : DbContext
    {
        public dataContext() { }
        public dataContext(DbContextOptions<dataContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<Question> Question { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #region Comment this region-code for database migration and update
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseMySql("server=localhost;database=naplanpractice_dev;user=root;password=p0k5PgOzmgkF");

            //    this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //}
            #endregion

            #region Uncomment this region-code for database migration and update
            //Note: Put the connection string of your db
            optionsBuilder.UseMySql("server=localhost;database=naplanpractice_dev;user=root;password=p0k5PgOzmgkF");
            #endregion
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Text)
                        .HasColumnType("varchar(500)");
                entity.Property(e => e.Description)
                        .HasColumnType("varchar(1000)");
                entity.Property(e => e.CreatedAt);
                entity.Property(e => e.ModifiedAt);
                entity.Property(e => e.CreatedByUser)
                        .HasColumnType("char(36)");
                entity.Property(e => e.ModifiedByUser)
                        .HasColumnType("char(36)");
                entity.Property(e => e.Subject)
                        .HasColumnType("varchar(100)");
                entity.Property(e => e.DurationMinutes);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName)
                        .HasColumnType("varchar(100)");
                entity.Property(e => e.LastName)
                        .HasColumnType("varchar(100)");
                entity.Property(e => e.Email)
                        .HasColumnType("varchar(100)");
                entity.Property(e => e.UserName)
                        .HasColumnType("varchar(100)");
                entity.Property(e => e.UserType)
                        .HasColumnType("varchar(100)");
                entity.Property(e => e.CreatedAt)
                        .HasColumnType("datetime");
                entity.Property(e => e.ModifiedAt)
                        .HasColumnType("datetime");

            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Text)
                        .HasColumnType("varchar(3000)");
                entity.Property(e => e.Description)
                        .HasColumnType("varchar(3000)");
                entity.Property(e => e.CreatedAt);
                entity.Property(e => e.ModifiedAt);
                entity.Property(e => e.CreatedByUser)
                        .HasColumnType("char(36)");
                entity.Property(e => e.ModifiedByUser)
                        .HasColumnType("char(36)");
            });
        }
    }
}
