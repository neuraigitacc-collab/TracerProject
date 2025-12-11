using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using Tracer.Application.Dto;
using Tracer.Domain.Entities;
using Tracer.Domain.Enums;

namespace Tracer.Application.Service.Contracts
{
    public interface IDevicesService
    {
        Task<ICollection<DeviceListDto>> GetDevices();
        Task<ICollection<CableListDto>> GetCables();
        Task<ICollection<GetSavedDto>> GetAllSaved();
        Task<ResponseAction> InsertSaveConnection(string title , string SavedData);
        Task<ResponseAction> UpdateSaveConnection(int Id ,string title , string SavedData);
        Task<string> GetSaveData();
        Task<ResponseAction> RemoveSaveData(int id);
        //Task<ICollection<DeviceDto>> GetDeviceTypes();
    }
}