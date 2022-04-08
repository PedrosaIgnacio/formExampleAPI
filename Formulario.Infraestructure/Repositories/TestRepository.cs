using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formulario.Core.DTOs;
using Formulario.Core.Entities;
using Formulario.Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Formulario.Infraestructure.Repositories
{
    public class TestRepository: ITestRepository
    {
        private readonly string _connection;

        public TestRepository(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("defaultConnection");
        }
        public async Task<Registro> AddRecord(RegistroDTO registro)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                return null;
            }
        }
    }
}
