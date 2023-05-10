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
    public class CarrierSeeding : IEntityTypeConfiguration<Carriers>
    {
        public void Configure(EntityTypeBuilder<Carriers> builder)
        {
            builder.HasData(new Carriers
            {
                Id = 1,
                CarrierIsActive = true,
                CarrierName="MNG",
                CarrierPlusDesiCost=4,


            });
        }
    }
}
