using Formulario.Core.DTOs;
using Formulario.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formulario.Core.Interfaces
{
    public interface ITestRepository
    {
        Task<Registro> AddRecord(RegistroDTO registro);
        Task<List<Registro>> GetRecords();
        Task<bool> DeleteRecord(int id);
    }
}
