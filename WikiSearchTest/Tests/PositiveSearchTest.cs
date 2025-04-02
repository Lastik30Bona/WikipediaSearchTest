using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WikiSearchTest.Pages;

namespace WikiSearchTest.Tests
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Search_Should_DisplayRelevantPage()
        {
            driver.Navigate().GoToUrl("https://wikipedia.org");

            var wiki = new WikipediaPage(driver);
            wiki.Search("Automation");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.Title.Contains("Automation"));


            Assert.That(driver.Title, Does.Contain("Automation"));
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
            driver.Dispose();
        }
    }


}