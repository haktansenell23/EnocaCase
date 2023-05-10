using EnocaCase.Core.Entities;
using EnocaCase.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaCase.Repository.Repositories
{
    public class CarriersConfigurationRepository : GenericRepository<CarrierConfiguration>, ICarrierConfigurationRepository
    {
        public CarriersConfigurationRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
