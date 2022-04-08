using Formulario.Core.DTOs;
using Formulario.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formulario.Core.Interfaces
{
    public interface ITestService
    {
        Task<Registro> AddRecord(RegistroDTO registro);
    }
}
