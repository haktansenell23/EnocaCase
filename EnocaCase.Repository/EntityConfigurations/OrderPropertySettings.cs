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
    public class OrderPropertySettings : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Carriers).WithMany(x => x.Orders).HasForeignKey(x => x.CarrierId);

            builder.Property(x=>x.OrderCarrierCost).IsRequired();   

            builder.Property(x=>x.OrderDate).IsRequired();

            builder.Property(x=>x.OrderDesi).IsRequired();  


        }
    }
}
