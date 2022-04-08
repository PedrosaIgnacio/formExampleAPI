using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formulario.Infraestructure.Data
{

    public class FormularioContext
    {
        private readonly string _connectionString;
        public FormularioContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }
    }
}
