using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.Extensions;
using WebScraping.Page.common;

namespace POMExample.PageObjects
{
    public class SearchAssetPage : Page
    {
        public SearchAssetPage(IWebDriver driver) : base(driver)
        {
            
        }

        public static string URL_PAGE = "http://www.bmfbovespa.com.br/pt_br/produtos/listados-a-vista-e-derivativos/renda-variavel/empresas-listadas.htm";

        [FindsBy(How = How.Id, Using = "ctl00_contentPlaceHolderConteudo_BuscaNomeEmpresa1_txtNomeEmpresa_txtNomeEmpresa_text")]
        public IWebElement searchText;

        [FindsBy(How = How.Id, Using = "ctl00_contentPlaceHolderConteudo_BuscaNomeEmpresa1_btnBuscar")]
        public IWebElement submitButton;

        [FindsBy(How = How.Id, Using = "bvmf_iframe")]
        public IWebElement bvmfFrame;

        [FindsBy(How = How.Id, Using = "ctl00_contentPlaceHolderConteudo_BuscaNomeEmpresa1_grdEmpresa_ctl01")]
        public IWebElement companyTable;

        [FindsBy(How = How.Id, Using = "ctl00_contentPlaceHolderConteudo_MenuEmpresasListadas1_tabMenuEmpresa_tabRelatoriosFinanceiros")]
        public IWebElement reportTab;

        [FindsBy(How = How.CssSelector, Using = "document.getElementById('ctl00_contentPlaceHolderConteudo_liDemonstrativoItrHistorico').children[1].children[0].children[0]")]
        public IWebElement reportHistoryButton;



        

        

        public void SelectCompany( string text )
        {
            var rows = this.companyTable.FindElements(By.TagName("tr"));

            for(int i = 1; i < rows.Count; i++ )
            {
                var cells = rows[i].FindElements(By.TagName("td"));

                if (text == cells[1].Text)
                {
                    cells[1].FindElement(By.XPath("*")).Click();
                }

                //for(int j = 0; j < cells.Count; j++)
                //{
                //    var opa = cells[j];
                //}
            }
        }

        public void SwitchToAssetPage()
        {
            this.SwitchToWindow(URL_PAGE);
        }

        public void ShowAllReports()
        {
            this.reportHistoryButton.Click();
        }
    }
}
 