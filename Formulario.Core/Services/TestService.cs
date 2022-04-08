using Formulario.Core.DTOs;
using Formulario.Core.Entities;
using Formulario.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formulario.Core.Services
{
    public class TestService
    {
        private readonly ITestRepository testRepository;
        public async Task<Registro> AddRecord(RegistroDTO registro)
        {
            return await testRepository.AddRecord(registro);
        }
    }
}
