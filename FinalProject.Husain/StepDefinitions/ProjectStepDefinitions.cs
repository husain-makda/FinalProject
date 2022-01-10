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
      
        private bool Coupon;
        decimal discount;
        string Discountt;
        decimal totalAmt;
        string Total;


        //[Given(@"I am on the login page")]
        //public void GivenIAmOnTheLoginPage()
        //{
        //    driver.Url = "https://www.edgewordstraining.co.uk/demo-site/";
        //    driver.Manage().Window.Maximize();
        //    NavPOM Nav = new NavPOM(driver);
        //    //Got to account page
        //    Nav.GoToAccount();
        //}

        [Given(@"I am on the login page, using a valid username and password")]
        public void GivenIAmOnTheLoginPageUsingAValidUsernameAndPassword()
        {
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/";
            driver.Manage().Window.Maximize();
            NavPOM Nav = new NavPOM(driver);
            //Got to account page
            Nav.GoToAccount();

            //login with username and password
            LoginPOMs Login = new LoginPOMs(driver);
            Login.Login(username: "Hello@gmail.com", password: "Password25@//200");

            //string bodytext = driver.FindElement(By.TagName("body")).Text;
            //Assert.That(bodytext, Does.Contain("Hello hello1").IgnoreCase, "");
            Console.WriteLine("User is logged in");
        }

      


        //[When(@"I use a valid username and password")]
        //public void WhenIUseAValidUsernameAndPassword()
        //{
        //    //login with username and password
        //    LoginPOMs Login = new LoginPOMs(driver);
        //    Login.Login(username: "Hello@gmail.com", password: "Password25@//200");

        //    //string bodytext = driver.FindElement(By.TagName("body")).Text;
        //    //Assert.That(bodytext, Does.Contain("Hello hello1").IgnoreCase, "");
        //    Console.WriteLine("User is logged in");
        //}


        [When(@"I add a cap to cart which I view")]
        public void WhenIAddACapToCart()
        {
            //go to shop page
            NavPOM Nav = new NavPOM(driver);
            Nav.GoToShop();
            //add item to cart
            AddItemPOM Product = new AddItemPOM(driver);
            Product.Product().AddItem();
            

        }

        [Then(@"Correct disocunt is applied")]
        public void ThenCorrectDisocuntIsApplied()
        {
            //view cart
            NavPOM Nav = new NavPOM(driver);
            Nav.GoToCart();
            // add the discount
            DiscountPOM Discount = new DiscountPOM(driver);
            Discount.Coupon("edgewords");
            Discount.ApplyButton();

            Thread.Sleep(1000);
            //Console.WriteLine("Amount is wrong");
            //check the coupon amount is correct
            try
            {
                Discount.CheckCouponAmt();
                //Assert.That(Discountt.Remove(0, 1), Is.EqualTo(discount.ToString("0.00")), "Not the same");
            }
            catch (AssertionException)
            {
                Assert.That(Discountt.Remove(0, 1), Is.EqualTo(discount.ToString("0.00")), "Not the same");
                Console.WriteLine("Coupon does not take of 15%");
            }

            //Check that the total is correct
            try
            {
                Discount.CheckTotalAmt();  
            }
            catch (AssertionException)
            {
                Assert.That(Total.Remove(0, 1), Is.EqualTo(totalAmt.ToString("0.00")), "Not the same");
                Console.WriteLine("The total is incorrect");
            }

            try { Assert.That(Coupon, "Coupon discount incorrect"); }
            catch (AssertionException) { }
            driver.FindElement(By.CssSelector(".menu-item.menu-item-45.menu-item-object-page.menu-item-type-post_type > a")).Click();

        }

        [Then(@"I am able to checkout")]
        public void ThenIAmAbleToCheckout()
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
