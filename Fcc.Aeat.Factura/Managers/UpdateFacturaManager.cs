using AutoMapper;
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
        private readonly IMapper _mapper;

        public UpdateFacturaManager(IFacturaRepository facturaRepository, IMapper mapper)
        {
            _facturaRepository = facturaRepository;
            _mapper = mapper;
         }

        public async Task<FacturaResponse> UpdateFactura(int id, FacturaRequest facturaRequest)
        {
            if (facturaRequest == null)
                throw new ArgumentNullException(nameof(facturaRequest));
            

            var facturaModel = await _facturaRepository.Update(id, facturaRequest);
            return _mapper.Map<FacturaResponse>(facturaModel);
        }
    }
}
