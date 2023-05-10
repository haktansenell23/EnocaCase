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
    public class CarrierConfigurationPropertySettings : IEntityTypeConfiguration<CarrierConfiguration>
    {
        public void Configure(EntityTypeBuilder<CarrierConfiguration> builder)
        {
            builder.ToTable("CarrierConfiguration");  

            builder.HasKey(x=> x.Id);   

            builder.HasOne(x=>x.Carriers).WithMany(x=>x.CarrierConfigurations).HasForeignKey(x=>x.CarrierId);

            builder.Property(x => x.CarrierMinDesi).IsRequired();

            builder.Property(x=>x.CarrierCost).IsRequired();    

            builder.Property(x=>x.CarrierMaxDesi).IsRequired();






        }
    }
}
