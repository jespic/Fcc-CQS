using Fcc.Aeat.Factura.Contracts.Models;
using System;

namespace Fcc.Aeat.Api.Models
{
    public class FacturaResponseDto
    {
        public int Id { get; set; }
        public string Pais { get; set; }
        public string Nif { get; set; }
        public decimal Importe { get; set; }
        public decimal Base { get; set; }
        public byte Iva { get; set; }
        public string Fecha { get; set; }

        public static FacturaResponseDto MapFromFacturaResponse(FacturaResponse facturaResponse)
        {
            if (facturaResponse == null)
                throw new ArgumentNullException(nameof(facturaResponse));

            return new FacturaResponseDto
            {
                Id = facturaResponse.Id,
                Pais = facturaResponse.Pais,
                Nif = facturaResponse.Nif,
                Importe = facturaResponse.Importe,
                Base = facturaResponse.Base,
                Iva = facturaResponse.Iva,
                Fecha = facturaResponse.Fecha

            };
        }
    }
}
