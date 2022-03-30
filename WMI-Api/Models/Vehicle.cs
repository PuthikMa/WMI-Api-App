using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WMI_Api.Models
{
    public class Vehicle
    {
        public int id { get; set; }
        public string country { get; set; }
        public string name { get; set; }
        public string vehicletype { get; set; }
        public string wmi { get; set; }
        public DateTime createdon { get; set; }
        public DateTime? updateon { get; set; }
        public DateTime dateavailabletopublic { get; set; }


    }
}
