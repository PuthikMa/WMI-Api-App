using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WMI_Api.Models;

namespace WMI_Api.Services.Broker
{
    public interface IDataAccessServices
    {
        Task<List<Vehicle>> GetAllVehicle(string country, string search);
        Task<List<string>> GetCountry();
    }
}
