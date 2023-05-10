using AutoMapper;
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
    public class CarrierReportsService : GenericService<CarrierReports>, ICarrierReportsService
    {
        public ICarrierReportsRepository _carrierReportsRepository;

        public IMapper _mapper;
        public CarrierReportsService(IGenericRepository<CarrierReports> repository, IUnitOfWork unitOfWork, ICarrierReportsRepository carrierReportsRepository,IMapper mapper) : base(repository, unitOfWork)
        {
            _carrierReportsRepository = carrierReportsRepository;
            _mapper = mapper;
        }

        public async Task<List<CarrierReports>> calculateCarrierReports(List<Orders> orders)
        {
      return await _carrierReportsRepository.calculateCarrierReports(orders);  
        }
    }
}
