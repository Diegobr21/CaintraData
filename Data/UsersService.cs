using CaintraData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaintraData.Data
{
    public class UsersService : IUsersService
    {

        private readonly UsersContext _context;
        public IEnumerable<Usuario> ActiveUsuarios { get; set; }
        public UsersService(UsersContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            var usuario = await _context.UsuariosTable.FindAsync(id);

            _context.UsuariosTable.Remove(usuario);

            return await _context.SaveChangesAsync() > 0;
        }
        

        public async Task<IEnumerable<Usuario>> GetAllUsuarios()
        {
            return await _context.UsuariosTable.ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> GetAllActiveUsuarios()
        {
            IEnumerable<Usuario> AllUsuarios = await _context.UsuariosTable.ToListAsync();
            

            foreach(Usuario usuario in AllUsuarios)
            {
                if(usuario.Activo == true)
                {
                    ActiveUsuarios.Append(usuario);
                }
            }
            return await ActiveUsuarios;
        }

        public async Task<Usuario> GetUsuarioDetails(int id)
        {
            return await _context.UsuariosTable.FindAsync(id);
        }

        public async Task<bool> InsertUsuario(Usuario usuario)
        {
            _context.UsuariosTable.Add(usuario);

            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<bool> SaveUsuario(Usuario usuario)
        {
            if (usuario.Id > 0)
                return await UpdateUsuario(usuario);
            else
                return await InsertUsuario(usuario);
        }

        public async Task<bool> UpdateUsuario(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
