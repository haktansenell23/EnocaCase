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
    public class CarrierReportsRepository : GenericRepository<CarrierReports>, ICarrierReportsRepository
    {
        public CarrierReportsRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<List<CarrierReports>> calculateCarrierReports(List<Orders>orders)
        {
            List<Orders> thisDays=new List<Orders>();
            List < CarrierReports>carrierReports = new List<CarrierReports>();
            // Today's orders have been received
            foreach (var item in orders)
            {
                TimeSpan timeDifference = DateTime.Now - item.OrderDate;



                if (timeDifference.Days<=1)
                {
                    var temp = new Orders { CarrierId = item.CarrierId, OrderCarrierCost = item.OrderCarrierCost, OrderDate = item.OrderDate, OrderDesi = item.OrderDesi }; 
                    thisDays.Add(temp);
                }
            }
           
            thisDays=thisDays.OrderBy(x=>x.CarrierId).ToList();


            var carrierGroup =  thisDays.GroupBy(x => x.CarrierId).Select(z => new
            {
                CarrierId = z.Key,
                CarrierTotalCost =z.Sum(x=>x.OrderCarrierCost),
            }).ToList();


            foreach (var item in carrierGroup)
            {
                 var carrierReport= new CarrierReports { Cost = Decimal.ToInt32(item.CarrierTotalCost), CarrierId = item.CarrierId, CarrierReportDate = DateTime.Now };

                carrierReports.Add(carrierReport);  


                
            }

            
            
      


            return carrierReports;
        }
    }
}
