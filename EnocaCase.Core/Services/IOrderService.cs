using EnocaCase.Core.Dtos;
using EnocaCase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaCase.Core.Services
{
    public interface IOrderService: IGenericService<Orders>
    {
        public Task<OrderPlusCarrierInformation> FindCarrierAsync(OrderDto orders);

    }
}
