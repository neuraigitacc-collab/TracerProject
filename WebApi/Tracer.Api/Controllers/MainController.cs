using Microsoft.AspNetCore.Mvc;
using Tracer.Application.Dto;
using Tracer.Application.Service.Contracts;


namespace Tracer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainController(IValidationService service , IDevicesService devicesService): ControllerBase
    {
        [HttpPost("Validation")]
        public async Task<IActionResult> Validation(RecieveDataDto dto)
        {
            return Ok(await service.ValidationAsync(dto));
        }

        [HttpGet("Devices-List")]
        public async Task<IActionResult> DevicesList()
        {
            return Ok(await devicesService.GetDevices());
        }

        [HttpGet("Cable-List")]
        public async Task<IActionResult> CableList()
        {
            return Ok(await devicesService.GetCables());
        }

        //[HttpGet("DeviceType-List")]
        //public async Task<IActionResult> DeviceType()
        //{
        //    return Ok(await devicesService.GetDeviceTypes());
        //}

        [HttpPost("SaveChange")]
        public async Task<IActionResult> SaveChanges(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("فایل صحیح نمیباشد");

            using var reader = new StreamReader(file.OpenReadStream());

            // متن JSON خام و بدون تغییر
            string rawJson = await reader.ReadToEndAsync();
            var result = await devicesService.SaveConnections(rawJson);
            return Ok(result);
        }


        [HttpGet("GetSaves")]
        public async Task<IActionResult> GetSaves()
        {
            var result = await devicesService.GetSaveData();
            return Ok(result);
        }

    }
}