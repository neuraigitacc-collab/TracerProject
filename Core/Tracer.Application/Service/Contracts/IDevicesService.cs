using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using Tracer.Application.Dto;
using Tracer.Domain.Entities;

namespace Tracer.Application.Service.Contracts
{
    public interface IDevicesService
    {
        Task<ICollection<DeviceListDto>> GetDevices();
        Task<ICollection<CableListDto>> GetCables();
        Task<bool> SaveConnections(string data);
        Task<string> GetSaveData();
        //Task<ICollection<DeviceDto>> GetDeviceTypes();
    }
}