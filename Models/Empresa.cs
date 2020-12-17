using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaintraData.Models
{
    public class Empresa
    {
        /// <summary>
        /// Identificador.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Razon Social de la empresa.
        /// </summary>
        public string RazonSocial { get; set; }

        /// <summary>
        /// Nombre comercial de la empresa.
        /// </summary>
        public string NombreComercial { get; set; }

        /// <summary>
        /// Calle, numero y CP de la empresa.
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Municipio y estado de la empresa.
        /// </summary>
        public string Municipio_Estado { get; set; }

        /// <summary>
        /// Sitio web de la empresa.
        /// </summary>
        public string SitioWeb { get; set; }


        /// <summary>
        /// Date of last update (Empresa).
        /// </summary>
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// Número de socio de la empresa.
        /// </summary>
        public string NumSocio { get; set; }

        /// <summary>
        /// Tamaño de la empresa.
        /// </summary>
        public string Empresa_Size { get; set; }

        /// <summary>
        /// Membresía vigente.
        /// </summary>
        public bool MembresiaVigente { get; set; }

        /// <summary>
        /// Usuarios ligados a la empresa.
        /// </summary>
        public virtual List<Usuario> Usuarios { get; set; }

    }
}
