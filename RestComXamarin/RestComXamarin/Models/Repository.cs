using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestComXamarin.Models
{
    public class Repository
    {
        public async Task<List<Car>> GetCars()
        {
            var Service = new Services.AzureServices<Car>();
            var Items = await Service.GetTable();
            return Items.ToList();

        }
    }
}
