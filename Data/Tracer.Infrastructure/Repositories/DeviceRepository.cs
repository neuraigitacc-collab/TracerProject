using Microsoft.EntityFrameworkCore;
using Tracer.Domain.Contracts;
using Tracer.Domain.Entities;
using Tracer.Infrastructure.Context;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tracer.Infrastructure.Repositories
{
    public class DeviceRepository(AppDbContext context) : IDeviceRepository
    {
        public async Task<ICollection<Device>> GetDevices(int id)
        {
            return await context.Devices.Where(x => x.DeviceType == id).ToListAsync();

        }

        public async Task<ICollection<Lanport>> GetDeviceLan(long id)
        {
            return context.LanforDevices.Include(x => x.Lan).Where(x => x.DeviceId == id).Select(x => x.Lan).ToList();
        }

        public async Task<ICollection<Wanport>> GetDeviceWan(long id)
        {
            return context.WanforDevices.Include(x => x.Wan).Where(x => x.DeviceId == id).Select(x => x.Wan).ToList();
        }

        public async Task<ICollection<Dslport>> GetDeviceDsl(long id)
        {
            return context.DslforDevices.Include(x => x.Dsl).Where(x => x.DeviceId == id).Select(x => x.Dsl).ToList();
        }

        public async Task<ICollection<Fiberport>> GetDeviceFiber(long id)
        {
            return context.FiberforDevices.Include(x => x.Sf).Where(x => x.DeviceId == id).Select(x => x.Sf).ToList();
        }

        public async Task<ICollection<Usbport>> GetDeviceUsb(long id)
        {
            return context.UsbforDevices.Include(x => x.Usb).Where(x => x.DeviceId == id).Select(x => x.Usb).ToList();
        }

        public Task<bool> ValidateConnection(int FirstPort, int Cable, int SecoundPort)
        {
            try
            {
                var valid = context.Connectionports.AnyAsync(x => x.Firstport == FirstPort && x.Cable == Cable && x.Conectedport == SecoundPort);
                return valid;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Devicestype?> GetDeviceType(int id)
        {
            var type = await context.Devicestypes.SingleOrDefaultAsync(x => x.Id == id);
            return type;
        }

        public async Task<ICollection<Cable>> GetCables()
        {
            return await context.Cables.ToListAsync();
        }

        public async Task<ICollection<Devicestype>> GetDeviceTypes()
        {
            return await context.Devicestypes.ToListAsync();
        }

        public async Task<ICollection<Connectioncategory>> ConnectionCategories()
        {
            return await context.Connectioncategories.Include(x => x.Cables)
                .ThenInclude(x => x.Properties).Include(x => x.Cables)
        .ThenInclude(c => c.Visuals).ToListAsync();
        }

        async ValueTask IAsyncDisposable.DisposeAsync()
        {
            if (context != null)
            {
                await context.DisposeAsync();
            }

        }

        public async Task<bool> SaveConnections(string data)
        {
            try
            {
                 context.Connectiondata.Add(new Connectiondatum() 
                 {
                     Savedata = data
                 });
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> GetSaveData()
        {
            try
            {
                var data = await context.Connectiondata.OrderBy(x=>x.Createddate).LastOrDefaultAsync();
                if (data == null) return "";
                return data.Savedata;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
