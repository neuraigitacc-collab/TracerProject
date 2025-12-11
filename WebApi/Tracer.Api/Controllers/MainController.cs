using Microsoft.AspNetCore.Mvc;
using Tracer.Application.Dto;
using Tracer.Application.Service.Contracts;
using Tracer.Domain.Enums;


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

        [HttpGet("GetAllSaves")]
        public async Task<IActionResult> GetAllSaves()
        {
            var result = await devicesService.GetAllSaved();
            return Ok(result);
        }

        [HttpPost("SaveChange")]
        public async Task<IActionResult> SaveChanges(SavedItemDto dto)
        {
            if (dto.SaveData == null || dto.SaveData.Length == 0)
                return BadRequest("فایل صحیح نمیباشد");

            using var reader = new StreamReader(dto.SaveData.OpenReadStream());

            // متن JSON خام و بدون تغییر
            string rawJson = await reader.ReadToEndAsync();
            var result = new ResponseAction();
            if(dto.Id!= null && dto.Id != 0)
            {
                result = await devicesService.UpdateSaveConnection(dto.Id.Value , dto.Title, rawJson);
            }
            else
            {
                result = await devicesService.InsertSaveConnection(dto.Title, rawJson);
            }
                return Ok(result);
        }

        [HttpGet("GetSave")]
        public async Task<IActionResult> GetSave()
        {
            var result = await devicesService.GetSaveData();
            return Ok(result);
        }

        [HttpPost("RemoveSave")]
        public async Task<IActionResult> RemoveSave(int Id)
        {
            var result = await devicesService.RemoveSaveData(Id);
            return Ok(result);
        }

    }
}