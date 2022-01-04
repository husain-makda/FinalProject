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
        decimal pricebeforediscount;
        decimal discount;
        decimal priceafterdiscount;
        decimal shipAmt;
        decimal totalAmt;
        public DiscountPOM(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement CouponCode => driver.FindElement(By.Id("coupon_code"));
        IWebElement Apply => driver.FindElement(By.Name("apply_coupon"));
        IWebElement SubtotalAmt => driver.FindElement(By.XPath("/html//article[@id='post-5']/div[@class='entry-content']/div[@class='woocommerce']//table[@class='shop_table shop_table_responsive']//tr[@class='cart-subtotal']/td/span"));
        IWebElement CouponAmt => driver.FindElement(By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount"));
        IWebElement ShippingFee => driver.FindElement(By.XPath("/html//article[@id='post-5']//div[@class='cart-collaterals']/div/table[@class='shop_table shop_table_responsive']//tr[@class='shipping']/td/span"));
        IWebElement Total => driver.FindElement(By.XPath("/html//article[@id='post-5']//div[@class='cart-collaterals']/div/table[@class='shop_table shop_table_responsive']//strong/span"));

        public void Coupon(string Code)
        {
            CouponCode.SendKeys(Code);
        }

        public void ApplyButton()
        {
            Apply.Click();
        }

        public void CheckCouponAmt()
        {
            string subtotal = SubtotalAmt.Text;
            string Discount = CouponAmt.Text;
            pricebeforediscount = Convert.ToDecimal(subtotal.Remove(0, 1));
            discount = (15m / 100m) * pricebeforediscount;
            Assert.That(Discount.Remove(0, 1), Is.EqualTo(discount.ToString("0.00")), "They are not equal");
        }
        
        public void CheckTotalAmt()
        {
            string shipping = ShippingFee.Text;
            priceafterdiscount = pricebeforediscount - discount;
            shipAmt = Convert.ToDecimal(shipping.Remove(0, 1));
            totalAmt = priceafterdiscount + shipAmt;
            Assert.That(Total.Text.Remove(0, 1), Is.EqualTo(totalAmt.ToString("0.00")), "They are not equal");

            
        }

    
    
    }
}
