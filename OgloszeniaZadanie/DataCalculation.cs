using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgloszeniaZadanie
{
    public class DataCalculation
    {
        public int numberOfVehicles;
        public double averagePrice;
        public double averageMileage;
        public double averageProductionYear;
        public double averageCapacity;

        public DataCalculation(List<Vehicle> vehicles)
        {
            numberOfVehicles = vehicles.Count;
            averagePrice = Calculate(vehicles, "price");
            averageMileage = Calculate(vehicles, "mileage");
            averageProductionYear = Calculate(vehicles, "productionYear");
            averageCapacity = Calculate(vehicles, "capacity");
        }

        private double Calculate(List<Vehicle> vehicles, string dataType)
        {
            double averageValue;
            List<int> valuesList = new List<int>();
            foreach(var vehicle in vehicles)
            {
                switch (dataType)
                {
                    case "price":
                        if (!String.IsNullOrEmpty(vehicle.price))
                        {
                            valuesList.Add(int.Parse(vehicle.price));
                        }
                        break;
                    case "mileage":
                        if (!String.IsNullOrEmpty(vehicle.mileage))
                        {
                            valuesList.Add(int.Parse(vehicle.mileage));
                        }
                        break;
                    case "productionYear":
                        if (!String.IsNullOrEmpty(vehicle.productionYear))
                        {
                            valuesList.Add(int.Parse(vehicle.productionYear));
                        }
                        break;
                    case "capacity":
                        if (!String.IsNullOrEmpty(vehicle.capacity))
                        {
                            valuesList.Add(int.Parse(vehicle.capacity));
                        }
                        break;
                }
            }

            averageValue = (double)valuesList.Sum() / (double)valuesList.Count;
            return averageValue;
        }
    }
}
