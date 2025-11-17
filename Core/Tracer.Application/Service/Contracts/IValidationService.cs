
using Tracer.Application.Dto;

namespace Tracer.Application.Service.Contracts
{
    public interface IValidationService
    {
        Task<bool> ValidationAsync(RecieveDataDto dto);
    
    }
}