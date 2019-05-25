using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraping.Page.common;

namespace WebScraping.Page.common
{
    public abstract class Page
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public Page(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Manage().Window.Maximize();
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        public void SwitchToWindow(string window)
        {
            this.driver.SwitchTo().Window(window);
        }

        public void SwitchToFrame(IWebElement frame)
        {
            this.driver.SwitchTo().DefaultContent();
            this.wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt( frame. ));
            this.driver.SwitchTo().Frame(frame);
        }

        public void EspecialClick(IWebElement element)
        {
            this.wait.Until(ExpectedConditions.ElementToBeClickable(element));
            element.Click();
        }

        public void NavegateTo(string url)
        {
            this.driver.Navigate().GoToUrl(url);
        }
    }
}
