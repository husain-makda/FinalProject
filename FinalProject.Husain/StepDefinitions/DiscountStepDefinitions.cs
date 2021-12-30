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
    public class DiscountStepDefinitions : Support.Hooks
    {
        private decimal Discount;
        private int Cost;

        [Given(@"I have added a item to cart")]
        public void GivenIHaveAddedAItemToCart()
        {
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/";
            driver.Manage().Window.Maximize();
            AddItemPOM Item = new AddItemPOM(driver);
            Item.Product();
            Item.AddItem();
        }

        [Given(@"I am on the cart page")]
        public void GivenIAmOnTheCartPage()
        {
            AddItemPOM View = new AddItemPOM(driver);
            View.viewCart();
        }

        [When(@"I apply the disocunt code")]
        public void WhenIApplyTheDisocuntCode()
        {
            driver.FindElement(By.Id("coupon_code")).SendKeys("edgewords");
          
        }

        [Then(@"Disount code is applied to total")]
        public void ThenDisountCodeIsAppliedToTotal()
        {
            driver.FindElement(By.Name("apply_coupon")).Click();
            driver.FindElement(By.XPath("/html//article[@id='post-5']/div[@class='entry-content']/div[@class='woocommerce']//table[@class='shop_table shop_table_responsive']//tr[@class='cart-subtotal']/td/span")).GetAttribute("textContent");
            Assert.That(Discount, Is.EqualTo((Cost / 100) * 15), "The Discount Amount is wrong");
            Console.WriteLine("Amount is wrong");
        }
    }
}
