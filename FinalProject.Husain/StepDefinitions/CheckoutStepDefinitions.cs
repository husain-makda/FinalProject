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
    public class CheckoutStepDefinitions : Support.Hooks
    {
        [Given(@"I have added item to cart")]
        public void GivenIHaveAddedItemToCart()
        {
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/";
            driver.Manage().Window.Maximize();
            NavPOM Nav = new NavPOM(driver);
            Nav.GoToShop();
            driver.FindElement(By.CssSelector("[class='post-27 product type-product status-publish has-post-thumbnail product_cat-accessories first instock sale shipping-taxable purchasable product-type-simple'] .attachment-woocommerce_thumbnail")).Click();
            driver.FindElement(By.Name("add-to-cart")).Click();

            Nav.GoToCart();
            driver.FindElement(By.Id("coupon_code")).SendKeys("edgewords");
            driver.FindElement(By.Name("apply_coupon")).Click();
            driver.FindElement(By.XPath("/html//article[@id='post-5']/div[@class='entry-content']/div[@class='woocommerce']//table[@class='shop_table shop_table_responsive']//tr[@class='cart-subtotal']/td/span")).GetAttribute("textContent");
            
        }

        [Given(@"I am on the checkout page")]
        public void GivenIAmOnTheCheckoutPage()
        {
            
            NavPOM nav = new NavPOM(driver);
            nav.GoToCheckout();
        }

        [When(@"I enter all billing details")]
        public void WhenIEnterAllBillingDetails()
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

        [Then(@"I can place the order")]
        public void ThenICanPlaceTheOrder()
        {
            try
            {
                driver.FindElement(By.XPath("/html//button[@id='place_order']")).Click();
            }
            catch (StaleElementReferenceException) { }

            Thread.Sleep(1000);
        }
    }
}
