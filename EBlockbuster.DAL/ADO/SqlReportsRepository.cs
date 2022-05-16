using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBlockbuster.Core;
using EBlockbuster.Core.DTOs;
using EBlockbuster.Core.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EBlockbuster.DAL.ADO
{
    public class SqlReportsRepository : IReportsRepository
    {
        private readonly IConfigurationRoot Config;
        string connectionString;
        private readonly FactoryMode mode;

        public SqlReportsRepository(IConfigurationRoot config)
        {
            Config = config;
            string environment = mode == FactoryMode.TEST ? "Test" : "Prod";
            connectionString = Config[$"ConnectionStrings:{environment}"];
        }
        public Response<List<TopThreeRentedProducts>> GetTopThreeRentedProducts()
        {
                Response<List<TopThreeRentedProducts>> response = new Response<List<TopThreeRentedProducts>>();
                response.Data = new List<TopThreeRentedProducts>();
                using (var connection = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("TopThreeRentedProducts", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.Data.Add(new TopThreeRentedProducts
                            {
                                ProductId = (int)reader["ProductId"],
                                ProductTitle = reader["ProductTitle"].ToString(),
                                ProductCount = (int)reader["ProductCount"]
                            });
                            response.Success = true;
                        }
                    }
                }

                return response;
        }
    }
}
