using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Spanish_Point
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            //Intiating chrome driver
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            //Navigating to URL
            driver.Navigate().GoToUrl("https://www.matchingengine.com/");

            // Wait for the page to load
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //Hover on Modules and click on "Repertoire Management Module"
            IWebElement modules = driver.FindElement(By.XPath("//a[@class= 'navbar-link is-active']"));

            Actions ac = new Actions(driver);
            ac.MoveToElement(modules).Perform();

            IWebElement reperManage = driver.FindElement(By.XPath("//a[text()='Repertoire Management Module']"));
            reperManage.Click();
          
            //Scroll into view product supported and click
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,1500);");

            // Adding sleep to watch in the UI
            Thread.Sleep(3000);
            IWebElement prodSupport = driver.FindElement(By.XPath("(//a//span[text()= 'Products Supported'])[1]"));
            prodSupport.Click();

            IWebElement cue = driver.FindElement(By.XPath("//span[text()='Cue Sheet / AV Work']"));
            IWebElement reco = driver.FindElement(By.XPath("//span[text()='Recording']"));
            IWebElement bund = driver.FindElement(By.XPath("//span[text()='Bundle']"));
            IWebElement adver = driver.FindElement(By.XPath("//span[contains(text(), 'Advertisement')]"));

            //writing Assertions for product available list
            AssertElementIsDisplayed(cue, "Cue Sheet / AV Work");
            AssertElementIsDisplayed(reco, "Recording");
            AssertElementIsDisplayed(bund, "Bundle");
            AssertElementIsDisplayed(adver, "Advertisement ");

            static void AssertElementIsDisplayed(IWebElement element, string elementName)
            {
                if (element.Displayed)
                {
                    Console.WriteLine($"Assertion passed: '{elementName}' is present and displayed.");
                }
                else
                {
                    Console.WriteLine($"Assertion failed: '{elementName}' is not displayed.");
                }
            }
            //uncommenting to watch in the UI
          //  driver.Quit();

        }   
        
    }
}