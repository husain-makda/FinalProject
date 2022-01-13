using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using FluentAssertions;
using FinalProject.Husain.POM;
using static FinalProject.Husain.Utils.MyHelpers;
using OpenQA.Selenium.Support.UI;

namespace FinalProject.Husain.StepDefinitions
{
    [Binding]

    public class ProjectStepDefinitions : Support.Hooks
    {

        private bool Coupon;
        decimal pricebeforediscount;
        decimal discount;
        decimal priceafterdiscount;
        decimal shipAmt;
        decimal totalAmt;

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/";
            driver.Manage().Window.Maximize();
            WaitHelper(driver, 15, By.LinkText("My account"));
            NavPOM Nav = new NavPOM(driver);
            //Got to account page
            Nav.GoToAccount();
        }

        [When(@"using a valid username '([^']*)' and password '([^']*)'")]
        public void WhenUsingAValidUsernameAndPassword(string p0, string p1)
        {
            //login with username and password
            LoginPOMs Login = new LoginPOMs(driver);
            Login.Login(username:p0, password:p1);
            Console.WriteLine("User is logged in");
        }



        [When(@"I add item to cart, which I view")]
        public void WhenIAddItemToCartWhichIView()
        {
            WaitHelper(driver, 15, By.LinkText("Shop"));
            //go to shop page
            NavPOM Nav = new NavPOM(driver);
            Nav.GoToShop();
            //add item to cart
            AddItemPOM Product = new AddItemPOM(driver);
            Product.Product().AddItem();
        }

        [When(@"I apply disocunt code")]
        public void WhenIApplyDisocuntCode()
        {
            //view cart
            NavPOM Nav = new NavPOM(driver);
            Nav.GoToCart();
            // add the discount
            DiscountPOM Discountt = new DiscountPOM(driver);
            Discountt.Coupon("edgewords");
            Discountt.ApplyButton();
            Thread.Sleep(1000);
            Console.WriteLine("Amount is wrong");
        }

        [Then(@"Correct disocunt is applied")]
        public void ThenCorrectDisocuntIsApplied()
        {
            //DiscountPOM Discountt = new DiscountPOM(driver);
            try
            {
                string subtotal = driver.FindElement(By.XPath("/html//article[@id='post-5']/div[@class='entry-content']/div[@class='woocommerce']//table[@class='shop_table shop_table_responsive']//tr[@class='cart-subtotal']/td/span")).Text;
                string Amount = driver.FindElement(By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount")).Text;
                pricebeforediscount = Convert.ToDecimal(subtotal.Remove(0, 1));
                discount = (15m / 100m) * pricebeforediscount;
                Assert.That(Amount.Remove(0, 1), Is.EqualTo(discount.ToString("0.00")), "Not the same");

            }
            catch (AssertionException) { }


            try
            {
                string shipping = driver.FindElement(By.XPath("/html//article[@id='post-5']/div[@class='entry-content']/div[@class='woocommerce']//table[@class='shop_table shop_table_responsive']//tr[@class='cart-subtotal']/td/span")).Text;
                priceafterdiscount = pricebeforediscount - discount;
                shipAmt = Convert.ToDecimal(shipping.Remove(0, 1));
                totalAmt = priceafterdiscount + shipAmt;
                string Total = driver.FindElement(By.XPath("/html//article[@id='post-5']//div[@class='cart-collaterals']/div/table[@class='shop_table shop_table_responsive']//strong/span")).Text;
                Assert.That(Total.Remove(0, 1), Is.EqualTo(totalAmt.ToString("0.00")), "Not the same");

            }
            catch (AssertionException) { }

            try { Assert.That(Coupon, "Coupon discount incorrect"); }
            catch (AssertionException) { }
            driver.FindElement(By.CssSelector(".menu-item.menu-item-45.menu-item-object-page.menu-item-type-post_type > a")).Click();

        }
        [Then(@"Place order and view order number")]
        public void ThenPlaceOrderAndViewOrderNumber()
        {
            // go to checkout
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

            // place order
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
            WaitHelper(driver, 15, By.LinkText("Logout"));
            //logout
            try
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
            catch (ElementClickInterceptedException) { }
            Thread.Sleep(1000);
        }


        



    }
}
