using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUpPortalSpecFlow.Utilities
{
    public class Wait
    {
         public static void WaitToBeClickable(IWebDriver driver, string locatorType, string locatorValue, int seconds)
            {
                if (locatorType == "XPath")
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
                }
                if (locatorType == "Id")
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(locatorValue)));
                }
            }
            public static void WaitToBeVisible(IWebDriver driver, string locatorType, string locatorValue, int seconds)
            {
                if (locatorType == "XPath")
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
                }
                if (locatorType == "Id")
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(locatorValue)));
                }
            }
        }
    }

