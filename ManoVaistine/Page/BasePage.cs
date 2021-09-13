﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace manoVaistine.Page
{
    public class BasePage
    {
        protected static IWebDriver Driver;

        public BasePage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        public WebDriverWait GetWait(int seconds = 5)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
            return wait;
        }

        public void Wait_Until_Loading_Invisible()
        {
            GetWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".tawk-emoji-loading")));
        }

        public void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}
