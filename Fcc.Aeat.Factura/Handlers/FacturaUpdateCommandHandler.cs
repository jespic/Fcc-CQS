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
    public class FacturaUpdateCommandHandler : IRequestHandler<FacturaUpdateCommand, FacturaResponse>
    {
        private readonly IUpdateFacturaManager _iUpdateFacturaManager;
        private readonly IMapper _mapper;

        public FacturaUpdateCommandHandler(IUpdateFacturaManager iUpdateFacturaManager, IMapper mapper)
        {
            _iUpdateFacturaManager = iUpdateFacturaManager;
            _mapper = mapper;
        }
        public async Task<FacturaResponse> Handle(FacturaUpdateCommand request, CancellationToken cancellationToken)
        {
            var facturaRequest = _mapper.Map<FacturaRequest>(request);
            var facturaResponse = await _iUpdateFacturaManager.UpdateFactura(request.Id, facturaRequest);

            return facturaResponse; 
        }
    }
}
