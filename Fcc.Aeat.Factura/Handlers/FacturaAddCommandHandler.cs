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
    public class FacturaAddCommandHandler : IRequestHandler<FacturaAddCommand>
    {
        private readonly IAddFacturaManager _iAddFacturaManager;

        public FacturaAddCommandHandler(IAddFacturaManager iAddFacturaManager)
        {
            _iAddFacturaManager = iAddFacturaManager;
        }
        public async Task<Unit> Handle(FacturaAddCommand request, CancellationToken cancellationToken)
        {
            var facturaRequest = new FacturaRequest
            {
                Base = request.Base,
                Fecha = request.Fecha,
                Iva = request.Iva,
                Nif = request.Nif,
                Pais = request.Pais,
                Importe = request.Importe
            };
            var facturaResponse = await _iAddFacturaManager.AddFactura(facturaRequest);
            
            return Unit.Value; //valor informativo. Vacio
        }
    }
}
