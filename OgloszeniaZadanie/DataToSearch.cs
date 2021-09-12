using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgloszeniaZadanie
{
    public class DataToSearch
    {
        public string brand;
        public string model;
        public string pages;
        private string configName = "config.txt";

        public DataToSearch()
        {
            brand = GetVehicle(configName).Split(' ')[0];
            model = GetVehicle(configName).Split(' ')[1];
            pages = GetPages(configName);
        }

        private string GetVehicle(string configName)
        {
            string vehicleFromConfig;
            try
            {
                vehicleFromConfig = ReadConfiguration.ReadVehicle(configName);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"There is no config file.");
                CreateConfiguration.CreateJsonConfig(configName);
                vehicleFromConfig = ReadConfiguration.ReadVehicle(configName);
            }
            return vehicleFromConfig;
        }

        private string GetPages(string configName)
        {
            string pagesFromConfig;
            try
            {
                pagesFromConfig = ReadConfiguration.ReadPages(configName);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"There is no config file.");
                CreateConfiguration.CreateJsonConfig(configName);
                pagesFromConfig = ReadConfiguration.ReadPages(configName);
            }
            return pagesFromConfig;
        }
    }
}
