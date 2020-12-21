using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaintraData.Models
{
    public class UsersContext:DbContext
    {
        public DbSet<Usuario> UsuariosTable { get; set; }
        public DbSet<Empresa> EmpresasTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-CN0JGTHQ\\SQLEXPRESS;Initial Catalog=CaintraDBTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
