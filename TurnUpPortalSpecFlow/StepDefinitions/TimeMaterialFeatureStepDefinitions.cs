using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Globalization;
using TechTalk.SpecFlow;
using TurnUpPortalSpecFlow.Pages;
using TurnUpPortalSpecFlow.Utilities;

namespace TurnUpPortalSpecFlow.StepDefinitions
{
    [Binding]
    public class TimeMaterialFeatureStepDefinitions: CommonDriver
    {
        
        [Given(@"I logged into TurnUp portal successfully")]
        public void GivenILoggedIntoTurnUpPortalSuccessfully()
        {
            driver=new ChromeDriver();
            LoginPage loginPageObj=new LoginPage();
            loginPageObj.LoginActions(driver);
        }

        [When(@"I navigate to the Time and Material page")]
        public void WhenINavigateToTheTimeAndMaterialPage()
        {
            //Home Page Object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.UserVerification(driver);
            homePageObj.NavigationToTimeAndMaterialPage(driver);
        }

        [When(@"I created a new Time record with '([^']*)','([^']*)','([^']*)'")]
        public void WhenICreatedANewTimeRecordWith(string timeModule,string price, string description)
        {
            //Time and Material Page Object initialization and definiton
            TM_Page timeMaterialObj = new TM_Page();
            //Create Time Record
            timeMaterialObj.CreateNewTimeRecord(driver, timeModule, price,description);
        }

        [Then(@"the Time record should be created successfully with new '([^']*)','([^']*)','([^']*)'")]
        public void ThenTheTimeRecordShouldBeCreatedSuccessfullyWithNew(string timeModule, string price, string description)
        {
            TM_Page timeMaterialObj = new TM_Page();
            string newCode=timeMaterialObj.GetCode(driver);
            string newPrice=timeMaterialObj.GetPrice(driver);
            string newDescription=timeMaterialObj.GetDescription(driver);
            string newTypeCode=timeMaterialObj.GetTypeCode(driver);
            Assert.That(newCode == timeModule, "Actual Code and Expected Code do not match");
            Assert.That(newPrice == price, "Actual Price and Expected Price do not match");
            Assert.That(newDescription == description, "Actual Description and Expected Description do not match");
            Assert.That(newTypeCode == "T", "Actual TypeCode and Expected TypeCode does not match");
        }

        [When(@"I updated the '([^']*)','([^']*)','([^']*)' of Time record")]
        public void WhenIUpdatedTheOfTimeRecord(string editedCode, string editedPrice, string editedDescription)
        {
            //Edit Time Record
            TM_Page timeMaterialObj = new TM_Page();
            timeMaterialObj.EditTimeRecord(driver,editedCode,editedPrice,editedDescription);
        }
        [Then(@"the time record should be updated with new '([^']*)','([^']*)','([^']*)'")]
        public void ThenTheTimeRecordShouldBeUpdatedWithNew(string code, string price, string description)
        {
            TM_Page timeMaterialObj=new TM_Page();
            string editedCode=timeMaterialObj.GetEditedCode(driver);
            string editedPrice=timeMaterialObj.GetPrice(driver);
            string editedDescription=timeMaterialObj.GetDescription(driver);
            string editedTypeCode=timeMaterialObj.GetTypeCode(driver);
            Assert.That(editedCode == code, "Actual code and Expected code does not match");
            Assert.That(editedDescription == description, "Actual description and Expected description does not match");
            Assert.That(editedPrice == price, "Actual price and Expected price does not match");
            Assert.That(editedTypeCode == "M", "Actual TypeCode and Expected TypeCode does not match");
        }

        [When(@"I deleted a Time record with '([^']*)'")]
        public void WhenIDeletedATimeRecordWith(string code)
        {
            //Delete Time Record
            TM_Page timeMaterialObj = new TM_Page();
            timeMaterialObj.DeleteTimeRecord(driver,code);
        }

        [Then(@"the Time record with '([^']*)' should be deleted successfully")]
        public void ThenTheTimeRecordWithShouldBeDeletedSuccessfully(string code)
        {
            TM_Page timeMaterialObj = new TM_Page();
            string lastCode=timeMaterialObj.GetCode(driver);
            Assert.That(lastCode != code, "Time record is not deleted");

        }
    }
}
