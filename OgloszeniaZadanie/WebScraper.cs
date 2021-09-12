using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace OgloszeniaZadanie
{
    class WebScraper
    {
        static string workingDirectory = Environment.CurrentDirectory;
        static string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        static IWebDriver driver = new ChromeDriver($"{projectDirectory}\\Resources\\");
        DataToSearch dataToSearch;
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

        public List<Vehicle> vehicles = new List<Vehicle>();

        public WebScraper()
        {
            dataToSearch = new DataToSearch();
            LoadPage();
            AcceptCookies();
            ChooseVehicle(dataToSearch.brand, dataToSearch.model);
            GetVehiclesFromAnnouncements(GetAnnouncements());
        }

        private void LoadPage()
        {
            driver.Navigate().GoToUrl("https://ogloszenia.trojmiasto.pl/motoryzacja-sprzedam/");
            driver.Manage().Window.Maximize();
        }

        private void AcceptCookies()
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@aria-label='ZGADZAM SIĘ']")));
                IWebElement acceptButton = driver.FindElement(By.XPath("//*[@aria-label='ZGADZAM SIĘ']"));
                acceptButton.Click();
            }
            catch (NoSuchElementException) { }
            
        }

        private void ChooseVehicle(string brand, string model)
        {
            SearchByPhrase(brand, true);
            SearchByPhrase(model, false);

            IWebElement searchButton = driver.FindElement(By.XPath("//*[@class='oglSearchbar__element oglSearchbar__element--submit']/button[contains(text(), 'Wyszukaj')]"));
            searchButton.Click();

            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }
        private void SearchByPhrase(string phrase, bool searchBrand)
        {
            string searchFieldXPath = searchBrand ? "marka" : "model";
            IWebElement select = driver.FindElement(By.XPath($"//*[@class='select']/select[@name='{searchFieldXPath}']"));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//*[@class='select']/select[@name='{searchFieldXPath}']/option[contains(text(), {phrase})]")));
                SelectElement selectElement = new SelectElement(select);
                selectElement.SelectByText(phrase);
            }
            catch (NoSuchElementException) { }
        }

        private IReadOnlyCollection<IWebElement> GetAnnouncements()
        {
            IReadOnlyCollection<IWebElement> announcements;
            //announcements = driver.FindElements(By.XPath("//*[@class='list__item list--item--wyroznione list--item--withPrice']"));
            announcements = driver.FindElements(By.XPath("//div[contains(@class, 'list--item--withPrice')]"));

            return announcements;
        }

        private string GetInfoFromAnnouncement(IWebElement announcement, string info)
        {
            string infoValue;
            try
            {
                infoValue = announcement.FindElement(By.XPath($".//*[@class='list__item__details__icons__element details--icons--element--{info}']/div/p[@class='list__item__details__icons__element__desc']")).Text;
            }
            catch (NoSuchElementException)
            {
                infoValue = String.Empty;
            }
            return infoValue;
        }

        private string GetInfoFromAnnouncement(IWebElement announcement)
        {
            string infoValue;
            try
            {
                string rawPriceStr = announcement.FindElement(By.XPath(".//*[@class='list__item__price__value']")).Text;
                string priceStr = Regex.Replace(rawPriceStr, @"\s+", "");
                infoValue = priceStr.Substring(0, priceStr.Length - 2);
            }
            catch (NoSuchElementException)
            {
                infoValue = String.Empty;
            }
            return infoValue;
        }

        private void GetVehiclesFromAnnouncements(IReadOnlyCollection<IWebElement> announcements)
        {
            //announcements = GetAnnouncements();
            string[] infos = {"przebieg", "rok_produkcji", "pojemnosc"};

            foreach (var announcement in announcements)
            {
                string price = GetInfoFromAnnouncement(announcement);
                string mileage = GetInfoFromAnnouncement(announcement, infos[0]);
                string productionAge = GetInfoFromAnnouncement(announcement, infos[1]);
                string capacity = GetInfoFromAnnouncement(announcement, infos[2]);

                Vehicle vehicle = new Vehicle(price, mileage, productionAge, capacity);
                vehicles.Add(vehicle);
            }
        }
    }
}
