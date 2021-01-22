using CaintraData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaintraData.Data
{
    public interface IUsersService
    {
        Task<IEnumerable<Usuario>> GetAllUsuarios();
        Task<IEnumerable<Usuario>> GetAllActiveUsuarios();
        Task<IEnumerable<Usuario>> GetAllNonActiveUsuarios();
        Task<Usuario> GetUsuarioDetails(int id);
        Task<bool> InsertUsuario(Usuario usuario);
        Task<bool> UpdateUsuario(Usuario usuario);
        Task<bool> DeleteUsuario(int id);
        Task<bool> SaveUsuario(Usuario usuario);
    }
}
