using System;
using Microsoft.WindowsAzure.MobileServices;

namespace RestComXamarin.Models
{
    [DataTable("cars")]
    public class Car
    {
        [Version]
        public string AzureVersion { get; set; }
        public string Id { get; set; }
        public string Fabricante { get; set; }
        public string Modelo { get; set; }
        public int Preco { get; set; }
        public string WebSite { get; set; }
        public string Image { get; set; }
    }
}
