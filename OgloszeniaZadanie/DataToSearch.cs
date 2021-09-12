using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgloszeniaZadanie
{
    class DataToSearch
    {
        public string brand;
        public string model;
        public int pages;
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

        private int GetPages(string configName)
        {
            int pagesFromConfig;
            try
            {
                pagesFromConfig = ReadConfiguration.ReadPages(configName);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"There is no config file. Caught {e.Message}.");
                CreateConfiguration.CreateJsonConfig(configName);
                pagesFromConfig = ReadConfiguration.ReadPages(configName);
            }
            return pagesFromConfig;
        }
    }
}
