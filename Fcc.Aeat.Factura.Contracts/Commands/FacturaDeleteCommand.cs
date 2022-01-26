using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcc.Aeat.Factura.Contracts.Commands
{
    public class FacturaDeleteCommand : IRequest<Boolean>
    {
        public int Id { get; set; }
    }
}
