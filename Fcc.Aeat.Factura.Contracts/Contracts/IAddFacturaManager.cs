using Fcc.Aeat.Factura.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcc.Aeat.Factura.Contracts.Contracts
{
    public interface IAddFacturaManager
    {
        Task<FacturaResponse> AddFactura(FacturaRequest facturaRequest);
    }
}
