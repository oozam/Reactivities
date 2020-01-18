namespace Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;

    public class ReactivitiesDbContext : DbContext
    {
        public ReactivitiesDbContext(DbContextOptions<ReactivitiesDbContext> options) : base(options)
        {

        }

        public DbSet<Value> Values { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Value>()
                .HasData(
                    new Value { Id = 1, Name = "Value 1"},
                    new Value { Id = 2, Name = "Value 2"},
                    new Value { Id = 3, Name = "Value 3"}
                );

            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
                entity.SetTableName(entity.DisplayName());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReactivitiesDbContext).Assembly);
        }
    }
}
