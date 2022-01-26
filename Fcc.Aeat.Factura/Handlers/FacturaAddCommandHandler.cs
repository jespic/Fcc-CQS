using AutoMapper;
using Fcc.Aeat.Factura.Contracts.Commands;
using Fcc.Aeat.Factura.Contracts.Contracts;
using Fcc.Aeat.Factura.Contracts.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fcc.Aeat.Factura.Handlers
{
    public class FacturaAddCommandHandler : IRequestHandler<FacturaAddCommand, FacturaResponse>
    {
        private readonly IAddFacturaManager _iAddFacturaManager;
        private readonly IMapper _mapper;

        public FacturaAddCommandHandler(IAddFacturaManager iAddFacturaManager, IMapper mapper)
        {
            _iAddFacturaManager = iAddFacturaManager;
            _mapper = mapper;
        }
        public async Task<FacturaResponse> Handle(FacturaAddCommand request, CancellationToken cancellationToken)
        {
            var facturaRequest = _mapper.Map<FacturaRequest>(request);
            
            var facturaResponse = await _iAddFacturaManager.AddFactura(facturaRequest);
            
            return facturaResponse; 
        }
    }
}
