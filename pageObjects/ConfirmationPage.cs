using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelFramework.pageObjects
{
    public class ConfirmationPage
    {

        //String confirText = driver.FindElement(By.CssSelector(".alert-success")).Text;

        IWebDriver driver;

        public ConfirmationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement country;

        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Croatia']")]
        private IWebElement chosenCountry;
        
        [FindsBy(How = How.CssSelector, Using = "label[for='checkbox2'")]
        private IWebElement checkbox;

        [FindsBy(How = How.ClassName, Using = "btn-success")]
        private IWebElement purchaseButton;

        [FindsBy(How = How.CssSelector, Using = ".alert-success")]
        private IWebElement confirmationText;

       
        public void purchase()
        {
            country.SendKeys("cro");
            WebDriverWait waitForResults = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            waitForResults.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[normalize-space()='Croatia']")));
            chosenCountry.Click();
            checkbox.Click();
            purchaseButton.Click();
            
        }

        public string getConfirmationText()
        {
            return confirmationText.Text;
        }
    }
}

//public IWebElement getCountry()
//{
//    return country;
//}

//public void waitForResults()
//{
//    WebDriverWait waitForResults = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
//    waitForResults.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[normalize-space()='Croatia']")));
//}


//public void getChosenCountry()
//{
//    chosenCountry.Click();
//}

//public void selectCheckbox()
//{
//    checkbox.Click();
//}
//public void getConfirmationButton()
//{
//    confirmationButton.Click();
//}

//public string getConfirmationText()
//{
//    return confirmationText.Text;
//}

