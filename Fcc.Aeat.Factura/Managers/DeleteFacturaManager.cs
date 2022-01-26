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
    public class DeleteFacturaManager : IDeleteFacturaManager
    {
        private readonly IFacturaRepository _facturaRepository;

        public DeleteFacturaManager(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        //Validations should be synchronous
        public Task DeleteFactura(string nif)
        {
            if (nif == null)
            {
                throw new ArgumentNullException(nameof(nif));
            }

            return _facturaRepository.Delete(nif);
        }
    }
}
