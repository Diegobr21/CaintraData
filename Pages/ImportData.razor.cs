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
    public partial class ImportData
    {
        [Inject]
        private IUsersService UsersService { get; set; }

        [Inject]
        private IEmpresaService EmpresaService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }
        private IFileListEntry FileEntry { get; set; }
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
            message = "Cargando datos...";
            var usuarios = await UsersService.GetAllUsuarios();
            var empresas = await EmpresaService.GetAllEmpresas();

            using var reader = new StreamReader(FileEntry.Data);
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

            await csvReader.ReadAsync();
            csvReader.ReadHeader();
            while (await csvReader.ReadAsync())
            {
                int empresaId = 0;
                var empresaName = csvReader.GetField("Empresa");
               
                if(empresaName.Length > 1)
                {
                    empresaName.ToLower();
                    // make upper case the first letter of the string
                    empresaName = char.ToUpper(empresaName[0]) + empresaName.Substring(1);
                }
                   

                    var empresa = empresas.FirstOrDefault(c => c.RazonSocial == empresaName);
                    // if the company is not in the database

                    if (empresa is null)
                    {
                        empresa = new Empresa
                        {
                            RazonSocial = empresaName,
                            LastUpdate = DateAndTime.Now,
                            Origen = FileEntry.Name


                        };
                        // add it
                        await EmpresaService.InsertEmpresa(empresa);
                        empresaId = empresa.Id;



                    }
                    else
                    {
                        empresaId = empresa.Id;
                    }
                
                



                // get category tag (id)
                var nombre = csvReader.GetField("Nombre Usuario");
                var mun_estado = "";
                var telefono = csvReader.GetField("Telefono");
                var correo = csvReader.GetField("Correo");


                var user = usuarios.FirstOrDefault(c => c.Correo == correo);
                if(user is null)
                {
                    var usuario = new Usuario
                    {
                        Nombre = nombre,
                        Municipio_Estado = mun_estado,
                        Telefono = telefono,
                        Correo = correo,
                        LastUpdate_Mail = DateAndTime.Now,
                        LastUpdate_Phone = DateAndTime.Now,
                        EmpresaId = empresaId,
                        RazonEmpresa = empresaName,
                        Origen = FileEntry.Name


                    };
                    await UsersService.InsertUsuario(usuario);
                }
                else
                {
                    user.Nombre = nombre;
                    user.Municipio_Estado = mun_estado;
                    if(telefono != "")
                    {
                        user.Telefono = telefono;
                        user.LastUpdate_Phone = DateAndTime.Now;
                    }
                    user.EmpresaId = empresaId;
                    user.RazonEmpresa = empresaName;


                }

                
            }

            NavigationManager.NavigateTo("/");
        }

        
    }
}
