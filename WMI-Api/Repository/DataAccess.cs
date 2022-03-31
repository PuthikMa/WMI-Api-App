using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WMI_Api.Models;

namespace WMI_Api.Repository
{
    public class DataAccess
    {
        public async Task<List<Vehicle>> GetVehicles(string country = null, string searchByName = null, string searchByWMI = null, string searchByVehicleType = null)
        {
            try
            {
                var file = await File.ReadAllTextAsync("honda_wmi.json");

                var results = JsonConvert.DeserializeObject<List<Vehicle>>(file);

                if (!string.IsNullOrEmpty(country))
                {
                    if (country == "Null")
                        country = null;
                    results = results.Where(x => x.country?.ToLower() == country?.ToLower()).ToList();
                }
                if (!string.IsNullOrEmpty(searchByName))
                {
                    results = results.Where(x => x.name.ToLower().Contains(searchByName.ToLower())).ToList();
                }
                else if (!string.IsNullOrEmpty(searchByWMI))
                {
                    results = results.Where(x => x.wmi.ToLower().Contains(searchByWMI.ToLower())).ToList();
                }
                else if (!string.IsNullOrEmpty(searchByVehicleType))
                {
                    results = results.Where(x => x.vehicletype.ToLower().Contains(searchByVehicleType.ToLower())).ToList();
                }
                return results;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
