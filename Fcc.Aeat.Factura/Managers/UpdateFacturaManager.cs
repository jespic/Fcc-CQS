using Fcc.Aeat.Factura.Contracts.Contracts;
using Fcc.Aeat.Factura.Contracts.Models;
using Fcc.Aeat.Factura.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcc.Aeat.Factura.Managers
{
    public class UpdateFacturaManager : IUpdateFacturaManager
    {
        private readonly IFacturaRepository _facturaRepository;

        public UpdateFacturaManager(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        public Task UpdateFactura(int id, FacturaRequest facturaRequest)
        {
            if (facturaRequest == null)
            {
                throw new ArgumentNullException(nameof(facturaRequest));
            }

            return _facturaRepository.Update(id, facturaRequest);
        }
    }
}
