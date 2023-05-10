using AutoMapper;
using EnocaCase.Core.Dtos;
using EnocaCase.Core.Entities;
using EnocaCase.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnocaCase.API.Controllers
{

    public class OrdersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        private readonly ICarriersService _carrierService;
        private readonly ICarrierConfigurationService _carrierConfigurationService;


        public OrdersController(IOrderService orderService, IMapper mapper, ICarriersService carrierService)
        {
            _carrierService = carrierService;
            _mapper = mapper;
            _orderService = orderService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            var orders = await _orderService.GetAllAsync();



            return CreateActionResult(ResponseDto<List<Orders>>.Success(orders, 200));


        }



        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDto ordersDto)
        {
            var orderPlusCarrierInformation = await _orderService.FindCarrierAsync(ordersDto);
            var messageDto = new MessageDto();
            var order = new Orders
            {
                CarrierId = orderPlusCarrierInformation.CarrierId,
                OrderCarrierCost = orderPlusCarrierInformation.OrderCarrierCost,
                OrderDate = DateTime.Now,
                OrderDesi = ordersDto.OrderDesi,
            };




            var entity = await _orderService.AddAsync(order);


            messageDto.Message = $"{entity.Id} id'li siprariş {order.OrderDate} Tarihinde {orderPlusCarrierInformation.CarrierName} adlı firmada {order.OrderCarrierCost} TL karşılığında siparişiniz oluşturulmuştur.  ";


            return CreateActionResult(ResponseDto<MessageDto>.Success(messageDto, 200));

        }

        [HttpDelete]

        public async Task<IActionResult> DeleteOrder(OrderDeleteDto orderDeleteDto)
        {

            var order = await _orderService.GetByIdAsync(orderDeleteDto.Id);

            await _orderService.DeleteAsync(order);

            var messageDto = new MessageDto { Message = $"{orderDeleteDto}.siparişiniz silinmiştir" };

            return CreateActionResult(ResponseDto<MessageDto>.Success(messageDto, 200));


        }














    }
}
