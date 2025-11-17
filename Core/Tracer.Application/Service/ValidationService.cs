using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracer.Application.Dto;
using Tracer.Application.Service.Contracts;
using Tracer.Domain.Contracts;

namespace Tracer.Application.Service
{
    public class ValidationService(IDeviceRepository repository) : IValidationService
    {
        
        public async Task<bool> ValidationAsync(RecieveDataDto dto)
        {
            return await repository.ValidateConnection(dto.FirstPort, dto.Cable, dto.SecoundPort);
        }


    }
}