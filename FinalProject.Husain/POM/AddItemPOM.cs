using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Husain.POM
{
    public class AddItemPOM
    {
        IWebDriver driver;
        public AddItemPOM(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement Item =>  driver.FindElement(By.CssSelector("[class='post-27 product type-product status-publish has-post-thumbnail product_cat-accessories first instock sale shipping-taxable purchasable product-type-simple'] .attachment-woocommerce_thumbnail"));
        IWebElement AddToCart => driver.FindElement(By.Name("add-to-cart"));
        IWebElement ViewCart => driver.FindElement(By.LinkText("View cart"));

        public AddItemPOM Product()
        {
            Item.Click();
            return this;
        }
   
        public AddItemPOM AddItem()
        {
            AddToCart.Click();
            return this;
        }
        public void viewCart()
        {
            ViewCart.Click();
        }
    }
}
