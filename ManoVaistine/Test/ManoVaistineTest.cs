using NUnit.Framework;

namespace manoVaistine.Test
{
    public class ManoVaistineTest : BaseTest
    {
        [TestCase("168", "60", false, 21.26, "Normal", TestName = "168_60_M")]
        [TestCase("180", "79", true, 24.38, "Normal", TestName = "180_79_V")]
        [TestCase("170", "52", false, 17.99, "Subnormal", TestName = "170_52_M")]
        [TestCase("168", "100", true, 35.43, "Abnormal", TestName = "168_100_V")]
        public static void TestKMICalculator(string Height, string Weight, bool Gender, double KMI, string KMIEvaluation)
        {
            manoVaistineHomePage.NavigateToPage();
            manoVaistineHomePage.AcceptCookies();
            manoVaistineHomePage.NavigateToKMI();
            kMIPage.EnterHeight(Height);
            kMIPage.EnterWeight(Weight);
            kMIPage.SelectGender(Gender);
            kMIPage.PressSubmit();
            kMIPage.AssertKMI(KMI); 
            kMIPage.AssertKMIBubblePosition(KMIEvaluation);
            kMIPage.AssertBubbleValue(KMI);
        }

        [Test]
        public static void TestRemoveFunctionInCart()
        {
            manoVaistineHomePage.NavigateToPage();
            manoVaistineHomePage.AcceptCookies();
            manoVaistineHomePage.ClickVitaminsButton();
            productsPage.SelectItem();
            itemPage.IncreaseAmount();
            itemPage.AddToCart();
            cartPage.RemoveItem();
            cartPage.VerifyRemovePopup();
            cartPage.VerifyEmptyCart();
        }


        [Test]
        public static void Test_Filter_By_Alphabet_Function()
        {
            manoVaistineHomePage.NavigateToPage();
            manoVaistineHomePage.AcceptCookies();
            manoVaistineHomePage.ClickVitaminsButton();
            productsPage.OrderItemsByLetterG();
            productsPage.VerifyFilterByAlphabet();
        }


        [Test]
        public static void TestPriceCountFunction()
        {
            manoVaistineHomePage.NavigateToPage();
            manoVaistineHomePage.AcceptCookies();
            manoVaistineHomePage.ClickVitaminsButton();
            productsPage.SelectItem();
            itemPage.IncreaseAmount();
            itemPage.AddToCart();
            cartPage.VerifyPriceCount();
        }


        [Test]
        public static void Test_Filter_By_Composit_Function()
        {
            manoVaistineHomePage.NavigateToPage();
            manoVaistineHomePage.AcceptCookies();
            manoVaistineHomePage.ClickVitaminsButton();
            productsPage.OrderItemsByComponentLetter();
            productsPage.ChooseComponent();
            productsPage.VerifyChosenComponent();
        }

    }
}
