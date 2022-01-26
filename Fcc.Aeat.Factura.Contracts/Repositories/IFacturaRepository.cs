using Fcc.Aeat.Factura.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcc.Aeat.Factura.Contracts.Repositories
{
    public interface IFacturaRepository
    {
        Task<FacturaModel> Add(FacturaRequest factura);
        Task<FacturaModel> Update(int id, FacturaRequest factura);
        Task<Boolean> Delete(int id);
    }
}
