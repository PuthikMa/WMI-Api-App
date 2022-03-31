using System.Collections.Generic;
using System.Threading.Tasks;
using WMI_Api.Models;

namespace WMI_Api.Services.Broker
{
    public interface IDataAccessServices
    {
        Task<List<Vehicle>> GetAllVehicle(string country, string searchByName, string searchByWMI, string searchByVehicleType);
        Task<List<string>> GetCountry();
    }
}
