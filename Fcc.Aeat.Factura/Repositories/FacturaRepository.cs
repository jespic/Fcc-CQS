using Dapper;
using Fcc.Aeat.Core.Data.Connection;
using Fcc.Aeat.Factura.Contracts.Models;
using Fcc.Aeat.Factura.Contracts.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcc.Aeat.Factura.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly ConnectionString _connectionString;

        public FacturaRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<FacturaModel> Add(FacturaRequest factura)
        {
            if(factura == null)
                throw new ArgumentNullException(nameof(factura));

            using(var conn = new SqlConnection(_connectionString.Value))
            {
                const string query =
                    @"INSERT INTO Factura (Nif,Pais,Importe,Base,Iva,Fecha) OUTPUT INSERTED.Id VALUES (@Nif,@Pais,@Importe,@Base,@Iva,@Fecha);";

                var insertedId = await conn.QuerySingleAsync<int>(query,
                    new
                    {
                        Nif = factura.Nif,
                        Pais = factura.Pais,
                        Importe = factura.Importe,
                        Base = factura.Base,
                        Iva = factura.Iva,
                        Fecha = factura.Fecha
                    });

                return await GetById(insertedId, conn);
            }
        }

        private async Task<FacturaModel> GetById(int id, SqlConnection conn)
        {
            string query = $"SELECT * FROM Factura WHERE Id = {id}";

            var Facturas = await conn.QueryAsync<FacturaModel>(query);

            FacturaModel factura = null;
            foreach(FacturaModel facturaModel in Facturas)
            {
                factura = facturaModel;
            }
            return factura;

        }

        public async Task<FacturaModel> Update(int id, FacturaRequest factura)
        {
            using (var conn = new SqlConnection(_connectionString.Value))
            {
                const string query =
                    "UPDATE Factura SET Nif = @Nif,Pais = @Pais,Importe = @Importe,Base = @Base,Iva = @Iva,Fecha = @Fecha WHERE Id =@Id";
                await conn.ExecuteAsync(query,
                    new
                    {
                        Id = id,
                        Nif = factura.Nif,
                        Pais = factura.Pais,
                        Importe = factura.Importe,
                        Base = factura.Base,
                        Iva = factura.Iva,
                        Fecha = factura.Fecha
                    });

                return await GetById(id, conn);
            }
        }

        public async Task<Boolean> Delete(int id)
        {
            using (var conn = new SqlConnection(_connectionString.Value))
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", id);

                var affectedRows = await conn.ExecuteAsync("DELETE FROM Factura WHERE Id = @Id", queryParameters);

                return affectedRows > 0;
            }

            
        }
    }
}
