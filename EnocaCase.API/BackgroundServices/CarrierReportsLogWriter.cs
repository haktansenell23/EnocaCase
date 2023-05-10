using EnocaCase.Core.Entities;
using EnocaCase.Core.Repositories;
using EnocaCase.Core.Services;

namespace EnocaCase.API.BackgroundServices
{
    public class CarrierReportsLogWriter
    {
        private readonly ICarriersService _carriersService;
        private readonly ICarrierReportsService _carrierReportsService;
        private readonly IOrderService _orderService;
        public CarrierReportsLogWriter(ICarriersService carriersService, ICarrierReportsService carrierReportsService, IOrderService orderService)
        {
            _orderService = orderService;

            _carriersService = carriersService;
        
            _carrierReportsService = carrierReportsService;
        }

        public async Task CarrierReportsWriter()
        {
            var carriers = await _orderService.GetAllAsync();

             
      var reports = await  _carrierReportsService.calculateCarrierReports(carriers);


            foreach (var item in reports)
            {
                var carrier =await _carriersService.GetByIdAsync(item.CarrierId);

                Console.WriteLine($"{item.CarrierReportDate} tarihinde 1 saatlik bölümde {carrier.CarrierName} isimli kargo firmasına {item.Cost} tutarında ödeme yapılmıştır");
            }

            

        }

    }
}
