using AutoMapper;
using EnocaCase.Core.Dtos;
using EnocaCase.Core.Entities;
using EnocaCase.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EnocaCase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarriersConfigurationController : CustomBaseController
    {
        private readonly ICarrierConfigurationService _carrierConfigurationService;

        private readonly IMapper _mapper;

        public CarriersConfigurationController(ICarrierConfigurationService carrierConfigurationService, IMapper mapper)
        {
            _mapper = mapper;
            _carrierConfigurationService = carrierConfigurationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarriersConfigurations()
        {
            var carriersConfigurations = await _carrierConfigurationService.GetAllAsync();

            var carriersDto = _mapper.Map<List<CarrierConfigurationDto>>(carriersConfigurations);

            return CreateActionResult(ResponseDto<List < CarrierConfigurationDto >>.Success(carriersDto, 200));

        }

        [HttpPost]

        public async Task<IActionResult> AddCarriersConfigurations(CarrierConfigurationDto carriersDto)
        {

            var carrier = await _carrierConfigurationService.AddAsync(_mapper.Map<CarrierConfiguration>(carriersDto));

            var messageDto = new MessageDto { Message = $"{carrier.Id} id 'li kargo firması veritabanına eklenmiştir." };

            return CreateActionResult(ResponseDto<MessageDto>.Success(messageDto, 200));

        }

        [HttpPut]

        public async Task<IActionResult> UpdateCarrierConfiguration(UpdateCarrierConfigurationDto carrierConfigurationDto)
        {

            await _carrierConfigurationService.UpdateAsync(_mapper.Map<CarrierConfiguration>(carrierConfigurationDto));

            var messageDto = new MessageDto { Message = $"{carrierConfigurationDto.Id} id 'li kargo firması konfigrasyonları güncellenmiştir." };

            return CreateActionResult(ResponseDto<MessageDto>.Success(messageDto, 200));

        }

        [HttpDelete]

        public async Task<IActionResult> DeleteCarrierConfiguration(int id)
        {
            var carrier = await _carrierConfigurationService.GetByIdAsync(id);
            await _carrierConfigurationService.DeleteAsync(carrier);

            var messageDto = new MessageDto { Message = $"{id} id 'li kargo firması konfigrasyonları silinmiştir." };

            return CreateActionResult(ResponseDto<MessageDto>.Success(messageDto, 200));

        }



    }
}
