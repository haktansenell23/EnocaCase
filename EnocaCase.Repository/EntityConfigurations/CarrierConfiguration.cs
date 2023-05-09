using EnocaCase.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaCase.Repository.EntityConfigurations
{
    public class CarrierConfiguration : IEntityTypeConfiguration<Carriers>
    {
        public void Configure(EntityTypeBuilder<Carriers> builder)
        {
           builder.ToTable("Carriers");
            
           builder.HasKey(x => x.Id);

           builder.HasMany(x=>x.CarrierConfigurations).WithOne(x=>x.Carriers).HasForeignKey(x=>x.CarrierId);   

           
         
        }
    }
}
