using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortalSpecFlow.Utilities;

namespace TurnUpPortalSpecFlow.Pages
{
    public class HomePage : Wait
    {
        private readonly By timeMaterialOptionLocator = By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a");
        public void NavigationToTimeAndMaterialPage(IWebDriver driver)
        {
            try
            {
                // Navigate to Time and Material Page
                IWebElement administartionTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
                administartionTab.Click();

                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(timeMaterialOptionLocator));

                //Click on Time and Material Page
                IWebElement timeAndMaterialModule = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
                timeAndMaterialModule.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("TurnUpPortal Time and Material Page is not loaded" + ex.Message);
            }

        }


        public void UserVerification(IWebDriver driver)
        {
            //Check if the user has logged in successfully
            IWebElement helloHari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

            //Check if the text of the web element is "Hello hari"
            Assert.That(helloHari.Text == "Hello hari!", "User has not logged in successfully. Test is failed");

        }


        public void NavigationToEmployeesPage(IWebDriver driver)
        {
            //Navigate to Employees page
            IWebElement administartionTabEmployee = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administartionTabEmployee.Click();

            //Click on Employees tab
            IWebElement employeeTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a"));
            employeeTab.Click();

        }
    }
}