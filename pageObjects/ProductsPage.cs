using CSharpSelFramework.pageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelFramework.pageObjects
{
    public class ProductsPage
    {
        //driver.FindElement(By.ClassName("btn-primary")).Click();

        private IWebDriver driver;
        private By cardTitle = By.CssSelector(".card-title a");
        private By addToCart = By.ClassName("btn-info");
        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;
        [FindsBy(How = How.ClassName, Using = "btn-primary")]
        private IWebElement checkoutBtn;

        public IList<IWebElement> getCards()
        {
            return cards;
        }

        public void waitForPageDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='nav-link btn btn-primary']")));
        }

        public By getCardTitle()
        {
            return cardTitle;
        }

        public By addToCartButton()
        {
            return addToCart;
        }
        public CheckoutPage checkout()
        {
             checkoutBtn.Click();
             return new CheckoutPage(driver);
        }

    }
}
//    public class ProductsPage
//    {
//        //WebDriverWait waitForUser = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
//        //waitForUser.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeVisible(By.XPath("//a[@class='nav-link btn btn-primary']")));
//        //driver.FindElement(By.TagName("app-card"));

       
//    }
//}
//private IWebDriver driver;
//By cardTitle = By.CssSelector(".card-title a");
//public ProductsPage(IWebDriver driver)
//{
//    this.driver = driver;
//    PageFactory.InitElements(driver, this);
//}

//[FindsBy(How = How.TagName, Using = "app-card")]
//private IList<IWebElement> cards;

//public void waitForPageDisplay()
//{
//    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
//    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='nav-link btn btn-primary']")));
//}

//public IList<IWebElement> getCards()
//{
//    return cards;
//}

//public By getCardTitle()
//{
//    return cardTitle;
//}