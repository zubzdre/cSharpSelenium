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
    public class LoginPage
    {
        private IWebDriver driver;
         
        public LoginPage(IWebDriver driver)
        {

            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        public void invalidLogin(string user, string pass)
        {
            getUserName().SendKeys(user);
            getPassword().SendKeys(pass);
            getTerms();
            getSignInBtn();

        }
        public ProductsPage validLogin(string user, string pass)
        {
            getUserName().SendKeys(user);
            getPassword().SendKeys(pass);
            selectRadioButton("user");
            //selectDropdown();
            getTerms();
            getSignInBtn();
            return new ProductsPage(driver);
        }

        public HomePage homeLogin(string user, string pass)
        {
            getUserName().SendKeys(user);
            getPassword().SendKeys(pass);
            getTerms();
            getSignInBtn();
            homeButton.Click(); 
            return new HomePage(driver);
        }
        public void selectRadioButton(string value)
        {
            var radioOptions = radioButton;

            foreach (var item in radioOptions)
            {
                if (item.GetAttribute("value").Equals(value))
                {
                    item.Click();
                }
            }
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("okayBtn")));
            okayBtn.Click();

        }
        public void selectDropdown()
        {
            //var dropdownOptions = dropdown;
            //foreach (var item in dropdownOptions)
            //{
            //    if(item.GetAttribute("value").Equals("teach"))
            //    {
            //        item.Click();
            //    }
            //}

            SelectElement dropdown = new SelectElement(driver.FindElement(By.XPath("//select[@class='form-control']")));
            dropdown.SelectByValue("teach");

        }

        //Pageobject factory

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;
        [FindsBy(How = How.CssSelector, Using = "input[type='password']")]
        private IWebElement password;
        [FindsBy(How = How.Id, Using = "terms")]
        private IWebElement terms;
        [FindsBy(How = How.Id, Using = "signInBtn")]
        private IWebElement signInBtn;
        [FindsBy(How = How.XPath, Using = "//input[@type=\"radio\"]")]
        private IList<IWebElement> radioButton;
        [FindsBy(How = How.Id, Using = "okayBtn")]
        private IWebElement okayBtn;
        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Home']")]
        private IWebElement homeButton;


        public IWebElement getUserName()

        {
            return username;
        }
        public IWebElement getPassword()

        {
            return password;
        }
        public void getTerms()

        {
            terms.Click();
        }
        public void getSignInBtn()

        {
            signInBtn.Click();
        }
    }
}
