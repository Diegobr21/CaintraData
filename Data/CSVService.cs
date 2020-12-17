using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;
using Microsoft.AspNetCore.Components;

namespace CaintraData.Data
{
    public partial class CSVService
    {

        private readonly NavigationManager navigationManager;

        public CSVService(NavigationManager navigationManager)
        {
            this.navigationManager = navigationManager;
        }

        public void Export2(string table, string type, Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"/export/CAINTRA/{table}/{type}") : $"/export/CAINTRA/{table}/{type}", true);
        }
    }
}
