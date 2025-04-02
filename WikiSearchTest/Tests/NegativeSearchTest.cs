using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WikiSearchTest.Pages;

namespace WikiSearchTest
{
    public class NegativeSearchTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Search_WithInvalidWord_ShouldSuggestAlternative()
        {
            driver.Navigate().GoToUrl("https://wikipedia.org");

            var wiki = new WikipediaPage(driver);
            wiki.Search("asdasd");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var suggestionBox = wait.Until(driver => driver.FindElement(By.ClassName("searchdidyoumean")));

            Assert.That(suggestionBox.Displayed, Is.True);
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
