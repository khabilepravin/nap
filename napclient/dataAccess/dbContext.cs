using Microsoft.EntityFrameworkCore;
using models;
using System;
using Microsoft.EntityFrameworkCore.SqlServer;

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
        public DbSet<UserTest> UserTest { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<UserTestRecord> UserTestRecord { get; set; }
        public DbSet<Explanation> Explanation { get; set; }
        public DbSet<LookupGroup> LookupGroup { get; set; }
        public DbSet<LookupValue> LookupValue { get; set; }
        public DbSet<FileStorage> FileStorage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #region Comment this region-code for database migration and update
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=nap;Integrated Security=true;");

                this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            }
            #endregion

            #region Uncomment this region-code for database migration and update
            //Note: Put the connection string of your db
            //optionsBuilder.UseMySql("server=localhost;database=naplanpractice_dev;user=root;password=p0k5PgOzmgkF");
            //optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=nap;Integrated Security=true;");
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
                entity.Property(e => e.Status)
                    .HasColumnType("char(1)");
                entity.Property(e => e.DifficultyLevel)
                        .HasColumnType("varchar(100)");
                entity.Property(e => e.Year);
            });

            modelBuilder.Entity<Test>().Property(e => e.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName)
                        .HasColumnType("varchar(100)");
                entity.Property(e => e.LastName)
                        .HasColumnType("varchar(100)");
                entity.Property(e => e.Password)
                        .HasColumnType("varchar(500)");
                entity.Property(e => e.Email)
                        .HasColumnType("varchar(100)");
                entity.Property(e => e.UserName)
                        .HasColumnType("varchar(100)");
                entity.Property(e => e.UserType)
                        .HasColumnType("varchar(100)");
                entity.Property(e => e.ParentUserId)
                        .HasColumnType("char(36)");
                entity.Property(e => e.CreatedAt)
                        ;
                entity.Property(e => e.ModifiedAt)
                        ;
                entity.Property(e => e.Status)
                        .HasColumnType("char(1)");

            });
            modelBuilder.Entity<User>().Property(e => e.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Text)
                        .HasColumnType("varchar(3000)");
                entity.Property(e => e.Description)
                        .HasColumnType("varchar(3000)");
                entity.Property(e => e.TestId)
                        .HasColumnType("char(36)");
                entity.Property(e => e.CreatedAt);
                entity.Property(e => e.ModifiedAt);
                entity.Property(e => e.CreatedByUser)
                        .HasColumnType("char(36)");
                entity.Property(e => e.ModifiedByUser)
                        .HasColumnType("char(36)");
                entity.Property(e => e.ImageUrl)
                        .HasColumnType("varchar(3000)");
                entity.Property(e => e.Status)
                        .HasColumnType("char(1)");
                entity.Property(e => e.DifficultyLevel)
                        .HasColumnType("varchar(100)");
                entity.Property(e => e.FileId)
                        .HasColumnType("char(36)");
                entity.Property(e => e.PlainText)
                    .HasColumnType("varchar(3000)");

            });
            modelBuilder.Entity<Question>().Property(e => e.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Text)
                        .HasColumnType("varchar(3000)");
                entity.Property(e => e.Description)
                        .HasColumnType("varchar(3000)");
                entity.Property(e => e.QuestionId)
                        .HasColumnType("char(36)");
                entity.Property(e => e.Type)
                        .HasColumnType("varchar(100)");
                entity.Property(e => e.IsCorrect);
                entity.Property(e => e.ImageUrl)
                        .HasColumnType("varchar(3000)");
                entity.Property(e => e.Sequence);
                entity.Property(e => e.Status)
                        .HasColumnType("char(1)");
                entity.Property(e => e.PlainText)
                  .HasColumnType("varchar(3000)");
            });
            modelBuilder.Entity<Answer>().Property(e => e.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<UserTest>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UserId)
                        .HasColumnType("char(36)");
                entity.Property(e => e.Status)
                        .HasColumnType("varchar(100)");
                entity.Property(e => e.Mode)
                        .HasColumnType("varchar(50)");
                entity.Property(e => e.TestId)
                        .HasColumnType("char(36)");
                entity.Property(e => e.CreatedAt);
                entity.Property(e => e.ModifiedAt);
            });
            modelBuilder.Entity<UserTest>().Property(e => e.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<UserTestRecord>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UserTestId)
                        .HasColumnType("char(36)");
                entity.Property(e => e.QuestionId)
                        .HasColumnType("char(36)");
                entity.Property(e => e.AnswerId)
                        .HasColumnType("char(36)");
            });
            modelBuilder.Entity<UserTestRecord>().Property(e => e.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Explanation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.QuestionId)
                        .HasColumnType("char(36)");
                entity.Property(e => e.TextExplanation)
                        .HasColumnType("varchar(3000)");
                entity.Property(e => e.ExternalLink)
                        .HasColumnType("varchar(3000)");
                entity.Property(e => e.LinkType)
                        .HasColumnType("varchar(100)");
                entity.Property(e => e.CreatedAt);
                entity.Property(e => e.ModifiedAt);
                entity.Property(e => e.CreatedByUser)
                                .HasColumnType("char(36)");
                entity.Property(e => e.ModifiedByUser)
                                .HasColumnType("char(36)");
                entity.Property(e => e.Status)
                            .HasColumnType("char(1)");

            });
            modelBuilder.Entity<Explanation>().Property(e => e.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<LookupGroup>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                                .HasColumnType("varchar(100)");
                entity.Property(e => e.Code)
                                .HasColumnType("varchar(30)");

            });
            modelBuilder.Entity<LookupGroup>().Property(e => e.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<LookupValue>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.GroupId)
                        .HasColumnType("char(36)");
                entity.Property(e => e.Name)
                                .HasColumnType("varchar(100)");
                entity.Property(e => e.Code)
                                .HasColumnType("varchar(30)");
                entity.Property(e => e.Description)
                                .HasColumnType("varchar(1000)");

            });
            modelBuilder.Entity<LookupValue>().Property(e => e.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<FileStorage>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FileType)
                        .HasColumnType("varchar(100)");
                entity.Property(e => e.Name)
                                .HasColumnType("varchar(300)");
                entity.Property(e => e.Extension)
                                .HasColumnType("varchar(30)");
                entity.Property(e => e.Data)
                                .HasColumnType("varbinary(max)");
                entity.Property(e => e.CreatedAt);
                entity.Property(e => e.ModifiedAt);
            });

            modelBuilder.Entity<FileStorage>().Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}
