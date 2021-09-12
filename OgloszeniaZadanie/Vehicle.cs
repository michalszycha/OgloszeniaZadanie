using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgloszeniaZadanie
{
    public class Vehicle
    {

        public string price;
        public string mileage;
        public string productionYear;
        public string capacity;

        public Vehicle(string price, string mileage, string productionYear, string capacity)
        {
            this.price = price;
            this.mileage = mileage;
            this.productionYear = productionYear;
            this.capacity = capacity;
        }
    }
}
