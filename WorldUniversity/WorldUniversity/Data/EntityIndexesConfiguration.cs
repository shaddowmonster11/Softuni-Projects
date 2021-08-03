using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Models.Entities;

namespace WorldUniversity.Data
{
    public class EntityIndexesConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            // IDeletableEntity.IsDeleted 
            var deletableEntityTypes = modelBuilder.Model
                .GetEntityTypes()
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                modelBuilder.Entity(deletableEntityType.ClrType).HasIndex(nameof(IDeletableEntity.IsDeleted));
            }
        }
    }
}
