using System;
using System.IO;

namespace OgloszeniaZadanie
{
    class Program
    {
        static void Main(string[] args)
        {
            WebScraper webScraper = new WebScraper();
            DataCalculation dataCalculation = new DataCalculation(webScraper.vehicles);
            HandleOutput.PrintResults(webScraper.dataToSearch, dataCalculation);
            HandleOutput.SaveResults(webScraper.dataToSearch, dataCalculation);
        }
    }
}
