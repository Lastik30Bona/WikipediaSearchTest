using OpenQA.Selenium;

namespace WikiSearchTest
{
    public class WikipediaPage
    {
        private IWebDriver driver;

        public WikipediaPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement SearchInput => driver.FindElement(By.Id("searchInput"));

        public void Search(string text)
        {
            SearchInput.SendKeys(text + Keys.Enter);
        }
    }

}
