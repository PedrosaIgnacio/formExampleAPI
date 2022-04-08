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
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }
        public async Task<Registro> AddRecord(RegistroDTO registro)
        {
            return await _testRepository.AddRecord(registro);
        }
        public async Task<List<Registro>> GetRecords()
        {
            return await _testRepository.GetRecords();
        }
        public async Task<bool> DeleteRecord(int id)
        {
            return await _testRepository.DeleteRecord(id);
        }
    }
}
