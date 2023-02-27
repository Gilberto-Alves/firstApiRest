using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JornadaNet.Entities;
using Microsoft.EntityFrameworkCore;

namespace JornadaNet.Persistence
{
    public class DevEncurtaUrlDbContext : DbContext
    {
    

        public DevEncurtaUrlDbContext(DbContextOptions<DevEncurtaUrlDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<ShortnedCustomLink> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<ShortnedCustomLink>(e => {
                e.HasKey(l => l.Id);
            });
        }
    }
}