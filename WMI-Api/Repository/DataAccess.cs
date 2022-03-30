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
        public async Task<List<Vehicle>> GetVehicles(string country, string searchbyName)
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
                if (!string.IsNullOrEmpty(searchbyName))
                {
                    results = results.Where(x => x.name.Contains(searchbyName)).ToList();
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
