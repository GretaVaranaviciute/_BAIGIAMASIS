using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;

namespace manoVaistine.Page
{
    public class KMIPage : BasePage
    {
        private IWebElement heightInputField => Driver.FindElement(By.Id("height"));
        private IWebElement weightInputField => Driver.FindElement(By.Id("weight"));
        private IWebElement submitButton => Driver.FindElement(By.Id("kmiSubmit"));
        private IWebElement selectgenderButton => Driver.FindElement(By.XPath("//*[@id='askForm']/div[3]/span/span[1]/span/span[2]/b"));
        private IWebElement KMIResultText => Driver.FindElement(By.XPath("//*[@id='kmi-result']/div/div/h2[2]"));
        private IWebElement KMIResultBubble => Driver.FindElement(By.CssSelector(".kmi-result-bubble"));
        private IWebElement KMIGreenLine => Driver.FindElement(By.XPath("//td[@class='kmi-limit-2 kmi-bg-green']"));
        private IWebElement KMISubnormalLine => Driver.FindElement(By.XPath("//td[@class='kmi-limit-1 kmi-bg-red']"));
        private IWebElement KMIAbnormalLine => Driver.FindElement(By.XPath("//td[@class='kmi-limit-3 kmi-bg-red2']"));
        private IWebElement genderOptions => Driver.FindElement(By.XPath("//ul[@class='select2-results__options']"));
        public KMIPage (IWebDriver webdriver) : base(webdriver) { }

        public void EnterHeight(string Height)
        {
            heightInputField.Clear();
            heightInputField.SendKeys(Height);
        }
        public void EnterWeight(string Weight)
        {
            weightInputField.Clear();
            weightInputField.SendKeys(Weight);
        }

        public void SelectGender(bool Gender)
        {
            selectgenderButton.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            if (Gender)
                genderOptions.FindElement(By.XPath("//li[contains(text(),'Vyras')]")).Click();
            else
                genderOptions.FindElement(By.XPath("//li[contains(text(),'Moteris')]")).Click();
        }


        public void PressSubmit()
        {
            submitButton.Click();
        }
        public void AssertKMI(double KMIResult)

        {
            Assert.IsTrue(KMIResult.Equals(double.Parse(KMIResultText.Text.Replace(",", "."))), $"{KMIResult} is not equal to {KMIResultText.Text.Replace(",", ".")}");
        }


        public void AssertKMIBubblePosition(string KMIEvaluation)
        {
            if ("Normal".Equals(KMIEvaluation))
            {
                IWebElement bubbleInNormal = KMIGreenLine.FindElement(By.CssSelector(".kmi-result-bubble"));
                Assert.IsTrue(bubbleInNormal.Displayed);
            }
            else if ("Subnormal".Equals(KMIEvaluation))
            {
                IWebElement bubbleInSubnormal = KMISubnormalLine.FindElement(By.CssSelector(".kmi-result-bubble"));
                Assert.IsTrue(bubbleInSubnormal.Displayed);
            }
            else if ("Abnormal".Equals(KMIEvaluation))
            {
                IWebElement bubbleInAbnormal = KMIAbnormalLine.FindElement(By.CssSelector(".kmi-result-bubble"));
                Assert.IsTrue(bubbleInAbnormal.Displayed);
            }
            else
                Assert.Fail();
        }



        public void AssertBubbleValue(double KMI)
        {
            Double KMIRounded = Math.Round((Double)KMI, 1);
            Double KMIBubleValue = double.Parse(KMIResultBubble.Text);
            Assert.AreEqual(KMIBubleValue, KMIRounded, message: $"{KMIBubleValue} is not equal {KMIRounded}");
        }
    }
}
