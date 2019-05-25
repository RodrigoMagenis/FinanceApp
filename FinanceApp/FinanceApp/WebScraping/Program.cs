using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebScraping.Scraps;

namespace WebScraping
{
    class Program
    {
        
        static void Main(string[] args)
        {
            AssetReport assetReport = new AssetReport();
            assetReport.RunSraping();
        }
    }
}
