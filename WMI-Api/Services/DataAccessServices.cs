using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WMI_Api.Models;
using WMI_Api.Repository;
using WMI_Api.Services.Broker;

namespace WMI_Api.Services
{
    public class DataAccessServices : IDataAccessServices
    {
        private readonly DataAccess _dataAccess;

        public DataAccessServices(DataAccess dataAccess)
        {
            _dataAccess = dataAccess ?? throw new ArgumentNullException(nameof(DataAccess));
        }
        public async Task<List<Vehicle>> GetAllVehicle(string country, string searchByName, string searchByWMI, string searchByVehicleType)
        {
            var results = await _dataAccess.GetVehicles(country, searchByName, searchByWMI, searchByVehicleType);

            return results.OrderBy(x => x.createdon).OrderBy(x => x.wmi).ToList();
        }

        public async Task<List<string>> GetCountry()
        {
            var results = await _dataAccess.GetVehicles();

            return results.GroupBy(c => c.country).Select(grp => grp.First()).Select(x => x.country ?? "Null").OrderBy(q => q).ToList();

        }
    }
}
