using Fcc.Aeat.Factura.Contracts.Commands;
using Fcc.Aeat.Factura.Contracts.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fcc.Aeat.Factura.Handlers
{
    public class FacturaDeleteCommandHandler : IRequestHandler<FacturaDeleteCommand, Boolean>
    {
        private readonly IDeleteFacturaManager _iDeleteFacturaManager;

        public FacturaDeleteCommandHandler(IDeleteFacturaManager iDeleteFacturaManager)
        {
            _iDeleteFacturaManager = iDeleteFacturaManager;
        }
        public async Task<Boolean> Handle(FacturaDeleteCommand request, CancellationToken cancellationToken)
        {
            int id = request.Id;
            var deleted = await _iDeleteFacturaManager.DeleteFactura(id);

            return deleted; 
        }
    }
}
