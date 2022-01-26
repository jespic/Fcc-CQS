using Fcc.Aeat.Factura.Contracts.Commands;
using Fcc.Aeat.Factura.Contracts.Models;
using System;
using System.Globalization;

namespace Fcc.Aeat.Api.Models
{
    public class FacturaRequestDto
    {
        public string FechaInicio { get; set; } //no podemos DateTime porque no podemos serializar lo recibido en httpRequest
        public string FechaFin { get; set; }
        public string Nif { get; set; }
        public string Pais { get; set; }
        public string Fecha { get; set; }
        public byte Iva { get; set; }
        public decimal Importe { get; set; }
        public decimal Base { get; set; }
        
        public FacturaRequestDto(string nif)
        {
            Nif = nif;
        }
        public static FacturaRequest MapToFacturaRequest(FacturaRequestDto facturaRequestDto) //queries
        {
            if(facturaRequestDto == null)
            {
                throw new ArgumentNullException(nameof(facturaRequestDto));
            }

            return new FacturaRequest
            {
                FechaFin = DateTime.ParseExact(facturaRequestDto.FechaFin, "dd-MM-yy", CultureInfo.InvariantCulture),
                FechaInicio = DateTime.ParseExact(facturaRequestDto.FechaInicio, "dd-MM-yy", CultureInfo.InvariantCulture),
                Nif = facturaRequestDto.Nif
            };
        }

        public static FacturaAddCommand MapToFacturaAddCommand(FacturaRequestDto facturaRequestDto) //transactions
        {
            if (facturaRequestDto == null)
            {
                throw new ArgumentNullException(nameof(facturaRequestDto));
            }

            return new FacturaAddCommand
            {
                Pais = facturaRequestDto.Pais,
                Nif = facturaRequestDto.Nif,
                Importe = facturaRequestDto.Importe,
                Fecha = DateTime.ParseExact(facturaRequestDto.Fecha, "dd-MM-yy", CultureInfo.InvariantCulture),
                Base = facturaRequestDto.Base,
                Iva = facturaRequestDto.Iva
            };
        }

        public static FacturaUpdateCommand MapToFacturaUpdateCommand(int id, FacturaRequestDto facturaRequestDto)
        {
            if (facturaRequestDto == null)
                throw new ArgumentNullException(nameof(facturaRequestDto));

            return new FacturaUpdateCommand
            {
                Id = id,
                Pais = facturaRequestDto.Pais,
                Nif = facturaRequestDto.Nif,
                Importe = facturaRequestDto.Importe,
                Fecha = DateTime.ParseExact(facturaRequestDto.Fecha, "dd-MM-yy", CultureInfo.InvariantCulture),
                Base = facturaRequestDto.Base,
                Iva = facturaRequestDto.Iva
            };
        }

        public static FacturaDeleteCommand MapToFacturaDeleteCommand(string nif) //transactions
        {
            if (nif == null)
            {
                throw new ArgumentNullException(nameof(nif));
            }

            return new FacturaDeleteCommand
            {
                Nif = nif,
            };
        }
    }
}
