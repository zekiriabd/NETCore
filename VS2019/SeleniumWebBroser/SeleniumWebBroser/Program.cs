
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.Threading;

namespace SeleniumWebBroser
{
    class Program
    {
        static void Main(string[] args)
        {
            const string url = "https://translate.google.fr/?hl=fr";
            
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

           /* Debug.WriteLine("===============================================");
            Debug.WriteLine(driver.Title);
            Debug.WriteLine("===============================================");
            Debug.WriteLine(driver.Url);
            Debug.WriteLine("===============================================");
            Debug.WriteLine(driver.PageSource);
            Debug.WriteLine("===============================================");
            */

            IWebElement source = driver.FindElement(By.Id("source"));
            source.SendKeys("السلام عليكم");
            
            Thread.Sleep(1000);

            IWebElement result = driver.FindElement(By.ClassName("tlid-translation"));
            string strResult = result.GetAttribute("innerText");
            Debug.WriteLine(strResult);

            //driver.Close();
            driver.Quit();
        }
    }
}
