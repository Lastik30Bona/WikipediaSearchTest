using OpenQA.Selenium;

namespace WikiSearchTest.Pages
{
    public class WikipediaPage
    {
        public IWebDriver driver;

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
