// Generated by Selenium IDE
using System;
using OpenQA.Selenium.Support;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using FinalProject.Husain.POM;
using static FinalProject.Husain.Utils.MyHelpers;


namespace FinalProject.Husain.Test
{
    [TestFixture]
    public class DemoTestTest : Utils.BaseClass
    {
        private bool Coupon;
        decimal pricebeforediscount;
        decimal discount;
        decimal priceafterdiscount;
        decimal shipAmt;
        decimal totalAmt;
        [Test]
        public void demoTest()
        {
            // Test name: DemoTest
            // Step # | name | target | value
            // 1 | open | /demo-site/my-account/ | 
            driver.Navigate().GoToUrl("https://www.edgewordstraining.co.uk/demo-site/my-account/");
            // 2 | setWindowSize | 1282x1040 | 
            driver.Manage().Window.Maximize();
            //driver.Manage().Window.Size = new System.Drawing.Size(1282, 1040);
            // login with username and password
            LoginPOMs Login = new LoginPOMs(driver);
            WaitHelper(driver, 15, By.LinkText("My account"));
            Login.Login(username: "Hello@gmail.com", password: "Password25@//200");
            Thread.Sleep(1000);
            Console.WriteLine("User is logged in");

            // go to shop page
            WaitHelper(driver, 15, By.LinkText("Shop"));
          
            NavPOM Nav = new NavPOM(driver);
            Nav.GoToShop();
            //add item
            AddItemPOM Product = new AddItemPOM(driver);
            Product.Product().AddItem();
            //go to cart page
            Nav.GoToCart();
            //add discount
            DiscountPOM Discount = new DiscountPOM(driver);
            Discount.Coupon("edgewords");
            Discount.ApplyButton();

         
            Thread.Sleep(1000);
            Console.WriteLine("Amount is wrong");
            try
            {
                string subtotal = driver.FindElement(By.XPath("/html//article[@id='post-5']/div[@class='entry-content']/div[@class='woocommerce']//table[@class='shop_table shop_table_responsive']//tr[@class='cart-subtotal']/td/span")).Text;
                string Amount = driver.FindElement(By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount")).Text;
                pricebeforediscount = Convert.ToDecimal(subtotal.Remove(0, 1));
                discount = (15m / 100m) * pricebeforediscount;
                Assert.That(Amount.Remove(0, 1), Is.EqualTo(discount.ToString("0.00")), "Not the same");

            }
            catch (AssertionException){}


            try
            {
                string shipping = driver.FindElement(By.XPath("/html//article[@id='post-5']/div[@class='entry-content']/div[@class='woocommerce']//table[@class='shop_table shop_table_responsive']//tr[@class='cart-subtotal']/td/span")).Text;
                priceafterdiscount = pricebeforediscount - discount;
                shipAmt = Convert.ToDecimal(shipping.Remove(0, 1));
                totalAmt = priceafterdiscount + shipAmt;
                string Total = driver.FindElement(By.XPath("/html//article[@id='post-5']//div[@class='cart-collaterals']/div/table[@class='shop_table shop_table_responsive']//strong/span")).Text;
                Assert.That(Total.Remove(0, 1), Is.EqualTo(totalAmt.ToString("0.00")), "Not the same");

            }
            catch (AssertionException){}


            try { Assert.That(Coupon, "Coupon discount incorrect"); }
            catch (AssertionException) { }
            try
            {
                
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
                driver.FindElement(By.XPath("/html//article[@id='post-5']/div[@class='entry-content']//a[@href='https://www.edgewordstraining.co.uk/demo-site/checkout/']")).Click();
            }
            catch (ElementClickInterceptedException)
            {
                
            }
            driver.FindElement(By.CssSelector(".menu-item.menu-item-45.menu-item-object-page.menu-item-type-post_type > a")).Click();
            BillingPOM Billing = new BillingPOM(driver);
            Billing.Firstname();
            Billing.Lastname();
            Billing.Address();
            Billing.City();
            Billing.Postcode();
            Billing.Phone();
            Billing.Email();
            Billing.Note();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(".payment_method_cheque > label")).Click();
            // 20 | click | id=place_order | 
            driver.FindElement(By.Id("place_order")).Click();

            try
            {
                driver.FindElement(By.XPath("/html//button[@id='place_order']")).Click();
            }
            catch (StaleElementReferenceException) { }

            Thread.Sleep(1000);
            //.Got to account page
            Nav.GoToAccount();
            Nav.GoToOrders();
            //screenshot
            TakeScreenshotElement(driver, "Order Number", By.CssSelector("tr:nth-of-type(1) > .woocommerce-orders-table__cell.woocommerce-orders-table__cell-order-number > a"));
            //Thread.Sleep(1000);
            WaitHelper(driver, 15, By.LinkText("Logout"));
            try
            {
                //logout
                driver.FindElement(By.LinkText("Logout")).Click();
            }
            catch (ElementClickInterceptedException) { }
            Thread.Sleep(1000);
            Console.WriteLine("User is logged out");
        }
    }
}
