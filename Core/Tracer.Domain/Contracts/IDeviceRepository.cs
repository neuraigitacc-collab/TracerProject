using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracer.Domain.Entities;
using Tracer.Domain.Enums;

namespace Tracer.Domain.Contracts
{
    public interface IDeviceRepository : IAsyncDisposable
    {
        Task<bool> ValidateConnection(int FirstPort, int Cable, int SecoundPort);
        Task<Devicestype?> GetDeviceType(int id);
        Task<ICollection<Device>> GetDevices(int id);
        Task<ICollection<Lanport>> GetDeviceLan(long id);
        Task<ICollection<Wanport>> GetDeviceWan(long id);
        Task<ICollection<Dslport>> GetDeviceDsl(long id);
        Task<ICollection<Fiberport>> GetDeviceFiber(long id);
        Task<ICollection<Usbport>> GetDeviceUsb(long id);
        Task<ICollection<Cable>> GetCables();
        Task<ICollection<Connectioncategory>> ConnectionCategories();
        Task<ICollection<Devicestype>> GetDeviceTypes();
        Task<ResponseAction> InsertSaveConnection(Connectiondatum model);
        Task<ResponseAction> UpdateSaveConnection(int Id, string title, string SavedData);
        Task<Connectiondatum?> GetSaveData(int id);
        Task<ResponseAction> RemoveSaveData(int id);
        Task SaveChangesAsync();
    }
}