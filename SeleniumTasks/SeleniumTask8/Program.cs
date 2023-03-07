using DevBy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

IWebDriver driver = new ChromeDriver();

HomePage devByioPage = new HomePage(driver);

var count = devByioPage.OpenVacancyInfo();
Console.WriteLine($"Vacancy: {count}");

devByioPage.GoToJava();
Console.WriteLine("We are on the Java jobs page");

var jobsCount = devByioPage.GetJavaJobsCount();
Console.WriteLine($"Actual jobs count: {jobsCount}");

devByioPage.PrintJavaJobs();

devByioPage.PrintJavaJobsDescriptions();

var condition = count != jobsCount ? "not" : "";
Console.WriteLine($"Count java jobs on main page are {condition} equal to count jobs on job page");

driver.Close();
