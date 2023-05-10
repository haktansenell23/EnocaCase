using EnocaCase.Core.Entities;
using EnocaCase.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaCase.Repository.Repositories
{
    public class CarriersRepository : GenericRepository<Carriers>, ICarriersRepository
    {
        public CarriersRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
