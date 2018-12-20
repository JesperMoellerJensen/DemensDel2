﻿// <auto-generated />
using System;
using DemensDel2API.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DemensDel2API.Migrations
{
    [DbContext(typeof(DemensDbContext))]
    [Migration("20181220085056_MoreDataAnnotations")]
    partial class MoreDataAnnotations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DemensDel2.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ExerciseTypeId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int?>("TrainingSessionId");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseTypeId");

                    b.HasIndex("TrainingSessionId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("DemensDel2.Models.ExerciseResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Effort");

                    b.Property<double>("ExecutionRate");

                    b.Property<int?>("ExerciseId");

                    b.Property<int>("PaintLevel");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("UserId");

                    b.ToTable("ExerciseResults");
                });

            modelBuilder.Entity("DemensDel2.Models.ExerciseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("Difficulty");

                    b.Property<float>("Duration");

                    b.Property<string>("MuscleGroup")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("ExerciseTypes");
                });

            modelBuilder.Entity("DemensDel2.Models.TrainingSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("TrainingSessions");
                });

            modelBuilder.Entity("DemensDel2.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int>("Age");

                    b.Property<string>("City");

                    b.Property<string>("Name");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("TelephoneNumber");

                    b.Property<string>("UserIdentityID");

                    b.Property<int>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DemensDel2.Models.UserTrainingSessionRelation", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("TrainingSessionId");

                    b.Property<double>("Percent");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("UserId", "TrainingSessionId");

                    b.ToTable("UserTrainingSessionRelations");
                });

            modelBuilder.Entity("DemensDel2.Models.Exercise", b =>
                {
                    b.HasOne("DemensDel2.Models.ExerciseType", "ExerciseType")
                        .WithMany()
                        .HasForeignKey("ExerciseTypeId");

                    b.HasOne("DemensDel2.Models.TrainingSession", "TrainingSession")
                        .WithMany()
                        .HasForeignKey("TrainingSessionId");
                });

            modelBuilder.Entity("DemensDel2.Models.ExerciseResult", b =>
                {
                    b.HasOne("DemensDel2.Models.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId");

                    b.HasOne("DemensDel2.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}