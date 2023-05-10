using EnocaCase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaCase.Core.Services
{
    public interface ICarrierReportsService : IGenericService<CarrierReports>
    {
        public Task<List<CarrierReports>> calculateCarrierReports(List<Orders> orders);

    }
}
