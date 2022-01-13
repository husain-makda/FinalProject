using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Husain.Utils
{
    public static class MyHelpers
    {
        public static void WaitHelper(IWebDriver driver, int Seconds, By locator)
        {
            WebDriverWait mysecodwait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            mysecodwait.Until(drv => drv.FindElement(locator).Displayed);
        }

        public static void TakeScreenshot(IWebDriver driver, string Filename)
        {
            
            ITakesScreenshot ssdriver = driver as ITakesScreenshot;
            Screenshot myscreenshot =  ssdriver.GetScreenshot();
            myscreenshot.SaveAsFile(@"C:\Users\HusainMakda\OneDrive - nFocus Limited\Pictures\Screenshots\" + Filename + ".png", ScreenshotImageFormat.Png);

        }

        public static void TakeScreenshotElement(IWebDriver driver, string Filename, By locator)
        {
            IWebElement myelm = driver.FindElement(locator);
            ITakesScreenshot ssdriver = myelm as ITakesScreenshot;
            Screenshot myscreenshot = ssdriver.GetScreenshot();
            myscreenshot.SaveAsFile(@"C:\Users\HusainMakda\OneDrive - nFocus Limited\Pictures\Screenshots\" + Filename + ".png", ScreenshotImageFormat.Png);

        }
    }
}
