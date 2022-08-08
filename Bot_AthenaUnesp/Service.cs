using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace Bot_AthenaUnesp
{
    public class Service : IService
    {
        public static string loginXpath = "/html/body/primo-explore/div[3]/md-dialog/prm-login/form/md-dialog-content/md-tabs/md-tabs-content-wrapper/md-tab-content[2]/div/md-content/div[1]/md-input-container[1]/input";
        public static string senhaXpath = "/html/body/primo-explore/div[3]/md-dialog/prm-login/form/md-dialog-content/md-tabs/md-tabs-content-wrapper/md-tab-content[2]/div/md-content/div[1]/md-input-container[2]/input";
        //public static string BotaoRenovacao = "/html/body/primo-explore/div/prm-account/md-content/div[2]/prm-account-overview/md-content/md-tabs/md-tabs-content-wrapper/md-tab-content[2]/div/div/prm-loans/div[1]/div[2]/div[2]/button";
        public static string BotaoRenovacao = "/html/body/primo-explore/div/prm-account/md-content/div[2]/prm-account-overview/md-content/md-tabs/md-tabs-content-wrapper/md-tab-content[2]/div/div/prm-loans/div[1]/div[2]/div[2]/button/prm-icon";

        public void Execute(string login, string senha)
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(new List<string>() { "headless" });

            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            ChromeDriver driver = new ChromeDriver(chromeDriverService, chromeOptions);
            //IWebDriver driver = new ChromeDriver();
            driver.Url = "https://unesp.primo.exlibrisgroup.com/discovery/search?vid=55UNESP_INST:UNESP";
            //driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            //login

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/primo-explore/div/prm-explore-main/div/prm-topbar/div/prm-user-area-expandable/button"))).Click();
            //driver.FindElement(By.XPath("/html/body/primo-explore/div/prm-explore-main/div/prm-topbar/div/prm-user-area-expandable/button")).Click();
            driver.FindElement(By.XPath(loginXpath)).SendKeys(login);
            driver.FindElement(By.XPath(senhaXpath)).SendKeys(senha);
            driver.FindElement(By.XPath("/html/body/primo-explore/div[3]/md-dialog/prm-login/form/md-dialog-actions/button[2]")).Click();

            //renovação

            Thread.Sleep(2000);
            driver.Navigate().GoToUrl("https://unesp.primo.exlibrisgroup.com/discovery/account?vid=55UNESP_INST:UNESP&section=loans&lang=pt");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("/html/body/primo-explore/div/prm-account/md-content/div[2]/prm-account-overview/md-content/md-tabs/md-tabs-content-wrapper/md-tab-content[2]/div/div/prm-loans/div[1]/div[2]/div[2]/button")).Click();

        }
    }
}
