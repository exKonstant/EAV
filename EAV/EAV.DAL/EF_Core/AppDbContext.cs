using System;
using System.Collections.Generic;
using System.Text;
using EAV.DAL.EntityAttributeValue;
using Microsoft.EntityFrameworkCore;

namespace EAV.DAL.EF_Core
{
    public class AppDbContext : DbContext
    {
        public DbSet<Entity> Entities { get; set; }
        public DbSet<Attributes> Attributes { get; set; }
        public DbSet<Value> Values { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }
    }
}
