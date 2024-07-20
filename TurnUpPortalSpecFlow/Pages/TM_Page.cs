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
        IWebElement createNewButton;
        private readonly By typeCodeButtonLocator = By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span");
        IWebElement typeCodeButton;
        private readonly By timeOptionLocator = By.XPath("//*[@id='TypeCode_listbox']/li[2]");
        IWebElement timeOption;
        private readonly By codeTextboxLocator = By.Id("Code");
        IWebElement codeTextbox;
        private readonly By descriptionTextboxLocator = By.Id("Description");
        IWebElement descriptionTextbox;
        private readonly By overlapTextboxLocator = By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]");
        IWebElement overlapTextbox;
        private readonly By priceTextboxLocator = By.Id("Price");
        IWebElement priceTextbox;
        private readonly By fileInputLocator = By.Id("files");
        IWebElement fileInput;
        private readonly By saveButtonLocator = By.Id("SaveButton");
        IWebElement saveButton;
        private readonly By goToLastPageLocator = By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span");
        IWebElement goToLastPage;
        private readonly By lastCodeLocator = By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]");
        IWebElement codelocator;
        private readonly By editButtonLocator = By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]");
        IWebElement editButton;
        private readonly By materialOptionLocator = By.XPath("//*[@id='TypeCode_listbox']/li[1]");
        IWebElement materialOption;
        private readonly By deleteButtonLocator = By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span");
        IWebElement deleteButton;
        private readonly By lastDescriptionLocator = By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]");
        IWebElement lastDescription;
        private readonly By lastTypeCodeLocator = By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[2]");
        IWebElement lastTypeCode;
        private readonly By lastpriceLocator = By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]");
        IWebElement lastPrice;

        //Method To Create Time Record
        public void CreateNewTimeRecord(IWebDriver driver, string newCode, string price, string description)
        {
            try
            {
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id='container']/p/a", 6);

                // Click on Create Button
                createNewButton = driver.FindElement(createNewButtonLocator);
                createNewButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Create New Button is not selectable" + ex.Message);
            }

            //Select Time from the TypeCode dropdown
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span", 6);
            typeCodeButton = driver.FindElement(typeCodeButtonLocator);
            typeCodeButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='TypeCode_listbox']/li[2]", 6);
            timeOption = driver.FindElement(timeOptionLocator);
            timeOption.Click();

            //Enter Code into Code text box
            codeTextbox = driver.FindElement(codeTextboxLocator);
            codeTextbox.SendKeys(newCode);

            //Enter Description into Description text box
            descriptionTextbox = driver.FindElement(descriptionTextboxLocator);
            descriptionTextbox.SendKeys(description);

            //Enter Price per unit into Price text box
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]", 6);

            //Identify overlapping element        
            overlapTextbox = driver.FindElement(overlapTextboxLocator);
            overlapTextbox.Click();

            //Identifying the price web element
            priceTextbox = driver.FindElement(priceTextboxLocator);
            priceTextbox.SendKeys(price);

            //File Upload
            fileInput = driver.FindElement(fileInputLocator);
            fileInput.SendKeys(@"D:\Eba\Industry Connect\DemoImage.jpg");

            //Explicit Wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(saveButtonLocator));

            //Click on Save button
            saveButton = driver.FindElement(saveButtonLocator);
            saveButton.Click();
            Thread.Sleep(1000);
            // Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]", 6);
            //Click on Go to last Page button
            try
            {
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 6);
                goToLastPage = driver.FindElement(goToLastPageLocator);
                goToLastPage.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("GoToLastPage Button is not selectable" + ex.Message);
            }
        }
        public void VerifyTableData(IWebDriver driver,string code,string price,string description)
        {
            Assert.That(GetCode(driver) == code, "Actual Code and Expected Code do not match");
            Assert.That(GetPrice(driver) == price, "Actual Price and Expected Price do not match");
            Assert.That(GetDescription(driver)== description, "Actual Description and Expected Description do not match");
            //Assert.That(GetTypeCode(driver) == "T", "Actual TypeCode and Expected TypeCode does not match");
        }
        public string GetCode(IWebDriver driver)
        {
           codelocator = driver.FindElement(lastCodeLocator);
            return codelocator.Text;
        }
        public string GetDescription(IWebDriver driver)
        {
            lastDescription = driver.FindElement(lastDescriptionLocator);
            return lastDescription.Text;
        }
        public string GetTypeCode(IWebDriver driver)
        {
            lastTypeCode = driver.FindElement(lastTypeCodeLocator);
            return lastTypeCode.Text;
        }
        public string GetPrice(IWebDriver driver)
        {
            lastPrice = driver.FindElement(lastpriceLocator);
            return lastPrice.Text;
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
                goToLastPage = driver.FindElement(goToLastPageLocator);
                goToLastPage.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("GoToLastPage Button is not selectable" + ex.Message);
            }

            //Click on Edit Button
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]", 5);
            editButton = driver.FindElement(editButtonLocator);
            editButton.Click();

            //Edit the TypeCode
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span", 7);
            typeCodeButton = driver.FindElement(typeCodeButtonLocator);
            typeCodeButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='TypeCode_listbox']/li[1]", 7);
            materialOption = driver.FindElement(materialOptionLocator);
            materialOption.Click();

            //Edit the Code
            codeTextbox = driver.FindElement(codeTextboxLocator);
            codeTextbox.Clear();
            codeTextbox.SendKeys(code);

            //Edit Description
            descriptionTextbox = driver.FindElement(descriptionTextboxLocator);
            descriptionTextbox.Clear();
            descriptionTextbox.SendKeys(description);
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]", 5);

            //Edit Price
            try
            {
                overlapTextbox = driver.FindElement(overlapTextboxLocator);
                overlapTextbox.Click();
                Wait.WaitToBeVisible(driver, "Id", "Price", 5);
                priceTextbox = driver.FindElement(priceTextboxLocator);
                priceTextbox.Clear();
                overlapTextbox.Click();
                priceTextbox.SendKeys(price);
            }
            catch (ElementNotInteractableException ex)
            {
                Assert.Fail("Price textbox is not interactable" + ex.Message);
            }

            //File Upload
            fileInput = driver.FindElement(fileInputLocator);
            fileInput.SendKeys(@"D:\Eba\Industry Connect\Demo2.jpg");

            Wait.WaitToBeVisible(driver, "Id", "SaveButton", 5);
            //Click on the Save button
            saveButton = driver.FindElement(saveButtonLocator);
            saveButton.Click();
            Thread.Sleep(2000);
            // Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]", 6);
            try
            {
                //Go To Last Page
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 6);

                goToLastPage = driver.FindElement(goToLastPageLocator);

                goToLastPage.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("GoToLastPage Button is not selectable" + ex.Message);
            }

           
           

        }
        //public string GetEditedCode(IWebDriver driver)
        //{
        //    IWebElement editedCode=driver.FindElement(codeLocator);
        //    return editedCode.Text;
        //}

        //public string GetEditedDescription(IWebDriver driver)
        //{
        //    IWebElement editedDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[8]/td[3]"));
        //    return editedDescription.Text;
        //}
        //public string GetEditedPrice(IWebDriver driver)
        //{
        //    IWebElement editedPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[8]/td[4]"));
        //    return editedPrice.Text;
        //}
        //public string GetEditedTypeCode(IWebDriver driver)
        //{
        //    IWebElement editedTypeCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[8]/td[2]"));
        //    return editedTypeCode.Text;
        //}
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
            Thread.Sleep(1000);
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
            IWebElement lastCode = driver.FindElement(lastCodeLocator);
            return lastCode.Text;
        }
    }
}
