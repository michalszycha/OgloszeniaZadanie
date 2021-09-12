﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgloszeniaZadanie
{
    public static class ReadConfiguration
    {
        public static string ReadVehicle(string configName)
        {
            var jsonData = File.ReadAllText($"D:\\VisualProjekty\\OgloszeniaZadanie\\OgloszeniaZadanie\\Resources\\{configName}");
            var vehicle = JsonConvert.DeserializeObject<IList<ConfigInfo>>(jsonData);
            return vehicle.First().SearchPhrase;
        }
        public static int ReadPages(string configName)
        {
            var jsonData = File.ReadAllText($"D:\\VisualProjekty\\OgloszeniaZadanie\\OgloszeniaZadanie\\Resources\\{configName}");
            var pages = JsonConvert.DeserializeObject<IList<ConfigInfo>>(jsonData);
            return pages.First().NumberOfPagesRequested;
        }
    }
}