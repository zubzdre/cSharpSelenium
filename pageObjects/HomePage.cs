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
    public class HomePage
    {
        IWebDriver driver;  
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        public void selectDropdown()
        {
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("exampleFormControlSelect1")));
            dropdown.SelectByText("Female");
        }

        public void waitForHomePageDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@value='Submit']")));
        }

        public void selectRadio()
        {
            var radioOptions = getRadioOptions();
            foreach (var option in radioOptions)
            {
                if (option.Text.Equals("Employed")) 
                {
                    option.Click();
                }
            }
          
        }

        //Pageobject factory
        [FindsBy(How = How.XPath, Using = "//div[@class='form-group']//input[@name='name']")]
        private IWebElement name;
        [FindsBy(How = How.XPath, Using = "//input[@name='email']")]
        private IWebElement email;
        [FindsBy(How = How.Id, Using = "exampleInputPassword1")]
        private IWebElement password;
        [FindsBy(How = How.Id, Using = "exampleCheck1")]
        private IWebElement checkbox;
        [FindsBy(How = How.Id, Using = "exampleFormControlSelect1")]
        private IWebElement dropdown;
        [FindsBy(How = How.ClassName, Using = "form-check-inline")]
        private IList<IWebElement> radioOptions;
        [FindsBy(How = How.XPath, Using = "//input[@name='bday']")]
        private IWebElement birthDate;
        [FindsBy(How = How.ClassName, Using = "btn-success")]
        private IWebElement successBtn;
        [FindsBy(How = How.ClassName, Using = "alert-dismissible")]
        public IWebElement confirmationMsg;
        


        public IWebElement getName()
        {
            return name;
        }
        public IWebElement getPassword()
        {
            return password;
        }
        public IWebElement getEmail()
        {
            return email;
        }
        public void selectCheckbox()
        {
            checkbox.Click();
        }
        public IWebElement getDropdown()
        {
            return dropdown;
        }

        public IList<IWebElement> getRadioOptions()
        {
            return radioOptions;
        }
        public IWebElement getBirthDate()
        {
            return birthDate;
        }
        public void clickSuccessBtn()
        {
            successBtn.Click();
        }


    }
}
