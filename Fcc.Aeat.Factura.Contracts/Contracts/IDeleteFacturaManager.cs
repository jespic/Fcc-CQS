using Fcc.Aeat.Factura.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcc.Aeat.Factura.Contracts.Contracts
{
    public interface IDeleteFacturaManager
    {
        Task<Boolean> DeleteFactura(int id);
    }
}
