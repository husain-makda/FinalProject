using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using FluentAssertions;
using FinalProject.Husain.POM;
using OpenQA.Selenium.Support.UI;
using FinalProject.Husain.Utils;

namespace FinalProject.Husain.StepDefinitions
{
    [Binding]
    public class OrderAndLogoutStepDefinitions : Support.Hooks
    {
        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/";
            driver.Manage().Window.Maximize();
            NavPOM Navs = new NavPOM(driver);
            Navs.GoToAccount();
            LoginPOMs Login = new LoginPOMs(driver);
            Login.Login("hello@gmail.com", "Password25@//200");
        }

        [Given(@"On my account page")]
        public void GivenOnMyAccountPage()
        {
            NavPOM Navs = new NavPOM(driver);
            Navs.GoToAccount();
        }

        [When(@"I go on orders")]
        public void WhenIGoOnOrders()
        {
            NavPOM Navs = new NavPOM(driver);
            Navs.GoToOrders();
        }

        [Then(@"I can view order number")]
        public void ThenICanViewOrderNumber()
        {
            //screenshot
            TakeScreenshotElement(driver, "Order Number", By.CssSelector("tr:nth-of-type(1) > .woocommerce-orders-table__cell.woocommerce-orders-table__cell-order-number > a"));
            Thread.Sleep(1000);
        }

        [Then(@"I can Logout")]
        public void ThenICanLogout()
        {
            try
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
            catch (ElementClickInterceptedException) { }
            Thread.Sleep(1000);
        }
    }
}
