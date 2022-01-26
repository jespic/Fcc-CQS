using AutoMapper;
using Fcc.Aeat.Factura.Contracts.Commands;
using Fcc.Aeat.Factura.Contracts.Models;

namespace Fcc.Aeat.Api.Models.AutoMapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<FacturaModel, FacturaResponse>(); //from FacturaModel to FacturaResponse
            CreateMap<FacturaRequestDto, FacturaRequest>();
            CreateMap<FacturaRequestDto, FacturaAddCommand>();
            CreateMap<FacturaRequestDto, FacturaUpdateCommand>();
            CreateMap<FacturaAddCommand, FacturaRequest>();
            CreateMap<FacturaResponse, FacturaResponseDto>();
        }
    }
}
