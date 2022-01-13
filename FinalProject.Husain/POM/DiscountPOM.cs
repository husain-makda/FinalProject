using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Husain.POM
{
    public class DiscountPOM
    {
        IWebDriver driver;
        public DiscountPOM(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement CouponCode => driver.FindElement(By.Id("coupon_code"));
        IWebElement Apply => driver.FindElement(By.Name("apply_coupon"));
        public void Coupon(string Code)
        {
            CouponCode.SendKeys(Code);
        }

        public void ApplyButton()
        {
            Apply.Click();
        }


      
    
    }
}
