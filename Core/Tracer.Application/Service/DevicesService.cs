using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Tracer.Application.Dto;
using Tracer.Application.Dto.Connections;
using Tracer.Application.Dto.Ports;
using Tracer.Application.Service.Contracts;
using Tracer.Domain.Contracts;
using Tracer.Domain.Entities;
using Tracer.Domain.Enums;

namespace Tracer.Application.Service;

public class DevicesService(IDeviceRepository repository) : IDevicesService
{
    public async Task<ICollection<DeviceListDto>> GetDevices()
    {
        try
        {
            var types = await repository.GetDeviceTypes();
            var result = new List<DeviceListDto>();
            foreach (var type in types)
            {
                var model = new DeviceListDto()
                {
                    Code = type.Code,
                    Icon = type.Icon,
                    Name = type.Name,
                    Devices = new List<DeviceDto>()
                };

                var devices = await repository.GetDevices(type.Id);
                foreach(var device in devices)
                {
                    //var deviceType = await repository.GetDeviceType(device.DeviceType);
                    var dsl = await repository.GetDeviceDsl(device.Id);
                    var lan = await repository.GetDeviceLan(device.Id);
                    var wan = await repository.GetDeviceWan(device.Id);
                    var fiber = await repository.GetDeviceFiber(device.Id);
                    var usb = await repository.GetDeviceUsb(device.Id);
                    var category = await repository.GetDeviceType(device.DeviceType);

                    var internalDevice = new DeviceDto();
                    internalDevice.name = device.Title;
                        //internalDevice.Brand = device.Brand;
                        //internalDevice.type = device.na;
                    internalDevice.Dsl = dsl?.Select(x => new DslDto() { Code = x.Code, Model = x.Model, Title = x.Title }).ToList();
                        internalDevice.Wan = wan?.Select(x => new WanDto() { Code = x.Code, Model = x.Model, Title = x.Title }).ToList();
                        internalDevice.Usb = usb?.Select(x => new UsbDto() { Code = x.Code, Model = x.Model, Title = x.Title }).ToList();
                    internalDevice.Fiber = fiber?.Select(x => new FiberDto() { Code = x.Code, Model = x.Model, Title = x.Title }).ToList();
                    internalDevice.Lan = lan?.Select(x => new LanDto() { Code = x.Code, Model = x.Model, Title = x.Title }).ToList();
                    internalDevice.type = device.Model;
                    internalDevice.Description = device.Description;
                    internalDevice.Color = device.Color;
                    internalDevice.Icon = device.Icon;

                    model.Devices.Add(internalDevice);
                }



                //var model = new DeviceListDto()
                //{
                //    Brand = device.Brand,
                //    Model = device.Model,
                //    Title = device.Title,
                //    Dsl = dsl.Select(x => new DslDto() { Code = x.Code, Model = x.Model, Title = x.Title }).ToList(),
                //    Wan = wan.Select(x => new WanDto() { Code = x.Code, Model = x.Model, Title = x.Title }).ToList(),
                //    Usb = usb.Select(x => new UsbDto() { Code = x.Code, Model = x.Model, Title = x.Title }).ToList(),
                //    Fiber = fiber.Select(x => new FiberDto() { Code = x.Code, Model = x.Model, Title = x.Title }).ToList(),
                //    Lan = lan.Select(x => new LanDto() { Code = x.Code, Model = x.Model, Title = x.Title }).ToList(),
                //    Type = type
                //};

                result.Add(model);
            }

            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ICollection<CableListDto>> GetCables()
    {
        try
        {
            var categories = await repository.ConnectionCategories();
            var result = new List<CableListDto>();

            foreach (var category in categories) 
            {
                result.Add(new CableListDto()
                {
                    Name = category.Title,
                    Icon = category.Icon,
                    connections = category.Cables.Select(x=> new ConnectionDto()
                    {
                        Code = x.Code,
                        Color = x.Color,
                        Description = x.Description,
                        Icon = x.Icon,
                        Name = x.Name,
                        type = x.Model,
                        propertice = x.Properties.Select(x=> new propertiesDto() 
                        {
                            Bandwidth = x.Bandwidth,
                            Maxdistance = x.Maxdistance,
                            Duplex = x.Duplex,
                             Latency = x.Latency
                        }).FirstOrDefault(),
                        visual = x.Visuals.Select(x=> new visualDto() 
                        {
                            Linestyle = x.Linestyle,
                            Showarrow = x.Showarrow,
                            Strokedasharray = x.Strokedasharray,
                            Strokewidth = x.Strokewidth
                        }).FirstOrDefault(),
                    }).ToList()
                }
                );
            }


            return result;
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task<string> GetSaveData()
    {
        var result =await  repository.GetSaveData();
        if (result == null) return null;

        return result;
    }

    public Task<ResponseAction> InsertSaveConnection(string title, string SavedData)
    {
        var model = new Connectiondatum()
        {
            Title = title,
            Savedata = SavedData,
            Createddate = DateTime.Now
        };
        return repository.InsertSaveConnection(model);
    }

    public async Task<ResponseAction> UpdateSaveConnection(int Id, string title, string SavedData)
    {
        return await repository.UpdateSaveConnection(Id, title, SavedData);
    }

    public async Task<ResponseAction> RemoveSaveData(int id)
    {
        return await repository.RemoveSaveData(id);
    }

    public async Task<ICollection<GetSavedDto>> GetAllSaved()
    {
        var items = await repository.GetAllSaved();
        return items.Select(x => new GetSavedDto() {Id = x.Id , SavedData = x.Savedata.ToString() ,Title = x.Title  }).ToList();
    }
}
