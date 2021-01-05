using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using BlazorInputFile;

using CsvHelper;
using Microsoft.AspNetCore.Components;
using CaintraData.Data;
using CaintraData.Models;
using Microsoft.VisualBasic;

namespace CaintraData.Pages
{
    public partial class ImportEmpresas
    {
        [Inject]
        private IUsersService UsersService { get; set; }

        [Inject]
        private IEmpresaService EmpresaService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }
        private IFileListEntry FileEntry { get; set; }

        private bool loading = false;
        private string message = "";

        public void OnFileUploaded(IFileListEntry[] files)
        {
            FileEntry = files.FirstOrDefault();
        }

        /// <summary>
        /// Reads a CSV file which contains information of electronic devices,
        /// parses the data and uploads the products as records to the database.
        /// </summary>
        private async Task UploadFileContentsAsync()
        {
            loading = true;

            var usuarios = await UsersService.GetAllUsuarios();
            var empresas = await EmpresaService.GetAllEmpresas();

            using var reader = new StreamReader(FileEntry.Data);
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
            
            await csvReader.ReadAsync();
            csvReader.ReadHeader();
            
            while (await csvReader.ReadAsync())
            {
                
                var empresaName = csvReader.GetField("Razon Social").ToLower();
                // make upper case the first letter of the string
                empresaName = char.ToUpper(empresaName[0]) + empresaName.Substring(1);

                var nombrecom = csvReader.GetField("Nombre Comercial");
                var direccion = csvReader.GetField("Direccion");
                var munestado = csvReader.GetField("Municipio/Estado");
                var sitioweb = csvReader.GetField("Sitio Web");
                var numsocio = csvReader.GetField("Num Socio");
                var size = csvReader.GetField("Size");
                var vigencia = csvReader.GetField("Vigente");
                var membresia = false;
                if (vigencia.Equals("TRUE"))
                {
                     membresia = true;
                }
                
                var empresa = empresas.FirstOrDefault(c => c.RazonSocial == empresaName);
                // if the company is not in the database
                if (empresa is null)
                {
                    empresa = new Empresa
                    {
                        NombreComercial = nombrecom,
                        RazonSocial = empresaName,
                        Direccion = direccion,
                        Municipio_Estado = munestado,
                        SitioWeb = sitioweb,
                        NumSocio = numsocio,
                        Empresa_Size = size,
                        MembresiaVigente = membresia,
                        LastUpdate = DateAndTime.Now,
                        Origen = FileEntry.Name
                    };
                    // add it
                    await EmpresaService.InsertEmpresa(empresa);

                }
                else
                {
                    empresa.NombreComercial = nombrecom;
                    empresa.Direccion = direccion;
                    empresa.Municipio_Estado = munestado;
                    empresa.SitioWeb = sitioweb;
                    empresa.NumSocio = numsocio;
                    empresa.Empresa_Size = size;
                    empresa.MembresiaVigente = membresia;
                    empresa.LastUpdate = DateAndTime.Now;
                   
                    await EmpresaService.UpdateEmpresa(empresa);
                }

            }
            loading = false;
            NavigationManager.NavigateTo("/");
        }


    }
}
