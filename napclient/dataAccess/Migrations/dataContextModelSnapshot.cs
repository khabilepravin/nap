﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dataAccess;

namespace dataAccess.Migrations
{
    [DbContext(typeof(dataContext))]
    partial class dataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("models.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(3000)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("varchar(3000)");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<string>("PlainText")
                        .HasColumnType("varchar(3000)");

                    b.Property<string>("QuestionId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<int>("Sequence")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("char(1)");

                    b.Property<string>("Text")
                        .HasColumnType("varchar(3000)");

                    b.Property<string>("Type")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("models.AnswerFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnswerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FileId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AnswerFile");
                });

            modelBuilder.Entity("models.Explanation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedByUser")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<string>("ExternalLink")
                        .HasColumnType("varchar(3000)");

                    b.Property<string>("LinkType")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedByUser")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<string>("QuestionId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<string>("Status")
                        .HasColumnType("char(1)");

                    b.Property<string>("TextExplanation")
                        .HasColumnType("varchar(3000)");

                    b.HasKey("Id");

                    b.ToTable("Explanation");
                });

            modelBuilder.Entity("models.FileStorage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Data")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Extension")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("FileType")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(300)");

                    b.HasKey("Id");

                    b.ToTable("FileStorage");
                });

            modelBuilder.Entity("models.LookupGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("LookupGroup");
                });

            modelBuilder.Entity("models.LookupValue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("GroupId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("LookupValue");
                });

            modelBuilder.Entity("models.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedByUser")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(3000)");

                    b.Property<string>("DifficultyLevel")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FileId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("varchar(3000)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedByUser")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<string>("PlainText")
                        .HasColumnType("varchar(3000)");

                    b.Property<string>("QuestionType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("Sequence")
                        .HasColumnType("smallint");

                    b.Property<string>("Status")
                        .HasColumnType("char(1)");

                    b.Property<string>("TestId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<string>("Text")
                        .HasColumnType("varchar(3000)");

                    b.HasKey("Id");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("models.QuestionFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("QuestionFile");
                });

            modelBuilder.Entity("models.Test", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedByUser")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("DifficultyLevel")
                        .HasColumnType("varchar(100)");

                    b.Property<short>("DurationMinutes")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedByUser")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<short>("Sequence")
                        .HasColumnType("smallint");

                    b.Property<string>("Status")
                        .HasColumnType("char(1)");

                    b.Property<string>("Subject")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Text")
                        .HasColumnType("varchar(500)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ParentUserId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Status")
                        .HasColumnType("char(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("UserType")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("models.UserTest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mode")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("TestId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("UserTest");
                });

            modelBuilder.Entity("models.UserTestRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnswerId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<string>("AnswerText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<string>("QuestionId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<string>("UserTestId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("UserTestRecord");
                });
#pragma warning restore 612, 618
        }
    }
}
