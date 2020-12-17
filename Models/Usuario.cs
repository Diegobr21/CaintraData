﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaintraData.Models
{
    public class Usuario
    {
        /// <summary>
        /// Identificador.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Municipio y estado del usuario.
        /// </summary>
        public string Municipio_Estado { get; set; }

        /// <summary>
        /// Teléfono del usuario.
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// Correo del usuario.
        /// </summary>
        public string Correo { get; set; }

        /// <summary>
        /// Date of last update (Teléfono).
        /// </summary>
        public DateTime LastUpdate_Phone { get; set; }

        /// <summary>
        /// Date of last update (Mail).
        /// </summary>
        public DateTime LastUpdate_Mail { get; set; }

        /// <summary>
        /// Empresa a la que está ligada el usuario si es que está ligada.
        /// </summary>
        public virtual Empresa Empresa { get; set; }

        /// <summary>
        /// Whatsapp del usuario.
        /// </summary>
        public string Whatsapp { get; set; }

        /// <summary>
        /// Facebook del usuario.
        /// </summary>
        public string Facebook { get; set; }

        /// <summary>
        /// Linkedin del usuario.
        /// </summary>
        public string Linkedin { get; set; }

        /// <summary>
        /// Instagram del usuario.
        /// </summary>
        public string Instagram { get; set; }

        /// <summary>
        /// Twitter del usuario.
        /// </summary>
        public string Twitter { get; set; }

    }
}
