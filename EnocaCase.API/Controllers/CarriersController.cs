using AutoMapper;
using EnocaCase.Core.Dtos;
using EnocaCase.Core.Entities;
using EnocaCase.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace EnocaCase.API.Controllers
{

    public class CarriersController : CustomBaseController
    {
        private readonly ICarriersService _carriersService;

        private readonly IMapper _mapper;

        public CarriersController(ICarriersService carriersService, IMapper mapper)
        {
            _mapper = mapper;
            _carriersService = carriersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarriers()
        {
            var carriers = await _carriersService.GetAllAsync();

            var carriersDto = _mapper.Map<List<CarriersDto>>(carriers);

            return CreateActionResult(ResponseDto<List<CarriersDto>>.Success(carriersDto, 200));

        }

        [HttpPost]

        public async Task<IActionResult> AddCarrier(CarriersDto carriersDto)
        {

            var carrier = await _carriersService.AddAsync(_mapper.Map<Carriers>(carriersDto));

            var messageDto = new MessageDto { Message = $"{carrier.Id} id 'li kargo firması güncellenmiştir" };

            return CreateActionResult(ResponseDto<MessageDto>.Success(messageDto, 200));

        }

        [HttpPut]

        public async Task<IActionResult> UpdateCarrier(UpdateCarrierDto carriersDto)
        {

            await _carriersService.UpdateAsync(_mapper.Map<Carriers>(carriersDto));

            var messageDto = new MessageDto { Message = $"{carriersDto.Id} id 'li kargo firması güncellenmiştir." };

            return CreateActionResult(ResponseDto<MessageDto>.Success(messageDto, 200));

        }

        [HttpDelete]

        public async Task<IActionResult> DeleteCarrier(int id)
        {
            var carrier = await _carriersService.GetByIdAsync(id);
            await _carriersService.DeleteAsync(carrier);

            var messageDto = new MessageDto { Message = $"{id} id 'li kargo firması silinmiştir." };

            return CreateActionResult(ResponseDto<MessageDto>.Success(messageDto, 200));

        }

    }
}
