﻿using System.ComponentModel.DataAnnotations.Schema;
using DemensDel2.Models;
using Microsoft.EntityFrameworkCore;

namespace DemensDel2API.DataAccess
{
    public class DemensDbContext : DbContext
    {
        public DemensDbContext(DbContextOptions<DemensDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<TrainingSession> TrainingSessions { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseType> ExerciseTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(p => p.RowVersion)
                .IsRowVersion();

            modelBuilder.Entity<TrainingSession>()
                .Property(p => p.RowVersion)
                .IsRowVersion();

            modelBuilder.Entity<Exercise>()
                .Property(p => p.RowVersion)
                .IsRowVersion();

            modelBuilder.Entity<ExerciseType>()
                .Property(p => p.RowVersion)
                .IsRowVersion();
        }
    }
}
