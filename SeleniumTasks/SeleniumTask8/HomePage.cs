using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;

namespace DevBy
{
    internal class HomePage
    {
        IWebDriver _driver;

        ReadOnlyCollection<IWebElement> _jobVacancy;
        const string SITE_NUMBER_VACANCY = "//a[@title='Java']/following-sibling::div";
        const string SITE_JAVA_LINK = "//a[@title='Java']";
        const string SITE_JAVA_JOBS = "//div[@class='vacancies-list-item']";
        const string SITE_JAVA_JOBS_DESCRIPTIONS = "//a[@class='vacancies-list-item__link_block']";
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Url = "https://devby.io/";
            _driver.Manage().Window.Maximize();
        }

        public int OpenVacancyInfo()
        {
            var element = _driver.FindElements(By.XPath(SITE_NUMBER_VACANCY)).FirstOrDefault();

            if (element != null)
            {
                var text = element.GetAttribute("innerHTML");
                var items = text.Split();
                int.TryParse(items[0], out var count);
                return count;
            }
            return 0;
        }

        public void GoToJava()
        {
            var javaJobs = _driver.FindElements(By.XPath(SITE_JAVA_LINK)).FirstOrDefault();

            if (javaJobs != null)
            {
                Actions action = new Actions(_driver);
                action.MoveToElement(javaJobs, 10, 10);
                action.Perform();
                javaJobs.Click();
                Task.Delay(2_000).Wait();

                //Grabs the browser handles open
            var browserTabs = _driver.WindowHandles;

                //When the link is clicked on switch to that tab
                _driver.SwitchTo().Window(_driver.WindowHandles[1]);
            }
        }

        public int GetJavaJobsCount()
        {
            var javaJobElements = _driver.FindElements(By.XPath(SITE_JAVA_JOBS));
            return javaJobElements?.Count ?? 0;
        }
        public void PrintJavaJobs()
        {
            var javaJobElements = _driver.FindElements(By.XPath(SITE_JAVA_JOBS));
            foreach (var jobElement in javaJobElements)
            {
            Console.WriteLine(jobElement.GetAttribute("innerHTML"));
            }
        }
        public void PrintJavaJobsDescriptions()
        {
            var javaJobDescriptions = _driver.FindElements(By.XPath(SITE_JAVA_JOBS_DESCRIPTIONS));
            foreach (var jobElementDescription in javaJobDescriptions)
            {
            var text = jobElementDescription.GetAttribute("innerHTML");
            Console.WriteLine(text);
            }           
        }
    }
}