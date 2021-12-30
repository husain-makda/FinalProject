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
    public class LoginStepDefinitions : Support.Hooks
    {
        [Given(@"I am on the account page")]
        public void GivenIAmOnTheAccountPage()
        {
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/";
            driver.Manage().Window.Maximize();
            NavPOM Nav = new NavPOM(driver);
            //Got to account page
            Nav.GoToAccount();
        }

        [When(@"I enter a valid username and password")]
        public void WhenIEnterAValidUsernameAndPassword()
        {
            //login with username and password
            LoginPOMs Login = new LoginPOMs(driver);
            Login.Login(username: "Hello@gmail.com", password: "Password25@//200");

        }

        [Then(@"I am logged in")]
        public void ThenIAmLoggedIn()
        {
            string bodytext = driver.FindElement(By.TagName("body")).Text;
            Assert.That(bodytext, Does.Contain("Hello hello1").IgnoreCase, "");
            Console.WriteLine("User is logged in");
        }
    }
}
