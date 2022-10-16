using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<RoleEntity> Roles => Set<RoleEntity>();
        public DbSet<FoodEntity> Foods => Set<FoodEntity>();
        public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
        public DbSet<PriceEntity> PriceEntities => Set<PriceEntity>();
        public DbSet<OrderEntity> Orders => Set<OrderEntity>();
        public DbSet<PostalCodeEntity> PostalCodes => Set<PostalCodeEntity>();
        public DbSet<AddressEntity> Addresses => Set<AddressEntity>();
        public DbSet<OpeningHoursEntity> OpeningHours => Set<OpeningHoursEntity>();
        public DbSet<DayEntity> Days => Set<DayEntity>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
