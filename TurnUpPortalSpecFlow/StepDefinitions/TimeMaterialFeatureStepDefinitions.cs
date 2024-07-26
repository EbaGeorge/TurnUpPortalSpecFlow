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
        LoginPage loginPageObj = new LoginPage();
        TM_Page timeMaterialObj=new TM_Page();
        HomePage homePageObj = new HomePage();  
        [BeforeScenario]
        public void SetUp()
        {
            driver=new ChromeDriver();
        }
        
        [Given(@"I logged into TurnUp portal successfully")]
        public void GivenILoggedIntoTurnUpPortalSuccessfully()
        {
            
            loginPageObj.LoginActions(driver);
        }

        [When(@"I navigate to the Time and Material page")]
        public void WhenINavigateToTheTimeAndMaterialPage()
        {
            //Home Page Object initialization and definition
           
            homePageObj.UserVerification(driver);
            homePageObj.NavigationToTimeAndMaterialPage(driver);
        }

        [When(@"I created a new Time record with '([^']*)','([^']*)','([^']*)'")]
        public void WhenICreatedANewTimeRecordWith(string timeModule,string price, string description)
        {
          
            //Create Time Record
            timeMaterialObj.CreateNewTimeRecord(driver, timeModule, price,description);
        }

        [Then(@"the Time record should be created successfully with new '([^']*)','([^']*)','([^']*)'")]
        public void ThenTheTimeRecordShouldBeCreatedSuccessfullyWithNew(string timeModule, string price, string description)
        {
           timeMaterialObj.VerifyTableData(driver,timeModule,price,description);
            string type=timeMaterialObj.GetTypeCode(driver);
            Assert.That(type == "T", "Actual Type and Expected Type does not match");
        }

        [When(@"I updated the '([^']*)','([^']*)','([^']*)' of Time record")]
        public void WhenIUpdatedTheOfTimeRecord(string editedCode, string editedPrice, string editedDescription)
        {
            //Edit Time Record
            timeMaterialObj.EditTimeRecord(driver,editedCode,editedPrice,editedDescription);
        }
        [Then(@"the time record should be updated with new '([^']*)','([^']*)','([^']*)'")]
        public void ThenTheTimeRecordShouldBeUpdatedWithNew(string code, string price, string description)
        {
           timeMaterialObj.VerifyTableData(driver,code,price,description);
            string type = timeMaterialObj.GetTypeCode(driver);
            Assert.That(type == "M", "Actual Typecode and Expected Typecode does not match")
        }

        [When(@"I deleted a Time record with '([^']*)'")]
        public void WhenIDeletedATimeRecordWith(string code)
        {
         
            timeMaterialObj.DeleteTimeRecord(driver,code);
        }

        [Then(@"the Time record with '([^']*)' should be deleted successfully")]
        public void ThenTheTimeRecordWithShouldBeDeletedSuccessfully(string code)
        {
          
            string lastCode=timeMaterialObj.GetCode(driver);
            Assert.That(lastCode != code, "Time record is not deleted");

        }
        [AfterScenario]
        public void CloseDriver()
        {
            driver.Quit();
        }
    }
}
