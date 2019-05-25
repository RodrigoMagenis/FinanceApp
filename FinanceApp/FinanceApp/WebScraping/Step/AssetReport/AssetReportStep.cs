using OpenQA.Selenium.Chrome;
using POMExample.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraping.Step
{
    public class AssetReportStep
    {
        private SearchAssetPage searchPage;
        private ChromeDriver driver;
        public AssetReportStep(ChromeDriver driver)
        {
            this.driver = driver;
            this.searchPage = new SearchAssetPage(this.driver);
        }

        public void AcessSearchPage()
        {
            this.searchPage.NavegateTo(SearchAssetPage.URL_PAGE);
        }

        public void SearchCompany( string company )
        {
            this.searchPage.SwitchToFrame(this.searchPage.bvmfFrame);
            this.searchPage.searchText.SendKeys(company);
            this.searchPage.submitButton.Click();
            this.searchPage.SelectCompany(company);
        }

        public void GetReportsData()
        {
            this.searchPage.reportTab.Click();
            //this.searchPage.SwitchToFrame(this.searchPage.bvmfFrame);
            //this.searchPage.SwitchToReportTab();
            this.searchPage.ShowAllReports();
        }

    }
}
