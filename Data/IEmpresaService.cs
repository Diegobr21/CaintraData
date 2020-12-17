using System;
using System.Collections.Generic;
using CaintraData.Models;
using System.Linq;
using System.Threading.Tasks;

namespace CaintraData.Data
{
    public interface IEmpresaService
    {
        Task<IEnumerable<Empresa>> GetAllEmpresas();
        Task<Empresa> GetEmpresaDetails(int id);
        Task<bool> InsertEmpresa(Empresa empresa);
        Task<bool> UpdateEmpresa(Empresa empresa);
        Task<bool> DeleteEmpresa(int id);
        Task<bool> SaveEmpresa(Empresa empresa);
    }
}
