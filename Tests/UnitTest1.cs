using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    public class Test_eMag
    {
        private IWebDriver _driver;
        [SetUp]
        public void SetupDriver()
        {
            _driver = new ChromeDriver("C:\\drivers");
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }


        [Test]
        public void ExpensesTest()
        {
            _driver.Url = "http://localhost:4200/home";
            bool foundAddExpensesButton = false;

            Thread.Sleep(2000);
            foreach (var button in _driver.FindElements(By.TagName("ion-button")))
            {            
                if (button.Text == "VIEW EXPENSES")
                {
                    foundAddExpensesButton = true;
                    button.Click();
                    break;
                }
            }
            Assert.IsTrue(foundAddExpensesButton);
            Thread.Sleep(2000);

            bool foundAddExpense = false;
            foreach (var button in _driver.FindElements(By.TagName("ion-button")))
            {
                if (button.Text == "ADD EXPENSE")
                {
                    foundAddExpense = true;
                    button.Click();
                    break;
                }
            }
            Assert.IsTrue(foundAddExpense);
            Thread.Sleep(2000);

            bool foundAddExpenseTitle = false;
            foreach (var title in _driver.FindElements(By.TagName("ion-title")))
            {
                if (title.Text == "Add Expense")
                {
                    foundAddExpenseTitle = true;
                    break;
                }
            }
            Assert.IsTrue(foundAddExpenseTitle);
            Thread.Sleep(2000);
        }

        
    }
}
