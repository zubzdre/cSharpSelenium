using CSharpSelFramework.utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using CSharpSelFramework.pageObjects;
using System.Linq;
using AngleSharp.Text;
using System.Security.Cryptography.X509Certificates;

namespace CSharpSelFramework.test
{
    //run all test files in project parallel
    //[Parallelizable(ParallelScope.Self)]

    //run all test methods in one class parallel
    [Parallelizable(ParallelScope.Children)]

    public class Tests : Base
    {


        [Test, Category("Regression")]
        [TestCaseSource("addTestDataConfig")]
        //[TestCase("rahulshettyacademy", "learning")

        // cd CSharpSelFramework
        // dotnet test pathto.csproj (All tests)
        // dotnet test pathto.csproj --filter TestCategory=Smoke
        // dotnet test CSharpSelFramework.csproj --filter TestCategory=Smoke --% -- TestRunParameters.Parameter(name=\"browserName\",value=\"Chrome\")
        

        //run all data sets of Test method in parallel
        [Parallelizable(ParallelScope.All)]

        public void E2ETest(string username, string password, string[] expectedProducts)
        {

            // String[] expectedProducts = { "iphone X", "Blackberry" };
            String[] actualProducts = new string[2];
            LoginPage loginPage = new LoginPage(getDriver());


            ProductsPage productsPage = loginPage.validLogin(username, password);
            productsPage.waitForPageDisplay();
            IList<IWebElement> products = productsPage.getCards();
            foreach (IWebElement product in products)
            {
                if (expectedProducts.Contains(product.FindElement(productsPage.getCardTitle()).Text))
                {
                    product.FindElement(productsPage.addToCartButton()).Click();
                }
            }


            CheckoutPage checkoutPage = productsPage.checkout();
            IList<IWebElement> checkoutProducts = checkoutPage.getCards();
            for (int i = 0; i < checkoutProducts.Count; i++)
            {
                actualProducts[i] = checkoutProducts[i].Text;
                TestContext.Progress.WriteLine(actualProducts[i].ToString());
            }
            Assert.AreEqual(expectedProducts, actualProducts);


            ConfirmationPage confirmationPage = checkoutPage.checkout();
            confirmationPage.purchase();
            StringAssert.Contains("Success", confirmationPage.getConfirmationText());

        }

        [Test, Category("Smoke")]
        [TestCase("rahulshetty", "learning")]
        public void unsuccessfulLogin(string username, string password)
        {
            string expectedErrorMsg = "Incorrect username/password.";
            LoginPage loginAttempt = new LoginPage(getDriver());
            loginAttempt.invalidLogin(username, password);
            WebDriverWait waitForMessage = new WebDriverWait(getDriver(), TimeSpan.FromSeconds(8));
            waitForMessage.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='alert alert-danger col-md-12']")));
            string errorMsg = driver.Value.FindElement(By.ClassName("alert-danger")).Text;
            StringAssert.IsMatch(errorMsg, expectedErrorMsg);
            TestContext.Progress.WriteLine(errorMsg);
        }



        public static IEnumerable<TestCaseData> addTestDataConfig()
        {
            yield return new TestCaseData(getDataParser().readData("username"), getDataParser().readData("password"), getDataParser().readDataArray("products"));
            yield return new TestCaseData(getDataParser().readData("username_wrong"), getDataParser().readData("password"), getDataParser().readDataArray("products"));
            yield return new TestCaseData(getDataParser().readData("username"), getDataParser().readData("password"), getDataParser().readDataArray("products"));
        }
    }
}

