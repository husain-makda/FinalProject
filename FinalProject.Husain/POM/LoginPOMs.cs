using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Husain.POM
{
    public class LoginPOMs
    {
        IWebDriver driver;

        public LoginPOMs(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement usernamefield => driver.FindElement(By.Id("username"));
        IWebElement passwordfield => driver.FindElement(By.Id("password"));
        IWebElement loginbutton => driver.FindElement(By.Name("login"));

        //service methods

        public LoginPOMs Login(string username, string password)
        {
            usernamefield.Clear();
            passwordfield.Clear();
            usernamefield.SendKeys(username);
            passwordfield.SendKeys(password);
            loginbutton.Click();
            return this;

        }
    }
}
