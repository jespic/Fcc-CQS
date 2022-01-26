using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcc.Aeat.Factura.Contracts.Commands
{
    public class FacturaAddCommand : IRequest
    {
        public string Pais { get; set; }
        public string Nif { get; set; }
        public decimal Importe { get; set; }
        public decimal Base { get; set; }
        public byte Iva { get; set; }
        public DateTime Fecha { get; set; }
    }
}
