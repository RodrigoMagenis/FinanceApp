using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraping.Page.common
{
    public static class IwebElementFunctions
    {
        public static IWebElement FindElementByJs(this IWebElement element, string jsCommand)
        {
            return (IWebElement)((IJavaScriptExecutor)element).ExecuteScript(jsCommand);
        }
    }
}
