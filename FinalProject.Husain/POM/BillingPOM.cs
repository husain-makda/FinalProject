using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Husain.POM
{
    public class BillingPOM
    {
        IWebDriver driver; 


        public BillingPOM (IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement Billing_firstname => driver.FindElement(By.Id("billing_first_name"));
        private IWebElement Billing_lastname => driver.FindElement(By.Id("billing_last_name"));
        private IWebElement Billing_address => driver.FindElement(By.Id("billing_address_1"));
        private IWebElement Billing_city => driver.FindElement(By.Id("billing_city"));
        private IWebElement Billing_postcode => driver.FindElement(By.Id("billing_postcode"));
        private IWebElement Billing_phone => driver.FindElement(By.Id("billing_phone"));
        private IWebElement Billing_email => driver.FindElement(By.Id("billing_email"));
        private IWebElement Billing_note => driver.FindElement(By.Id("order_comments"));
       
        public void Firstname()
        {
            Billing_firstname.Clear();
            Billing_firstname.SendKeys("Ben");
        }

        public void Lastname()
        {
            Billing_lastname.Clear();   
            Billing_lastname.SendKeys("smith");
        }

        public void Address()
        {
           Billing_address.Clear();
            Billing_address.SendKeys("25 sherrard road");
        }

        public void City()
        {
            Billing_city.Clear();
            Billing_city.SendKeys("leicester");
        }

        public void Postcode()
        {
            Billing_postcode.Clear();
            Billing_postcode.SendKeys("le5 3dr");
        }

        public void Phone()
        {
            Billing_phone.Clear();
            Billing_phone.SendKeys("07723112356");
        }

        public void Email()
        {
            Billing_email.Clear();
            Billing_email.SendKeys("hello@gmail.com");
        }

        public void Note()
        {
            Billing_note.Click();
            Billing_note.SendKeys("");
        }

    }
}
