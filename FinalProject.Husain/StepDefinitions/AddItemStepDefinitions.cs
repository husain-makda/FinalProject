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
    public class AddItemStepDefinitions : Support.Hooks
    {
        [Given(@"I am Logged in")]
        public void GivenIAmLoggedIn()
        {
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/";
            driver.Manage().Window.Maximize();
            NavPOM Navs = new NavPOM(driver);
            Navs.GoToAccount();
            LoginPOMs Login = new LoginPOMs(driver);
            Login.Login("hello@gmail.com", "Password25@//200");
        }

        [Given(@"I am on the shop page")]
        public void GivenIAmOnTheShopPage()
        {
            NavPOM Nav = new NavPOM(driver);
            Nav.GoToShop();
        }

        [When(@"I add item to cart")]
        public void WhenIAddItemToCart()
        {
            AddItemPOM Item = new AddItemPOM(driver);
            Item.Product();
            Item.AddItem();
            //driver.FindElement(By.CssSelector("[class='post-27 product type-product status-publish has-post-thumbnail product_cat-accessories first instock sale shipping-taxable purchasable product-type-simple'] .attachment-woocommerce_thumbnail")).Click();
            //driver.FindElement(By.Name("add-to-cart")).Click();
        }

        [Then(@"item is added to cart")]
        public void ThenItemIsAddedToCart()
        {
            AddItemPOM View = new AddItemPOM(driver);
            View.viewCart();
        }
    }
}
