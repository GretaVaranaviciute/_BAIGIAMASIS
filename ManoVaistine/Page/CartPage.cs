using NUnit.Framework;
using OpenQA.Selenium;

namespace manoVaistine.Page
{
    public class CartPage : BasePage
    { 
        private IWebElement removeButton => Driver.FindElement(By.CssSelector("#cartForm > div.table--flex.table--products > div.item.fj-cart-item > div > div.table-col.action > a > svg"));
        private IWebElement modalMessage => Driver.FindElement(By.XPath("//div[@class='bootbox-body']"));
        private IWebElement confirmationOfRemovalButton => Driver.FindElement(By.XPath("//button[@data-bb-handler='confirm']"));
        private IWebElement emptyCartMessage => Driver.FindElement(By.XPath("//div[@class='cart-products-list']"));
        private IWebElement priceWithDiscount => Driver.FindElement(By.XPath("//div[@class='price price--discount']"));
        private IWebElement fullPriceWithDiscount => Driver.FindElement(By.XPath("//div[@class='price color-danger']"));
        private IWebElement amountOfItems => Driver.FindElement(By.XPath("//input[@class='fj-qnt-spinner ui-spinner-input']"));
        public CartPage(IWebDriver webdriver) : base(webdriver) { }

        public void RemoveItem()
        {
            removeButton.Click();
        }

        public void VerifyRemovePopup()
        {
            modalMessage.Click();
            Assert.AreEqual("Ar tikrai norite pašalinti šį įrašą?", modalMessage.Text, message: $" {modalMessage.Text} is not - Ar tikrai norite pašalinti šį įrašą?");
        }
        public void VerifyEmptyCart()
        {
            confirmationOfRemovalButton.Click();
            Assert.IsTrue(emptyCartMessage.Text.Contains("Prekių krepšelis tuščias"));
        }

        public void VerifyPriceCount()
        {
            double countedPrice = double.Parse(priceWithDiscount.Text.Replace("€ ", "")) * double.Parse(amountOfItems.GetAttribute("value"));
            Assert.IsTrue(countedPrice.ToString(@"###\,#0").Equals(fullPriceWithDiscount.Text.Replace("€ ", "")), message: $"{countedPrice.ToString(@"###\.#0")} was not equal {fullPriceWithDiscount.Text.Replace("€ ", "")} ");
        }

       
    }
}
