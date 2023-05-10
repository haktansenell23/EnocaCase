using EnocaCase.Core.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnocaCase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : Controller
    {
        public IActionResult CreateActionResult<T>(ResponseDto<T> response)
        {
             if (response.StatusCode == 204)
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode,
                    Value = response,
                    
                   
                };


            }
            return new ObjectResult(response)
            {
                Value=response,
                StatusCode = response.StatusCode,
            };
        }


    }
}
