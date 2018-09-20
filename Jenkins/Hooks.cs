using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace Jenkins
{
    public class Hooks:Base
    {


        //Enum for browserType
        public enum BrowerType
        {
            Chrome,
            Firefox,
            IE
        }
       
            private BrowerType _browserType;

            [OneTimeSetUp]
            public void InitializeTest()
            {
                //Get the value from NUnit-console --params 
                //e.g. nunit3-console.exe --params:Browser=Firefox \SeleniumNUnitParam.dll
                //If nothing specified, test will run in Chrome browser
                var browserType = TestContext.Parameters.Get("Browser", "Firefox");
                //Parse the browser Type, since its Enum
                _browserType = (BrowerType)Enum.Parse(typeof(BrowerType), browserType);
                //Pass it to browser
                ChooseDriverInstance(_browserType);
            }



        private void ChooseDriverInstance(BrowerType browserType)
        {
            if (browserType == BrowerType.Chrome) { 
                Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("http://executeautomation.com/demosite/Login.html");
            Driver.FindElement(By.Name("UserName")).SendKeys("admin");
            Driver.FindElement(By.Name("Password")).SendKeys("admin");
            Driver.FindElement(By.XPath("/html/body/form/p[3]/input")).Click(); }

            else if (browserType == BrowerType.Firefox)
                {
                   
                    Driver = new FirefoxDriver();
                Driver.Navigate().GoToUrl("http://executeautomation.com/demosite/Login.html");
                Driver.FindElement(By.Name("UserName")).SendKeys("admin2");
                Driver.FindElement(By.Name("Password")).SendKeys("admin2");
                Driver.FindElement(By.XPath("/html/body/form/p[3]/input")).Click();
            }
                else if (browserType == BrowerType.IE)
                {
                    Driver = new InternetExplorerDriver();
                Driver.Navigate().GoToUrl("http://executeautomation.com/demosite/Login.html");
                Driver.FindElement(By.Name("UserName")).SendKeys("admin3");
                Driver.FindElement(By.Name("Password")).SendKeys("admin3");
                Driver.FindElement(By.XPath("/html/body/form/p[3]/input")).Click();
            }
            }
        }
    }

