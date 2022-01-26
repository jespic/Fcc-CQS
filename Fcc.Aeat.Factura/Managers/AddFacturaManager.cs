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
    public class AddFacturaManager: IAddFacturaManager
    {
        private readonly IFacturaRepository _facturaRepository;

        public AddFacturaManager(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        //Validations should be synchronous
        public Task<FacturaResponse> AddFactura(FacturaRequest facturaRequest)
        {
            if (facturaRequest == null)
            {
                throw new ArgumentNullException(nameof(facturaRequest));
            }

            var facturaModel = _facturaRepository.Add(facturaRequest);
            return MapToFacturaResponse(facturaModel);
        }

        private Task<FacturaResponse> MapToFacturaResponse(FacturaModel facturaModel)
        {
            FacturaResponse facturaResponse = new FacturaResponse
            {
                Id = facturaModel.Id,
                Pais = facturaModel.Pais,
                Nif = facturaModel.Nif,
                Importe = facturaModel.Importe,
                Base = facturaModel.Base,
                Iva = facturaModel.Iva,
                Fecha = facturaModel.Fecha
            };
            return Task.FromResult(facturaResponse);
        }
    }
}
