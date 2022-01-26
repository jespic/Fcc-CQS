using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using Fcc.Aeat.Core.Data.Connection;
using Microsoft.Data.SqlClient;
using Fcc.Aeat.Factura.Queries.Contracts;
using Fcc.Aeat.Factura.Contracts.Models;

namespace Fcc.Aeat.Factura.Queries.Impl
{
    public class FacturaQueries : IFacturaQueries
    {
        private readonly ConnectionString _connectionString;

        public FacturaQueries(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<FacturaModel>> GetAll(string nif)
        {
            using(SqlConnection conn = new SqlConnection(_connectionString.Value))
            {
                if(conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Nif", nif);

                var facturas = (await conn
                                .QueryAsync<FacturaModel>
                                ("Select * from factura where Nif = @Nif", 
                                queryParameters))
                                .ToList();
                
                return facturas;
            }
        }
    }
}
