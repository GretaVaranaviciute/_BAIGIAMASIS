using manoVaistine.Drivers;
using manoVaistine.Page;
using manoVaistine.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace manoVaistine.Test
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static ManoVaistineHomePage manoVaistineHomePage;
        public static KMIPage kMIPage;
        public static ProductsPage productsPage;
        public static ItemPage itemPage;
        public static CartPage cartPage;




        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();

            manoVaistineHomePage = new ManoVaistineHomePage(driver);
            kMIPage = new KMIPage(driver);
            productsPage = new ProductsPage(driver);
            itemPage = new ItemPage(driver);
            cartPage = new CartPage(driver);
        }

        [TearDown]
        public static void TakeScreeshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                MyScreenshot.MakeScreeshot(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            driver.Quit();
        }
    }
}

