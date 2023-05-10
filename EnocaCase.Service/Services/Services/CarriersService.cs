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
    public class CarriersService : GenericService<Carriers>, ICarriersService
    {
        private readonly ICarriersRepository _carriersRepository;

        public CarriersService(ICarriersRepository carriersRepository,IGenericRepository<Carriers>repository,IUnitOfWork unitOfWork):base(repository,unitOfWork)
        {
            _carriersRepository = carriersRepository;
        }


    }
}
