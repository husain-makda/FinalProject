﻿using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FinalProject.Husain.POM;
using OpenQA.Selenium.Support.UI;

namespace FinalProject.Husain.Support
{
    [Binding]
    public class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        public IWebDriver driver;
        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
            driver =new ChromeDriver();
          
        }

        public static void WaitHelper(IWebDriver driver, int Seconds, By locator)
        {
            WebDriverWait mysecodwait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            mysecodwait.Until(drv => drv.FindElement(locator).Displayed);

        }

        //public static void TakeScreenshot(IWebDriver driver, string Filename)
        //{

        //    ITakesScreenshot ssdriver = driver as ITakesScreenshot;
        //    Screenshot myscreenshot = ssdriver.GetScreenshot();
        //    myscreenshot.SaveAsFile(@"C:\Users\HusainMakda\OneDrive - nFocus Limited\Pictures\Screenshots\" + Filename + ".png", ScreenshotImageFormat.Png);

        //}

        public static void TakeScreenshotElement(IWebDriver driver, string Filename, By locator)
        {
            IWebElement myelm = driver.FindElement(locator);
            ITakesScreenshot ssdriver = myelm as ITakesScreenshot;
            Screenshot myscreenshot = ssdriver.GetScreenshot();
            myscreenshot.SaveAsFile(@"C:\Users\HusainMakda\OneDrive - nFocus Limited\Pictures\Screenshots\" + Filename + ".png", ScreenshotImageFormat.Png);

        }



        //[BeforeScenario(Order = 1)]
        //public void FirstBeforeScenario()
        //{
        //    // Example of ordering the execution of hooks
        //    // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=order#hook-execution-order

        //    //TODO: implement logic that has to run before executing each scenario
        //}

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            driver.Quit();
        }
    }
}