using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcc.Aeat.Factura.Queries.Contracts
{
    public interface IFacturaQueries
    {
        Task<Factura.Contracts.Models.FacturaModel> GetById(int id);
    }
}
