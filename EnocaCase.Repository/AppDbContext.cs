using EnocaCase.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EnocaCase.Repository
{
    public class AppDbContext : DbContext
    {

        public DbSet<Orders> Orders { get; set; }


        public DbSet<Carriers>Carriers { get; set; }

        public DbSet<CarrierConfiguration> CarrierConfigurations { get; set; }



        public AppDbContext(DbContextOptions<AppDbContext> options) : base()
        {

        }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
           Builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());    
        }

    }
}
