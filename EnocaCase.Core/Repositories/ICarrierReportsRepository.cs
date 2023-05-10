using EnocaCase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaCase.Core.Repositories
{
    public interface ICarrierReportsRepository : IGenericRepository<CarrierReports>
    {
        public Task<List<CarrierReports>> calculateCarrierReports(List<Orders> orders);
    }
}
