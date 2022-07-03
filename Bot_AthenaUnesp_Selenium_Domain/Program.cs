using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Bot_AthenaUnesp_Selenium_Domain
{
    internal class Program
    {
        public static string loginXpath = "/html/body/primo-explore/div[3]/md-dialog/prm-login/form/md-dialog-content/md-tabs/md-tabs-content-wrapper/md-tab-content[2]/div/md-content/div[1]/md-input-container[1]/input";
        public static string senhaXpath = "/html/body/primo-explore/div[3]/md-dialog/prm-login/form/md-dialog-content/md-tabs/md-tabs-content-wrapper/md-tab-content[2]/div/md-content/div[1]/md-input-container[2]/input";

      
        
        static void Main(string[] args)
        {

            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://unesp.primo.exlibrisgroup.com/discovery/search?vid=55UNESP_INST:UNESP";
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            //login

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/primo-explore/div/prm-explore-main/div/prm-topbar/div/prm-user-area-expandable/button"))).Click();
            //driver.FindElement(By.XPath("/html/body/primo-explore/div/prm-explore-main/div/prm-topbar/div/prm-user-area-expandable/button")).Click();
            driver.FindElement(By.XPath(loginXpath)).SendKeys("phrm.silva");
            driver.FindElement(By.XPath(senhaXpath)).SendKeys("Louielindo42");
            driver.FindElement(By.XPath("/html/body/primo-explore/div[3]/md-dialog/prm-login/form/md-dialog-actions/button[2]")).Click();

            //renovação
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //var div = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/primo-explore/div/prm-account/div/prm-topbar/div/prm-user-area-expandable")));

            //driver.FindElement(By.XPath("/html/body/primo-explore/div/prm-explore-main/div/prm-topbar/div/prm-user-area-expandable")).Click();
            //driver.FindElement(By.XPath("/html/body/primo-explore/div/prm-explore-main/div/prm-topbar/div/prm-user-area-expandable/md-menu")).Click();
            var divLogin = driver.FindElement(By.CssSelector("body > primo-explore > div > prm-explore-main > div > prm-topbar > div > prm-user-area-expandable"));
            Actions action = new Actions(driver);
            action.MoveToElement(divLogin).Click().Build().Perform();

            driver.FindElement(By.CssSelector("#menu_container_128 > md-menu-content > md-menu-item.menu-item-indented.my-loans-ctm > button")).Click();
            //IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            //executor.ExecuteScript("argument")
            //executor.executeScript(“arguments[0].click();”, element);
            //Actions action = new Actions(driver);
            //action.MoveByOffset(200, 0).Perform();
            //action.Click();
            //driver.FindElement(By.XPath("/html/body/primo-explore/div/prm-explore-main/div/prm-topbar/div/prm-user-area-expandable/md-menu/button")).Click();
            //driver.FindElement(By.XPath("/html/body/primo-explore/div/prm-explore-main/div/prm-topbar/div/prm-user-area-expandable/md-menu/button/span[1]")).Click();
            //driver.FindElement(By.XPath("/html/body/primo-explore/div/prm-explore-main/div/prm-topbar/div/prm-user-area-expandable/md-menu/button/div")).Click();

            //driver.FindElement(By.XPath("/html/body/primo-explore/div/prm-explore-main/div/prm-topbar/div/prm-user-area-expandable/md-menu/button")).Click();
            //driver.FindElement(By.XPath("/html/body/primo-explore/div/prm-account/div/prm-topbar/div/prm-user-area-expandable/md-menu")).Click();


            //driver.FindElement(By.XPath("/html/body/primo-explore/div/prm-explore-main/div/prm-topbar/div/prm-user-area-expandable/md-menu/button")).Click();
            //driver.FindElement(By.XPath("/html/body/div[3]/md-menu-content/md-menu-item[3]")).Click();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //driver.Navigate().GoToUrl("https://unesp.primo.exlibrisgroup.com/discovery/search?vid=55UNESP_INST:UNESP");
            //driver.Navigate().GoToUrl("https://unesp.primo.exlibrisgroup.com/discovery/account?vid=55UNESP_INST:UNESP&section=loans");

        }
    }
}
