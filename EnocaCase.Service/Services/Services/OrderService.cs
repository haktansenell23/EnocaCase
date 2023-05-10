using AutoMapper;
using EnocaCase.Core.Dtos;
using EnocaCase.Core.Entities;
using EnocaCase.Core.Repositories;
using EnocaCase.Core.Services;
using EnocaCase.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaCase.Service.Services.Services
{
    public class OrderService : GenericService<Orders>, IOrderService
    {
        IOrderRepository _orderRepository;
        ICarrierConfigurationRepository _carrierConfigurationRepository;
        private readonly IMapper _mapper;

        public OrderService(IMapper mapper,IGenericRepository<Orders> repository, IUnitOfWork unitOfWork, IOrderRepository orderRepository, ICarrierConfigurationRepository carrierConfigurationRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _carrierConfigurationRepository = carrierConfigurationRepository;
            _orderRepository = orderRepository;
        }

        public  async Task<OrderPlusCarrierInformation> FindCarrierAsync(OrderDto orders)
        {

            var orderDesi = orders.OrderDesi;

            var selectedCarrierConfiguration = await _orderRepository.FindCarrierAsync(orders);

            return selectedCarrierConfiguration;

        }
    }
}
