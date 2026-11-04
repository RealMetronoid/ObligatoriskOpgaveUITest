using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics.CodeAnalysis;

namespace ObligatoriskOpgaveUITest
{
    public class ObligatoriskTests
    {
        private static readonly string DriverDirectory = "C:\\webDrivers";

        string url = "http://127.0.0.1:5500/index.html";
        [Fact]
        public void TitleSearchTest()
        {
            //IWebDriver driver = new ChromeDriver(DriverDirectory);
            IWebDriver driver = new FirefoxDriver(DriverDirectory);
            //IWebDriver driver = new EdgeDriver(DriverDirectory);

            driver.Navigate().GoToUrl(url);

            Assert.Equal("Music Repo", driver.Title);

            IWebElement titleInput = driver.FindElement(By.Id("titleSearch"));
            titleInput.SendKeys("Mad");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            IWebElement message = driver.FindElement(By.ClassName("records"));

            Assert.Equal("Mad in love by Progressive Metal (2023 - 1000 listeners)", message.Text);

            driver.Dispose();
        }

        [Fact]
        public void SortByTest()
        {
            //IWebDriver driver = new ChromeDriver(DriverDirectory);
            IWebDriver driver = new FirefoxDriver(DriverDirectory);
            //IWebDriver driver = new EdgeDriver(DriverDirectory);'

            driver.Navigate().GoToUrl(url);

            Assert.Equal("Music Repo", driver.Title);

            IWebElement sortByDropdown = driver.FindElement(By.Id("sortBy"));
            SelectElement dropdownElement = new SelectElement(sortByDropdown);

            dropdownElement.SelectByValue("title");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            var messages = driver.FindElements(By.ClassName("records"));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            List<string> expected = [ "Hearts and minds by Kale Eaters (2020 - 50 listeners)",
                    "Kojak by One Republic(2026 - 2000 listeners)",
                    "Mad in love by Progressive Metal (2023 - 1000 listeners)",
                    "Still human by Daft Punk (2016 - 100000 listeners)" ];

            foreach (IWebElement message in messages)
            {
                var i = 0;
                Assert.Equal(expected[i], message.Text);
                i++;
            }

            //driver.Dispose();
        }
    }
}
