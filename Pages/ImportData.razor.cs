using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using BlazorInputFile;

using CsvHelper;
using Microsoft.AspNetCore.Components;
using CaintraData.Data;
using CaintraData.Models;

namespace CaintraData.Pages
{
    public partial class ImportData
    {
        [Inject]
        private UsersService usersService { get; set; }

        [Inject]
        private EmpresaService empresaService { get; set; }
        private IFileListEntry FileEntry { get; set; }

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
            var usuarios = await usersService.GetAllUsuarios();
            var empresas = await empresaService.GetAllEmpresas();

            using var reader = new StreamReader(FileEntry.Data);
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

            await csvReader.ReadAsync();
            csvReader.ReadHeader();
            while (await csvReader.ReadAsync())
            {
                /*
                var companyName = csvReader.GetField("Product Brand").ToLower();
                // make upper case the first letter of the string
                companyName = char.ToUpper(companyName[0]) + companyName.Substring(1);
                var company = companies.FirstOrDefault(c => c.Name == companyName);
                // if the company is not in the database
                if (company is null)
                {
                    company = new Company
                    {
                        Name = companyName
                    };
                    // add it
                    await UploadDataContext.InsertCompanyAsync(company);
                    companies.Add(company);
                }

    */
                // get category tag (id)
                var tag = csvReader.GetField<int>("Tag");
               
               

                var model = csvReader.GetField("Product Model").Split(' ');
                // first 3 words will be the name
                var name = string.Join(" ", model.Take(3));
                // the rest of the words will be the description
                var description = string.Join(" ", model.Skip(3));

                var imagePath = csvReader.GetField("ProductImg");
                var mun_estado = "";
                var empresaId = new Empresa();

                var usuario = new Usuario
                {
                    Nombre = name,
                    Correo = description,
                    Telefono = imagePath,
                    Municipio_Estado = mun_estado,
                    Empresa = empresaId
                };
                await usersService.InsertUsuario(usuario);
            }
        }

        
    }
}
