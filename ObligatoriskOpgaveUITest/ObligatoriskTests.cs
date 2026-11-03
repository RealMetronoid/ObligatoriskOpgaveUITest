using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace ObligatoriskOpgaveUITest
{
    public class ObligatoriskTests
    {
        private static readonly string DriverDirectory = "C:\\webDrivers";

        string url = "http://localhost:5292/index.html";
        [Fact]
        public void Test1()
        {
            //IWebDriver driver = new ChromeDriver(DriverDirectory);
            IWebDriver driver = new FirefoxDriver(DriverDirectory);
            //IWebDriver driver = new EdgeDriver(DriverDirectory);

            driver.Navigate().GoToUrl(url);
        }
    }
}
