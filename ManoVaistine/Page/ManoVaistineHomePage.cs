using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace manoVaistine.Page
{
    public class ManoVaistineHomePage : BasePage
    {
        private const string PageAddress = "https://www.manovaistine.lt/";
        private IWebElement KMIButton => Driver.FindElement(By.XPath("//a[@title='KMI']"));
        private IWebElement vitaminsButton => Driver.FindElement(By.CssSelector("#category-840 > span"));
        private IWebElement brainCategoryButton => Driver.FindElement(By.CssSelector("#category-1027"));
        public ManoVaistineHomePage(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
        }
      
        public void AcceptCookies()
        {
            Cookie myCookie = new Cookie("FJ_Cookie_Inform",
            "61321bd63ba77",
            "www.manovaistine.lt",
            "/",
            DateTime.Now.AddDays(5));
            Driver.Manage().Cookies.AddCookie(myCookie);
            Driver.Navigate().Refresh();
        }

        public void NavigateToKMI()
        {
            KMIButton.Click();
        }
        public void ClickVitaminsButton()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            vitaminsButton.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            brainCategoryButton.Click();
            Wait_Until_Loading_Invisible();
        }
        
    }
}
