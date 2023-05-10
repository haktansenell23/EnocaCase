using EnocaCase.Core.Dtos;
using EnocaCase.Core.Entities;
using EnocaCase.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaCase.Repository.Repositories
{
    public class OrderRepository : GenericRepository<Orders>, IOrderRepository
    {
        public OrderRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<OrderPlusCarrierInformation> FindCarrierAsync(OrderDto orders)
        {
            int cost = 0;

            var orderDesi = orders.OrderDesi;

            List<CarrierConfiguration> carrierConfigurations = new List<CarrierConfiguration>();    

            CarrierConfiguration carrierConfiguration = null;

            carrierConfigurations=await _appDbContext.Set<CarrierConfiguration>().Where(x=>x.CarrierMaxDesi>=orderDesi && x.CarrierMinDesi<=orderDesi).ToListAsync();

            if (carrierConfigurations.Count == 0)
            {
                carrierConfigurations = await _appDbContext.Set<CarrierConfiguration>().ToListAsync();

                int minDesi = carrierConfigurations.First().CarrierMinDesi;

                int maxDesi = carrierConfigurations.First().CarrierMaxDesi;

                int tempDesi = Math.Abs(orders.OrderDesi - minDesi);

                int tempDesi2 = Math.Abs(orders.OrderDesi - maxDesi);

                int minQunatity = Math.Min(tempDesi, tempDesi2);

                carrierConfiguration = carrierConfigurations.First();

                carrierConfiguration.Carriers = await _appDbContext.Set<Carriers>().FindAsync(carrierConfiguration.CarrierId);

                int tempCost = minQunatity * carrierConfiguration.Carriers.CarrierPlusDesiCost + carrierConfiguration.CarrierCost;


                foreach (var item in carrierConfigurations)
                {
                     minDesi = item.CarrierMinDesi;

                     maxDesi = item.CarrierMaxDesi;

                     minQunatity = Math.Min(tempDesi, tempDesi2);

                     item.Carriers= await _appDbContext.Set<Carriers>().FindAsync(item.CarrierId);

                     cost = item.CarrierCost+minQunatity*item.Carriers.CarrierPlusDesiCost;



                    if (cost < tempCost && carrierConfiguration.Carriers.CarrierIsActive==true )
                    {
                        tempCost = cost;

                        carrierConfiguration = item;
                    }
                }
                OrderPlusCarrierInformation orderPlusCarrierInformation = new OrderPlusCarrierInformation
                {
                    CarrierId = carrierConfiguration.CarrierId,
                    CarrierIsActive = carrierConfiguration.Carriers.CarrierIsActive,
                    CarrierName = carrierConfiguration.Carriers.CarrierName,
                    OrderCarrierCost= tempCost,
                };
                   
                return orderPlusCarrierInformation;


            }

            else
            {
                 carrierConfiguration = carrierConfigurations.First();

                carrierConfiguration.Carriers = await _appDbContext.Set<Carriers>().FindAsync(carrierConfiguration.CarrierId);
              
                int tempCost = carrierConfiguration.CarrierCost;

                carrierConfiguration = carrierConfigurations.First();
                foreach (var item in carrierConfigurations)
                {
                  
                     cost = item.CarrierCost;

                    if (tempCost<cost)
                    {
                        cost = tempCost;

                        carrierConfiguration = item;
                    }
                }
                OrderPlusCarrierInformation orderPlusCarrierInformation = new OrderPlusCarrierInformation
                {
                    CarrierId = carrierConfiguration.CarrierId,
                    CarrierIsActive = carrierConfiguration.Carriers.CarrierIsActive,
                    CarrierName = carrierConfiguration.Carriers.CarrierName,
                    OrderCarrierCost = tempCost,
                    
                   

                };
                return orderPlusCarrierInformation;
            }

        }
    }
}
