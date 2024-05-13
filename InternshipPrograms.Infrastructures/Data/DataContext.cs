using InternshipPrograms.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace InternshipPrograms.Infrastructures.Data
{
    public class DataContext : DbContext
    { 
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Questions> Questions { get; set; }
        public DbSet<CandidateApplication> CandidateApplication { get; set; }
        public DbSet<Program> Program { get; set; } 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultContainer("ProgramsDetails");

            builder.Entity<Questions>()
             .ToContainer(nameof(Questions))
             .HasPartitionKey(c => c.Id)
             .HasNoDiscriminator();

            builder.Entity<CandidateApplication>()
             .ToContainer(nameof(CandidateApplication))
             .HasPartitionKey(o => o.Id)
            .HasNoDiscriminator();

            builder.Entity<Program>()
             .ToContainer(nameof(Program))
             .HasPartitionKey(c => c.Id)
             .HasNoDiscriminator();
              
            base.OnModelCreating(builder);
        }
    }
}