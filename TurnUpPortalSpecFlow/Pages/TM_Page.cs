using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortalSpecFlow.Utilities;

namespace TurnUpPortalSpecFlow.Pages
{
    public class TM_Page:Wait
    {

        private readonly By createNewButtonLocator = By.XPath("//*[@id='container']/p/a");
        private readonly By typeCodeButtonLocator = By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span");
        private readonly By timeOptionLocator = By.XPath("//*[@id='TypeCode_listbox']/li[2]");
        private readonly By codeTextboxLocator = By.Id("Code");
        private readonly By descriptionTextboxLocator = By.Id("Description");
        private readonly By overlapTextboxLocator = By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]");
        private readonly By priceTextboxLocator = By.Id("Price");
        private readonly By fileInputLocator = By.Id("files");
        private readonly By saveButtonLocator = By.Id("SaveButton");
        private readonly By goToLastPageLocator = By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span");
        private readonly By codeLocator = By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]");
        private readonly By editButtonLocator = By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]");
        private readonly By materialOptionLocator = By.XPath("//*[@id='TypeCode_listbox']/li[1]");
        private readonly By deleteButtonLocator = By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span");

        //Method To Create Time Record
        public void CreateNewTimeRecord(IWebDriver driver,string newCode,string price,string description)
        {
            try
            {
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id='container']/p/a", 6);

                // Click on Create Button
                IWebElement createNewButton = driver.FindElement(createNewButtonLocator);
                createNewButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Create New Button is not selectable" + ex.Message);
            }

            //Select Time from the TypeCode dropdown
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span", 6);
            IWebElement typeCodeButton = driver.FindElement(typeCodeButtonLocator);
            typeCodeButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='TypeCode_listbox']/li[2]", 6);
            IWebElement timeOption = driver.FindElement(timeOptionLocator);
            timeOption.Click();

            //Enter Code into Code text box
            IWebElement codeTextbox = driver.FindElement(codeTextboxLocator);
            codeTextbox.SendKeys(newCode);

            //Enter Description into Description text box
            IWebElement descriptionTextbox = driver.FindElement(descriptionTextboxLocator);
            descriptionTextbox.SendKeys(description);

            //Enter Price per unit into Price text box
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]", 6);

            //Identify overlapping element        
            IWebElement overlapTextbox = driver.FindElement(overlapTextboxLocator);
            overlapTextbox.Click();

            //Identifying the price web element
            IWebElement priceTextbox = driver.FindElement(priceTextboxLocator);
            priceTextbox.SendKeys(price);

            //File Upload
            IWebElement fileInput = driver.FindElement(fileInputLocator);
            fileInput.SendKeys(@"D:\Eba\Industry Connect\DemoImage.jpg");

            //Explicit Wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(saveButtonLocator));

            //Click on Save button
            IWebElement saveButton = driver.FindElement(saveButtonLocator);
            saveButton.Click();
            Thread.Sleep(1000);
           // Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]", 6);
            //Click on Go to last Page button
            try
            {
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 6);
                IWebElement goToLastPage = driver.FindElement(goToLastPageLocator);
                goToLastPage.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("GoToLastPage Button is not selectable" + ex.Message);
            }
           }
        public string GetCode(IWebDriver driver)
        {
            IWebElement newTimeModuleCode = driver.FindElement(codeLocator);
            return newTimeModuleCode.Text;
        }
        public string GetDescription(IWebDriver driver)
        {
            IWebElement newTimeDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return newTimeDescription.Text;
        }
        public string GetTypeCode(IWebDriver driver)
        {
            IWebElement newTimeTypeCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[2]"));
            return newTimeTypeCode.Text;
        }
        public string GetPrice(IWebDriver driver)
        {
            IWebElement newTimePrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return newTimePrice.Text;
        }

        //Method To Edit Time Record
        public void EditTimeRecord(IWebDriver driver,string code,string price,string description)
        {
            //CreateNewTimeRecord(driver);
            Thread.Sleep(1000);
            //Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]", 6);
            try
            {
                //Go To Last Page Button
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 6);
                IWebElement editedLastPageButton = driver.FindElement(goToLastPageLocator);
                editedLastPageButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("GoToLastPage Button is not selectable" + ex.Message);
            }

            //Click on Edit Button
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]", 5);
            IWebElement editButton = driver.FindElement(editButtonLocator);
            editButton.Click();

            //Edit the TypeCode
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span", 7);
            IWebElement editedTypecode = driver.FindElement(typeCodeButtonLocator);
            editedTypecode.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='TypeCode_listbox']/li[1]", 7);
            IWebElement editedOptions = driver.FindElement(materialOptionLocator);
            editedOptions.Click();

            //Edit the Code
            IWebElement editedCode = driver.FindElement(codeTextboxLocator);
            editedCode.Clear();
            editedCode.SendKeys(code);

            //Edit Description
            IWebElement editedDescription = driver.FindElement(descriptionTextboxLocator);
            editedDescription.Clear();
            editedDescription.SendKeys(description);
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]", 5);

            //Edit Price
            try
            {
                IWebElement editedOverlapTextbox = driver.FindElement(overlapTextboxLocator);
                editedOverlapTextbox.Click();
                Wait.WaitToBeVisible(driver, "Id", "Price", 5);
                IWebElement editedpriceTextbox = driver.FindElement(priceTextboxLocator);
                editedpriceTextbox.Clear();
                editedOverlapTextbox.Click();
                editedpriceTextbox.SendKeys(price);
            }
            catch (ElementNotInteractableException ex)
            {
                Assert.Fail("Price textbox is not interactable" + ex.Message);
            }

            //File Upload
            IWebElement fileInput = driver.FindElement(fileInputLocator);
            fileInput.SendKeys(@"D:\Eba\Industry Connect\Demo2.jpg");

            Wait.WaitToBeVisible(driver, "Id", "SaveButton", 5);
            //Click on the Save button
            IWebElement editedSaveButton = driver.FindElement(saveButtonLocator);
            editedSaveButton.Click();
            Thread.Sleep(2000);
            // Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]", 6);
            try
            {
                //Go To Last Page
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 6);

                IWebElement editedlastpage = driver.FindElement(goToLastPageLocator);

                editedlastpage.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("GoToLastPage Button is not selectable" + ex.Message);
            }

           
           

        }
        public string GetEditedCode(IWebDriver driver)
        {
            IWebElement editedCode=driver.FindElement(codeLocator);
            return editedCode.Text;
        }

        public string GetEditedDescription(IWebDriver driver)
        {
            IWebElement editedDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[8]/td[3]"));
            return editedDescription.Text;
        }
        public string GetEditedPrice(IWebDriver driver)
        {
            IWebElement editedPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[8]/td[4]"));
            return editedPrice.Text;
        }
        public string GetEditedTypeCode(IWebDriver driver)
        {
            IWebElement editedTypeCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[8]/td[2]"));
            return editedTypeCode.Text;
        }
        //Method To Delete Time Record
        public void DeleteTimeRecord(IWebDriver driver,string code)
        {
           
            Thread.Sleep(1000);
            //Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]", 6);
            //Delete newly created time module 
            try
            {
                //Go To Last Page Button
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 6);
                IWebElement deleteLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
                deleteLastPageButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("GoToLastPage Button is not selectable" + ex.Message);
            }


            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]", 5);
            //Click on the delete button
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();

            //Handle pop up dialog box
            driver.SwitchTo().Alert().Accept();

            driver.Navigate().Refresh();
            Thread.Sleep(5000);
            // Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]", 6);
          
                //Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 6);
                //Go To Last Page
                IWebElement deleteLastPageButtonAfter = driver.FindElement(deleteButtonLocator);

                deleteLastPageButtonAfter.Click();
           
        }
        public string GetLastCode(IWebDriver driver)
        {
            IWebElement lastCode = driver.FindElement(codeLocator);
            return lastCode.Text;
        }
    }
}
