using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace manoVaistine.Page
{
    public class ProductsPage : BasePage
    {
        IReadOnlyCollection<IWebElement> productList => Driver.FindElements(By.XPath("//img[@class='lazy loaded']"));
        private IWebElement alphabetToggle => Driver.FindElement(By.XPath("//a[contains(text(),'Produktai pagal abėcėlę')]"));
        private IWebElement componentToggle => Driver.FindElement(By.XPath("//a[contains(text(),'Sudėtinė medžiaga')]"));
        private IWebElement letter_G_Button => Driver.FindElement(By.CssSelector(".links:nth-child(1) > li:nth-child(9) > a"));
        private IWebElement component_G_Button => Driver.FindElement(By.CssSelector("#filter-mats > ul > li:nth-child(10) > a"));
        private IWebElement itemName => Driver.FindElement(By.XPath("//div[@class='item-title']"));
        private IWebElement numberOfItems => Driver.FindElement(By.XPath("//div[@class='total']"));
        private IWebElement componentCheckbox => Driver.FindElement(By.XPath("//li[19]/div/label/div/ins"));
        private IWebElement confirm_Selected_Component_Button => Driver.FindElement(By.XPath("//button[contains(text(),'Priskirti')]"));
        private IWebElement chosenComponentMessage => Driver.FindElement(By.XPath("//a[@data-id='mats-input-14584']"));

        public ProductsPage(IWebDriver webdriver) : base(webdriver) { }


        public void OrderItemsByComponentLetter()
        {
            componentToggle.Click();
            component_G_Button.Click();
        }


        public void ChooseComponent() 
        {
            if (!componentCheckbox.Selected)
            { 
                componentCheckbox.Click(); 
            }

            Driver.SwitchTo().ActiveElement();
            Wait_Until_Loading_Invisible();
            confirm_Selected_Component_Button.Click();
        }

        public void VerifyChosenComponent()
        {
            Assert.IsTrue(chosenComponentMessage.Text.Equals("Ginkmedžio ekstraktas"));
        }

        public void OrderItemsByLetterG()
        {
            alphabetToggle.Click();
            letter_G_Button.Click();
        }

        public void VerifyFilterByAlphabet()
        {
            int counter = 0;
            foreach (IWebElement result in productList)
            {
                if (itemName.Text.StartsWith("G"))
                {
                counter++;
                }
            }
            Assert.AreEqual(counter, int.Parse(numberOfItems.GetAttribute("data-cnt")), message: $"{counter} is not equal to {numberOfItems.GetAttribute("data-cnt")}");
        }



         public void SelectItem()
         {
            if (productList.Count > 0)
            {
            IWebElement firstResultElement = productList.ElementAt(0);
            firstResultElement.Click();
            Wait_Until_Loading_Invisible();
            }
         }

    }
}
