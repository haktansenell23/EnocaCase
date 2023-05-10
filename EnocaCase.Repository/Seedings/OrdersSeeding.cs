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
    public class OrdersSeeding : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
     
            builder.HasData(new Orders
            {
                Id = 1,
                CarrierId=1,
                OrderDesi=13,
                OrderCarrierCost=44,
                OrderDate=DateTime.Now, 
                
            });
        }
    }
}
