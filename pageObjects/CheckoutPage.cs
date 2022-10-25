using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelFramework.pageObjects
{
    public class CheckoutPage
    {
        private IWebDriver driver;
        //var checkoutProducts = driver.FindElements(By.CssSelector("h4 a"));
        //driver.FindElement(By.ClassName("btn-success")).Click();

        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> checkoutCards;

        [FindsBy(How = How.ClassName, Using = "btn-success")]
        private IWebElement checkoutButton;

        public IList<IWebElement> getCards()
        {
            return checkoutCards;   
        }

        public ConfirmationPage checkout()
        {
            checkoutButton.Click();
            return new ConfirmationPage(driver);
        }
    }
}
