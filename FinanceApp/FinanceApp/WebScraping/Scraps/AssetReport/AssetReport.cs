using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraping.Step;

namespace WebScraping.Scraps
{
    public class AssetReport
    {
        private AssetReportStep step;
        private ChromeDriver driver;
        public AssetReport()
        {
            this.driver = new ChromeDriver();
            this.step = new AssetReportStep(this.driver);
        }

        public bool RunSraping()
        {
            using (this.driver)
            {
                this.step.AcessSearchPage();
                this.step.SearchCompany("WEG");
                this.step.GetReportsData();

                this.driver.Quit();
                this.driver.Close();
            }
            return true;
        }
    }
}
