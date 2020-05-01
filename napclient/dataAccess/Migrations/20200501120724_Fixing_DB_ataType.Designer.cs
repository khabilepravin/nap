﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dataAccess;

namespace dataAccess.Migrations
{
    [DbContext(typeof(dataContext))]
    [Migration("20200501120724_Fixing_DB_ataType")]
    partial class Fixing_DB_ataType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("models.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(3000)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("varchar(3000)");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("QuestionId")
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

            modelBuilder.Entity("models.Explanation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("CreatedByUser")
                        .HasColumnType("char(36)");

                    b.Property<string>("ExternalLink")
                        .HasColumnType("varchar(3000)");

                    b.Property<string>("LinkType")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("ModifiedByUser")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Status")
                        .HasColumnType("char(1)");

                    b.Property<string>("TextExplanation")
                        .HasColumnType("varchar(3000)");

                    b.HasKey("Id");

                    b.ToTable("Explanation");
                });

            modelBuilder.Entity("models.LookupGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

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
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(1000)");

                    b.Property<Guid>("GroupId")
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
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("CreatedByUser")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(3000)");

                    b.Property<string>("DifficultyLevel")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("varchar(3000)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("ModifiedByUser")
                        .HasColumnType("char(36)");

                    b.Property<string>("QuestionType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<short>("Sequence")
                        .HasColumnType("smallint");

                    b.Property<string>("Status")
                        .HasColumnType("char(1)");

                    b.Property<Guid>("TestId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Text")
                        .HasColumnType("varchar(3000)");

                    b.HasKey("Id");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("models.Test", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("CreatedByUser")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("DifficultyLevel")
                        .HasColumnType("varchar(100)");

                    b.Property<short>("DurationMinutes")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("ModifiedByUser")
                        .HasColumnType("char(36)");

                    b.Property<short>("Sequence")
                        .HasColumnType("smallint");

                    b.Property<string>("Status")
                        .HasColumnType("char(1)");

                    b.Property<string>("Subject")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Text")
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime");

                    b.Property<Guid>("ParentUserId")
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
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Status")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("TestId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("UserTest");
                });

            modelBuilder.Entity("models.UserTestRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AnswerId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserTestId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("UserTestRecord");
                });
#pragma warning restore 612, 618
        }
    }
}
