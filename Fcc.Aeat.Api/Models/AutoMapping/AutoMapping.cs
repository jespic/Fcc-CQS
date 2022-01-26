using AutoMapper;
using Fcc.Aeat.Factura.Contracts.Commands;
using Fcc.Aeat.Factura.Contracts.Models;
using System.Collections.Generic;

namespace Fcc.Aeat.Api.Models.AutoMapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<FacturaModel, FacturaResponse>(); //from FacturaModel to FacturaResponse
            CreateMap<IEnumerable<FacturaModel>, FacturaResponse>();
            CreateMap<FacturaRequestDto, FacturaRequest>();
            CreateMap<FacturaRequestDto, FacturaAddCommand>();
            CreateMap<FacturaRequestDto, FacturaUpdateCommand>();
            CreateMap<FacturaAddCommand, FacturaRequest>();
            CreateMap<FacturaResponse, FacturaResponseDto>();
            CreateMap<FacturaUpdateCommand, FacturaRequest>();
        }
    }
}
