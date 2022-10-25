using CSharpSelFramework.pageObjects;
using CSharpSelFramework.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelFramework.test
{
    //run all test files in project parallel
    //[Parallelizable(ParallelScope.Self)]

    public class HomeTest : Base
    {
        [Test]
        [TestCaseSource("addTestDataConfig")]

        public void testHomePage(string username, string password)
        {
            LoginPage loginPage = new LoginPage(getDriver());
            HomePage homePage = loginPage.homeLogin(username, password);
            homePage.waitForHomePageDisplay();
            homePage.getName().SendKeys("zubzdre");
            homePage.getEmail().SendKeys("zubzdre@gmail.com");
            homePage.getPassword().SendKeys("learning");           
            homePage.selectCheckbox();
            homePage.selectDropdown();
            homePage.selectRadio();
            homePage.getBirthDate().SendKeys("04201990");
            homePage.clickSuccessBtn();

            string expectedMsg = "Success! The Form has been submitted successfully!.";
            StringAssert.Contains(expectedMsg, homePage.confirmationMsg.Text);
            
        }

        public static IEnumerable<TestCaseData> addTestDataConfig()
        {
            yield return new TestCaseData(getDataParser().readData("username"), getDataParser().readData("password"));
            //yield return new TestCaseData(getDataParser().readData("username_wrong"), getDataParser().readData("password"), getDataParser().readDataArray("products"));
        }

    }
}
