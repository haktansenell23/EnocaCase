using EnocaCase.Core.Dtos;
using EnocaCase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaCase.Core.Repositories
{
    public interface IOrderRepository : IGenericRepository<Orders>
    {

        public Task<OrderPlusCarrierInformation> FindCarrierAsync(OrderDto orders);

    }
}
