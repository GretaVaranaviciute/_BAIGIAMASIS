using OpenQA.Selenium;

namespace manoVaistine.Page
{
    public class ItemPage : BasePage
    {
        private IWebElement increaseAmountButton => Driver.FindElement(By.XPath("//a[@class='ui-spinner-button ui-spinner-up ui-corner-tr']"));
        private IWebElement toCartButton => Driver.FindElement(By.XPath("//span[@class='btn-title']"));
        private IWebElement buyButton => Driver.FindElement(By.XPath("//a[@title='Pirkti ir apmokėti']"));
        private IWebElement cartIcon => Driver.FindElement(By.XPath("//a[@id='dd-cart']"));
        public ItemPage(IWebDriver webdriver) : base(webdriver) { }

        public void IncreaseAmount()
        {
            for (int i = 1; i < 3; i++)
            {
                Wait_Until_Loading_Invisible();
                increaseAmountButton.Click();
            }
        }
        public void AddToCart()
        {
            toCartButton.Click();
            cartIcon.Click();
            buyButton.Click();
        }

    }
}
