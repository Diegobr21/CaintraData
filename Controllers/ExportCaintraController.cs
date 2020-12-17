using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaintraData.Data;
using CaintraData.Models;
using Microsoft.AspNetCore.Mvc;



namespace CaintraData.Controllers
{
    public partial class ExportCaintraController : ExportController
    {
        private readonly UsersContext context;

        public ExportCaintraController(UsersContext context)
        {
            this.context = context;
        }

        [HttpGet("/export/CAINTRA/Empresas/csv")]
        public FileStreamResult ExportEmpresasToCSV()
        {
            return ToCSV(ApplyQuery(context.Empresa, Request.Query));
        }

        [HttpGet("/export/CAINTRA/Empresas/excel")]
        public FileStreamResult ExportEmpresasToExcel()
        {
            return ToExcel(ApplyQuery(context.Empresa, Request.Query));
        }
        [HttpGet("/export/CAINTRA/Usuarios/csv")]
        public FileStreamResult ExportUsuariosToCSV()
        {
            return ToCSV(ApplyQuery(context.UsuariosTable, Request.Query));
        }

        [HttpGet("/export/CAINTRA/Usuarios/excel")]
        public FileStreamResult ExportUsuariosToExcel()
        {
            return ToExcel(ApplyQuery(context.UsuariosTable, Request.Query));
        }
    }
}
