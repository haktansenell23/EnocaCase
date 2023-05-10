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
    public class CarrierConfigurationService : GenericService<CarrierConfiguration>, ICarrierConfigurationService
    {
        ICarrierConfigurationRepository _carrierConfigurationRepository;
        public CarrierConfigurationService(ICarrierConfigurationRepository carrierConfigurationRepository, IGenericRepository<CarrierConfiguration> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _carrierConfigurationRepository = carrierConfigurationRepository;  

        }

    }
}
