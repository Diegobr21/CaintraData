using CaintraData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaintraData.Data
{
    public class EmpresaService : IEmpresaService
    {
        private readonly UsersContext _context;
        public EmpresaService(UsersContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteEmpresa(int id)
        {
            var empresa = await _context.EmpresasTable.FindAsync(id);

            _context.EmpresasTable.Remove(empresa);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Empresa>> GetAllEmpresas()
        {
            return await _context.EmpresasTable.ToListAsync();
        }

        public async Task<Empresa> GetEmpresaDetails(int id)
        {
            return await _context.EmpresasTable.FindAsync(id);
        }

        public async Task<bool> InsertEmpresa(Empresa empresa)
        {
            _context.EmpresasTable.Add(empresa);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SaveEmpresa(Empresa empresa)
        {
            if (empresa.Id > 0)
                return await UpdateEmpresa(empresa);
            else
                return await InsertEmpresa(empresa);
        }

        public async Task<bool> UpdateEmpresa(Empresa empresa)
        {
            _context.Entry(empresa).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
