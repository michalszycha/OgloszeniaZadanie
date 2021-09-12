using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgloszeniaZadanie
{
    public static class CreateConfiguration
    {

        static string GetVehicleToSearch()
        {
            Console.Write("Insert model.\n:");
            string vehicle = Console.ReadLine();
            return vehicle;
        }
        static int GetPagesToSearch()
        {
            Console.Write("Insert number of pages.\n:");
            string pagesStr = Console.ReadLine();
            return int.Parse(pagesStr);
        }
        public static void CreateJsonConfig(string configName)
        {
            List<ConfigInfo> config = new List<ConfigInfo>();
            config.Add(new ConfigInfo()
            {
                SearchPhrase = GetVehicleToSearch(),
                NumberOfPagesRequested = GetPagesToSearch()
            });
            string jsonConfig = JsonConvert.SerializeObject(config.ToArray());
            System.IO.File.WriteAllText($"D:\\VisualProjekty\\OgloszeniaZadanie\\OgloszeniaZadanie\\Resources\\{configName}", jsonConfig);
        }


    }
}
