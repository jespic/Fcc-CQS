using Fcc.Aeat.Factura.Contracts.Contracts;
using Fcc.Aeat.Factura.Contracts.Models;
using Fcc.Aeat.Factura.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Fcc.Aeat.Factura.Managers
{
    public class AddFacturaManager: IAddFacturaManager
    {
        private readonly IFacturaRepository _facturaRepository;
        private readonly IMapper _mapper;

        public AddFacturaManager(IFacturaRepository facturaRepository, IMapper mapper)
        {
            _facturaRepository = facturaRepository;
            _mapper = mapper;
        }

        //Validations should be synchronous
        public async Task<FacturaResponse> AddFactura(FacturaRequest facturaRequest)
        {
            if (facturaRequest == null)
            {
                throw new ArgumentNullException(nameof(facturaRequest));
            }

            var facturaModel = await _facturaRepository.Add(facturaRequest);
            return _mapper.Map<FacturaResponse>(facturaModel);
        }
    }
}
