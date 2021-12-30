using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Husain.POM
{
    public class NavPOM
    {
        IWebDriver driver;
        

        public NavPOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement account_page => driver.FindElement(By.LinkText("My account"));
        private IWebElement Shop => driver.FindElement(By.LinkText("Shop"));
        private IWebElement cart => driver.FindElement(By.LinkText("View cart"));
        private IWebElement checkout => driver.FindElement(By.LinkText("Checkout"));
        private IWebElement orders => driver.FindElement(By.LinkText("Orders"));

        public void GoToAccount()
        {
            account_page.Click();
        }

        public void GoToShop()
        {
            Shop.Click();
        }

        public void GoToCart()
        {
            cart.Click();
        }

        public void GoToCheckout()
        {
            checkout.Click();
        }

        public void GoToOrders()
        {
            orders.Click();
        }
    }
}
