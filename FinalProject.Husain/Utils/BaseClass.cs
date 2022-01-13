using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace FinalProject.Husain.Utils
{
    public class BaseClass
    {
        public IWebDriver driver;
        public string baseUrl = "https://www.edgewordstraining.co.uk/demo-site";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site";
        }

        [TearDown]
        public void TearDown()
        {
            //driver.Close();
            driver.Quit();
        }
    }
}
