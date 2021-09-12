using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgloszeniaZadanie
{
    public static class HandleOutput
    {
        public static void PrintResults(DataToSearch dataToSearch, DataCalculation dataCalculation)
        {
            Console.Clear();
            Console.WriteLine($"Brand: {dataToSearch.brand}");
            Console.WriteLine($"Model: {dataToSearch.model}");
            Console.WriteLine($"NumberOfItems: {dataCalculation.numberOfVehicles}");
            Console.WriteLine($"AveragePrice: {dataCalculation.averagePrice}");
            Console.WriteLine($"AverageMileage: {dataCalculation.averageMileage}");
            Console.WriteLine($"AverageEngineCapacity: {dataCalculation.averageCapacity}");
            Console.WriteLine($"AverageYearOfProduction: {dataCalculation.averageProductionYear}");
        }

        public static void SaveResults(DataToSearch dataToSearch, DataCalculation dataCalculation)
        {
            List<DataInfo> dataToSave = new List<DataInfo>();
            dataToSave.Add(new DataInfo()
            {
                SearchPhrase = $"{dataToSearch.brand} {dataToSearch.model}",
                NumberOfItems = dataCalculation.numberOfVehicles,
                AveragePrice = dataCalculation.averagePrice,
                AverageMileage = dataCalculation.averageMileage,
                AverageEngineCapacity = dataCalculation.averageCapacity,
                AverageYearOfProduction = dataCalculation.averageProductionYear
            });
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string jsonConfig = JsonConvert.SerializeObject(dataToSave.ToArray());
            File.WriteAllText($"{projectDirectory}\\results.txt", jsonConfig);
        }
    }
}
