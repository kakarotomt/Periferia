using Dapper;
using Microsoft.Data.SqlClient;
using Mono.TextTemplating;
using proyectoWebApi.DataLayer.Models;
using System;
using System.Data;

namespace proyectoWebApi.DataLayer.Dapper
{
    public class ProductRepository : IProductRepository
    {

        private readonly IConfiguration _config;
        private readonly string? _connectionString;

        public ProductRepository(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("connectionDB");
        }


        private IDbConnection Connection => new SqlConnection(_connectionString);

        public async Task<int> CreateAsync(Product user)
        {
            using var conn = Connection;
            return await conn.ExecuteScalarAsync<int>(
                "BT_CreateProduct",
                new
                {
                    user.Code,
                    user.FullName,
                    user.Description,
                    user.InternalReference,
                    user.UnitPrice,
                    user.Estate,
                    user.MeassureUnit,
                    user.CreatedDate
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<bool> DeleteAsync(int code)
        {
            using var conn = Connection;
            int rows = await conn.ExecuteScalarAsync<int>(
                "BT_DeleteProduct",
                new { code },
                commandType: CommandType.StoredProcedure
            );
            return rows > 0;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(int? code)
        {
            using var conn = Connection;
            return await conn.QueryAsync<Product>(
                "BT_SelectProduct",
                new { code },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<bool> UpdateAsync(Product user)
        {
            using var conn = Connection;
            int rows = await conn.ExecuteScalarAsync<int>(
                "BT_UpdateProduct",
                new
                {
                    user.Code,
                    user.FullName,
                    user.Description,
                    user.InternalReference,
                    user.UnitPrice,
                    user.Estate,
                    user.MeassureUnit,
                    user.CreatedDate
                },
                commandType: CommandType.StoredProcedure
            );
            return rows > 0;
        }
    }
}
