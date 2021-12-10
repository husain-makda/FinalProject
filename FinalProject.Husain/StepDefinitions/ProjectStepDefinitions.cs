using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using FluentAssertions;
using FinalProject.Husain.POM;
using OpenQA.Selenium.Support.UI;

namespace FinalProject.Husain.StepDefinitions
{
    [Binding]
    public class ProjectStepDefinitions : Support.Hooks
    {
        private decimal Discount;
        private int Cost;

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/";
            NavPOM Nav = new NavPOM(driver);
            //Got to account page
            Nav.GoToAccount();
        }

        [When(@"I use a valid username and password")]
        public void WhenIUseAValidUsernameAndPassword()
        {
            //login with username and password
            LoginPOMs Login = new LoginPOMs(driver);
            Login.Login(username: "Hello@gmail.com", password: "Password25@//200");

            string bodytext = driver.FindElement(By.TagName("body")).Text;
            Assert.That(bodytext, Does.Contain("Hello hello1").IgnoreCase, "");
            Console.WriteLine("User is logged in");
        }


        [When(@"I add a cap to cart which I view")]
        public void WhenIAddACapToCart()
        {
            NavPOM Nav = new NavPOM(driver);
            Nav.GoToShop();
            driver.FindElement(By.CssSelector("[class='post-27 product type-product status-publish has-post-thumbnail product_cat-accessories first instock sale shipping-taxable purchasable product-type-simple'] .attachment-woocommerce_thumbnail")).Click();
            driver.FindElement(By.Name("add-to-cart")).Click();

            Nav.GoToCart();
            driver.FindElement(By.Id("coupon_code")).SendKeys("edgewords");
            driver.FindElement(By.Name("apply_coupon")).Click();
            driver.FindElement(By.XPath("/html//article[@id='post-5']/div[@class='entry-content']/div[@class='woocommerce']//table[@class='shop_table shop_table_responsive']//tr[@class='cart-subtotal']/td/span")).GetAttribute("textContent");
            Assert.That(Discount, Is.EqualTo((Cost / 100) * 15), "The Discount Amount is wrong");
            Console.WriteLine("Amount is wrong");
        }

        [Then(@"I am able to checkout")]
        public void ThenIAmAbleToCheckout()
        {
            driver.FindElement(By.CssSelector(".menu-item.menu-item-45.menu-item-object-page.menu-item-type-post_type > a")).Click();
            BillingPOM Billing = new BillingPOM(driver);
            Billing.Firstname();
            Billing.Lastname();
            Billing.Address();
            Billing.City();
            Billing.Postcode();
            Billing.Phone();
            Billing.Email();
            Thread.Sleep(1000);
        }

        [Then(@"I can place order")]
        public void ThenICanPlaceOrder()

        {
            try
            {
                driver.FindElement(By.XPath("/html//button[@id='place_order']")).Click();
            }
            catch (StaleElementReferenceException) { }

            Thread.Sleep(1000);
            //.Got to account page
            NavPOM Nav = new NavPOM(driver);
            Nav.GoToAccount();
            Nav.GoToOrders();
            //screenshot
            TakeScreenshotElement(driver, "Order Number", By.CssSelector("tr:nth-of-type(1) > .woocommerce-orders-table__cell.woocommerce-orders-table__cell-order-number > a"));
            Thread.Sleep(1000);
            try
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
            catch (ElementClickInterceptedException) { }
            Thread.Sleep(1000);
        }

    }
}
