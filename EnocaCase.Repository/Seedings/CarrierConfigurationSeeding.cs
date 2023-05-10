using EnocaCase.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaCase.Repository.Seedings
{
    public class CarrierConfigurationSeeding : IEntityTypeConfiguration<CarrierConfiguration>
    {
        public void Configure(EntityTypeBuilder<CarrierConfiguration> builder)
        {
            builder.HasData(new CarrierConfiguration
            {
                Id = 1,
                CarrierId=1,
                CarrierCost=32,
                CarrierMaxDesi=10,
                CarrierMinDesi=1,
                

            });
        }
    }
}
