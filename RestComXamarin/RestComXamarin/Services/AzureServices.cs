using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace RestComXamarin.Services
{
    public class AzureServices<T>
    {
        IMobileServiceClient Client;
        IMobileServiceTable<T> Table;

        public AzureServices()
        {
            string MyappServiceURL = "http://meoapp.azurewebsites.net/";
            Client = new MobileServiceClient(MyappServiceURL);
            Table = Client.GetTable<T>();
        }

        public Task<IEnumerable<T>> GetTable()
        {
            return Table.ToEnumerableAsync();
        }
    }
}
